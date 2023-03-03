namespace CommunicationModel.ProductManagementRequest
{
    public class WriteOffRequest : ProductRequest
    {
        public int orderNumber { get; set; }
        public WriteOffRequest() 
        {
            positions = new Dictionary<int, int>();
        }
    }
}
