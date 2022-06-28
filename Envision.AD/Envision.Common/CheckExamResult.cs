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

    public class CheckExamResult
    {
        private int _sptype;
        private string _accessionno;
        private int _assignedto;
        private int _assignedby;

        public CheckExamResult()
        {
        }

        public int SpType
        {
            get { return _sptype; }
            set { _sptype = value; }
        }

        public string AccessionNo
        {
            get { return _accessionno; }
            set { _accessionno = value; }
        }


        public int AssignedTO
        {
            get { return _assignedto; }
            set { _assignedto = value; }
        }

        public int AssignedBy
        {
            get { return _assignedby; }
            set { _assignedby = value; }
        }

        

    }

}
