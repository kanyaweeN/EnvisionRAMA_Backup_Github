using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class InventoryStockManSelectData : DataAccessBase 
    {
        public InventoryStockManSelectData()
        { 
        }

        public DataSet GetAuthorization()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_AUTHORIZATION_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@PR_ID",0)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetSelectAuthorization(int PR_ID)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_AUTHORIZATION_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@PR_ID",PR_ID)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetPR()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PRDTL_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@PR_ID",0)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetSelectPR(int pr_id)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PR_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@PR_ID",pr_id)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetPR_Detail(int pr_id)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PRDTL_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@PR_ID",pr_id)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetPO_Detail()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PODTL_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@PO_ID",0)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetSelectPO(int po_id)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PODTL_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@PO_ID",po_id)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetPO_Detail(int po_id)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_PODTL_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@PO_ID",po_id)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetRequest()
        {
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITIONDTL_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@REQUISITION_ID",0)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetSelectRequest(int request_id)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@REQUISITION_ID",request_id)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetRequest_Detail(int requisition_id)
        {
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITIONDTL_Select;
            ParameterList = new DbParameter[]{			
                    base.Parameter("@REQUISITION_ID",requisition_id)
			    };
            DataSet ds = ExecuteDataSet();
            return ds;
        }
    }
}
