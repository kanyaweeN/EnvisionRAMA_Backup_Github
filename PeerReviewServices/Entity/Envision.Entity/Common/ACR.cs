using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Entity.Common
{
    public class ACR : BaseObject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
    }
}
