using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArganTest.Features.Orders
{
    public class ShippingDto
    {
        public Guid ShipmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Address { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}