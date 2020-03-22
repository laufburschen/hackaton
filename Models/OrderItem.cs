using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    [Table("order_items")]
    public class OrderItem
    {
        [ForeignKey(nameof(Order))]
        public string order_id {get;set;}

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

        public Order Order { get; set; }
    }
}