using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectInternetAppsTest.Data;
using ProjectInternetAppsTest.Models;

namespace ProjectInternetAppsTest.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ProjectInternetAppsTestContext _context;

        public CategoriesController(ProjectInternetAppsTestContext context)
        {
            _context = context;
        }

        //HomePage
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("userType") == "Admin")
                return View(category);
            else
                return RedirectToAction("login", "Users");
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // GET: Categories/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
                return View();
            else
                return RedirectToAction("login", "Users");
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Img")] Category category)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                var q = 0;
                if (ModelState.IsValid)
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }
            else
                return RedirectToAction("login", "Users");
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _context.Category.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
            else
                return RedirectToAction("login", "Users");
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Img")] Category category)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                if (id != category.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.ID))
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
                return View(category);
            }
            else
                return RedirectToAction("login", "Users");
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _context.Category
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }
            else
                return RedirectToAction("login", "Users");
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                var category = await _context.Category.FindAsync(id);
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction("login", "Users");
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.ID == id);
        }
    }
}
