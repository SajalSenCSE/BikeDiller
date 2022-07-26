using AutoMapper;
using BikeDiller.App.Models.ModelModels;
using BikeDiller.DataBase;
using BikeDiller.EntityModels;
using BikeDiller.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeDiller.App.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class ModelController : Controller
    {

        IModelService _modelService;
        IMakeService _makeService;
        IMapper _mapper;

        public ModelController(IModelService modelService, IMapper mapper, IMakeService makeService)
        {
            _modelService = modelService;
            _mapper = mapper;
            _makeService = makeService;
        }
       

        public async Task<IActionResult> List()
        {
            var modelList =await _modelService.GetAll();
            var newObj = new ModelListVM()
            {
                Models = modelList.ToList()
            };

            return View(newObj);
        }

        public async Task<IActionResult> Create()
        {
            var makes =await _makeService.GetAll();
            var obj = new ModelCreateVM()
            {
                Makes = makes.ToList()
            };

            return View(obj);
        }

        [HttpPost,ActionName("Create")]
        public async Task<IActionResult> CreatePost(ModelCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var newModel = new Model()
                {
                    Name = model.Name,
                    MakeId = model.MakeId
                };
                var result =await _modelService.AddNew(newModel);
                if (result)
                {

                    return RedirectToAction("List");
                }
                return View(); 
            }
            return View();
  
        }


        public async Task<IActionResult> Edit(int id)
        {
            var oldModel = await _modelService.GetById(id);
            var makeList = await _makeService.GetAll();
            var newModel = new ModelEditVM()
            {
                Id = oldModel.Id,
                Name = oldModel.Name,
                MakeId = oldModel.MakeId,
                Makes=makeList.ToList()
            };
            return View(newModel);

        }

        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> EditPost(ModelEditVM model)
        {
            if (ModelState.IsValid)
            {
                var newModel = _mapper.Map<Model>(model);
                bool result =await _modelService.UpdateEntity(newModel);
                if (result)
                {
                    return RedirectToAction("List");
                }
                return View();
            }
            return View();

        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (id == 0)
            {
                return NoContent();
            }

            var aModel =await _modelService.GetById(id);
            if (aModel == null)
            {
                return NoContent();
            }
            bool result =await _modelService.DeleteEntity(aModel);

            if (result)
            {
                return RedirectToAction("List");
            }

            return View();
        }

    }
}
