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

        [Column("product")]
        public string product {get; set;}

        [Column("items")]
        public int items  {get; set;}
        
        [Column("max_price_per_item")]
        public float maximum_price_per_item  {get; set;}

        [Column("comment")]
        public string comment  {get; set;}  
    }
}