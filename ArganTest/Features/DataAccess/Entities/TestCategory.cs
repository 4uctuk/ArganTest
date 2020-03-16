using System.Collections.Generic;
using ArganTest.Features.DataAccess.Entities.Base;

namespace ArganTest.Features.DataAccess.Entities
{
    public class TestCategory : BaseNamedEntity
    {
        public virtual ICollection<TestProduct> Products { get; set; }
    }
}