using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using ArganTest.Features.DataAccess.Context;

namespace ArganTest.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var db = new ArganDbContext())
            {
                var orders = await db.TestOrders.ToListAsync();
                return View(orders);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}