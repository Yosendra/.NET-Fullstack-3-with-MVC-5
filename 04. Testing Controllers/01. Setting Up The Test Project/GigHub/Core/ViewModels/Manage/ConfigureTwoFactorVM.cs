using System.Collections.Generic;

namespace GigHub.Core.ViewModels.Manage
{
    public class ConfigureTwoFactorVM
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}
