using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankQ1Investment.Models;

namespace BankQ1Investment.Controllers
{
    public class ClientBasicInfoesController : Controller
    {
        private readonly BankQ1InvestmentContext _context;

        public ClientBasicInfoesController(BankQ1InvestmentContext context)
        {
            _context = context;      //We are registering the database context
        }

        // GET: ClientBasicInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientBasicInfo.ToListAsync());
        }

        // GET: ClientBasicInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBasicInfo = await _context.ClientBasicInfo
                .FirstOrDefaultAsync(m => m.Customer_Id == id);
            if (clientBasicInfo == null)
            {
                return NotFound();
            }

            return View(clientBasicInfo);
        }

        // GET: ClientBasicInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientBasicInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customer_Id,Customer_Name,Location,Current_Investment")] ClientBasicInfo clientBasicInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientBasicInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientBasicInfo);
        }

        // GET: ClientBasicInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBasicInfo = await _context.ClientBasicInfo.FindAsync(id);
            if (clientBasicInfo == null)
            {
                return NotFound();
            }
            return View(clientBasicInfo);
        }

        // POST: ClientBasicInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Customer_Id,Customer_Name,Location,Current_Investment")] ClientBasicInfo clientBasicInfo)
        {
            if (id != clientBasicInfo.Customer_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientBasicInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientBasicInfoExists(clientBasicInfo.Customer_Id))
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
            return View(clientBasicInfo);
        }

        // GET: ClientBasicInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBasicInfo = await _context.ClientBasicInfo
                .FirstOrDefaultAsync(m => m.Customer_Id == id);
            if (clientBasicInfo == null)
            {
                return NotFound();
            }

            return View(clientBasicInfo);
        }

        // POST: ClientBasicInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientBasicInfo = await _context.ClientBasicInfo.FindAsync(id);
            _context.ClientBasicInfo.Remove(clientBasicInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientBasicInfoExists(int id)
        {
            return _context.ClientBasicInfo.Any(e => e.Customer_Id == id);
        }
    }
}
