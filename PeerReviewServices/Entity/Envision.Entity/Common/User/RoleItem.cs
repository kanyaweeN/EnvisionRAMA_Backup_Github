using System;

namespace Envision.Entity.Common.User
{
    public class RoleItem : BaseObject
    {
        public RoleItem(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public int? ParentId { get; set;}
        public int? SubMenuId { get; set;}
        public bool? CanView { get; set;}
        public bool? CanModify { get; set; }
        public bool? CanRemove { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
        public bool? CanCreate { get; set; }
    }
}