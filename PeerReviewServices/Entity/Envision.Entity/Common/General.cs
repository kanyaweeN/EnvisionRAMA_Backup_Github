using System;

namespace Envision.Entity.Common
{
    public class General : BaseObject
    {
        public General(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public string Type { get; set;}
        public int LangId { get; set; }
    }
}