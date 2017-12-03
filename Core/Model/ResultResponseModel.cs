using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class ResultResponseModel
    {
        public object data { get; set; }
        public Error error { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }

        public Error(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
