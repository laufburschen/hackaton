using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    [Table("offers")]
    public class Offer
    {
        [Column("id")]
        [Key]
        public string id {get; set;}

        [Column("comment")]
        public string comment  {get; set;}  
    }
}