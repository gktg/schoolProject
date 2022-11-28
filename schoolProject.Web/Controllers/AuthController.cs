using Microsoft.AspNetCore.Mvc;
using schoolProject.Application.Repositories;
using schoolProject.Domain.ViewModels;
using schoolProject.Domain.Entities;
using schoolProject.Insfastructure.Tools;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using schoolProject.Domain.Enums;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;

namespace schoolProject.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly IStudentReadRepository _studentReadRepository;
        private readonly ITeacherReadRepository _teacherReadRepository;

        public AuthController(IStudentReadRepository studentReadRepository, ITeacherReadRepository teacherReadRepository)
        {
            _studentReadRepository = studentReadRepository;
            _teacherReadRepository = teacherReadRepository;

        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            string returnUrl = HttpContext.Request.Query["returnUrl"];

            var loginVm = new LoginVm();

            if (returnUrl != null)
            {
                loginVm.ReturnUrl = returnUrl;
            }

            return View(loginVm);
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginVm login)
        {
            Student? studentAuth = _studentReadRepository.GetWhere(x => x.StudentId == login.StudentId && x.Password == HashPass.hashPass(login.Password)).FirstOrDefault();
            Teacher? teacherAuth = _teacherReadRepository.GetWhere(x => x.TeacherId == login.StudentId && x.Password == HashPass.hashPass(login.Password)).FirstOrDefault();

            ClaimsIdentity? identity = null;


            if (studentAuth != null)
            {

                identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Role, Enum.GetName(typeof(Role), Role.Student)));


                ClaimsPrincipal? principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(30),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                if(login.ReturnUrl != null)
                {
                    return Redirect(login.ReturnUrl);

                }
                else
                {
                    return RedirectToAction("index", "Teacher");
                }
            }
            else if (teacherAuth != null)
            {
                identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Role, Enum.GetName(typeof(Role), Role.Teacher)));


                ClaimsPrincipal? principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(30),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                if (login.ReturnUrl != null)
                {
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("index", "Teacher");
                }


            }
            else
            {
                ModelState.AddModelError("", "Giriş Yapılamadı");
                return View(login);
            }

        }
    }
}
