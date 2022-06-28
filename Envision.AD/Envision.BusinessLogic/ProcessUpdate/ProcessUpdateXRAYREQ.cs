using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateXRAYREQ : IBusinessLogic
    {
        public XRAYREQ XRAYREQ { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateXRAYREQ()
        {
            XRAYREQ = new XRAYREQ();
        }
        public void Invoke()
        {
            XRAYREQUpdateData _proc = new XRAYREQUpdateData();
            _proc.XRAYREQ = this.XRAYREQ;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
        }
        public void updateCancel(int order_id)
        {
            XRAYREQUpdateData _proc = new XRAYREQUpdateData();
            _proc.updateCancel(order_id);
        }
        public void updateDeleteWithModality(int order_id, int modality_id)
        {
            XRAYREQUpdateData _proc = new XRAYREQUpdateData();
            _proc.updateDeleteWithModality(order_id, modality_id);
        }
        public void updateMergeRequest(int order_id, string clinical_instruction, string ref_doc_instruction, string reason)
        {
            XRAYREQUpdateData _proc = new XRAYREQUpdateData();
            _proc.updateMergeRequest(order_id, clinical_instruction, ref_doc_instruction, reason);
        }
        public void updateLockCase(int order_id, string is_busy, int busy_by)
        {
            XRAYREQUpdateData _proc = new XRAYREQUpdateData();
            _proc.updateLockCase(order_id, is_busy, busy_by);
        }
    }
}

