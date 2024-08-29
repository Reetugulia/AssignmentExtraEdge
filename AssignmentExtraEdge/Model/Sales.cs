using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentExtraEdge.Model
{
    [Table("Sales")]
    public class Sales
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        [ForeignKey("Id")]
        public int MobileId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
