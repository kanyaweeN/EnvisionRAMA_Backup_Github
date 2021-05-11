using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core
{
    public class General
    {
        public static bool IsInDesignMode()
        {
            // this is a radical way of finding out if you are in DesignMode
            //****************Windows Forms FAQ***************************
            //***********http://www.syncfusion.com/FAQ/Winforms/**********

            string exePath = Application.ExecutablePath;
            exePath = exePath.ToLower();

            if (Application.ExecutablePath.ToLower().IndexOf("devenv.exe") > -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
