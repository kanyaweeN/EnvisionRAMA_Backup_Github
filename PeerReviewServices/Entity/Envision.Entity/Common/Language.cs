using System;

namespace Envision.Entity.Common
{
    public class Language : BaseObject
    {
        public Language()
        {

        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string IsDefault { get; set; }
        public string IsActive { get; set; }
        public string IsUpdate { get; set; }
        public string IsDelete { get; set; }
    }
}