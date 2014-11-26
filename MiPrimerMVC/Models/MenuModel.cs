using System.Collections.Generic;

namespace MiPrimerMVC.Models
{
    public class MenuModel
    {
        public string ApplicationTitle { get; set; }
        public string AccountName { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }
    }

    public class MenuItemModel
    {
        public bool IsDropdown { get; set; }
        public List<ActionLinkModel> SubMenuItems { get; set; }
        public ActionLinkModel ActionLinkModel { get; set; }
    }

    public class ActionLinkModel
    {
        public string DisplayName { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}