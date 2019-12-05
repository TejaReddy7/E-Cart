using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Cart.WebSite.Models;

namespace E_Cart.WebSite.Controllers
{
    public class SellerAccountsController : Controller
    {
        private readonly ECartDbContext _context;

        public SellerAccountsController(ECartDbContext context)
        {
            _context = context;
        }

        // GET: SellerAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SellerAccounts.ToListAsync());
        }

        // GET: SellerAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerAccounts = await _context.SellerAccounts
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (sellerAccounts == null)
            {
                return NotFound();
            }

            return View(sellerAccounts);
        }

        // GET: SellerAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellerAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountNumber,SellerId,BankName,IFSC,MobileNumber")] SellerAccounts sellerAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellerAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellerAccounts);
        }

        // GET: SellerAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerAccounts = await _context.SellerAccounts.FindAsync(id);
            if (sellerAccounts == null)
            {
                return NotFound();
            }
            return View(sellerAccounts);
        }

        // POST: SellerAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountNumber,SellerId,BankName,IFSC,MobileNumber")] SellerAccounts sellerAccounts)
        {
            if (id != sellerAccounts.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellerAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerAccountsExists(sellerAccounts.AccountNumber))
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
            return View(sellerAccounts);
        }

        // GET: SellerAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerAccounts = await _context.SellerAccounts
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (sellerAccounts == null)
            {
                return NotFound();
            }

            return View(sellerAccounts);
        }

        // POST: SellerAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellerAccounts = await _context.SellerAccounts.FindAsync(id);
            _context.SellerAccounts.Remove(sellerAccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerAccountsExists(int id)
        {
            return _context.SellerAccounts.Any(e => e.AccountNumber == id);
        }
    }
}
