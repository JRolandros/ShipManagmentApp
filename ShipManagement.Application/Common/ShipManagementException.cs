using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Common
{
    public class ShipManagementException : Exception
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public ShipManagementException(int errorCode, string errorMessage, Exception? ex=null):base(errorMessage,ex)
        {
            ErrorCode=errorCode;
            ErrorMessage=errorMessage;
        }
    }
}
