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
    public class UsersController : Controller
    {
        private readonly ProjectInternetAppsTestContext _context;

        public UsersController(ProjectInternetAppsTestContext context)
        {
            _context = context;
        }



        //for admin only !!!!!!!!!!!!!!!!!!!!
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }




        // GET: Users/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: Users/SignUp
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("FirstName,LastName,UserName,Password,Email,Address,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(int id, [Bind("ID,FirstName,LastName,UserName,Password,Email,Address,Phone")] User user)
        {

            if (ModelState.IsValid)
            {
                var q = from a in _context.User
                        where a.UserName == user.UserName &&
                            a.Password == user.Password
                        select a;
                if (q.Count() > 0){
                    HttpContext.Session.SetString("user", q.First().FirstName);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        //for admin only!!!!!!!!!!!!!!!!!!!!
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //for admin only !!!!!!!!!!!!!!!!!!!!
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.ID == id);
        }
    }
}
