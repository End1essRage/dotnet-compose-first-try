using CommunicationModel.ProductManagementRequest;
using LogModel;
using ProductManagementService.Communication;
using ProductManagementService.Data.DataAccess;

namespace ProductManagementService.Services
{
    public class RequestWorker
    {
        private IProductRepository _repository;
        private RmqSender _mqSender;
        private ILogSender _logger;

        public RequestWorker(IProductRepository repository, RmqSender mqSender, ILogSender logger)
        {
            _repository = repository;
            _mqSender = mqSender;
            _logger = logger;
        }

        public bool HandleRequest(WriteOffRequest request) 
        {
            _logger.SendMessage(new LogMessage("RequestWorker - HandleRequest"));
            bool status = !_repository.tryToWriteOff(request);
            _logger.SendMessage(new LogMessage("writeoff status = " + status.ToString()));
            _mqSender.SendMessage(new ProductManagementAnswer(request.orderNumber, status));
            return true;
        }
    }
}
