using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    [Table("orders")]
    public class Order
    {
        [Column("id")]
        [Key]
        public string id {get; set;}
    }
}