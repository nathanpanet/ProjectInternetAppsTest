﻿using System;
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
    public class ProductsController : Controller
    {
        private readonly ProjectInternetAppsTestContext _context;

        public ProductsController(ProjectInternetAppsTestContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(int? id)
        {
            //we should get all the products for cotegoryID = id.....
            var q = from a in _context.Product
                    where a.Category.ID == id
                    select a;
            return View(await q.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        //for admin and suplier only !!!!!!!!!!!!!!!!!!!!
        // GET: Products/Create
        public async Task<IActionResult> CreateAsync(int? id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin" || HttpContext.Session.GetString("userType") == "Supplier")
            {
                var q = from category in _context.Category
                        select category;
                return View(await q.ToListAsync());
            }
            else
                return RedirectToAction("login", "Users");
        }

        //for admin and suplier only !!!!!!!!!!!!!!!!!!!!
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Description,Category,Img")] Product product)
        {
            if (HttpContext.Session.GetString("userType") == "Admin" || HttpContext.Session.GetString("userType") == "Supplier")
            {
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            else
                return RedirectToAction("login", "Users");
        }


        //for admin and suplier only !!!!!!!!!!!!!!!!!!!!
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin" || HttpContext.Session.GetString("userType") == "Supplier")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = await _context.Product.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            else
                return RedirectToAction("login", "Users");
        }


        //for admin and suplier only !!!!!!!!!!!!!!!!!!!!
        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,Description,Img")] Product product)
        {
            if (HttpContext.Session.GetString("userType") == "Admin" || HttpContext.Session.GetString("userType") == "Supplier")
            {
                if (id != product.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.ID))
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
                return View(product);
            }
            else
                return RedirectToAction("login", "Users");
        }


        //for admin only !!!!!!!!!!!!!!!!!!!!
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = await _context.Product
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
            else
                return RedirectToAction("login", "Users");
        }


        //for admin only !!!!!!!!!!!!!!!!!!!!
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                var product = await _context.Product.FindAsync(id);
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction("login", "Users");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
