using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;


namespace RIS.BusinessLogic
{
    public class ProcessGetGBLSessionViewer : IBusinessLogic
    {
        private DataSet result;
        private int mode;
        private DateTime start;
        private DateTime end;

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public ProcessGetGBLSessionViewer(int mode)
        {
            this.mode = mode;
        }
        public void Invoke()
        {
            GBLSessionViewerSelect gblSessionViewerSelect = new GBLSessionViewerSelect(mode);
            gblSessionViewerSelect.Start = start;
            gblSessionViewerSelect.End = end;
            result = gblSessionViewerSelect.GetSubMenu();
        }
    }
}
