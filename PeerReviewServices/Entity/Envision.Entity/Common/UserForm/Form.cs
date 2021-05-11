using System;

namespace Envision.Entity.Common.UserForm
{
    public class Form : BaseObject
    {
        public Form(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public int? ParentId { get; set;}
        public string SubmenuType { get; set;}
        public string ClassMenuName { get; set;}
        public string SystemMenuName { get; set;}
        public string UserMenuName { get; set;}
        public int? Parent { get; set;}
        public string Description { get; set;}
        public int? SL { get; set;}
        public bool? IsActive { get; set;}
        public bool? AddToHome { get; set; }
        public bool? CanView { get; set; }
        public bool? CanModify { get; set; }
        public bool? CanRemove { get; set; }
        public bool? CanCreate { get; set; }
    }
}