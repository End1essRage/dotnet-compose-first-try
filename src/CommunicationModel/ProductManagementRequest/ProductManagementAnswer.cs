using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationModel.ProductManagementRequest
{
    public class ProductManagementAnswer
    {
        public int orderNumber { get; set; }
        public bool isWritedOff { get; set; }

        public ProductManagementAnswer(int orderNumber, bool isWritedOff)
        {
            this.orderNumber = orderNumber;
            this.isWritedOff = isWritedOff;
        }
    }
}
