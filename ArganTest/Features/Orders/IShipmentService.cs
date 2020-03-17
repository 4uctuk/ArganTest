using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArganTest.Features.Orders
{
    /// <summary>
    /// Shipments service
    /// </summary>
    public interface IShipmentService
    {
        /// <summary>
        /// Grouping orders to shipments
        /// </summary>
        /// <param name="orderIds">orderIds</param>
        /// <returns></returns>
        Task<List<ShippingDto>> SubmitForShipment(List<int> orderIds);
    }
}
