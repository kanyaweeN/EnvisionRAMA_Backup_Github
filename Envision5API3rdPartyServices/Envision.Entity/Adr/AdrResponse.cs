using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Adr
{
    public class AdrResponse
    {
        public int code { get; set; }
        public string message { get; set; }
        public object resultJson { get; set; }
    }
}
