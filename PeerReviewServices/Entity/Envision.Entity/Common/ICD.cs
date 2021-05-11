using System;

namespace Envision.Entity.Common
{
    public class ICD : BaseObject
    {
        public ICD()
        {

        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
    }
}