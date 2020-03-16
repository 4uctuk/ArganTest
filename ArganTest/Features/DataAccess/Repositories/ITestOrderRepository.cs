using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArganTest.Features.DataAccess.Entities;
using ArganTest.Features.Orders;

namespace ArganTest.Features.DataAccess.Repositories
{
    public interface ITestOrderRepository : IGenericRepository<TestOrder>
    {
        Task<List<IGrouping<AddressDto, TestOrder>>> GetOrdersByIdsGroupedByAddress(List<int> ids);
    }
}
