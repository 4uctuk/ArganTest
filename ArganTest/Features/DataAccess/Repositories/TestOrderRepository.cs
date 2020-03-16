using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ArganTest.Features.DataAccess.Entities;
using ArganTest.Features.Orders;

namespace ArganTest.Features.DataAccess.Repositories
{
    public class TestOrderRepository : GenericRepository<TestOrder>, ITestOrderRepository
    {
        public async Task<List<IGrouping<AddressDto, TestOrder>>> GetOrdersByIdsGroupedByAddress(List<int> ids)
        {
            var result = SetWithRelatedEntitiesAsNoTracking.Include("TestOrderProducts.TestProduct.Categories")
                .Where(c => ids.Contains(c.Id)).GroupBy(c => new AddressDto
                    {Country = c.Country, State = c.State, City = c.City, Address = c.Address});
            return await result.ToListAsync();
        }
    }
}