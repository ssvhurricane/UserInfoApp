using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserInfoApp.Model;
using UserInfoApp.Model.Context;

namespace UserInfoApp.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private MainContext _dbContext;
        public HomeController(MainContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Users.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Back()
        {
         return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
           if (id != null)
            {
                User user = new User { Id = id.Value };
                _dbContext.Entry(user).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id!=null)
            {
                User? user = await _dbContext.Users.FirstOrDefaultAsync(p=>p.Id==id);
                if (user != null) return View(user);
            }
            return NotFound();
        }

         public async Task<IActionResult> More(int? id)
        {
            if(id!=null)
            {
                User? user = await _dbContext.Users.FirstOrDefaultAsync(p=>p.Id==id);
                if (user != null) return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}