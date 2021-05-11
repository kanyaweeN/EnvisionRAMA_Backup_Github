using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class XrayReqSendToOrder : DataAccessBase
    {
        public XrayReqSendToOrder()
        {
            this.StoredProcedureName = StoredProcedure.Prc_XRAY_SendToOrder;
        }

        public void SendToOrder(int order_id, int last_modified_by, int org_id, int xrayId)
        {
            this.ParameterList = new DbParameter[] { 
                Parameter("@ORDER_ID", order_id),
                Parameter("@LAST_MODIFIED_BY", last_modified_by),
                Parameter("@ORG_ID", org_id),
                Parameter("@XRAY_ID", xrayId)
            };
            this.ExecuteNonQuery();
        }
        public void UpdateAccession(int xrayreq_id,int exam_id,string accession_no, int last_modified_by, int org_id)
        {
            this.StoredProcedureName = StoredProcedure.Prc_XRAY_UpdateAccessionValue;
            this.ParameterList = new DbParameter[] { 
                Parameter("@XRAYREQ_ID", xrayreq_id),
                Parameter("@EXAM_ID", exam_id),
                Parameter("@ACCESSION_NO",accession_no),
                Parameter("@LAST_MODIFIED_BY", last_modified_by),
                Parameter("@ORG_ID", org_id)
                
            };
            this.ExecuteNonQuery();
        }
    }
}
