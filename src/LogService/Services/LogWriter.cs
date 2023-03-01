using LogModel;
using LogService.Data;

namespace LogService.Services
{
    public class LogWriter
    {
        private LogRepository logRepository = new LogRepository();

        public void AddMessage(LogMessageControllers message)
        {
            logRepository.WriteMessage(message);
        }
    }
}
