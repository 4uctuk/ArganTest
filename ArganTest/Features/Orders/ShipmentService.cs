using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArganTest.Features.DataAccess.Entities;
using ArganTest.Features.DataAccess.Repositories;

namespace ArganTest.Features.Orders
{
    public class ShipmentService : IShipmentService
    {
        private readonly ITestOrderRepository _orderRepository;
        
        public ShipmentService(ITestOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<ShippingDto>> SubmitForShipment(List<int> orderIds)
        {
            var groupByAddress = await _orderRepository.GetOrdersByIdsGroupedByAddress(orderIds);

            var result = new List<ShippingDto>();

            foreach (var group in groupByAddress)
            {
                FillByAddressGroup(group, result);
            }

            return result;
        }

        private static void FillByAddressGroup(IGrouping<AddressDto, TestOrder> @group, List<ShippingDto> shippingDtos)
        {
            var orderProductsList = group.First().TestOrderProducts;
            var productsInAllOrdersToAddress = orderProductsList.Select(c => c.TestProduct).ToList();
            var productCategories = new HashSet<int>();
            
            foreach (var testProduct in productsInAllOrdersToAddress)
            {
                var categories = testProduct.Categories.Select(c => c.Id).ToList();
                foreach (var category in categories)
                {
                    productCategories.Add(category);
                }
            }
            
            foreach (var categoryId in productCategories)
            {
                var shipping = new ShippingDto()
                {
                    ShipmentId = Guid.NewGuid(),
                    Address = group.Key.Address,
                    State = group.Key.State,
                    Country = group.Key.Country,
                    FirstName = group.First().FirstName,
                    LastName = group.First().LastName
                };

                var testProducts = orderProductsList.Where(p => p.TestProduct.Categories.Any(c => c.Id == categoryId)).ToList();

                shipping.Products = testProducts.Select(c => new ProductDto()
                {
                    Quantity = c.Quantity,
                    SKU = c.TestProduct.SKU
                }).ToList();

                shippingDtos.Add(shipping);
            }
        }
    }
}