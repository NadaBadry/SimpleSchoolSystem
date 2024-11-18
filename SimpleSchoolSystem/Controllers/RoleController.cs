using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleSchoolSystem.ServicesLayer.Dto.Identity;
using SimpleSchoolSystem.ServicesLayer.Dto.Role;

namespace SimpleSchoolSystem.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;
        private readonly UserManager<User>_userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, IMapper mapper, UserManager<User> _userManager)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
            this._userManager = _userManager;
        }
        public IActionResult Index()
        {
            var rol = roleManager.Roles.ToList();
            var result = mapper.Map<List<GetRoles>>(rol);
            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddRole model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole() { Name = model.Name };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);

            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var result =  mapper.Map<UpdateRole>(role);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRole model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);
                if (role == null) return NotFound();
                var result = mapper.Map(model, role);
                var r = await roleManager.UpdateAsync(result);
                if (r.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }

            return View(model);
        }
        public async Task<IActionResult> Details(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var result = mapper.Map<GetRoleById>(role);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var result = mapper.Map<GetRoleById>(role);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult>Delete(GetRoleById model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null) return NotFound();
            var result=await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
       
        [HttpGet]
        public async Task<IActionResult> ManageUserInRole(string roleId)
        {
            var role=await roleManager.FindByIdAsync(roleId);
            if (role == null) return NotFound();
            var users = await _userManager.Users.ToListAsync();
           var userlist= mapper.Map<List<ManageUserInRoleModel>>(users);
            foreach (var user in users)
            {
                var manageuser=mapper.Map<ManageUserInRoleModel>(user);
                var IsUserRolrd = await _userManager.IsInRoleAsync(user,role.Name);
                manageuser.IsSelected=IsUserRolrd;
                userlist.Add(manageuser);
            }
            ViewBag.RoleId = roleId;
            return View(userlist);
        }
        [HttpPost]
        public async Task<IActionResult> ManageUserInRole(List<ManageUserInRoleModel> users,string roleId)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(roleId);
                if (role == null) return NotFound();

                foreach (var model in users)
                {
                    var user = await _userManager.FindByIdAsync(model.UserId);
                    if (user == null) return NotFound();
                    if (model.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);

                    }
                    else if (!model.IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.Name);
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
                ModelState.AddModelError(string.Empty,ex.Message);
                return View("ManageUserInRoleModel");
            }
        }


    }
}
