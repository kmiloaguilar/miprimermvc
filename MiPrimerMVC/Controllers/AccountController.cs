using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Domain.Entities;
using Domain.Services;
using MiPrimerMVC.Models;

namespace MiPrimerMVC.Controllers
{
    public class AccountController : Controller
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IPasswordEncryptor _passwordEncryptor;

        public AccountController(IReadOnlyRepository readOnlyRepository, IPasswordEncryptor passwordEncryptor)
        {
            _readOnlyRepository = readOnlyRepository;
            _passwordEncryptor = passwordEncryptor;
        }

        public ActionResult Login()
        {
            return View(new AccountLoginModel());
        }

        [HttpPost]
        public ActionResult Login(AccountLoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var encryptedPassword = _passwordEncryptor.Encrypt(model.Password);
                var userisValid =
                    _readOnlyRepository.FirstOrDefault<Account>(x => x.Email == model.Email && x.EncryptedPassword == encryptedPassword);
                if (userisValid != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index","Clasificados");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }
    }
}