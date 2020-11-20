using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TM1.Helpers
{
    public class Response
    {
        public string message;
        public bool successStatus;

        public Response(bool successStatus)
        {
            this.successStatus = successStatus;
        }

        public Response(bool successStatus, string message)
        {
            this.successStatus = successStatus;
            this.message = message;
        }
    }
}