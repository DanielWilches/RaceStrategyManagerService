using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Layer.Enum
{
    public enum StatusCodeHTTPEnum
    {
         [Description("The request has been received and the process is continuing.")]
         Continue = 100,

         [Description("The request has succeeded.")]
         OK = 200,

         [Description("The server could not understand the request due to invalid syntax.")]
         BadRequest = 400,

         [Description("The server can not find the requested resource.")]
         NotFound = 404,

         [Description("The server was acting as a gateway or proxy and did not receive a timely response from the upstream server.")]
         GatewayTimeout = 504
     
    }
   

}
