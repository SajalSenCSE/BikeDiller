using AutoMapper;
using BikeDiller.App.Models.CurrencyModels;
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
    public class CurrencyController : Controller
    {
        ICurrencyService _currencyService;
        IMapper _mapper;

        public CurrencyController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }




        public async Task<IActionResult> List()
        {
            var result = await _currencyService.GetAll();

            var mapperListVM = new CurrencyListVM()
            {
                Currencies = result.ToList()
            };
            
            return View(mapperListVM);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CurrencyCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var newCurrency = _mapper.Map<Currency>(model);

                bool result = await _currencyService.AddNew(newCurrency);
                if (result)
                {
                    return View();
                }
                else
                    return View();

            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("Faild");
            }
            var aCurrency = await _currencyService.GetById((int)id);
            if (aCurrency == null)
            {
                return NoContent();
            }
            bool result = await _currencyService.DeleteEntity(aCurrency);
            if (result)
            {
                return RedirectToAction("List");
            }
            return View();

        }



        public async Task<IActionResult> Edit(int id)
        {
            var aCurrency = await _currencyService.GetById(id);
            if (aCurrency == null)
            {
                return NoContent();
            }
            var obj = _mapper.Map<CurrencyEditVM>(aCurrency);

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CurrencyEditVM model)
        {
            if (ModelState.IsValid)
            {
                var newMake = _mapper.Map<Currency>(model);
                bool result = await _currencyService.UpdateEntity(newMake);
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
