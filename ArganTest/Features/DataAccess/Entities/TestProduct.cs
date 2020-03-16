using System.Collections.Generic;
using ArganTest.Features.DataAccess.Entities.Base;

namespace ArganTest.Features.DataAccess.Entities
{
    public class TestProduct : BaseNamedEntity
    {
        public string SKU { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TestCategory> Categories { get; set; }

        public virtual ICollection<TestOrderProduct> OrderProducts { get; set; }
    }
}