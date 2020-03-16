using System.Collections.Generic;

namespace ArganTest.Features.DataAccess.Entities
{
    public class TestOrder : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public virtual ICollection<TestOrderProduct> TestOrderProducts { get; set; }
    }
}