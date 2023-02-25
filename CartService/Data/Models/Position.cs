namespace CartService.Data.Models
{
    public class Position
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double Price => Product.Price * Amount;
    }
}
