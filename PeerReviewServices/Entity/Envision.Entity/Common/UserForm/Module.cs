using System;

namespace Envision.Entity.Common.UserForm
{
    public class Module : BaseObject
    {
        public Module(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public string Name { get; set;}
        public string Namespace { get; set;}
        public byte[] Icon { get; set;}
        public string Description { get; set;}
        public int? Parent { get; set;}
        public int? SL { get; set;}
        public bool? IsActive { get; set;}
    }
}