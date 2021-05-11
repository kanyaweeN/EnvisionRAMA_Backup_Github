using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Common
{
    public class PatientDestination
    {
        public int Id { get; set; }
        public ConditionTypes Type { get; set; }
        public string Label { get; set; }
        public string EncounterType { get; set; }
        public string EncounterClinicType { get; set; }
        public string[] OrderingDept { get; set; }
        public int ExamUnit { get; set; }
    }
}
