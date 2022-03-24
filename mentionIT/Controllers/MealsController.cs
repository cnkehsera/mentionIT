﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mentionIT.Data;
using mentionIT.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace mentionIT.Controllers
{
    public class MealsController : Controller
    {
        private readonly mentionITContext _context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public MealsController(mentionITContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        // GET: Meals
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meal.ToListAsync());
        }

        // GET: Meals/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id, bool? changeLikes)
        {           
            if (id == null)
            {
                return NotFound();
            }
            var meal = await _context.Meal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            if (changeLikes == true)
            {
                
                string likeCookieName = Request.Cookies["ckiLikes"];
                if (!string.IsNullOrEmpty(likeCookieName))
                {
                    List<LikesUserLink> tempLst = _context.LikesUserLink.ToList<LikesUserLink>();
                    bool canLike = true;

                    for (int i = 0; i < tempLst.Count; i++)
                    {
                        if (tempLst[i].MealId==meal.Id&&tempLst[i].Liked==true&&tempLst[i].Name==likeCookieName)
                        {
                            canLike = false;
                            break;
                        }
                    }
                    if (canLike == true)
                    {
                        meal.Likes += 1;
                        _context.Update(meal);
                        int temp = tempLst.Count<LikesUserLink>();
                        LikesUserLink newRecord = new LikesUserLink { Id = default, Name = likeCookieName, Liked = true, MealId = meal.Id };
                        _context.Add(newRecord);
                    }                 
                }
                await _context.SaveChangesAsync();
            }
            return View(meal);
        }

        // GET: Meals/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ImageAdd()
        {

            return View();
        }
        private bool HasImageExtension(string source)
        {
            if (source == null) { return false; }
            return (
                source.EndsWith(".png") ||
                source.EndsWith(".PNG") ||
                source.EndsWith(".jpeg") ||
                source.EndsWith(".JPEG") ||
                source.EndsWith(".gif") ||
                source.EndsWith(".GIF") ||
                source.EndsWith(".jpg") ||
                source.EndsWith(".JPG"));
        }
        [HttpPost]
        public IActionResult ImageAdd(MealViewModel vm)
        {
            string stringFileName = UploadFile(vm);
            if (stringFileName == null)
            {
                return View("ImageAdd");
            }
            else
            {
                var meal = new Meal
                {
                    Name = vm.Name,
                    MealImage = stringFileName
                };
                _context.Meal.Add(meal);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        private string UploadFile(MealViewModel vm)
        {
            string fileName = null;
            if (vm.MealImage != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "ImageForMeals");
                fileName = Guid.NewGuid().ToString() + "-" + vm.MealImage.FileName;
                bool compareExtension = HasImageExtension(fileName) /*stringFileName.ToString().Substring(stringFileName.Length -4).ToUpper()*/;
                if (compareExtension == true)
                {
                    string filePath = Path.Combine(uploadDir, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        vm.MealImage.CopyTo(fileStream);

                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Extention File");
                    return null;
                }


            }
            return fileName;
        }
        // POST: Meals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cuisine,Likes,Comments,YLink")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meal);
        }

        // GET: Meals/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meal.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cuisine,Likes,Comments,YLink")] Meal meal)
        {
            if (id != meal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(meal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meal);
        }

        // GET: Meals/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Meal.FindAsync(id);
            _context.Meal.Remove(meal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Meal.Any(e => e.Id == id);
        }
        //private IActionResult IncreaseLikes(int id)
        //{
        //    Meal meal = _context.Meal.Find(id);
        //    meal.Likes += 1;
        //    _context.SaveChanges();
        //    return Details(meal.Id);
        //}
    }
}