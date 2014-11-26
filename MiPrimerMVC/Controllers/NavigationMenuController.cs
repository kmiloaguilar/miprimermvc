using System.Collections.Generic;
using System.Web.Mvc;
using BootstrapMvcSample.Controllers;
using MiPrimerMVC.Models;

namespace MiPrimerMVC.Controllers
{
    public class NavigationMenuController : BootstrapBaseController
    {
        [ChildActionOnly]
        public ActionResult Render()
        {
            var menu = new MenuModel();
            menu.ApplicationTitle = "Clasificados";

            menu.MenuItems = new List<MenuItemModel>();
            menu.MenuItems.Add(
                new MenuItemModel
                {
                    IsDropdown = false,
                    ActionLinkModel = new ActionLinkModel
                    {
                        Action = "SignIn",
                        Controller = "Account",
                        DisplayName = "Sign In"
                    }
                });
            menu.MenuItems.Add(new MenuItemModel
            {
                IsDropdown = false,
                ActionLinkModel = new ActionLinkModel
                {
                    Action = "Register",
                    Controller = "Account",
                    DisplayName = "Register"
                }
            });


            return PartialView(menu);
        }
    }
}