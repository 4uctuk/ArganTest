using System.Collections.Generic;
using System.Web.Http;

namespace ArganTest.Features.Orders
{
    [Route("orders")]
    public class OrdersController : ApiController
    {
        public IHttpActionResult Post([FromBody]List<ShippingDto> shippingDto)
        {
            return Json(shippingDto);
        }
    }
}
