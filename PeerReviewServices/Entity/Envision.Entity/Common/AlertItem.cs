using System;

namespace Envision.Entity.Common
{
    public class AlertItem : BaseObject
    {
        public AlertItem(){

        }

        public int Id { get; set;}
        public int ParentId { get; set;}
        public int LangId { get; set;}
        public string Text { get; set;}
        public string Type { get; set;}
        public string Title { get; set;}
        public int? NumberOfButton { get; set;}
        public string TextButton1 { get; set;}
        public string TextButton2 { get; set;}
        public string TextButton3 { get; set;}
        public byte? DefaultButton { get; set;}
        public byte? TimeSec { get; set;}
        public bool? IsActive { get; set;}
        public bool? IsUpdate { get; set;}
        public bool? IsDelete { get; set;}
    }
}