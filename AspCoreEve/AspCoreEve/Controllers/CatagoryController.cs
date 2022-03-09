using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCoreEve.Models;

namespace AspCoreEve
{
    public class CatagoryController : Controller
    {
        public ApplicationDbContext _AppContext;

        public CatagoryController(ApplicationDbContext context)
        {
            _AppContext = context;
        }

      
        public async Task<IActionResult> Index()
        {
            CatagoryViewModel catagoryViewModel = new CatagoryViewModel();
            catagoryViewModel.CatagoriVM = (IEnumerable<Catagory>)_AppContext.Catagories.AsAsyncEnumerable();
            return View(catagoryViewModel.CatagoriVM);
        }
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cid,CatagoryName")] Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                _AppContext.Catagories.Add(catagory);
                await _AppContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catagory);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _AppContext.Catagories.FindAsync(id);
            if (catagory == null)
            {
                return NotFound();
            }
            return View(catagory);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Catagory catagory)
        {
            if (id != catagory.Cid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _AppContext.Update(catagory);
                    await _AppContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatagoryExists(catagory.Cid))
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
            return View(catagory);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _AppContext.Catagories
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (catagory == null)
            {
                return NotFound();
            }

            return View(catagory);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catagory = await _AppContext.Catagories.FindAsync(id);
            _AppContext.Catagories.Remove(catagory);
            await _AppContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatagoryExists(int id)
        {
            return _AppContext.Catagories.Any(e => e.Cid == id);
        }
    }
}
