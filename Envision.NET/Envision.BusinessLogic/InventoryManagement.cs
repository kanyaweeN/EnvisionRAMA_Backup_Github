using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

using Envision.Common;
using Envision.Common.Linq;

using Envision.DataAccess.Select;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;

namespace Envision.BusinessLogic
{
    public enum DataManageType
    {
        Insert, InsertUpdate, Delete
    }
    public enum GuiMode
    {
        Normal, Add, Edit, Remove, Show
    }
    public class InventoryManagement
    {
        private InventoryStock _InventoryStock;
        public InventoryStock InventoryStock
        {
            get { return _InventoryStock; }
            set { _InventoryStock = value; }
        }
        private PR _PR;
        public PR PR
        {
            get { return _PR; }
            set { _PR = value; }
        }
        private PO _PO;
        public PO PO
        {
            get { return _PO; }
            set { _PO = value; }
        }
        private Request _Request;
        public Request Request
        {
            get { return _Request; }
            set { _Request = value; }
        }

        private Authorization _Authorization;
        public Authorization Authorization
        {
            get { return _Authorization; }
            set { _Authorization = value; }
        }
        private ItemTransation _ItemTransation;
        public ItemTransation ItemTransation
        {
            get { return _ItemTransation; }
            set { _ItemTransation = value; }
        }
        public InventoryManagement()
        {
            PO = new PO();
            PR = new PR();
            Request = new Request();
            InventoryStock = new InventoryStock();
            Authorization = new Authorization();
            ItemTransation = new ItemTransation();
        }
    }
    public class InventoryStock
    {
        public InventoryStock()
        {

        }
        public DataSet GetREQMaster(int REQUISITION_ID, int UNIT_ID)
        {
            ProcessGetINVRequisition prc = new ProcessGetINVRequisition();
            return prc.GetREQMaster(REQUISITION_ID, UNIT_ID);
        }
        public DataSet GetREQDetail(int REQUISITION_ID, int UNIT_ID)
        {
            ProcessGetINVRequisition prc = new ProcessGetINVRequisition();
            return prc.GetREQDetail(REQUISITION_ID, UNIT_ID);
        }
        public DataSet GetPOMaster(int PO_ID)
        {
            ProcessGetINVPo prc = new ProcessGetINVPo();
            return prc.GetPOMaster(PO_ID);
        }
        public DataSet GetPODetail(int PO_ID)
        {
            ProcessGetINVPo prc = new ProcessGetINVPo();
            return prc.GetPODetail(PO_ID);
        }
        public DataSet GetItemStockMaster(int UNIT_ID)
        {
            ProcessGetINVItemstock prc = new ProcessGetINVItemstock();
            prc.InvokeStockMaster(UNIT_ID);
            DataSet ds = prc.Result.Copy();
            return ds;
        }
        public DataSet GetItemStockDetail(int UNIT_ID)
        {
            ProcessGetINVItemstock prc = new ProcessGetINVItemstock();
            prc.InvokeStockDetail(UNIT_ID);
            DataSet ds = prc.Result.Copy();
            return ds;
        }
    }
    public class Authorization
    {
        private DataSet _dsInsert;
        public DataSet dsInsert
        {
            get { return _dsInsert; }
            set { _dsInsert = value; }
        }

        public DataSet SelectAll()
        {
            //ProcessGetInvAuthorisation prc = new ProcessGetInvAuthorisation();
            //return prc.SelectMaster();
            DataSet ds = null;
            return ds;
        }
        public DataSet SelectByPR(int PR_ID)
        {
            //_dsInsert = new DataSet();

            //ProcessGetInvAuthorisation prc = new ProcessGetInvAuthorisation();
            //_dsInsert = prc.SelectDetail(PR_ID);
            //return _dsInsert; 
            DataSet ds = null;
            return ds;

        }
        public bool AuthorizationAcceptChange(DataSet _ds)
        {
            _dsInsert = new DataSet();
            _dsInsert = _ds;
            bool retFlag = true;
            bool flag = true;
            DbTransaction tran = null;
            DbConnection con = null;

            try
            {
                DataAccess.DataAccessBase baseData = new Envision.DataAccess.DataAccessBase();
                con = baseData.Connection();
                //DataAccess.DataAccessBase baseData = new Envision.DataAccess.DataAccessBase();
                //con = baseData.Connection();

                con.Open();
                tran = con.BeginTransaction();

                ProcessAddINVAuthorization prcAdd = new ProcessAddINVAuthorization(tran);
                ProcessUpdateINVAuthorization prcUpdate = new ProcessUpdateINVAuthorization(tran);
                ProcessDeleteINVAuthorization prcDel = new ProcessDeleteINVAuthorization(tran);

                foreach (DataRow dr in _dsInsert.Tables[0].Rows)
                {
                    if (dr["PR_QTY"].ToString() == dr["AUTH_QTY"].ToString())
                    {
                        if (dr["Display"].ToString() == dr["AUTH_QTY"].ToString())
                        {
                            prcAdd.INV_AUTHORIZATION.PR_ID = Convert.ToInt32(dr["PR_ID"].ToString());
                            prcAdd.INV_AUTHORIZATION.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                            prcAdd.INV_AUTHORIZATION.EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString());
                            prcAdd.INV_AUTHORIZATION.QTY = Convert.ToInt32(dr["QTY"].ToString());
                            prcAdd.INV_AUTHORIZATION.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
                            prcAdd.INV_AUTHORIZATION.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
                            prcAdd.INV_AUTHORIZATION.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());

                            prcAdd.Invoke();
                        }
                    }
                    else
                    {
                        if (dr["Display"].ToString() == dr["PR_QTY"].ToString())
                        {
                            //delete
                            prcDel.INV_AUTHORIZATION.AUTH_ID = Convert.ToInt32(dr["AUTH_ID"].ToString());
                            prcDel.Invoke();
                        }
                        else
                        {
                            //update
                            prcUpdate.INV_AUTHORIZATION.AUTH_ID = Convert.ToInt32(dr["AUTH_ID"].ToString());
                            prcUpdate.INV_AUTHORIZATION.EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString());
                            prcUpdate.INV_AUTHORIZATION.QTY = Convert.ToInt32(dr["QTY"].ToString());
                            prcUpdate.INV_AUTHORIZATION.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                            prcUpdate.Invoke();
                        }
                    }
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //throw new Exception(ex.Message);
                //retFlag = false;//MessageBox.Show(ex.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                tran.Dispose();
            }
            return retFlag;
        }
    }
    public class PR
    {
        private PR_Data _PR_Data;
        public PR_Data PR_Data
        {
            get { return _PR_Data; }
            set { _PR_Data = value; }
        }
        private DataSet _dsInsert;
        public DataSet PRDTL_InsertUpdate
        {
            get { return _dsInsert; }
            set { _dsInsert = value; }
        }
        private DataSet _dsDelete;
        public DataSet PRDTL_dsDelete
        {
            get { return _dsDelete; }
            set { _dsDelete = value; }
        }
        public PR()
        {
            PR_Data = new PR_Data();
            ProcessGetINVPrdtl prc = new ProcessGetINVPrdtl();
            prc.INV_PRDTL.PR_ID = 0;
            prc.Invoke();
            _dsInsert = new DataSet();
            _dsDelete = new DataSet();
            _dsDelete = prc.Result;
            _dsInsert = prc.Result;
        }
        public void SelectPR(int pr_id)
        {
            int num;
            PR_Data = new PR_Data();

            ProcessGetINVPr prc = new ProcessGetINVPr();
            prc.INV_PR.PR_ID = pr_id;
            prc.Invoke();
            DataSet ds = new DataSet();
            ds = prc.Result;
            if (ds.Tables[0].Rows.Count > 0)
            {
                try { PR_Data.PR_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["PR_ID"].ToString()); }
                catch { }
                PR_Data.PR_UID = ds.Tables[0].Rows[0]["PR_UID"].ToString();
                PR_Data.GENERATE_MODE = Convert.ToChar(ds.Tables[0].Rows[0]["GENERATE_MODE"].ToString());
                try { PR_Data.GENERATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["GENERATED_BY"].ToString()); }
                catch { }
                try { PR_Data.GENERATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["GENERATED_ON"].ToString()); }
                catch { }
                PR_Data.PR_STATUS = Convert.ToChar(ds.Tables[0].Rows[0]["PR_STATUS"].ToString());
                try { PR_Data.ORG_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ORG_ID"].ToString()); }
                catch { }
                try { PR_Data.GENERATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["GENERATED_BY"].ToString()); }
                catch { }
                PR_Data.GENERATED_BY_TEXT = ds.Tables[0].Rows[0]["GENERATED_BY_TEXT"].ToString();
                try { PR_Data.CREATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["CREATED_BY"].ToString()); }
                catch { }
                try { PR_Data.CREATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["CREATED_ON"].ToString()); }
                catch { }
                try { PR_Data.LAST_MODIFIED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["LAST_MODIFIED_BY"].ToString()); }
                catch { }
                try { PR_Data.LAST_MODIFIED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString()); }
                catch { }
                try { PR_Data.LAST_MODIFIED_BY_TEXT = ds.Tables[0].Rows[0]["LAST_MODIFIED_BY_TEXT"].ToString(); }
                catch { }
                try { PR_Data.STATUS = ds.Tables[0].Rows[0]["STATUS"].ToString(); }
                catch { }
            }
            _dsInsert = PR_Data.PR_Detail.Copy();
        }
        public DataSet SelectAll()
        {
            ProcessGetINVPr prc = new ProcessGetINVPr();
            return prc.SelectAll();
        }
        public void dsInsertUpdateAdd(int PR_ID, int ITEM_ID, string ITEM_NAME, decimal QTY, string REMARK, int ORG_ID, int CREATED_BY, int LAST_MODIFIED_BY)
        {
            DataRow dr = _dsInsert.Tables[0].NewRow();
            dr["PR_ID"] = PR_ID;
            dr["ITEM_ID"] = ITEM_ID;
            dr["ITEM_NAME"] = ITEM_NAME;
            dr["QTY"] = QTY;
            dr["REMARK"] = REMARK;
            dr["ORG_ID"] = ORG_ID;
            dr["CREATED_BY"] = CREATED_BY;
            dr["LAST_MODIFIED_BY"] = LAST_MODIFIED_BY;

            _dsInsert.Tables[0].Rows.Add(dr);
            _dsInsert.Tables[0].AcceptChanges();
        }
        public void dsDeleteAdd(DataRow dr)
        {
            try
            {
                _dsDelete.Tables[0].Rows.Add(dr.ItemArray);
                _dsDelete.Tables[0].AcceptChanges();
            }
            catch { }
        }
        public bool prManagement(DataManageType Type)
        {
            bool retFlag = true;
            bool flag = true;
            DbTransaction tran = null;
            DbConnection con = null;
            int RecievePRID;
            //DataTable dtt = dtOrder.Clone();
            try
            {

                DataAccess.DataAccessBase baseData = new Envision.DataAccess.DataAccessBase();
                con = baseData.Connection();

                con.Open();
                tran = con.BeginTransaction();

                ProcessAddINVPr prcAdd = new ProcessAddINVPr(tran);
                ProcessAddINVPrdtl prcDetailAdd = new ProcessAddINVPrdtl(tran);

                ProcessUpdateINVPr prcUpdate = new ProcessUpdateINVPr(tran);
                ProcessUpdateINVPrdtl prcDetailUpdate = new ProcessUpdateINVPrdtl(tran);

                ProcessDeleteINVPr prcDel = new ProcessDeleteINVPr();
                ProcessDeleteINVPrdtl prcDetailDel = new ProcessDeleteINVPrdtl(tran);

                switch (Type)
                {
                    case DataManageType.Insert:
                        prcAdd.INV_PR.PR_UID = PR_Data.PR_UID;
                        prcAdd.INV_PR.ORG_ID = PR_Data.ORG_ID;
                        prcAdd.INV_PR.GENERATED_BY = PR_Data.GENERATED_BY;
                        prcAdd.INV_PR.CREATED_BY = PR_Data.CREATED_BY;
                        prcAdd.INV_PR.LAST_MODIFIED_BY = PR_Data.LAST_MODIFIED_BY;
                        prcAdd.Invoke();

                        RecievePRID = prcAdd.INV_PR.PR_ID;

                        foreach (DataRow dr in _dsInsert.Tables[0].Rows)
                        {
                            prcDetailAdd.INV_PRDTL.PR_ID = prcAdd.INV_PR.PR_ID;
                            prcDetailAdd.INV_PRDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                            prcDetailAdd.INV_PRDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                            prcDetailAdd.INV_PRDTL.REMARK = dr["REMARK"].ToString();
                            prcDetailAdd.INV_PRDTL.ORG_ID = PR_Data.ORG_ID;
                            prcDetailAdd.INV_PRDTL.CREATED_BY = PR_Data.CREATED_BY;
                            prcDetailAdd.INV_PRDTL.LAST_MODIFIED_BY = PR_Data.LAST_MODIFIED_BY;
                            prcDetailAdd.Invoke();

                        }
                        break;
                    case DataManageType.InsertUpdate:
                        #region Update Master
                        prcUpdate.INV_PR.PR_UID = PR_Data.PR_UID;
                        prcUpdate.INV_PR.PR_ID = PR_Data.PR_ID;
                        prcUpdate.INV_PR.LAST_MODIFIED_BY = PR_Data.LAST_MODIFIED_BY;
                        prcUpdate.Invoke();
                        #endregion

                        #region Update Details
                        foreach (DataRow dr in _dsDelete.Tables[0].Rows)
                        {
                            if (dr["CREATED_ON"].ToString() != string.Empty)
                            {
                                prcDetailDel.INV_PRDTL.PR_ID = PR_Data.PR_ID;
                                prcDetailDel.INV_PRDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailDel.Invoke();
                            }
                        }

                        foreach (DataRow dr in _dsInsert.Tables[0].Rows)
                        {
                            if (dr["PR_ID"].ToString() == "0")
                            {
                                prcDetailAdd.INV_PRDTL.PR_ID = PR_Data.PR_ID;
                                prcDetailAdd.INV_PRDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailAdd.INV_PRDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                                prcDetailAdd.INV_PRDTL.REMARK = dr["REMARK"].ToString();
                                prcDetailAdd.INV_PRDTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
                                prcDetailAdd.INV_PRDTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
                                prcDetailAdd.INV_PRDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                                prcDetailAdd.Invoke();
                            }
                            else
                            {
                                prcDetailUpdate.INV_PRDTL.PR_ID = PR_Data.PR_ID;
                                prcDetailUpdate.INV_PRDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailUpdate.INV_PRDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                                prcDetailUpdate.INV_PRDTL.REMARK = dr["REMARK"].ToString();
                                prcDetailUpdate.INV_PRDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                                prcDetailUpdate.Invoke();
                            }
                        }

                        #endregion
                        break;
                    case DataManageType.Delete:
                        prcDel.INV_PR.PR_ID = PR_Data.PR_ID;
                        prcDel.Invoke();
                        break;
                    default:
                        break;
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //throw new Exception(ex.Message);
                //retFlag = false;//MessageBox.Show(ex.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                tran.Dispose();
            }
            return retFlag;
        }
    }
    public class PR_Data : INV_PR
    {
        #region Member
        private DataSet _PR_Detail;
        private string _last_modified_by_text;
        private string _status;
        private string _generate_by_text;
        #endregion
        #region Property
        public DataSet PR_Detail
        {
            get
            {
                _PR_Detail = GetPR_Detail(this.PR_ID);
                return _PR_Detail;
            }
            // set { last_modified_on = value; }
        }
        public string LAST_MODIFIED_BY_TEXT
        {
            get { return _last_modified_by_text; }
            set { _last_modified_by_text = value; }
        }
        public string GENERATED_BY_TEXT
        {
            get { return _generate_by_text; }
            set { _generate_by_text = value; }
        }
        public string STATUS
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion
        private DataSet GetPR_Detail(int pr_id)
        {
            ProcessGetINVPrdtl prc = new ProcessGetINVPrdtl();
            prc.INV_PRDTL.PR_ID = pr_id;
            prc.Invoke();
            return prc.Result;
        }
    }
    public class PO
    {
        private PO_Data _PO_Data;
        public PO_Data PO_Data
        {
            get { return _PO_Data; }
            set { _PO_Data = value; }
        }
        private DataSet _dsInsert;
        public DataSet PODTL_InsertUpdate
        {
            get { return _dsInsert; }
            set { _dsInsert = value; }
        }
        private DataSet _dsDelete;
        public DataSet PODTL_dsDelete
        {
            get { return _dsDelete; }
            set { _dsDelete = value; }
        }
        public PO()
        {
            ProcessGetINVPodtl prc = new ProcessGetINVPodtl();
            prc.INV_PODTL.PO_ID = 0;
            prc.Invoke();
            _dsDelete = prc.Result;
            _dsInsert = prc.Result;
        }
        public void SelectPO(int po_id)
        {
            PO_Data = new PO_Data();

            ProcessGetINVPo prc = new ProcessGetINVPo();
            prc.INV_PO.PO_ID = po_id;
            prc.Invoke();
            DataSet ds = new DataSet();
            ds = prc.Result;
            if (ds.Tables[0].Rows.Count > 0)
            {
                try { PO_Data.PO_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["PO_ID"].ToString()); }
                catch { }
                PO_Data.PO_UID = ds.Tables[0].Rows[0]["PO_UID"].ToString();
                try { PO_Data.PR_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["PR_ID"].ToString()); }
                catch { }
                PO_Data.PR_UID = ds.Tables[0].Rows[0]["PR_UID"].ToString();
                PO_Data.PO_STATUS = Convert.ToChar(ds.Tables[0].Rows[0]["PO_STATUS"].ToString());
                PO_Data.STATUS = ds.Tables[0].Rows[0]["STATUS"].ToString();
                PO_Data.TOC = ds.Tables[0].Rows[0]["TOC"].ToString();
                try { PO_Data.VENDOR_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["VENDOR_ID"].ToString()); }
                catch { }
                PO_Data.VENDOR_NAME = ds.Tables[0].Rows[0]["VENDOR_NAME"].ToString();
                PO_Data.GENERATED_BY_TEXT = ds.Tables[0].Rows[0]["GENERATED_BY_TEXT"].ToString();
                try { PO_Data.GENERATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["GENERATED_ON"].ToString()); }
                catch { }
                PO_Data.LAST_MODIFIED_BY_TEXT = ds.Tables[0].Rows[0]["LAST_MODIFIED_BY_TEXT"].ToString();
                try { PO_Data.LAST_MODIFIED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString()); }
                catch { }
            }
            _dsInsert = PO_Data.PO_Detail.Copy();
        }
        public DataSet SelectForRecieve()
        {
            ProcessGetINVPo prc = new ProcessGetINVPo();
            return prc.SelectForRecieve();
        }
        public DataSet SelectAll()
        {
            ProcessGetINVPo prc = new ProcessGetINVPo();
            return prc.SelectAll();
        }
        public void BuildPO_FromAuthorizer(string PO_UID, int PR_ID, int VENDOR_ID, string TOC, int ORG_ID, int CREATE_BY, int LAST_MODIFIED_BY)
        {
            ProcessAddINVPo BuildPO = new ProcessAddINVPo();
            BuildPO.INV_PO = new INV_PO();
            BuildPO.INV_PO.PO_UID = PO_UID;
            BuildPO.INV_PO.PR_ID = PR_ID;
            BuildPO.INV_PO.VENDOR_ID = VENDOR_ID;
            BuildPO.INV_PO.TOC = TOC;
            BuildPO.INV_PO.ORG_ID = ORG_ID;
            BuildPO.INV_PO.CREATED_BY = CREATE_BY;
            BuildPO.INV_PO.LAST_MODIFIED_BY = LAST_MODIFIED_BY;

            BuildPO.Invoke();
        }
        public void dsInsertUpdateAdd(int PR_ID, int ITEM_ID, string ITEM_NAME, decimal QTY, decimal UNITPRICE, int ORG_ID, int CREATED_BY, int LAST_MODIFIED_BY)
        {
            //PO_ID, 
            //ITEM_ID,
            //ITEM_NAME, 
            //QTY, 
            //PO_ITEM_STATUS, 
            //UNITPRICE, 

            //QTY * INV_PODTL.UNITPRICE AS TOTAL_PRICE
            DataRow dr = _dsInsert.Tables[0].NewRow();
            dr["PO_ID"] = PR_ID;
            dr["ITEM_ID"] = ITEM_ID;
            dr["ITEM_NAME"] = ITEM_NAME;
            dr["QTY"] = QTY;
            dr["UNITPRICE"] = UNITPRICE;
            dr["TOTAL_PRICE"] = QTY * UNITPRICE;
            dr["ORG_ID"] = ORG_ID;
            dr["CREATED_BY"] = CREATED_BY;
            dr["LAST_MODIFIED_BY"] = LAST_MODIFIED_BY;

            _dsInsert.Tables[0].Rows.Add(dr);
            _dsInsert.Tables[0].AcceptChanges();
        }
        public void dsDeleteAdd(DataRow dr)
        {
            try
            {
                _dsDelete.Tables[0].Rows.Add(dr.ItemArray);
            }
            catch { }
        }
        public bool poManagement(DataManageType Type)
        {
            bool retFlag = true;
            bool flag = true;
            DbTransaction tran = null;
            DbConnection con = null;
            int RecievePRID;
            //DataTable dtt = dtOrder.Clone();
            try
            {

                DataAccess.DataAccessBase baseData = new Envision.DataAccess.DataAccessBase();
                con = baseData.Connection();

                con.Open();
                tran = con.BeginTransaction();

                ProcessAddINVPo prcAdd = new ProcessAddINVPo(tran);
                ProcessAddINVPodtl prcDetailAdd = new ProcessAddINVPodtl(tran);

                ProcessUpdateINVPo prcUpdate = new ProcessUpdateINVPo(tran);
                ProcessUpdateINVPodtl prcDetailUpdate = new ProcessUpdateINVPodtl(tran);

                ProcessDeleteINVPo prcDel = new ProcessDeleteINVPo();
                ProcessDeleteINVPodtl prcDetailDel = new ProcessDeleteINVPodtl(tran);

                switch (Type)
                {
                    case DataManageType.Insert:
                        prcAdd.INV_PO.PO_ID = PO_Data.PO_ID;
                        prcAdd.INV_PO.PO_UID = PO_Data.PO_UID;
                        prcAdd.INV_PO.PR_ID = PO_Data.PR_ID;
                        prcAdd.INV_PO.VENDOR_ID = PO_Data.VENDOR_ID;
                        prcAdd.INV_PO.TOC = PO_Data.TOC;
                        prcAdd.INV_PO.ORG_ID = PO_Data.ORG_ID;
                        prcAdd.INV_PO.CREATED_BY = PO_Data.CREATED_BY;
                        prcAdd.INV_PO.LAST_MODIFIED_BY = PO_Data.LAST_MODIFIED_BY;

                        prcAdd.Invoke();

                        foreach (DataRow dr in _dsInsert.Tables[0].Rows)
                        {
                            prcDetailAdd.INV_PODTL.PO_ID = prcAdd.INV_PO.PO_ID;
                            prcDetailAdd.INV_PODTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                            prcDetailAdd.INV_PODTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                            prcDetailAdd.INV_PODTL.UNITPRICE = Convert.ToDecimal(dr["UNITPRICE"].ToString());
                            prcDetailAdd.INV_PODTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
                            prcDetailAdd.INV_PODTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
                            prcDetailAdd.INV_PODTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                            prcDetailAdd.Invoke();

                        }
                        break;
                    case DataManageType.InsertUpdate:
                        #region Update Master
                        prcUpdate.INV_PO = PO_Data;
                        //prcUpdate.INV_PO.PO_UID = PO_Data.PO_UID;
                        //prcUpdate.INV_PO.PO_ID = PO_Data.PO_ID;
                        //prcUpdate.INV_PO.VENDOR_ID = PO_Data.VENDOR_ID;
                        //prcUpdate.INV_PO.TOC = PO_Data.TOC;
                        //prcUpdate.INV_PO.LAST_MODIFIED_BY = PO_Data.LAST_MODIFIED_BY;
                        prcUpdate.Invoke();
                        #endregion

                        #region Update Details
                        foreach (DataRow dr in _dsDelete.Tables[0].Rows)
                        {
                            if (dr["CREATED_ON"].ToString() != string.Empty)
                            {
                                prcDetailDel.INV_PODTL.PO_ID = PO_Data.PO_ID;
                                prcDetailDel.INV_PODTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailDel.Invoke();
                            }
                        }

                        foreach (DataRow dr in _dsInsert.Tables[0].Rows)
                        {
                            if (dr["CREATED_ON"].ToString() == string.Empty)
                            {
                                prcDetailAdd.INV_PODTL.PO_ID = prcAdd.INV_PO.PO_ID;
                                prcDetailAdd.INV_PODTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailAdd.INV_PODTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                                prcDetailAdd.INV_PODTL.UNITPRICE = Convert.ToDecimal(dr["UNITPRICE"].ToString());
                                prcDetailAdd.INV_PODTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
                                prcDetailAdd.INV_PODTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
                                prcDetailAdd.INV_PODTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                                prcDetailAdd.Invoke();
                            }
                            else
                            {
                                prcDetailUpdate.INV_PODTL.PO_ID = PO_Data.PO_ID;
                                prcDetailUpdate.INV_PODTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailUpdate.INV_PODTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                                prcDetailUpdate.INV_PODTL.UNITPRICE = Convert.ToDecimal(dr["UNITPRICE"].ToString());
                                prcDetailUpdate.INV_PODTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                                prcDetailUpdate.Invoke();
                            }
                        }

                        #endregion
                        break;
                    case DataManageType.Delete:
                        prcDel.INV_PO.PO_ID = PO_Data.PO_ID;
                        prcDel.Invoke();
                        break;
                    default:
                        break;
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //throw new Exception(ex.Message);
                //retFlag = false;//MessageBox.Show(ex.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                tran.Dispose();
            }
            return retFlag;
        }
    }
    public class PO_Data : INV_PO
    {
        #region Member
        private string pr_uid;
        private string vendor_name;
        private string _last_modified_by_text;
        private string _status;
        private string _generate_by_text;
        #endregion


        #region Property
        public string PR_UID
        {
            get { return pr_uid; }
            set { pr_uid = value; }
        }
        public string VENDOR_NAME
        {
            get { return vendor_name; }
            set { vendor_name = value; }
        }
        public DataSet PO_Detail
        {
            get { return GetPO_Detail(this.PO_ID); }
            // set { last_modified_on = value; }
        }
        public string LAST_MODIFIED_BY_TEXT
        {
            get { return _last_modified_by_text; }
            set { _last_modified_by_text = value; }
        }
        public string GENERATED_BY_TEXT
        {
            get { return _generate_by_text; }
            set { _generate_by_text = value; }
        }
        public string STATUS
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion

        private DataSet GetPO_Detail(int po_id)
        {
            ProcessGetINVPodtl prc = new ProcessGetINVPodtl();
            prc.INV_PODTL.PO_ID = po_id;
            prc.Invoke();
            return prc.Result;
        }
    }
    public class Request
    {
        private RequestData _Request_Data;
        public RequestData Request_Data
        {
            get { return _Request_Data; }
            set { _Request_Data = value; }
        }
        private DataSet _dsInsert;
        public DataSet RequestDTL_InsertUpdate
        {
            get { return _dsInsert; }
            set { _dsInsert = value; }
        }
        private DataSet _dsDelete;
        public DataSet RequestDTL_dsDelete
        {
            get { return _dsDelete; }
            set { _dsDelete = value; }
        }
        public Request()
        {
            Request_Data = new RequestData();
            ProcessGetINVRequisitiondtl prc = new ProcessGetINVRequisitiondtl();
            prc.INV_REQUISITIONDTL.REQUISITION_ID = 0;
            prc.Invoke();

            DataSet ds = prc.Result;
            _dsDelete = ds;
            _dsInsert = ds;
        }
        public DataSet SelectAll()
        {
            ProcessGetINVRequisition prc = new ProcessGetINVRequisition();
            return prc.SelectAll();
        }
        public DataSet SelectForTranfer()
        {
            ProcessGetINVRequisition prc = new ProcessGetINVRequisition();
            return prc.SelectForTranfer();
        }
        public void SelectRequest(int request_id)
        {
            Request_Data = new RequestData();
            ProcessGetINVRequisition prc = new ProcessGetINVRequisition();
            prc.INV_REQUISITION.REQUISITION_ID = request_id;
            prc.Invoke();
            DataSet ds = new DataSet();
            ds = prc.Result;
            if (ds.Tables[0].Rows.Count > 0)
            {
                try { Request_Data.REQUISITION_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["REQUISITION_ID"].ToString()); }
                catch { }
                Request_Data.REQUISITION_UID = ds.Tables[0].Rows[0]["REQUISITION_UID"].ToString();
                Request_Data.REQUISITION_TYPE = Convert.ToChar(ds.Tables[0].Rows[0]["REQUISITION_TYPE"].ToString());
                Request_Data.GENERATE_MODE = Convert.ToChar(ds.Tables[0].Rows[0]["GENERATE_MODE"].ToString());
                try { Request_Data.FROM_UNIT = Convert.ToInt32(ds.Tables[0].Rows[0]["FROM_UNIT"].ToString()); }
                catch { }
                try { Request_Data.TO_UNIT = Convert.ToInt32(ds.Tables[0].Rows[0]["TO_UNIT"].ToString()); }
                catch { }
                try { Request_Data.GENERATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["GENERATED_BY"].ToString()); }
                catch { }
                Request_Data.GENERATED_BY_TEXT = ds.Tables[0].Rows[0]["GENERATED_BY_TEXT"].ToString();
                Request_Data.LAST_MODIFIED_BY_TEXT = ds.Tables[0].Rows[0]["LAST_MODIFIED_BY_TEXT"].ToString();
                try { Request_Data.GENERATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["GENERATED_ON"].ToString()); }
                catch { }
                Request_Data.STATUS = Convert.ToChar(ds.Tables[0].Rows[0]["STATUS"].ToString());
                try { Request_Data.ORG_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ORG_ID"].ToString()); }
                catch { }
                try { Request_Data.CREATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["CREATED_BY"].ToString()); }
                catch { }
                try { Request_Data.CREATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["CREATED_ON"].ToString()); }
                catch { }
                try { Request_Data.LAST_MODIFIED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["LAST_MODIFIED_BY"].ToString()); }
                catch { }
                try { Request_Data.LAST_MODIFIED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString()); }
                catch { }
                Request_Data.IS_STAT = ds.Tables[0].Rows[0]["IS_STAT"].ToString();

            }
            _dsInsert = Request_Data.RequestDetail;
        }
        public void dsDeleteAdd(DataRow dr)
        {
            try
            {
                _dsDelete.Tables[0].Rows.Add(dr.ItemArray);
                _dsDelete.Tables[0].AcceptChanges();
            }
            catch { }
        }
        public void dsInsertUpdateAdd(int REQUISITION_ID, int ITEM_ID, string ITEM_NAME, decimal QTY, string REMARK, int ORG_ID, int CREATED_BY, int LAST_MODIFIED_BY)
        {
            DataRow dr = _dsInsert.Tables[0].NewRow();
            dr["REQUISITION_ID"] = REQUISITION_ID;
            dr["ITEM_ID"] = ITEM_ID;
            dr["ITEM_NAME"] = ITEM_NAME;
            dr["QTY"] = QTY;
            dr["REMARK"] = REMARK;
            dr["ORG_ID"] = ORG_ID;
            dr["CREATED_BY"] = CREATED_BY;
            dr["LAST_MODIFIED_BY"] = LAST_MODIFIED_BY;

            _dsInsert.Tables[0].Rows.Add(dr);
            _dsInsert.Tables[0].AcceptChanges();
        }

        public bool RequestManagement(DataManageType Type)
        {
            bool retFlag = true;
            bool flag = true;
            DbTransaction tran = null;
            DbConnection con = null;
            int RecieveID;
            //DataTable dtt = dtOrder.Clone();
            try
            {

                DataAccess.DataAccessBase baseData = new Envision.DataAccess.DataAccessBase();
                con = baseData.Connection();

                con.Open();
                tran = con.BeginTransaction();

                ProcessAddINVRequisition prcAdd = new ProcessAddINVRequisition(tran);
                ProcessAddINVRequisitiondtl prcDetailAdd = new ProcessAddINVRequisitiondtl(tran);

                ProcessUpdateINVRequisition prcUpdate = new ProcessUpdateINVRequisition(tran);
                ProcessUpdateINVRequisitiondtl prcDetailUpdate = new ProcessUpdateINVRequisitiondtl(tran);

                ProcessDeleteINVRequisition prcDel = new ProcessDeleteINVRequisition();
                ProcessDeleteINVRequisitiondtl prcDetailDel = new ProcessDeleteINVRequisitiondtl(tran);

                switch (Type)
                {
                    case DataManageType.Insert:
                        prcAdd.INV_REQUISITION.REQUISITION_UID = Request_Data.REQUISITION_UID;
                        prcAdd.INV_REQUISITION.REQUISITION_TYPE = Request_Data.REQUISITION_TYPE;
                        prcAdd.INV_REQUISITION.FROM_UNIT = Request_Data.FROM_UNIT;
                        prcAdd.INV_REQUISITION.TO_UNIT = Request_Data.TO_UNIT;
                        prcAdd.INV_REQUISITION.GENERATED_BY = Request_Data.GENERATED_BY;
                        prcAdd.INV_REQUISITION.ORG_ID = Request_Data.ORG_ID;
                        prcAdd.INV_REQUISITION.CREATED_BY = Request_Data.CREATED_BY;
                        prcAdd.INV_REQUISITION.LAST_MODIFIED_BY = Request_Data.LAST_MODIFIED_BY;

                        prcAdd.Invoke();

                        RecieveID = prcAdd.INV_REQUISITION.REQUISITION_ID;
                        foreach (DataRow dr in _dsInsert.Tables[0].Rows)
                        {
                            prcDetailAdd.INV_REQUISITIONDTL.REQUISITION_ID = prcAdd.INV_REQUISITION.REQUISITION_ID;
                            prcDetailAdd.INV_REQUISITIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                            prcDetailAdd.INV_REQUISITIONDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                            prcDetailAdd.INV_REQUISITIONDTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
                            prcDetailAdd.INV_REQUISITIONDTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
                            prcDetailAdd.INV_REQUISITIONDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                            prcDetailAdd.Invoke();

                        }
                        break;
                    case DataManageType.InsertUpdate:
                        #region Update Master

                        prcUpdate.INV_REQUISITION.REQUISITION_UID = Request_Data.REQUISITION_UID;
                        prcUpdate.INV_REQUISITION.REQUISITION_ID = Request_Data.REQUISITION_ID;
                        prcUpdate.INV_REQUISITION.REQUISITION_TYPE = Request_Data.REQUISITION_TYPE;
                        prcUpdate.INV_REQUISITION.FROM_UNIT = Request_Data.FROM_UNIT;
                        prcUpdate.INV_REQUISITION.TO_UNIT = Request_Data.TO_UNIT;
                        prcUpdate.INV_REQUISITION.LAST_MODIFIED_BY = Request_Data.LAST_MODIFIED_BY;
                        prcUpdate.Invoke();
                        #endregion

                        #region Update Details
                        foreach (DataRow dr in _dsDelete.Tables[0].Rows)
                        {
                            if (dr["REQUISITION_ID"].ToString() == "0")
                            {
                                prcDetailDel.INV_REQUISITIONDTL.REQUISITION_ID = Request_Data.REQUISITION_ID;
                                prcDetailDel.INV_REQUISITIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailDel.Invoke();
                            }
                        }

                        foreach (DataRow dr in _dsInsert.Tables[0].Rows)
                        {
                            if (dr["REQUISITION_ID"].ToString() == "0")
                            {
                                prcDetailAdd.INV_REQUISITIONDTL.REQUISITION_ID = Request_Data.REQUISITION_ID;
                                prcDetailAdd.INV_REQUISITIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailAdd.INV_REQUISITIONDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                                prcDetailAdd.INV_REQUISITIONDTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
                                prcDetailAdd.INV_REQUISITIONDTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
                                prcDetailAdd.INV_REQUISITIONDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                                prcDetailAdd.Invoke();
                            }
                            else
                            {
                                prcDetailUpdate.INV_REQUISITIONDTL.REQUISITION_ID = Request_Data.REQUISITION_ID;
                                prcDetailUpdate.INV_REQUISITIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                                prcDetailUpdate.INV_REQUISITIONDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                                prcDetailUpdate.INV_REQUISITIONDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
                                prcDetailUpdate.Invoke();
                            }
                        }

                        #endregion
                        break;
                    case DataManageType.Delete:
                        prcDel.INV_REQUISITION.REQUISITION_ID = Request_Data.REQUISITION_ID;
                        prcDel.Invoke();
                        break;
                    default:
                        break;
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //throw new Exception(ex.Message);
                //retFlag = false;//MessageBox.Show(ex.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                tran.Dispose();
            }
            return retFlag;
        }
    }
    public class RequestData : INV_REQUISITION
    {
        #region Member
        private string is_stat;
        private string generated_by_text;
        private DataSet request_detail;
        private string _last_modified_by_text;
        private string _rq_status;
        #endregion

        #region Property
        public string IS_STAT
        {
            get { return is_stat; }
            set { is_stat = value; }
        }
        public string GENERATED_BY_TEXT
        {
            get { return generated_by_text; }
            set { generated_by_text = value; }
        }
        public string LAST_MODIFIED_BY_TEXT
        {
            get { return _last_modified_by_text; }
            set { _last_modified_by_text = value; }
        }
        public string RQ_STATUS
        {
            get { return _rq_status; }
            set { _rq_status = value; }
        }
        public DataSet RequestDetail
        {
            get
            {
                request_detail = GetRequest_Detail(this.REQUISITION_ID);
                return request_detail;
            }
        }
        #endregion
        private DataSet GetRequest_Detail(int requisition_id)
        {
            ProcessGetINVRequisitiondtl prc = new ProcessGetINVRequisitiondtl();
            prc.INV_REQUISITIONDTL.REQUISITION_ID = requisition_id;
            prc.Invoke();
            return prc.Result;
        }


    }
    public class ItemTransation
    {
        private DataTable dt_default;
        private DataTable dt;
        private ProcessAddINVTransaction InsertTran;

        private INV_TRANSACTION _invtransaction;
        public INV_TRANSACTION INVTransaction
        {
            get { return _invtransaction; }
            set { _invtransaction = value; }
        }

        public ItemTransation()
        {
            _invtransaction = new INV_TRANSACTION();
            // myArray = new List<INVTransactiondtl>();
            dt_default = new DataTable();
            dt_default.Columns.Add("TXNDTL_ID");
            dt_default.Columns.Add("TXN_ID");
            dt_default.Columns.Add("ITEM_ID");
            dt_default.Columns.Add("TXN_UNIT");
            dt_default.Columns.Add("BATCH");
            dt_default.Columns.Add("EXPIRY_DT");
            dt_default.Columns.Add("QTY");
            dt_default.Columns.Add("PRICE");
            dt_default.Columns.Add("COMMENTS");
            dt_default.Columns.Add("ORG_ID");
            dt_default.Columns.Add("ITEMSTOCK_ID");
            dt_default.Columns.Add("REF_ITEM_ID");

            dt = dt_default.Copy();
        }
        public bool InsertTransaction()
        {
            DbTransaction tran = null;
            DbConnection con = null;
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {

                    DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
                    con = db.Connection();
                    con.Open();
                    tran = con.BeginTransaction();

                    ProcessAddINVTransaction addTran = new ProcessAddINVTransaction();
                    addTran.Transaction = tran;
                    addTran.INV_TRANSACTION = _invtransaction;
                    addTran.Invoke();

                    ProcessAddINVTransactiondtl addTrandtl = new ProcessAddINVTransactiondtl();
                    addTrandtl.Transaction = tran;

                    foreach (DataRow dr in dt.Rows)
                    {
                        addTrandtl.INV_TRANSACTIONDTL.TXN_ID = addTran.INV_TRANSACTION.TXN_ID;
                        addTrandtl.INV_TRANSACTIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
                        addTrandtl.INV_TRANSACTIONDTL.REF_ITEM_ID = Convert.ToInt32(dr["REF_ITEM_ID"].ToString());
                        addTrandtl.INV_TRANSACTIONDTL.TXN_UNIT = Convert.ToInt32(dr["TXN_UNIT"].ToString());
                        addTrandtl.INV_TRANSACTIONDTL.BATCH = Convert.ToInt32(dr["BATCH"].ToString());
                        addTrandtl.INV_TRANSACTIONDTL.EXPIRY_DT = Convert.ToDateTime(dr["EXPIRY_DT"].ToString());
                        addTrandtl.INV_TRANSACTIONDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
                        addTrandtl.INV_TRANSACTIONDTL.PRICE = Convert.ToDecimal(dr["PRICE"].ToString());
                        addTrandtl.INV_TRANSACTIONDTL.COMMENTS = dr["COMMENTS"].ToString();
                        addTrandtl.INV_TRANSACTIONDTL.ORG_ID = addTran.INV_TRANSACTION.ORG_ID;
                        addTrandtl.INV_TRANSACTIONDTL.CREATED_BY = addTran.INV_TRANSACTION.CREATED_BY;
                        addTrandtl.INV_TRANSACTIONDTL.LAST_MODIFIED_BY = addTran.INV_TRANSACTION.LAST_MODIFIED_BY;
                        addTrandtl.INV_TRANSACTIONDTL.ITEMSTOCK_ID = Convert.ToInt32(dr["ITEMSTOCK_ID"].ToString());
                        addTrandtl.Invoke();
                    }
                    tran.Commit();
                    dt = dt_default.Copy();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    dt = dt_default.Copy();
                    return false;
                }
            }
            else
            {
                dt = dt_default.Copy();
                return false;
            }
            dt = dt_default.Copy();
            return false;
        }
        public bool InsertTransactionPOCancel()
        {
            ProcessAddINVTransaction add = new ProcessAddINVTransaction();
            if (add.InvokePOCancel(_invtransaction.PO_ID.Value, _invtransaction.CREATED_BY.Value))
            {
                return true;
            }
            return false;
        }
        public bool InsertTransactionRQCancel()
        {
            ProcessAddINVTransaction add = new ProcessAddINVTransaction();
            if (add.InvokeRQCancel(_invtransaction.REQUISITION_ID.Value, _invtransaction.CREATED_BY.Value))
            {
                return true;
            }
            return false;
        }
        public void AddTransactionDtl(int ITEM_ID, int REF_ITEM_ID, int TXN_UNIT, string BATCH, DateTime EXPIRY_DT, double QTY, double PRICE, string Comments, int ITEMSTOCK_ID)
        {
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = 0;
            dr[2] = ITEM_ID;
            dr[3] = TXN_UNIT;
            dr[4] = BATCH;
            dr[5] = EXPIRY_DT;
            dr[6] = QTY;
            dr[7] = PRICE;
            dr[8] = Comments;
            dr[9] = _invtransaction.ORG_ID;
            dr[10] = ITEMSTOCK_ID;
            dr[11] = REF_ITEM_ID;
            dt.Rows.Add(dr);
        }
    }
}
