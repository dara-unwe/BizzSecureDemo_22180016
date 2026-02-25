using BizzSecureDemo_22180016.Data;
using BizzSecureDemo_22180016.Models;
using BizzSecureDemo_22180016.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BizzSecureDemo_22180016.Controllers;

[Authorize]
public class OrdersController : Controller
{
    private readonly AppDbContext _db;

    public OrdersController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateOrderVm vm)
     {
         if (!ModelState.IsValid)
             return RedirectToAction("Index", "Home");

         var uid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

         var order = new Order
         {
             UserId = uid,
             Title = vm.Title,
             Amount = vm.Amount
         };

         _db.Orders.Add(order);
         await _db.SaveChangesAsync();

         return RedirectToAction("Index", "Home");
     }

     public async Task<IActionResult> Details(int id)
     {
         var uid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

         // Филтрираме по Id И по UserId (защита срещу IDOR)
         var order = await _db.Orders
             .FirstOrDefaultAsync(o => o.Id == id && o.UserId == uid);

         if (order == null)
             return NotFound(); // или return Forbid();

         return View(order);
     }
    
/* public async Task<IActionResult> Details(int id)
{
    // Обърнете внимание: търсим само по Id, без проверка за собственост
    var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);
    if (order == null) return NotFound();
    return View(order);
}*/

}