using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentExtraEdge.Model
{
    [Table("MobilePhones")]
    public class MobilePhones
    {
        [Key]
       
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public int BrandId { get; set; }
    }
}
