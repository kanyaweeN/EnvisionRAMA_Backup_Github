using System;

namespace Envision.Entity.Common
{
    public class GeneralItem : BaseObject
    {
        public GeneralItem(){

        }

        public int Id { get; set;}
        public int ParentId { get; set;}
        public int LangId { get; set;}
        public string Text { get; set;}
        public string Title { get; set;}
        public bool? IsActive { get; set;}
        public bool? IsUpdate { get; set; }
        public bool? IsDelete { get; set; }
    }
}