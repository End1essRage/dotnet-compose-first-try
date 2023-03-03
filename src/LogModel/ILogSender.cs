using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogModel
{
    public interface ILogSender
    {
        public void SendMessage(LogMessage message);
    }
}
