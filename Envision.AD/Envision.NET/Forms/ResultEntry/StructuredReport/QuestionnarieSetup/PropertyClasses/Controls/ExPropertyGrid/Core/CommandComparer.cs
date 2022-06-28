using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core
{
    public class CommandComparer : System.Collections.IComparer
    {
        int System.Collections.IComparer.Compare(object o1, object o2)
        {
            return string.Compare(o1.ToString(), o2.ToString(), true);
        }
    }
}
