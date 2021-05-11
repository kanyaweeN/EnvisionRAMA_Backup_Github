using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
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
            result = new DataSet();
            start = DateTime.MinValue;
            end = DateTime.MinValue;
            mode = 0;
            this.mode = mode;
        }
        public ProcessGetGBLSessionViewer()
        {
        }
        public void Invoke()
        {
            GBLSessionViewerSelect gblSessionViewerSelect = new GBLSessionViewerSelect(mode);
            gblSessionViewerSelect.Start = start;
            gblSessionViewerSelect.End = end;
            result = gblSessionViewerSelect.GetSubMenu();
        }
        public DataSet GetSessionAltMsg(int EMP_ID)
        {
            GBLSessionViewerSelect gblSessionViewerSelect = new GBLSessionViewerSelect();
            return gblSessionViewerSelect.GetSessionAltMsg(EMP_ID);
        }
    }
}
