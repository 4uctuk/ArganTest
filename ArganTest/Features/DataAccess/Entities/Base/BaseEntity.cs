using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArganTest.Features.DataAccess.Entities
{
    public class BaseEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
    }
}