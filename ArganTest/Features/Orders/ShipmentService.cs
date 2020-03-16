using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArganTest.Features.DataAccess.Repositories;

namespace ArganTest.Features.Orders
{
    public class ShipmentService : IShipmentService
    {
        private readonly ITestOrderRepository _orderRepository;
        private readonly ITestCategoryRepository _categoryRepository;

        public ShipmentService(ITestOrderRepository orderRepository, ITestCategoryRepository categoryRepository)
        {
            _orderRepository = orderRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ShippingDto>> SubmitForShipment(List<int> orderIds)
        {
            var groupByAddress = await _orderRepository.GetOrdersByIdsGroupedByAddress(orderIds);

            var result = new List<ShippingDto>();

            foreach (var group in groupByAddress)
            {
                foreach (var testOrder in group)
                {
                    var orderProducts = testOrder.TestOrderProducts.ToList();
                    var products = testOrder.TestOrderProducts.Select(c => c.TestProduct).ToList();
                    var productIds = products.Select(c => c.Id);
                    var categories = await _categoryRepository.GetAllAsync();

                    //foreach (var testCategory in categories)
                    //{
                    //    var categorizedProducts = products.Where(c => c.Categories.Select(s=>s.Id)).ToList();
                    //}

                    //foreach (var catGroup in groupByCategory)
                    //{
                    //    var shippingDto = new ShippingDto
                    //    {
                    //        ShipmentId = Guid.NewGuid(),
                    //        Address = group.Key.Address,
                    //        State = group.Key.State,
                    //        Country = group.Key.Country,
                    //        FirstName = testOrder.FirstName,
                    //        LastName = testOrder.LastName,
                    //        Products = catGroup.Products.Where(c => productIds.Contains(c.Id)).Select(s=>new ProductDto()
                    //        {
                    //            SKU = s.SKU
                    //        }).ToList()
                    //    };



                    //    result.Add(shippingDto);
                    //}
                }
            }

            return result;
        }
    }
}