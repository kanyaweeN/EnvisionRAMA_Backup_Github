using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace EnvisionOnline.Common
{

        public class FormLanguage
        {
            private int _formid;
            private int _langid;
            private int _sp;
           
            public FormLanguage()
            {
            }

            public int FormID
            {
                get { return _formid; }
                set { _formid = value; }
            }

            public int LanguageID
            {
                get { return _langid; }
                set { _langid = value; }
            }

            public int ProcedureType
            {
                get { return _sp; }
                set { _sp = value; }
            }

            
        }
    
}
