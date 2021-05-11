using System;

namespace Envision.Entity.Common
{
    public class Unit : BaseObject
    {
        public Unit(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public int? ParentId { get; set;}
        public string Name { get; set;}
        public string NameAlias { get; set;}
        public string PhoneNo { get; set;}
        public string Description { get; set;}
        public string UnitAlias { get; set;}
        public string Type { get; set;}
        public string Instruction { get; set;}
        public string LocAlias { get; set; }
        public string Loc { get; set;}
        public bool? IsDelete { get; set;}
        public bool? IsExternal { get; set; }
    }
}