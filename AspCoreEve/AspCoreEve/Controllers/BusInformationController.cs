using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCoreEve.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AspCoreEve
{
    public class BusInformationController : Controller
    {
        public ApplicationDbContext _AppContext;
        IWebHostEnvironment _webHostEnvironment;

        public BusInformationController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _AppContext = context;
            _webHostEnvironment = webHostEnvironment;

        }    
        public async Task<IActionResult> Index()
        {
            var apllicationDbContext = _AppContext.BusInformations.Include(b => b.Catagory);
            return View(await apllicationDbContext.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_AppContext.Catagories, "Cid", "CatagoryName");
            return View();
        }

        
        [HttpPost]
        
        public async Task<IActionResult> Create( BusInformation busInformation)
        {
            if (ModelState.IsValid)
            {
                string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (busInformation.Image.Length > 0)
                {
                    string filePath = Path.Combine(uploads, busInformation.Image.FileName);
                    using(Stream fileStream=new FileStream(filePath, FileMode.Create))
                    {
                        await busInformation.Image.CopyToAsync(fileStream);
                        busInformation.ImagePath = busInformation.Image.FileName;
                    }
                }
                _AppContext.Add(busInformation);
                await _AppContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_AppContext.Catagories, "Cid", "CatagoryName", busInformation.Cid);
            return View(busInformation);
        }

    
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busInformation = await _AppContext.BusInformations.FindAsync(id);
            if (busInformation == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_AppContext.Catagories, "Cid", "CatagoryName", busInformation.Cid);
            return View(busInformation);
        }

       
        [HttpPost]
       
        public async Task<IActionResult> Edit(int id,  BusInformation busInformation)
        {
            if (id != busInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (busInformation.Image.Length > 0)
                {
                    string filePath = Path.Combine(uploads, busInformation.Image.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await busInformation.Image.CopyToAsync(fileStream);
                        busInformation.ImagePath = busInformation.Image.FileName;
                    }
                }
                try
                {
                    _AppContext.Update(busInformation);
                    await _AppContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusInformationExists(busInformation.Id))
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
            ViewData["Cid"] = new SelectList(_AppContext.Catagories, "Cid", "CatagoryName", busInformation.Cid);
            return View(busInformation);
        }

     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busInformation = await _AppContext.BusInformations
                .Include(b => b.Catagory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (busInformation == null)
            {
                return NotFound();
            }

            return View(busInformation);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busInformation = await _AppContext.BusInformations.FindAsync(id);
            _AppContext.BusInformations.Remove(busInformation);
            await _AppContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusInformationExists(int id)
        {
            return _AppContext.BusInformations.Any(e => e.Id == id);
        }
    }
}
