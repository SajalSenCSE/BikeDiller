using AutoMapper;
using BikeDiller.App.Models.MakeModels;
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
    [Authorize(Roles ="Admin,Executive")]
    public class MakeController : Controller
    {

        IMakeService _makeService;
        IMapper _mapper;

        public MakeController(IMakeService makeService,IMapper mapper)
        {
            _makeService = makeService;
            _mapper = mapper;
        }

        //Make/list
        public async Task<IActionResult> List()
        {
            var result = await _makeService.GetAllMakes();

            var mapperListVM = new MakeListVM()
            {
                List = result.ToList()
            };

            return View(mapperListVM);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MakeCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var newMake = _mapper.Map<Make>(model);

                bool result = await _makeService.AddNewMake(newMake);
                if (result)
                {
                    return RedirectToAction("List");
                }
                else
                    return View();

            }
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return View("Faild");
            }
            var aMake =await _makeService.GetById(id);
            if (aMake == null)
            {
                return NoContent();
            }
            bool result =await _makeService.DeleteMake(aMake);
            if (result)
            {
                return RedirectToAction("List");
            }
            return View("Faild");
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aMake =await _makeService.GetById(id);
            if (aMake == null)
            {
                return NoContent();
            }
            var obj = _mapper.Map<MakeEditVM>(aMake);

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MakeEditVM model)
        {
            if (ModelState.IsValid)
            {
                var newMake = _mapper.Map<Make>(model);
                bool result =await _makeService.UpdateMake(newMake);
                if (result)
                {
                    return RedirectToAction("List");
                }
                return View();
            }
            return View();   

        }



    }
}
