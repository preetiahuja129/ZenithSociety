using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ZenithSociety.Models;
using Microsoft.AspNetCore.Identity;
using ZenithSociety.Models.UserRoleModels;
using ZenithSociety.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithSociety.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public RoleController(RoleManager<ApplicationRole> roleManager, ApplicationDbContext db)
        {
            this._roleManager = roleManager;
            this._db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<RoleListViewModel> rlvm = new List<RoleListViewModel>();
            rlvm = _roleManager.Roles.Select(r => new RoleListViewModel
            {
                Id = r.Id,
                RoleName = r.Name,
                Description = r.Description,
                NumberOfUsers = r.Users.Count
            }).ToList();
            return View(rlvm);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(string id)
        {
            RoleViewModel rvm = new RoleViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationRole ar = await _roleManager.FindByIdAsync(id);
                if (ar != null)
                {
                    rvm.Id = ar.Id;
                    rvm.RoleName = ar.Name;
                    rvm.Description = ar.Description;
                }
            }
            return View(rvm);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(string id, RoleViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                bool isExist = !String.IsNullOrEmpty(id);
                ApplicationRole ar = isExist ? await _roleManager.FindByIdAsync(id) :
               new ApplicationRole
               {
                   CreatedDate = DateTime.UtcNow
               };
                ar.Name = rvm.RoleName;
                ar.Description = rvm.Description;
                IdentityResult roleRuslt = isExist ? await _roleManager.UpdateAsync(ar)
                                                    : await _roleManager.CreateAsync(ar);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(rvm);
        }
        

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _db.Roles.SingleOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }
        

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _db.Roles.SingleOrDefaultAsync(m => m.Id == id);
            _db.Roles.Remove(role);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}