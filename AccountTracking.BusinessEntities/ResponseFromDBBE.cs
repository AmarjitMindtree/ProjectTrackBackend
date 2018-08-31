using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountTracking.BusinessEntities
{
    public class ResponseFromDBBE
    {
        public string Message;
        public bool Status;
        public HttpStatusCode StatusCode;
        public object ResponseData;
    }
}
