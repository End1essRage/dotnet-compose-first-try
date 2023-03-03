namespace OrderService.Data.Models
{
    public static class OrderStatus
    {
        public static readonly string Draft = "Draft";
        public static readonly string Unpaid = "Unpaid";
        public static readonly string Paid = "Paid";
        public static readonly string Delivering = "Delivering";
        public static readonly string Received = "Received";
        public static readonly string Cancelled = "Cancelled";
        public static readonly string Closed = "Closed";
    }
}
