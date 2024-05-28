using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projekti.Models;
using Projekti.Areas.Identity.Pages.Account;
using Projekti.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;


namespace Projekti.Controllers
{
    [Authorize(Roles = "Menaxher")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> UserManager;
        public RoleManager<IdentityRole> RoleManager;
        public IEnumerable<IdentityRole> Roles { get; set; }

        public AdminController(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var users = UserManager.Users.Select(user => new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = string.Join(",", UserManager.GetRolesAsync(user).Result.ToArray())
            }).ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> ShowEdit(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest("User nuk gjendet");
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return BadRequest("User nuk gjendet" + model.Id);
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user != null)

            {
                await UserManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Create(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                return BadRequest("User nuk gjendet");
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email
            };

            var roles = RoleManager.Roles;
            ViewBag.Roles = new SelectList(roles.ToList(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUserRole(UserViewModel u)
        {
            var name = Convert.ToString(await RoleManager.FindByIdAsync(u.Role));
            var user = await UserManager.FindByEmailAsync(u.Email);
            if (user == null)
            {
                return BadRequest("User nuk ekziston" + user);
            }
            await UserManager.AddToRoleAsync(user, name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUserRole(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                return BadRequest("User nuk gjendet");
            }

            var roles = await UserManager.GetRolesAsync(user);
            var model = new UserViewModel
            {
                Id = id,
                Role = roles.First(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserRolePost(UserViewModel u)
        {
            var user = await UserManager.FindByIdAsync(u.Id);

            if (user == null)
            {
                return BadRequest("User nuk ekziston");
            }

            var roles = await UserManager.GetRolesAsync(user);
            var roleName = roles.FirstOrDefault();

            if (string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Perdoruesi nuk ka asnje rol");
            }

            var fshirje = await UserManager.RemoveFromRoleAsync(user, roleName);
            if (fshirje.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View("Veprim i pasuksesshem");
        }
    }
}