namespace HydroGarden.Models
{
    public class Order
    {
        public int id { get; set; }
        public string customerName { get; set; }

        public Order()
        {
            id = -1;
        }
            
    }
}