using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArganTest.Features.Orders
{
    public interface IShipmentService
    {
        Task<List<ShippingDto>> SubmitForShipment(List<int> orderIds);
    }
}
