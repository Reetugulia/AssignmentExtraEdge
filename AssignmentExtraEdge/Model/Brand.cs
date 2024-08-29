using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentExtraEdge.Model
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
      
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
