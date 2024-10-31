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
    
        public async Task<IActionResult> Index(string selectedVal, int page = 1, FilterMode filterMode= FilterMode.FirstName, SortState sortOrder = SortState.LastNameAsc)
        {
            int pageSize = 3;

            IQueryable<User>? users = _dbContext.Users; 

            if (!string.IsNullOrEmpty(selectedVal))
            {
                switch(filterMode)
                {
                    case FilterMode.LastName:
                    {
                         users = users.Where(p => p.LastName!.Contains(selectedVal));
                        break;
                    }
                    case FilterMode.FirstName:
                    {
                         users = users.Where(p => p.FirstName!.Contains(selectedVal));
                        break;
                    }
                    case FilterMode.PatronymicName:
                    {
                         users = users.Where(p => p.PatronymicName!.Contains(selectedVal));
                        break;
                    }
                    case FilterMode.PhoneNumber:
                    {
                         users = users.Where(p => p.PhoneNumber!.Contains(selectedVal));
                        break;
                    }
                    case FilterMode.EmailAddress:
                    {
                         users = users.Where(p => p.EmailAddress!.Contains(selectedVal));
                        break;
                    }
                }
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
                new FilterViewModel(selectedVal, filterMode),
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