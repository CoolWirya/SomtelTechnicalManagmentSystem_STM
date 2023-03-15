using Microsoft.AspNetCore.Mvc;
using SomtelTechnicalManagmentSystem_STM.Data.Services;
using SomtelTechnicalManagmentSystem_STM.Data.Classes;

using SomtelTechnicalManagmentSystem_STM.Models.LoginModel;
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
       
                

            await  _service.NewUser(login);
           return RedirectToAction(nameof(Index));
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

    }
}
