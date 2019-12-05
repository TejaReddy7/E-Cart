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
    public class OrdersController : Controller
    {
        private readonly ECartDbContext _context;

        public OrdersController(ECartDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var eCartDbContext = _context.Orders.Include(o => o.OrderDetails).Include(o => o.Payments).Include(o => o.Products).Include(o => o.Shipments).Include(o => o.Users);
            return View(await eCartDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Payments)
                .Include(o => o.Products)
                .Include(o => o.Shipments)
                .Include(o => o.Users)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["OrderNumber"] = new SelectList(_context.OrderDetails, "OrderNumber", "OrderNumber");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "ModeOfPayment");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description");
            ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "ShipmentId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Address");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,SellerId,UserId,OrderNumber,ShipmentId,PaymentId,DateStamp,EstimatedDeliveryDate")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderNumber"] = new SelectList(_context.OrderDetails, "OrderNumber", "OrderNumber", orders.OrderNumber);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "ModeOfPayment", orders.PaymentId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description", orders.ProductId);
            ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "ShipmentId", orders.ShipmentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Address", orders.UserId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["OrderNumber"] = new SelectList(_context.OrderDetails, "OrderNumber", "OrderNumber", orders.OrderNumber);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "ModeOfPayment", orders.PaymentId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description", orders.ProductId);
            ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "ShipmentId", orders.ShipmentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Address", orders.UserId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductId,SellerId,UserId,OrderNumber,ShipmentId,PaymentId,DateStamp,EstimatedDeliveryDate")] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderId))
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
            ViewData["OrderNumber"] = new SelectList(_context.OrderDetails, "OrderNumber", "OrderNumber", orders.OrderNumber);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "PaymentId", "ModeOfPayment", orders.PaymentId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description", orders.ProductId);
            ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "ShipmentId", orders.ShipmentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Address", orders.UserId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Payments)
                .Include(o => o.Products)
                .Include(o => o.Shipments)
                .Include(o => o.Users)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
