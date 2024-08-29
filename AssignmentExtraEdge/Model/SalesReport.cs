using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentExtraEdge.Model
{
    [Table("SaleDetails")]
    public class SalesReport
    {
        [Key]
        public int Id { get; set; }            
        public int SaleId { get; set; }      
        public int MobileId { get; set; }      
        public int Quantity { get; set; }     
        public decimal Discount { get; set; }  
        public DateTime DateTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
