using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using BootstrapMvcSample.Controllers;
using Domain.Entities;
using Domain.Services;
using MiPrimerMVC.Models;

namespace MiPrimerMVC.Controllers
{
    public class AccountController : BootstrapBaseController
    {
        readonly IPasswordEncryptor _passwordEncryptor;
        readonly IWriteOnlyRepository _writeOnlyRepository;
        readonly IMappingEngine _mappingEngine;
        readonly IReadOnlyRepository _readOnlyRepository;

        public AccountController(IReadOnlyRepository readOnlyRepository, 
            IPasswordEncryptor passwordEncryptor, 
            IWriteOnlyRepository writeOnlyRepository, 
            IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;
            _passwordEncryptor = passwordEncryptor;
            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
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
                string encryptedPassword = _passwordEncryptor.Encrypt(model.Password);
                var userisValid =
                    _readOnlyRepository.FirstOrDefault<Account>(
                        x => x.Email == model.Email && x.EncryptedPassword == encryptedPassword);
                if (userisValid != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    SetAuthenticationCookie(model.Email, userisValid.Roles);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Clasificados");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View(new AccountRegisterModel());
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Account newAccount = _mappingEngine.Map<AccountRegisterModel, Account>(model);
                newAccount.ChangeEncryptedPassword( _passwordEncryptor.Encrypt(model.Password));
                newAccount = _writeOnlyRepository.Create(newAccount);
                Success(string.Format("The user with the email {0} has been created",newAccount.Email));
                return RedirectToAction("Login","Account");
            }

            return View(model);
        }
    }
}