using System;

namespace Envision.Entity.Common.User
{
    public class Role : BaseObject
    {
        public Role(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public bool? IsActive { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
    }
}