namespace WebApplication.Models
{
    public class Order
    {
        public string product {get; set;}
        public int items  {get; set;}
        public float maximum_price_per_item  {get; set;}
        public string comment  {get; set;}  
    }
}