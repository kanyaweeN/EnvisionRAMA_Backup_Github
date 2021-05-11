using System;

namespace Envision.Entity.Common
{
    public class Alert : BaseObject
    {
        public Alert(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public int? LangId { get; set; }

    }
}