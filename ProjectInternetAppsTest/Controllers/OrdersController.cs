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
    public class OrdersController : Controller
    {
        private readonly ProjectInternetAppsTestContext _context;

        public OrdersController(ProjectInternetAppsTestContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            //כל אחד לפי ההזמנות שלו 
            //ומנהל שיקבל את כולם 
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //לבדוק שההזמנה שייכת אליו
            if (id == null) return NotFound();

            var order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);
            if (order == null) return NotFound();

            return View(order);
        }



        //צריך לייצר פונקציה כזאת ביצירת עגלת קניות

        //// GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Orders/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AddedOn,ConfirmedOn,PayedOn,Status,TotalPrice")] Order order)
        {
            string v = HttpContext.Session.GetString("userId");
            int a = Convert.ToInt32(v);
            var q = from b in _context.User
                    where b.ID == a
                    select b;

            order.User = q.FirstOrDefault();
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }


        //לא בטוח שזה שימושי
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AddedOn,ConfirmedOn,PayedOn,Status,TotalPrice")] Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ID))
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
            return View(order);
        }


        //for admin only!!!!!!!!!!!!!!!!!!!!
        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var order = await _context.Order
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (order == null)
                {
                    return NotFound();
                }

                return View(order);
            }
            else
                return RedirectToAction("login", "Users");
        }


        //for admin only!!!!!!!!!!!!!!!!!!!!
        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("userType") == "Admin")
            {
                var order = await _context.Order.FindAsync(id);
                _context.Order.Remove(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction("login", "Users");
        }

        public IActionResult Pay()
        {//should be a post function
            return View();
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.ID == id);
        }
        public async Task<IActionResult> NewOrder(Product product)
        {
            string v = HttpContext.Session.GetString("userId");
            int a = Convert.ToInt32(v);
            var q = from b in _context.User
                    where b.ID == a
                    select b;

            //order.User = q.FirstOrDefault();
            //if (ModelState.IsValid)
            //{
            //    _context.Add(order);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }
    }
}
