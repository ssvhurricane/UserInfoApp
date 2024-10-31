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

        public async Task<IActionResult> Index(string name, int page = 1, SortState sortOrder = SortState.LastNameAsc)
        {
            int pageSize = 3;

            IQueryable<User>? users = _dbContext.Users; 

            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.FirstName!.Contains(name));
            }

            switch (sortOrder)
            {
                case SortState.LastNameDesc:
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                case SortState.FirstNameDesc:
                    users = users.OrderByDescending(s => s.FirstName);
                    break;
                 case SortState.FirstNameAsc:
                    users = users.OrderBy(s => s.FirstName);
                    break;
                default:
                    users = users.OrderBy(s => s.LastName);
                    break;
            }
 
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
           
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel( name),
                new SortViewModel(sortOrder)
            );
           
            return View(viewModel);
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