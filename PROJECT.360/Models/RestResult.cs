using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT._360.Models
{
    public class RestResult
    {
        public object Data { get; set; } = null;
        public string Message { get; set; }
    }
}