using System.Collections.Generic;
using System.Web.Http;

namespace ArganTest.Features.Orders
{
    [Route("orders")]
    public class OrdersController : ApiController
    {
        /// <summary>
        /// Api endpoint to receive shipping request
        /// </summary>
        /// <param name="shippingDto"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]List<ShippingDto> shippingDto)
        {
            return Json(shippingDto);
        }
    }
}
