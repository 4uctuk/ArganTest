using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ArganTest.Features.DataAccess.Repositories;
using ArganTest.Features.Orders;

namespace ArganTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestOrderRepository _orderRepository;
        private readonly IShipmentService _shipmentService;

        public HomeController(ITestOrderRepository orderRepository, IShipmentService shipmentService)
        {
            _orderRepository = orderRepository;
            _shipmentService = shipmentService;
        }

        public async Task<ActionResult> Index()
        {
            var orders = await _orderRepository.GetAllAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<ActionResult> PrepareShipments(List<int> orderIds)
        {
            var shipments = await _shipmentService.SubmitForShipment(orderIds);

            return Json(shipments);
        }
    }
}