using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ZenithSociety.Models;
using ZenithSociety.Models.UserRoleModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ZenithSociety.Data;

namespace ZenithSociety.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
 
        public UserRoleController (ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this._db = db;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var model = from ur in _db.UserRoles
                        join u in _db.Users on ur.UserId equals u.Id
                        join r in _db.Roles on ur.RoleId equals r.Id
                        select new { u.UserName, u.FirstName, u.LastName, u.Email, r.Name, ur.UserId, ur.RoleId };


            List<UserRoleViewModel> lists = new List<UserRoleViewModel>();

            foreach (var m in model)
            {
                UserRoleViewModel user = new UserRoleViewModel();
                user.RoleId = m.RoleId;
                user.UserId = m.UserId;
                user.UserName = m.UserName;
                user.RoleName = m.Name;
                lists.Add(user);
            }
            return View(lists);
        }

        [HttpGet]
        public IActionResult Assign()
        {
            UserRoleViewModel ur = new UserRoleViewModel();
            ur.Users = _userManager.Users.Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.Id
            }).ToList();

            ur.Roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            return View(ur);
        }

        [HttpPost]
        public async Task<IActionResult> Assign(UserRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.UserId);
                if(User != null)
                {
                    ApplicationRole role = await _roleManager.FindByIdAsync(model.RoleId);

                    if(!await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, role.Name);
                        if (roleResult.Succeeded)
                            return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(IFormCollection collection)
        {
            string roleName = Request.Form["roleName"];
            string userId = Request.Form["userId"];
            
            if (!string.IsNullOrEmpty(roleName) && !string.IsNullOrEmpty(userId))
            {
                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, roleName);
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }
    }
}