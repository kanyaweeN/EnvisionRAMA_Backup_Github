using System;

namespace Envision.Entity.Common
{
    public class Group : BaseObject
    {
        public Group(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public string Name { get; set;}
        public string UserName { get; set;}
        public string Pass { get; set;}
        public string Type { get; set;}
        public int? HeadId { get; set;}
        public string HeadName { get; set;}
        public int? ContactNumber { get; set;}
        public bool? IsActive { get; set;}
    }
}