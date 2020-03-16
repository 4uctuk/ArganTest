using System.ComponentModel.DataAnnotations.Schema;

namespace ArganTest.Features.DataAccess.Entities
{
    public class TestOrderProduct : BaseEntity
    {
        [ForeignKey("TestOrder")]
        public int OrderId { get; set; }

        [ForeignKey("TestProduct")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public virtual TestOrder TestOrder { get; set; }
        public virtual TestProduct TestProduct { get; set; }
    }
}