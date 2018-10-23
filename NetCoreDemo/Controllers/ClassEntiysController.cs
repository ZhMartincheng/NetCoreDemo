using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Models;

namespace NetCoreDemo.Controllers
{
    public class ClassEntiysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassEntiysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassEntiys
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassEntitys.ToListAsync());
        }

        // GET: ClassEntiys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classEntiy = await _context.ClassEntitys
                .FirstOrDefaultAsync(m => m.ID == id);
            if (classEntiy == null)
            {
                return NotFound();
            }

            return View(classEntiy);
        }

        // GET: ClassEntiys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassEntiys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClassName")] ClassEntiy classEntiy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classEntiy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classEntiy);
        }

        // GET: ClassEntiys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classEntiy = await _context.ClassEntitys.FindAsync(id);
            if (classEntiy == null)
            {
                return NotFound();
            }
            return View(classEntiy);
        }

        // POST: ClassEntiys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClassName")] ClassEntiy classEntiy)
        {
            if (id != classEntiy.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classEntiy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassEntiyExists(classEntiy.ID))
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
            return View(classEntiy);
        }

        // GET: ClassEntiys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classEntiy = await _context.ClassEntitys
                .FirstOrDefaultAsync(m => m.ID == id);
            if (classEntiy == null)
            {
                return NotFound();
            }

            return View(classEntiy);
        }

        // POST: ClassEntiys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classEntiy = await _context.ClassEntitys.FindAsync(id);
            _context.ClassEntitys.Remove(classEntiy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassEntiyExists(int id)
        {
            return _context.ClassEntitys.Any(e => e.ID == id);
        }
    }
}
