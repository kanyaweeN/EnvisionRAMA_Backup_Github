using System;

namespace Envision.Entity.Common.User
{
    public class GrantRole : BaseObject
    {
        public GrantRole(){

        }

        public int Id { get; set;}
        public int RoleId { get; set;}
        public int EmpId { get; set;}
        public int? CanGrant { get; set;}
        public int? Grantor { get; set;}
        public DateTime? GrantDate { get; set;}
        public bool? IsUpdate { get; set;}
        public bool? IsDelete { get; set;}
    }
}