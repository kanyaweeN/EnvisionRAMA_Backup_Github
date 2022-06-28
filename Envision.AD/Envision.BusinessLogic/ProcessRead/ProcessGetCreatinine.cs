using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetCreatinine : IBusinessLogic
    {
        public RIS_LABCREATININE RIS_LABCREATININE { get; set; }
        public DataTable Result { get; set; }

        public ProcessGetCreatinine()
        {
            this.RIS_LABCREATININE = new RIS_LABCREATININE();
        }

        public void Invoke()
        {
            RisCreatinineSelect processor = new RisCreatinineSelect();
            processor.RIS_LABCREATININE = RIS_LABCREATININE;
            this.Result = processor.selectLabCreatinine();
        }

        public void insertCreatinine()
        {
            RisCreatinineSelect processor = new RisCreatinineSelect();
            processor.RIS_LABCREATININE = RIS_LABCREATININE;
            processor.insertLabCreatinine();
        }

        public void updateCreatinine()
        {
            RisCreatinineSelect processor = new RisCreatinineSelect();
            processor.RIS_LABCREATININE = RIS_LABCREATININE;
            processor.updateLabCreatinine();
        }
    }
}
