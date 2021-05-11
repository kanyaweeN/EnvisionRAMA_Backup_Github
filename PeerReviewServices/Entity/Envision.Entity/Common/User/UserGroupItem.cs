using System;

namespace Envision.Entity.Common.User
{
    public class UserGroupItem : BaseObject
    {
        public UserGroupItem(){

        }

        public int ParentId { get; set;}
        public int EmpId { get; set;}
        public int? SL { get; set;}
        public bool? IsActive { get; set;}
    }
}