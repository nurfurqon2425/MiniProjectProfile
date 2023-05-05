using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProfile2.Models;

namespace WebProfile2.Controllers
{
    public class ProfileController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApiService _apiService = new ApiService();

        public ProfileController()
        {
            
        }

        public async Task<IActionResult> Index()
        {
            var profile = await _apiService.GetProfile();
            return View(profile);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.CreateProfile(profile);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(profile);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.UpdateProfile(id);

                if (result != null)
                {
                    return View(result);                    
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.UpdateProfile(profile);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(profile);
        }

        [HttpGet]
        public async Task<IActionResult> GetDelete(int? id)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.GetDeleteProfile(id);

                if (result != null)
                {
                    return View(result);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiService.Delete(id);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
