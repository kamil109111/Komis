using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    public class AccountController : Controller
    {
        // pozwala użytkownikom na logowanie, wylogowanie itp.
        private readonly SignInManager<IdentityUser> _signInManager;

        // pozwala pracować z użytkownikami, sprawdzać jakie mają role itp.
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        // metoda async zwraca Task
        [HttpPost]
        public async Task<IActionResult>  Login(LoginViewModel loginViewModel)
        {
            //jeśli dane nie są poprawne
            if (!ModelState.IsValid)
                return View(loginViewModel);

            //jeśli dane są poprawne
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            //jeśli użytkownik istnieje
            if (user != null)
            // to logujemy użytkownika używając jego danych nazwa, hasło
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                // jeśli wszystko pójdzie dobrze to przkierujemy użytkownika do Index Home
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }              

            }

            //jeśli coś poszło nie tak
            ModelState.AddModelError("", "Nazwa użytkownika/hasło nie właściwe");

            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }

        // metoda do rejestracji
        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = loginViewModel.UserName };
                var result = await _userManager.CreateAsync(user, loginViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(loginViewModel);
        }

        //metoda do wylogowania
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
