namespace OrderService.Data.Models
{
    public class Position
    {
        public Product Product { get;}
        public int Amount { get;}

        public Position(Product product, int amount)
        {
            this.Product = product;
            this.Amount = amount;
        }
    }
}
