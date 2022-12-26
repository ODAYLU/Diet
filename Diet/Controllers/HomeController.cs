using Diet.Data;
using Diet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Diet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> OrdersDoctor()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _context.Orders
                            .Where(z => z.DoctorId == userId)
                            .Include(x => x.Doctor)
                            .Include(x => x.Patient)
                            .ToListAsync();
            return View(orders);
        }
        [Authorize]
        public async Task<IActionResult> OrdersPatient()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _context.Orders
                            .Where(z => z.PatientId == userId)
                            .Include(x => x.Doctor)
                            .Include(x => x.Patient)
                            .ToListAsync();
            return View(orders);
        } 
        public async Task<IActionResult> RepliesForOrder(int id)
        {
            var replies = await _context.Replies
                                    .Where(x => x.OrderId == id)
                                    .Include(z => z.GetOrder)
                                    .ToListAsync();
            return View(replies);
        }
        public async Task<IActionResult> ReplyOrder(int id)
        {
            var newReply = new Reply
            {
                OrderId = id
            };
            ViewBag.Orders = await _context.Orders.ToListAsync();
            return View(newReply);
        }

        public IActionResult CreateOrder()
		{
            return View();
		}
        [HttpPost]
        public async Task<IActionResult> ReplyOrder(Reply reply)
        {
            var newReply = new Reply
            {
                OrderId = reply.OrderId,
                Date = DateTime.Now,
                Description = reply.Description,
                Title = reply.Title
            };
          await  _context.Replies.AddAsync(reply);
          await _context.SaveChangesAsync();
            return RedirectToAction("OrdersDoctor");
        }

       
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}