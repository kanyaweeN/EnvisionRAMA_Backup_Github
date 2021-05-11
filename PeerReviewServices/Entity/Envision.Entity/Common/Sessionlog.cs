using System;

namespace Envision.Entity.Common
{
    public class SessionLog : BaseObject
    {
        public SessionLog(){

        }

        public int Id { get; set;}
        public int? SessionId { get; set;}
        public string SessionGuid { get; set;}
        public int? SubMenuId { get; set;}
        public DateTime? AccessedOn { get; set;}
        public DateTime? AccessedOut { get; set;}
        public string ActivityDesciption { get; set;}
    }
}