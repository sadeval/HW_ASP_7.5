using HW_ASP_7._5.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_ASP_7._5.Controllers
{
    public class UserController : Controller
    {
        private List<User> _users = new()
    {
        new User { Id = 1, Name = "Alice", Position = "Manager", Age = 30, Salary = 70000 },
        new User { Id = 2, Name = "Bob", Position = "Developer", Age = 25, Salary = 50000 },
        new User { Id = 3, Name = "Charlie", Position = "Designer", Age = 28, Salary = 60000 }
    };

        public IActionResult Index(string name, string position, string sortBy)
        {
            var users = _users.AsQueryable();

            // Фильтрация
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(position))
            {
                users = users.Where(u => u.Position.Contains(position, StringComparison.OrdinalIgnoreCase));
            }

            // Сортировка
            users = sortBy switch
            {
                "Age" => users.OrderBy(u => u.Age),
                "AgeDesc" => users.OrderByDescending(u => u.Age),
                "Salary" => users.OrderBy(u => u.Salary),
                "SalaryDesc" => users.OrderByDescending(u => u.Salary),
                _ => users
            };

            return View(users.ToList());
        }
    }
}
