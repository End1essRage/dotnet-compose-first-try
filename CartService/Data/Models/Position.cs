namespace CartService.Data.Models
{
    public class Position
    {
        public Product Product { get; set; }
        public int Amount { get; set; }

        public Position(Product product)
        {
            this.Product = product;
            this.Amount = 1;
        }

        public bool ChangeAmount(int amount)
        {
            if((this.Amount + amount) > 0)
            {
                this.Amount += amount;
                return true;
            }
            return false; 
        }
    }
}
