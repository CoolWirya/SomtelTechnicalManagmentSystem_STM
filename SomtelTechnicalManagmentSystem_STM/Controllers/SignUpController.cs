using Microsoft.AspNetCore.Mvc;
using SomtelTechnicalManagmentSystem_STM.Data.Security;
using SomtelTechnicalManagmentSystem_STM.Data.Services;

using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SomtelTechnicalManagmentSystem_STM.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ILoginService _service;

        public SignUpController(ILoginService service)
        {
            _service = service;
        }

        //Get:SignUp
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                var data = await _service.GetAllAsync();
                return View(data);
            }
            else
            {
                return Redirect("/");
            }
       
        }

        //Get: SignUp/Create
        public IActionResult Create()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,UserName,PhoneNumber,Email")] Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            //Validate from DB
           bool userExists = await _service.CheckLoginUsernameExists(login.UserName);
           if (userExists)
                ViewBag.UserName = "User name Exists";
            bool numberExists = await _service.CheckLoginNumberExists(login.PhoneNumber);
            if (numberExists)
                ViewBag.PhoneNumber = "Phone Number Exists";
            bool emailExists = await _service.CheckLoginEmailExists(login.Email);
            if (emailExists)
                ViewBag.Email = "Email Exists";

            if (numberExists || numberExists || emailExists)
                return View(login);

            //Validate Input
            Dictionary<string, object> newUserDictionary  =  await  _service.AddNewUser(login);
            if(Convert.ToBoolean(newUserDictionary["Added"]) == false)
            {
                if (Convert.ToBoolean(newUserDictionary["UsernameIsOK"]) == false)
                    ViewBag.UserName = "User Name Should contain between 6 to 15 characters, be ('letters', 'Numbers', '_', '.', '-') and with no spaces";
                if (Convert.ToBoolean(newUserDictionary["PhoneNumberIsOK"]) == false)
                    ViewBag.PhoneNumber = "Number Is not in correct format, example: 659*******";
                if (Convert.ToBoolean(newUserDictionary["EmailIsOK"]) == false)
                    ViewBag.Email = "Email format not correct";
                return View(login);
            }
            // return RedirectToAction(nameof(Index));
            return View("FirstSignIn");
        }

        //Get: SignUp/Details/1
        public async Task<IActionResult> Details(int id)
        {

            if (!User.Identity.IsAuthenticated)
            {
                var loginDetails = await _service.GetByIdAsync(id);
                if (loginDetails == null)
                    return View("NotFound");
                return View(loginDetails);
            }
            else
            {
                return Redirect("/");
            }

          
        }

        //Get: SignUp/Edit/1
        public async Task<IActionResult> Edit(int id)
        {

            if (!User.Identity.IsAuthenticated)
            {
                var loginDetails = await _service.GetByIdAsync(id);
                if (loginDetails == null)
                    return View("NotFound");
                return View(loginDetails);
            }
            else
            {
                return Redirect("/");
            }
         
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,UserName,PhoneNumber,Email")] Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            await _service.UpdateAsync(id, login);
            return RedirectToAction(nameof(Index));
        }

        //Get: SignUp/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
          
            if (!User.Identity.IsAuthenticated)
            {
                var loginDetails = await _service.GetByIdAsync(id);
                if (loginDetails == null)
                    return View("NotFound");
                return View(loginDetails);


            }
            else
            {
                return Redirect("/");
            }
        }

        //[HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginDetails = await _service.GetByIdAsync(id);

            if (loginDetails == null)
                return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var loginDetails = await _service.GetByIdAsync(id);
            loginDetails.Activate = false;
            if (loginDetails == null)
                return View("NotFound");
            await _service.UpdateAsync(id, loginDetails);
            return RedirectToAction(nameof(Index));
        }

       [HttpPost]
        public async Task<IActionResult> ActivateUser(int id)
        {
            var loginDetails = await _service.GetByIdAsync(id);
            loginDetails.Activate = true;
            if (loginDetails == null)
                return View("NotFound");
            await _service.UpdateAsync(id, loginDetails);
            return RedirectToAction(nameof(Index));
        }

        //Get
        public IActionResult FirstSignIn()
        {

            if (!User.Identity.IsAuthenticated)
            {
               
                return View();
            }
            else
            {
                return Redirect("/");
            }


        }

        //Post
        [HttpPost, ActionName("FirstSignIn")]
        public async Task<IActionResult> ValidateOTPFirstSignIn(Login login)
        {

            if (!User.Identity.IsAuthenticated)
            {
                var loginDetails = await _service.GetByPhoneNumber(login.PhoneNumber);
                if(login.OTP == loginDetails.OTP)
                {
                    Hash256 sha = new Hash256();
                    string salt = sha.CreateSalt(10);
                    string hash = sha.GenerateSHA256Hash(login.Password, salt);
                    loginDetails.Password = hash;
                    loginDetails.Salt = salt;
                    loginDetails.Activate = true;
                    await _service.UpdateAsync(loginDetails.Id,loginDetails);
                    return Redirect("/");
                }
                else
                {
                    ViewBag.OTP = "OTP Not Correct";
                    return View("FirstSignIn");
                }

               
            }
            else
            {
                return Redirect("/");
            }


        }

    }
}
