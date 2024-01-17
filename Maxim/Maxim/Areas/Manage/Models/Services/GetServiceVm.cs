using System.ComponentModel.DataAnnotations;

namespace Maxim.Areas.Manage.Models.Services
{
    public class GetServiceVm
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
