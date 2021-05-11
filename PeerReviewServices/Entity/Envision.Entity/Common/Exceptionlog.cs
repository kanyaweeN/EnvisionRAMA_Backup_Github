using System;

namespace Envision.Entity.Common
{
    public class ExceptionLog : BaseObject
    {
        public ExceptionLog()
        {

        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string IP { get; set; }
        public string MachineName { get; set; }
        public int? CurrentFormId { get; set; }
        public int? CurrentLangId { get; set; }
        public int? ConnectEmpId { get; set; }
    }
}