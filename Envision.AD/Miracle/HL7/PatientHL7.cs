using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.HL7
{
    public class PatientHL7
    {
        public string HN { get; set; }
        public string FirstThaiName { get; set; }
        public string MiddleThaiName { get; set; }
        public string LastThaiName { get; set; }
        public string FirstEnglishName { get; set; }
        public string MiddleEnglishName { get; set; }
        public string LastEnglishame { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public string OperatorName { get; set; }
    }
}
