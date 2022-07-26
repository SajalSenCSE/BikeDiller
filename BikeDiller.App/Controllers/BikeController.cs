using AutoMapper;
using BikeDiller.App.Models.BikeModels;
using BikeDiller.EntityModels;
using BikeDiller.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using BikeDiller.App.Models.MakeModels;
using BikeDiller.App.Models.ModelModels;
using cloudscribe.Pagination.Models;

namespace BikeDiller.App.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class BikeController : Controller
    {
        IModelService _modelService;
        IMakeService _makeService;
        IBikeService _bikeService;
        IMapper _mapper;
        ICurrencyService _currencyService;
        IWebHostEnvironment _webHostEnvironment;

        public BikeController(IModelService modelService, 
                              IMakeService makeService,
                              IBikeService bikeService, 
                              IMapper mapper,
                              ICurrencyService currencyService,
                              IWebHostEnvironment webHostEnvironment
            )

        {
            _modelService = modelService;
            _makeService = makeService;
            _bikeService = bikeService;
            _mapper = mapper;
            _currencyService = currencyService;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> List(string searchString, string sortOrder, int pageSize=2,int pageNumber=1)
        {
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentFilter = searchString;

            ViewBag.PriceSortParams = String.IsNullOrEmpty(sortOrder) ? "Price_Desc" : "";
            int excludeRecord = (pageSize * pageNumber) - pageSize;

            var bikes = await _bikeService.GetAll();

            var bikes2 = from b in bikes select b;

            var bikeCount = bikes2.Count();


            bikes2.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                bikes2 = bikes2.Where(x => x.Make.Name.Contains(searchString));
                bikeCount = bikes2.Count();
            }
            


            //Sorting 

            switch (sortOrder)
            {
                case "Price_Desc":
                    bikes2 = from b in bikes2 orderby b.Price descending select b;
                    break;
                default:
                    bikes2 = from b in bikes2 orderby b.Price select b;
                    break;
            }

            var filterBikes = bikes2
                                   .Skip(excludeRecord)
                                   .Take(pageSize);

            var viewObj = new BikeListVM
            {
                Bikes = filterBikes.ToList(),
                TotalItem = bikeCount,
                PageNumber =pageNumber,
                PageSize=pageSize
            };
            
            return View(viewObj);
        }

        public async Task<IActionResult> Create()
        {
            var modelList =await _modelService.GetAll();
            var makeList = await _makeService.GetAll();
            var currencyList = await _currencyService.GetCurrencies();
            var viewObj = new BikeCreateVM()
            {
                Makes = makeList.ToList(),
                Models = modelList.ToList(),
                Currenies=currencyList.ToList()
            };
            return View(viewObj);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BikeCreateVM model)
        {
            string filePath = UploadFile(model.ImagePathFile);
            model.ImagePath = filePath;
            model.ImagePathFile = null;
            if (ModelState.IsValid)
            {
                var newBike = _mapper.Map<Bike>(model);

                bool result =await _bikeService.AddNew(newBike);
                if (result)
                {
                    return RedirectToAction("List");
                }
                return View();
            }
            return View();
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteBike(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var aBike =await _bikeService.GetById(id);
            if (aBike == null)
            {
                return NoContent();
            }
            bool result = await _bikeService.DeleteEntity(aBike);
            if (result)
            {
                return RedirectToAction("List");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            
            if (id == 0)
            {
                return NoContent();
            }
            var oldBike = await _bikeService.GetById(id);

            var modelList2 = await _modelService.GetAll();
            var modelList = modelList2.Where(x => x.MakeId == oldBike.MakeId);
            var makeList = await _makeService.GetAll();
            var currencyList = await _currencyService.GetCurrencies();

            if (oldBike == null)
            {
                return NoContent();
            }
            var viewObj = _mapper.Map<BikeEditVM>(oldBike);
            viewObj.ImagePathFile = null;
            viewObj.Makes = makeList.ToList();
            viewObj.Models = modelList.ToList();
            viewObj.Currenies = currencyList.ToList();

            return View(viewObj);   
        }


        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> EditBike(BikeEditVM model)
        {
            if (model.ImagePathFile == null)
            {
                model.ImagePath = model.ImagePath;
            }
            else
            {
                model.ImagePath = UploadFile(model.ImagePathFile);
            }
            model.ImagePathFile = null;

            if (ModelState.IsValid)
            {
                var updatedBike = _mapper.Map<Bike>(model);
                bool result =await _bikeService.UpdateEntity(updatedBike);
                if (result)
                {
                    return RedirectToAction("List");
                }
                return NoContent();
            }
            return View(); 
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> View(int id)
        {
            var modelList = await _modelService.GetAll();
            var makeList = await _makeService.GetAll();
            var currencyList = await _currencyService.GetCurrencies();
            if (id == 0)
            {
                return NoContent();
            }
            var oldBike = await _bikeService.GetById(id);

            if (oldBike == null)
            {
                return NoContent();
            }
            var viewObj = _mapper.Map<BikeEditVM>(oldBike);
            viewObj.ImagePathFile = null;
            viewObj.Makes = makeList.ToList();
            viewObj.Models = modelList.ToList();
            viewObj.Currenies = currencyList.ToList();

            return View(viewObj);
        }








        private string UploadFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }


        [HttpGet("api/models/{id}")] ///Id,Name ,inside CreateVM no Id property that' why i am using EditVM
        public async Task<IEnumerable<ModelEditVM>> ModelsList(int id)   
        {
            var modelList = await _modelService
                                 .GetAll();

            var result = modelList.Where(x => x.MakeId == id).ToList();
            var obj = _mapper.Map<IEnumerable<ModelEditVM>>(result);

            return obj;
        }




        
    }
}
