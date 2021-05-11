using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
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
