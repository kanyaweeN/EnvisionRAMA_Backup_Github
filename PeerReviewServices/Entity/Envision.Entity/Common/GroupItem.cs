using System;

namespace Envision.Entity.Common
{
    public class GroupItem : BaseObject
    {
        public GroupItem(){

        }

        public int ParentId { get; set;}
        public int MemberId { get; set;}
        public byte? SL { get; set;}
        public bool? IsActive { get; set;}
    }
}