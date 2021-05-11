using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetSRTemplate : IBusinessLogic
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }
        public DataSet Result { get; set; }
        public enum Modes
        {
            SelectTemplateAndTemplatePart, SelectAllById
        }
        private Modes _mode = Modes.SelectAllById;
        public Modes Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public ProcessGetSRTemplate()
        {
            this.SR_TEMPLATE = new SR_TEMPLATE();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            if (_mode == Modes.SelectAllById)
            {
                SRTemplateSelectById processor = new SRTemplateSelectById();
                processor.SR_TEMPLATE = this.SR_TEMPLATE;
                this.Result = processor.SelectData();
            }
        }

        #endregion
        public DataSet GetbyId()
        {
            DataSet ds = new DataSet();
            SRTemplateSelectData proc = new SRTemplateSelectData();
            proc.SR_TEMPLATE = SR_TEMPLATE;
            ds = proc.GetById();
            return ds;
        }
        public DataTable GetByExam()
        {
            SRTemplateSelectData proc = new SRTemplateSelectData();
            proc.SR_TEMPLATE = SR_TEMPLATE;
            return proc.GetByExam();
        }
        public DataTable GetTemplate()
        {
            SRTemplateSelectData proc = new SRTemplateSelectData();
            return proc.GetTemplate();
        }
    }
}
