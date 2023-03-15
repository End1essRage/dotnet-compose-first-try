namespace CommunicationModel.ProductManagementRequest
{
    public class WriteOffRequest
    {  
        public int orderNumber { get; set; }
        public Dictionary<int, int> positions { get; set; }
        public WriteOffRequest() 
        {
            positions = new Dictionary<int, int>();
        }
    }
}
