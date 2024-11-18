using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SimpleSchoolSystem.ServicesLayer.Dto.Account;
using SimpleSchoolSystem.ServicesLayer.Dto.Identity;
using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
      //  private readonly IStringLocalizer<sharedResources> stringLocalizer;
      private readonly IMapper _mapper;
        public AccountController(UserManager<User> _userManager, SignInManager<User> signInManager, IMapper _mapper)
        {
            this._userManager = _userManager;
            _signInManager = signInManager;
            this._mapper = _mapper;
        }
        [HttpGet]
        public IActionResult Login(string returnurl)
        {
            var Log = new LoginViewModel
            {
                ReturnUrl= returnurl
            };
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel log)
        {
            if (ModelState.IsValid)
            {
                var isEmailValid=new EmailAddressAttribute().IsValid(log.Email);//bool
                var user=new User();
                if (isEmailValid)
                {
                    user= await _userManager.FindByEmailAsync(log.Email);
                }
                else user=await _userManager.FindByNameAsync(log.Email);
                //var user = await _userManager.FindByEmailAsync(log.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "UserName or Password is Wrong");
                    return View(log);
                }

                var result = await _userManager.CheckPasswordAsync(user, log.Password);
                if (!result)
                {
                    ModelState.AddModelError(string.Empty, "Password is wrong");
                    return View(log);
                }

                var r = await _signInManager.PasswordSignInAsync(user, log.Password, log.RemmemberMe, false);
                if (r.Succeeded)
                {
                    if (!string.IsNullOrEmpty(log.ReturnUrl)/* && Url.IsLocalUrl(log.ReturnUrl)*/)
                    {
                       // return LocalRedirect(log.ReturnUrl);
                        return LocalRedirect(log.ReturnUrl);

                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Failed to login");
                return View(log);
            }
            return View(log);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Registration model)
        {
            if (ModelState.IsValid)
            {
                var user=await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    //var newUser = new User()
                    //{
                    //    Email = model.Email,
                    //    UserName=model.Email
                    //};
                    var newUser = _mapper.Map<User>(model);
                    var result=await _userManager.CreateAsync(newUser,model.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(newUser            , isPersistent: false);
                        return RedirectToAction("Index","Department");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                ModelState.AddModelError(string.Empty, "UserEmail is Already Exist");
                return View(model);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        public IActionResult AccessDenied(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }
    }
}
