using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models
{
    [Table("orders")]
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();            
        }
        
        [Column("id")]
        [Key]
        public string id {get; set;}

        public List<OrderItem> Items {get; set;}
    }
}