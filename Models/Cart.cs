namespace HydroGarden.Models
{
    public class Cart
    {
        public int UserId { get; set; }
        public List<CartItem> Items = new List<CartItem>();

        public void AddToCart(CartItem c)
        {
            Items.Add(c);
        }

        public void RemoveFromCart(CartItem c)
        {
            if (Items.Contains(c))
            {
                Items.Remove(c);
            }
        }

       
    }
}
