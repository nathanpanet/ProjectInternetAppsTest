using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectInternetAppsTest.Data;
using ProjectInternetAppsTest.Models;

namespace ProjectInternetAppsTest.Controllers
{
    //for admin only!!!!!!!!!!!!!!!!!!!!
    //maybe for supliers also
    [Authorize(Roles = "Admin")]
    public class SaleDiscountsController : Controller
    {
        private readonly ProjectInternetAppsTestContext _context;

        public SaleDiscountsController(ProjectInternetAppsTestContext context)
        {
            _context = context;
        }

        // GET: SaleDiscounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleDiscount.ToListAsync());
        }

        // GET: SaleDiscounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDiscount = await _context.SaleDiscount
                .FirstOrDefaultAsync(m => m.ID == id);
            if (saleDiscount == null)
            {
                return NotFound();
            }

            return View(saleDiscount);
        }

        // GET: SaleDiscounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleDiscounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,FromDate,TillDate,Discount,Description")] SaleDiscount saleDiscount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleDiscount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleDiscount);
        }

        // GET: SaleDiscounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDiscount = await _context.SaleDiscount.FindAsync(id);
            if (saleDiscount == null)
            {
                return NotFound();
            }
            return View(saleDiscount);
        }

        // POST: SaleDiscounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,FromDate,TillDate,Discount,Description")] SaleDiscount saleDiscount)
        {
            if (id != saleDiscount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleDiscount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleDiscountExists(saleDiscount.ID))
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
            return View(saleDiscount);
        }

        // GET: SaleDiscounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDiscount = await _context.SaleDiscount
                .FirstOrDefaultAsync(m => m.ID == id);
            if (saleDiscount == null)
            {
                return NotFound();
            }

            return View(saleDiscount);
        }

        // POST: SaleDiscounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleDiscount = await _context.SaleDiscount.FindAsync(id);
            _context.SaleDiscount.Remove(saleDiscount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleDiscountExists(int id)
        {
            return _context.SaleDiscount.Any(e => e.ID == id);
        }
    }
}
