using CommunicationModel.ProductManagementRequest;

namespace ProductManagementService.Data.DataAccess
{
    public interface IProductRepository
    {
        public bool tryToWriteOff(WriteOffRequest request);
    }
}
