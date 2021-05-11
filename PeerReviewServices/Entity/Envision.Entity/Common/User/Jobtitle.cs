using System;

namespace Envision.Entity.Common.User
{
    public class JobTitle : BaseObject
    {
        public JobTitle(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public string Description { get; set;}
        public bool? IsActive { get; set;}
        public byte? SL { get; set;}
    }
}