using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using CineClub.Data;
using CineClub.Models;

namespace CineClub.Controllers
{
    public class ReviewController : Controller
    {
        private readonly CineDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IHubContext<ReviewsHub> _hub;

        public ReviewController(CineDbContext context, UserManager<IdentityUser> userManager, IHubContext<ReviewsHub> hub)
        {
            _context = context;
            _userManager = userManager;
            _hub = hub;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            var cineDbContext = _context.Reviews.Include(r => r.Movie);
            return View(await cineDbContext.ToListAsync());
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            
            //to display user name 
            string? userName = null;
            if (!string.IsNullOrEmpty(review.UserId))
            {
                var user = await _userManager.FindByIdAsync(review.UserId);
                userName = user?.UserName;
            }

            ViewBag.UserName = userName;

            return View(review);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Rating,CreatedAtUtc,MovieId")] Review review)
        {
            if (ModelState.IsValid)
            {
                // Get current user's (logged-in) Id
                var userId = _userManager.GetUserId(User);
                review.UserId = userId;
                review.CreatedAtUtc = DateTime.UtcNow;
                _context.Add(review);
                await _context.SaveChangesAsync();

                //SignalR
                await _hub.Clients
                .Group($"movie-{review.MovieId}")
                .SendAsync("ReceiveReview", new
                {
                    reviewId = review.Id,
                    user = User.Identity?.Name ?? "Unknown",
                    content = review.Content,
                    rating = review.Rating,
                    createdAt = review.CreatedAtUtc?.ToString("dd.MM.yyyy HH:mm") + " (UTC)"
                });



                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", review.MovieId);
            return View(review);
        }

        // GET: Review/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            
            var currentUserId = _userManager.GetUserId(User);
            if (review.UserId != currentUserId && !User.IsInRole("Admin"))
            {
                return Forbid(); 
            }

            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", review.MovieId);
            return View(review);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Rating,CreatedAtUtc,MovieId")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            var reviewFromDb = await _context.Reviews.FindAsync(id);
            if (reviewFromDb == null)
            {
                return NotFound();
            }

            var currentUserId = _userManager.GetUserId(User);
            if (reviewFromDb.UserId != currentUserId && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    reviewFromDb.Content = review.Content;
                    reviewFromDb.Rating  = review.Rating;

                    _context.Update(reviewFromDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
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

            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", review.MovieId);
            return View(review);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            var currentUserId = _userManager.GetUserId(User);
            if (review.UserId != currentUserId && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
