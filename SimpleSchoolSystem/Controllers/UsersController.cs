using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleSchoolSystem.ServicesLayer.Dto.Identity;
using SimpleSchoolSystem.ServicesLayer.Dto.User;

namespace SimpleSchoolSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<User> _userManager, IMapper m, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = _userManager;
            _mapper = m;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var u = await _userManager.Users.ToListAsync();
            var result = _mapper.Map<List<UserViewModel>>(u);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
            var response = _mapper.Map<updateUser>(user);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(updateUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null) { return NotFound(); }
                var map = _mapper.Map(model, user);
                var r = await _userManager.UpdateAsync(map);
                if (r.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
            var response = _mapper.Map<GetUserByIdViewModel>(user);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(GetUserByIdViewModel model)
        {
            var x = await _userManager.FindByIdAsync(model.Id);
            if (x == null) { return NotFound(); }
            var result = await _userManager.DeleteAsync(x);
            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ManageRoleInUser(string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null) { return NotFound(); }
            var roles = await _roleManager.Roles.ToListAsync();
            var userroles = _mapper.Map<List<ManageRoleInUserViewModel>>(roles);
            foreach (var role in userroles)
            {
                if (await _userManager.IsInRoleAsync(user, role.RoleName))
                    role.IsSelected = true;
            }
            ViewBag.Userid = userid;
            return View(userroles);
        }
        [HttpPost]
        public async Task<IActionResult> ManageUserInRole(List<ManageRoleInUserViewModel> manageRoles, string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) return NotFound();

                foreach (var role in manageRoles)
                {
                    if(role.IsSelected&&!(await _userManager.IsInRoleAsync(user,role.RoleName)))
                        {
                        await _userManager.AddToRoleAsync(user, role.RoleName);

                    }
                   
                    else if (!role.IsSelected && (await _userManager.IsInRoleAsync(user, role.RoleName)))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                    }
                    else
                    {
                        continue;
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(manageRoles);
            }
        }
    }
}

