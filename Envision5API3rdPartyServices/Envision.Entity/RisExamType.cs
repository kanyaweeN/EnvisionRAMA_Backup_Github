using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity
{
    public class RisExamType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public string Abbr { get; set; }
        public string Instruction { get; set; }
        public string InstructionKid { get; set; }
        public bool? IsActive { get; set; }
        public int? OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public ICollection<RisExam> ExamList { get; set; }
    }
}
