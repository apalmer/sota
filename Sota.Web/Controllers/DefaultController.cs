using Microsoft.AspNet.Mvc;
using Sota.Web.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sota.Web
{
    public class DefaultController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new DefaultModel();
            model.Name = "Test User";
            return View(model);
        }
    }
}
