using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;
namespace Envision.Common
{
    public class RIS_EXAMDF
    {
        public RIS_EXAMDF()
        {
        }

        public int EXAM_DF_ID { get; set; }
        public int EXAM_ID { get; set; }
        public int SL_NO { get; set; }
        public char JOB_TYPE { get; set; }
        public char CLINIC_TYPE { get; set; }
        public decimal DF { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_UPDATED_BY { get; set; }
        public DateTime LAST_UPDATED_ON { get; set; }
        public char IS_DELETED { get; set; }
        public char IS_ACTIVE { get; set; }
    }
}
