using System;

namespace Envision.Entity.Common
{
    public class BISettings : BaseObject
    {
        public BISettings(){

        }

        public int Id { get; set;}
        public int ReportId { get; set; }
        public int EmpId { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public string Tag { get; set;}
        public bool? IsGlobal { get; set;}
        public string OrderField { get; set;}
    }
}