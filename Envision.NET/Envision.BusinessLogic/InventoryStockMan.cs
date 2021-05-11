using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.DataAccess.Select;
using Envision.Common;
using System.Data.Common;

namespace Envision.BusinessLogic
{
    public enum SqlType
    {
        Insert, Update, Delete
    }
    public class InventoryStockMan
    {
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
        public InventoryStockMan()
        {
           PO = new PO();
           PR = new PR();
           Request = new Request();
           Authorization = new Authorization();
        }
    }
    //public class Authorization
    //{
    //    private DataSet _dsInsert;
    //    public DataSet dsInsert
    //    {
    //        get { return _dsInsert; }
    //        set { _dsInsert = value; }
    //    }

    //    public Authorization()
    //    {
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Prc_INV_AUTHORIZATION_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //    new SqlParameter("@PR_ID",0)
    //        //    };
    //        //DataSet ds = dbhelper.Run(base.ConnectionString, parameters);
    //        //_dsInsert = ds;
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        _dsInsert = inv.GetAuthorization();
    //    }
    //    public void SelectAuthorization(int PR_ID)
    //    {
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Prc_INV_AUTHORIZATION_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //    new SqlParameter("@PR_ID",PR_ID)
    //        //    };
    //        //DataSet ds = dbhelper.Run(base.ConnectionString, parameters);
    //        //_dsInsert = ds;
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        _dsInsert = inv.GetSelectAuthorization(PR_ID);
    //    }
    //    public bool AuthorizationAcceptChange()
    //    {
    //        bool retFlag = true;
    //        bool flag = true;
    //        //SqlTransaction tran = null;
    //        //SqlConnection con = null;
    //        DbTransaction tran = null;
    //        DbConnection con = null;
    //        int RecieveID;
    //        //DataTable dtt = dtOrder.Clone();
    //        try
    //        {

    //            //DataAccess.DataAccessBase baseData = new Envision.DataAccess.DataAccessBase();
    //            //con = baseData.GetSQLConnection();

    //            //con.Open();
    //            //tran = con.BeginTransaction();

    //            DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
    //            con = db.Connection();
    //            con.Open();
    //            tran = con.BeginTransaction();

    //            ProcessAddINVAuthorization prcAdd = new ProcessAddINVAuthorization(tran);
    //            ProcessUpdateINVAuthorization prcUpdate = new ProcessUpdateINVAuthorization(tran);
    //            ProcessDeleteINVAuthorization prcDel = new ProcessDeleteINVAuthorization(tran);

    //            foreach (DataRow dr in _dsInsert.Tables[0].Rows)
    //            {
    //                if (dr["PR_QTY"].ToString() == dr["AUTH_QTY"].ToString())
    //                {
    //                    if (dr["Display"].ToString() == dr["AUTH_QTY"].ToString())
    //                    {
    //                        prcAdd.INV_AUTHORIZATION.PR_ID = Convert.ToInt32(dr["PR_ID"].ToString());
    //                        prcAdd.INV_AUTHORIZATION.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                        prcAdd.INV_AUTHORIZATION.EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString());
    //                        prcAdd.INV_AUTHORIZATION.QTY = Convert.ToInt32(dr["QTY"].ToString());
    //                        prcAdd.INV_AUTHORIZATION.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
    //                        prcAdd.INV_AUTHORIZATION.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
    //                        prcAdd.INV_AUTHORIZATION.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());

    //                        prcAdd.Invoke();
    //                    }
    //                }
    //                else
    //                {
    //                    if (dr["Display"].ToString() == dr["PR_QTY"].ToString())
    //                    {
    //                        //delete
    //                        prcDel.INV_AUTHORIZATION.AUTH_ID = Convert.ToInt32(dr["AUTH_ID"].ToString());
    //                        prcDel.Invoke();
    //                    }
    //                    else
    //                    {
    //                        //update
    //                        prcUpdate.INV_AUTHORIZATION.AUTH_ID = Convert.ToInt32(dr["AUTH_ID"].ToString());
    //                        prcUpdate.INV_AUTHORIZATION.EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString());
    //                        prcUpdate.INV_AUTHORIZATION.QTY = Convert.ToInt32(dr["QTY"].ToString());
    //                        prcUpdate.INV_AUTHORIZATION.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                        prcUpdate.Invoke();
    //                    }
    //                }
    //            }
    //            tran.Commit();
    //        }
    //        catch (Exception ex)
    //        {
    //            tran.Rollback();
    //            //throw new Exception(ex.Message);
    //            //retFlag = false;//MessageBox.Show(ex.Message);

    //        }
    //        finally
    //        {
    //            if (con.State == ConnectionState.Open)
    //                con.Close();
    //            tran.Dispose();
    //        }
    //        return retFlag;
    //    }
    //}
    //public class PR
    //{
    //    private PR_Data _PR_Data;
    //    public PR_Data PR_Data
    //    {
    //        get { return _PR_Data; }
    //        set { _PR_Data = value; }
    //    }
    //    private DataSet _dsInsert;
    //    public DataSet dsInsert
    //    {
    //        get { return _dsInsert; }
    //        set { _dsInsert = value; }
    //    }
    //    private DataSet _dsDelete;
    //    public DataSet dsDelete
    //    {
    //        get { return _dsDelete; }
    //        set { _dsDelete = value; }
    //    }
    //    public PR()
    //    {
    //        PR_Data = new PR_Data();
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Prc_INV_PRDTL_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //    new SqlParameter("@PR_ID",0)
    //        //    };
    //        //DataSet ds = dbhelper.Run(base.ConnectionString, parameters);
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetPR();
    //        _dsDelete = ds;
    //        _dsInsert = ds;
    //    }
    //    public void SelectPR(int pr_id)
    //    {
    //        int num;
    //        PR_Data = new PR_Data();
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Prc_INV_PR_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //new SqlParameter("@PR_ID",pr_id)
    //        //};
    //        //DataSet ds = new DataSet();
    //        //ds = dbhelper.Run(base.ConnectionString, parameters);
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetSelectPR(pr_id);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            try { PR_Data.PR_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["PR_ID"].ToString()); }
    //            catch {}
    //            PR_Data.PR_UID = ds.Tables[0].Rows[0]["PR_UID"].ToString();
    //            PR_Data.GENERATE_MODE = ds.Tables[0].Rows[0]["GENERATE_MODE"].ToString();
    //            try { PR_Data.GENERATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["GENERATED_BY"].ToString()); }
    //            catch { }
    //            try { PR_Data.GENERATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["GENERATED_ON"].ToString()); }
    //            catch {}
    //            PR_Data.PR_STATUS = ds.Tables[0].Rows[0]["PR_STATUS"].ToString();
    //            try { PR_Data.ORG_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ORG_ID"].ToString()); }
    //            catch {}
    //            try { PR_Data.GENERATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["GENERATED_BY"].ToString()); }
    //            catch {}
    //            PR_Data.GENERATED_BY_TEXT = ds.Tables[0].Rows[0]["GENERATED_BY_TEXT"].ToString();
    //            try { PR_Data.CREATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["CREATED_BY"].ToString()); }
    //            catch {}
    //            try { PR_Data.CREATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["CREATED_ON"].ToString()); }
    //            catch {}
    //            try { PR_Data.LAST_MODIFIED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["LAST_MODIFIED_BY"].ToString()); }
    //            catch {}
    //            try { PR_Data.LAST_MODIFIED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString()); }
    //            catch {}
    //            _dsInsert = PR_Data.PR_Detail;
    //            //prdata.pr_detail = GetPR_Detail(this.PR_ID);             
    //        }
    //    }
    //    public void dsInsertAdd(int PR_ID, int ITEM_ID, decimal QTY, int ORG_ID, int CREATED_BY, int LAST_MODIFIED_BY)
    //    {
    //        DataRow dr = _dsInsert.Tables[0].NewRow();
    //        dr["PR_ID"] = PR_ID;
    //        dr["ITEM_ID"] = ITEM_ID;
    //        dr["QTY"] = QTY;
    //        dr["ORG_ID"] = ORG_ID;
    //        dr["CREATED_BY"] = CREATED_BY;
    //        dr["LAST_MODIFIED_BY"] = LAST_MODIFIED_BY;

    //        _dsInsert.Tables[0].Rows.Add(dr);
    //    }
    //    public void dsDeleteAdd(DataRow dr)
    //    {
    //        try
    //        {
    //            _dsDelete.Tables[0].Rows.Add(dr.ItemArray);
    //        }
    //        catch { }
    //    }
    //    public bool prManagement(SqlType Type)
    //    {
    //        bool retFlag = true;
    //        bool flag = true;
    //        //SqlTransaction tran = null;
    //        //SqlConnection con = null;
    //        DbTransaction tran = null;
    //        DbConnection con = null;
    //        int RecievePRID;
    //        //DataTable dtt = dtOrder.Clone();
    //        try
    //        {

    //            //DataAccess.DataAccessBase baseData = new RIS.DataAccess.DataAccessBase();
    //            //con = baseData.GetSQLConnection();
    //            //con.Open();
    //            //tran = con.BeginTransaction();

    //            DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
    //            con = db.Connection();
    //            con.Open();
    //            tran = con.BeginTransaction();

    //            ProcessAddINVPr prcAdd = new ProcessAddINVPr(tran);
    //            ProcessAddINVPrdtl prcDetailAdd = new ProcessAddINVPrdtl(tran);

    //            ProcessUpdateINVPr prcUpdate = new ProcessUpdateINVPr(tran);
    //            ProcessUpdateINVPrdtl prcDetailUpdate = new ProcessUpdateINVPrdtl(tran);

    //            ProcessDeleteINVPr prcDel = new ProcessDeleteINVPr();
    //            ProcessDeleteINVPrdtl prcDetailDel = new ProcessDeleteINVPrdtl(tran);

    //            switch (Type)
    //            {
    //                case SqlType.Insert:
    //                    prcAdd.INV_PR.PR_UID = PR_Data.PR_UID;
    //                    prcAdd.INV_PR.ORG_ID = PR_Data.ORG_ID;
    //                    prcAdd.INV_PR.GENERATED_BY = PR_Data.GENERATED_BY;
    //                    prcAdd.INV_PR.CREATED_BY = PR_Data.CREATED_BY;
    //                    prcAdd.INV_PR.LAST_MODIFIED_BY = PR_Data.LAST_MODIFIED_BY;
    //                    prcAdd.Invoke();

    //                    RecievePRID = prcAdd.INV_PR.PR_ID;

    //                    foreach (DataRow dr in _dsInsert.Tables[0].Rows)
    //                    {
    //                        prcDetailAdd.INV_PRDTL.PR_ID = prcAdd.INV_PR.PR_ID;
    //                        prcDetailAdd.INV_PRDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                        prcDetailAdd.INV_PRDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                        prcDetailAdd.INV_PRDTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
    //                        prcDetailAdd.INV_PRDTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
    //                        prcDetailAdd.INV_PRDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                        prcDetailAdd.Invoke();

    //                    }
    //                    break;
    //                case SqlType.Update:
    //                    #region Update Master
    //                    prcUpdate.INV_PR.PR_UID = PR_Data.PR_UID;
    //                    prcUpdate.INV_PR.PR_ID = PR_Data.PR_ID;
    //                    prcUpdate.INV_PR.LAST_MODIFIED_BY = PR_Data.LAST_MODIFIED_BY;
    //                    prcUpdate.Invoke();
    //                    #endregion

    //                    #region Update Details
    //                    foreach (DataRow dr in _dsInsert.Tables[0].Rows)
    //                    {
    //                        if (dr["CREATED_ON"].ToString() == string.Empty)
    //                        {
    //                            prcDetailAdd.INV_PRDTL.PR_ID = PR_Data.PR_ID;
    //                            prcDetailAdd.INV_PRDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailAdd.INV_PRDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                            prcDetailAdd.INV_PRDTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
    //                            prcDetailAdd.INV_PRDTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
    //                            prcDetailAdd.INV_PRDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                            prcDetailAdd.Invoke();
    //                        }
    //                        else
    //                        {
    //                            prcDetailUpdate.INV_PRDTL.PR_ID = PR_Data.PR_ID;
    //                            prcDetailUpdate.INV_PRDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailUpdate.INV_PRDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                            prcDetailUpdate.INV_PRDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                            prcDetailUpdate.Invoke();
    //                        }
    //                    }
    //                    foreach (DataRow dr in _dsDelete.Tables[0].Rows)
    //                    {
    //                        if (dr["CREATED_ON"].ToString() != string.Empty)
    //                        {
    //                            prcDetailDel.INV_PRDTL.PR_ID = PR_Data.PR_ID;
    //                            prcDetailDel.INV_PRDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailDel.Invoke();
    //                        }
    //                    }
    //                    #endregion
    //                    break;
    //                case SqlType.Delete:
    //                    prcDel.INV_PR.PR_ID = PR_Data.PR_ID;
    //                    prcDel.Invoke();
    //                    break;
    //                default:
    //                    break;
    //            }
    //            tran.Commit();
    //        }
    //        catch (Exception ex)
    //        {
    //            tran.Rollback();
    //            //throw new Exception(ex.Message);
    //            //retFlag = false;//MessageBox.Show(ex.Message);

    //        }
    //        finally
    //        {
    //            if (con.State == ConnectionState.Open)
    //                con.Close();
    //            tran.Dispose();
    //        }
    //        return retFlag;
    //    }
    //}
    //public class PR_Data
    //{
    //    #region Member
    //    private int pr_id;
    //    private string pr_uid;
    //    private string generate_mode;
    //    private int generated_by;
    //    private string generated_by_text;
    //    private DateTime generated_on;
    //    private string pr_status;
    //    private int org_id;
    //    private int created_by;
    //    private DateTime created_on;
    //    private int last_modified_by;
    //    private DateTime last_modified_on;
    //    private DataSet pr_detail;
    //    #endregion
    //    #region Property
    //    public int PR_ID
    //    {
    //        get { return pr_id; }
    //        set { pr_id = value; pr_detail = GetPR_Detail(pr_id); }

    //    }
    //    public string PR_UID
    //    {
    //        get { return pr_uid; }
    //        set { pr_uid = value; }
    //    }
    //    public string GENERATE_MODE
    //    {
    //        get { return generate_mode; }
    //        set { generate_mode = value; }
    //    }
    //    public int GENERATED_BY
    //    {
    //        get { return generated_by; }
    //        set { generated_by = value; }
    //    }
    //    public string GENERATED_BY_TEXT
    //    {
    //        get { return generated_by_text; }
    //        set { generated_by_text = value; }
    //    }
    //    public DateTime GENERATED_ON
    //    {
    //        get { return generated_on; }
    //        set { generated_on = value; }
    //    }
    //    public string PR_STATUS
    //    {
    //        get { return pr_status; }
    //        set { pr_status = value; }
    //    }
    //    public int ORG_ID
    //    {
    //        get { return org_id; }
    //        set { org_id = value; }
    //    }
    //    public int CREATED_BY
    //    {
    //        get { return created_by; }
    //        set { created_by = value; }
    //    }
    //    public DateTime CREATED_ON
    //    {
    //        get { return created_on; }
    //        set { created_on = value; }
    //    }
    //    public int LAST_MODIFIED_BY
    //    {
    //        get { return last_modified_by; }
    //        set { last_modified_by = value; }
    //    }
    //    public DateTime LAST_MODIFIED_ON
    //    {
    //        get { return last_modified_on; }
    //        set { last_modified_on = value; }
    //    }
    //    public DataSet PR_Detail
    //    {
    //        get { return pr_detail; }
    //        // set { last_modified_on = value; }
    //    }
    //    #endregion
    //    private DataSet GetPR_Detail(int pr_id)
    //    {
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_INV_PRDTL_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //    new SqlParameter("@PR_ID",pr_id)
    //        //    };
    //        //DataSet ds_detail = dbhelper.Run(base.ConnectionString, parameters);
    //        //return ds_detail;
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetPR_Detail(pr_id);
    //        return ds;
    //    }
    //}
    //public class PO
    //{
    //    private PO_Data _PO_Data;
    //    public PO_Data PO_Data
    //    {
    //        get { return _PO_Data; }
    //        set { _PO_Data = value; }
    //    }
    //    private DataSet _dsInsert;
    //    public DataSet dsInsert
    //    {
    //        get { return _dsInsert; }
    //        set { _dsInsert = value; }
    //    }
    //    private DataSet _dsDelete;
    //    public DataSet dsDelete
    //    {
    //        get { return _dsDelete; }
    //        set { _dsDelete = value; }
    //    }
    //    public PO()
    //    {
    //        PO_Data = new PO_Data();
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_INV_PODTL_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //    new SqlParameter("@PO_ID",0)
    //        //    };
    //        //DataSet ds = dbhelper.Run(base.ConnectionString, parameters);

    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetPO_Detail();
    //        _dsDelete = ds;
    //        _dsInsert = ds;
    //    }
    //    public void SelectPO(int po_id)
    //    {
    //        PO_Data = new PO_Data();
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_INV_PO_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //new SqlParameter("@PO_ID",po_id)
    //        //};
    //        //DataSet ds = new DataSet();
    //        //ds = dbhelper.Run(base.ConnectionString, parameters);
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetSelectPO(po_id);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            try { PO_Data.PO_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["PO_ID"].ToString()); }
    //            catch { }
    //            PO_Data.PO_UID = ds.Tables[0].Rows[0]["PO_UID"].ToString();
    //            try { PO_Data.PR_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["PR_ID"].ToString()); }
    //            catch { }
    //            PO_Data.PR_UID = ds.Tables[0].Rows[0]["PR_UID"].ToString();
    //            PO_Data.PO_STATUS = ds.Tables[0].Rows[0]["PO_STATUS"].ToString();
    //            PO_Data.TOC = ds.Tables[0].Rows[0]["TOC"].ToString();
    //            try { PO_Data.VENDOR_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["VENDOR_ID"].ToString()); }
    //            catch { }
    //            PO_Data.VENDOR_NAME = ds.Tables[0].Rows[0]["VENDOR_NAME"].ToString();

    //            _dsInsert = PO_Data.PO_Detail;
    //            //prdata.pr_detail = GetPR_Detail(this.PR_ID);             
    //        }
    //    }
    //    public void BuildPO_FromAuthorizer(string PO_UID, int PR_ID, int VENDOR_ID, string TOC, int ORG_ID, int CREATE_BY, int LAST_MODIFIED_BY)
    //    {
    //        ProcessAddINVPo BuildPO = new ProcessAddINVPo();
    //        BuildPO.INV_PO = new INV_PO();
    //        BuildPO.INV_PO.PO_UID = PO_UID;
    //        BuildPO.INV_PO.PR_ID = PR_ID;
    //        BuildPO.INV_PO.VENDOR_ID = VENDOR_ID;
    //        BuildPO.INV_PO.TOC = TOC;
    //        BuildPO.INV_PO.ORG_ID = ORG_ID;
    //        BuildPO.INV_PO.CREATED_BY = CREATE_BY;
    //        BuildPO.INV_PO.LAST_MODIFIED_BY = LAST_MODIFIED_BY;

    //        BuildPO.Invoke();
    //    }
    //    public void dsDeleteAdd(DataRow dr)
    //    {
    //        try
    //        {
    //            _dsDelete.Tables[0].Rows.Add(dr.ItemArray);
    //        }
    //        catch { }
    //    }
    //    public bool poManagement(SqlType Type)
    //    {
    //        bool retFlag = true;
    //        bool flag = true;
    //        //SqlTransaction tran = null;
    //        //SqlConnection con = null;
    //        DbTransaction tran = null;
    //        DbConnection con = null;
    //        int RecievePRID;
    //        //DataTable dtt = dtOrder.Clone();
    //        try
    //        {

    //            //DataAccess.DataAccessBase baseData = new RIS.DataAccess.DataAccessBase();
    //            //con = baseData.GetSQLConnection();
    //            //con.Open();
    //            //tran = con.BeginTransaction();

    //            DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
    //            con = db.Connection();
    //            con.Open();
    //            tran = con.BeginTransaction();

    //            ProcessAddINVPo prcAdd = new ProcessAddINVPo(tran);
    //            ProcessAddINVPodtl prcDetailAdd = new ProcessAddINVPodtl(tran);

    //            ProcessUpdateINVPo prcUpdate = new ProcessUpdateINVPo(tran);
    //            ProcessUpdateINVPodtl prcDetailUpdate = new ProcessUpdateINVPodtl(tran);

    //            ProcessDeleteINVPo prcDel = new ProcessDeleteINVPo();
    //            ProcessDeleteINVPodtl prcDetailDel = new ProcessDeleteINVPodtl(tran);

    //            switch (Type)
    //            {
    //                case SqlType.Insert:
    //                    prcAdd.INV_PO.PO_ID = PO_Data.PO_ID;
    //                    prcAdd.INV_PO.PO_UID = PO_Data.PO_UID;
    //                    prcAdd.INV_PO.PR_ID = PO_Data.PR_ID;
    //                    prcAdd.INV_PO.VENDOR_ID = PO_Data.VENDOR_ID;
    //                    prcAdd.INV_PO.TOC = PO_Data.TOC;
    //                    prcAdd.INV_PO.ORG_ID = PO_Data.ORG_ID;
    //                    prcAdd.INV_PO.CREATED_BY = PO_Data.CREATED_BY;
    //                    prcAdd.INV_PO.LAST_MODIFIED_BY = PO_Data.LAST_MODIFIED_BY;

    //                    prcAdd.Invoke();

    //                    foreach (DataRow dr in _dsInsert.Tables[0].Rows)
    //                    {
    //                        prcDetailAdd.INV_PODTL.PO_ID = prcAdd.INV_PO.PO_ID;
    //                        prcDetailAdd.INV_PODTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                        prcDetailAdd.INV_PODTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                        prcDetailAdd.INV_PODTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
    //                        prcDetailAdd.INV_PODTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
    //                        prcDetailAdd.INV_PODTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                        prcDetailAdd.Invoke();

    //                    }
    //                    break;
    //                case SqlType.Update:
    //                    #region Update Master
    //                    prcUpdate.INV_PO.PO_UID = PO_Data.PO_UID;
    //                    prcUpdate.INV_PO.PO_ID = PO_Data.PO_ID;
    //                    prcUpdate.INV_PO.VENDOR_ID = PO_Data.VENDOR_ID;
    //                    prcUpdate.INV_PO.TOC = PO_Data.TOC;
    //                    prcUpdate.INV_PO.LAST_MODIFIED_BY = PO_Data.LAST_MODIFIED_BY;
    //                    prcUpdate.Invoke();
    //                    #endregion

    //                    #region Update Details
    //                    foreach (DataRow dr in _dsInsert.Tables[0].Rows)
    //                    {
    //                        if (dr["CREATED_ON"].ToString() == string.Empty)
    //                        {
    //                            prcDetailAdd.INV_PODTL.PO_ID = prcAdd.INV_PO.PO_ID;
    //                            prcDetailAdd.INV_PODTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailAdd.INV_PODTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                            prcDetailAdd.INV_PODTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
    //                            prcDetailAdd.INV_PODTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
    //                            prcDetailAdd.INV_PODTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                            prcDetailAdd.Invoke();
    //                        }
    //                        else
    //                        {
    //                            prcDetailUpdate.INV_PODTL.PO_ID = PO_Data.PO_ID;
    //                            prcDetailUpdate.INV_PODTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailUpdate.INV_PODTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                            prcDetailUpdate.INV_PODTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                            prcDetailUpdate.Invoke();
    //                        }
    //                    }
    //                    foreach (DataRow dr in _dsDelete.Tables[0].Rows)
    //                    {
    //                        if (dr["CREATED_ON"].ToString() != string.Empty)
    //                        {
    //                            prcDetailDel.INV_PODTL.PO_ID = PO_Data.PO_ID;
    //                            prcDetailDel.INV_PODTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailDel.Invoke();
    //                        }
    //                    }
    //                    #endregion
    //                    break;
    //                case SqlType.Delete:
    //                    prcDel.INV_PO.PO_ID = PO_Data.PO_ID;
    //                    prcDel.Invoke();
    //                    break;
    //                default:
    //                    break;
    //            }
    //            tran.Commit();
    //        }
    //        catch (Exception ex)
    //        {
    //            tran.Rollback();
    //            //throw new Exception(ex.Message);
    //            //retFlag = false;//MessageBox.Show(ex.Message);

    //        }
    //        finally
    //        {
    //            if (con.State == ConnectionState.Open)
    //                con.Close();
    //            tran.Dispose();
    //        }
    //        return retFlag;
    //    }
    //}
    //public class PO_Data
    //{
    //    #region Member
    //    private int po_id;
    //    private string po_uid;
    //    private int pr_id;
    //    private DateTime generated_on;
    //    private int vendor_id;
    //    private string toc;
    //    private string po_status;
    //    private int org_id;
    //    private int created_by;
    //    private DateTime created_on;
    //    private int last_modified_by;
    //    private DateTime last_modified_on;
    //    private DataSet po_detail;
    //    private string pr_uid;
    //    private string vendor_name;
    //    #endregion

    //    #region Property
    //    public string PR_UID
    //    {
    //        get { return pr_uid; }
    //        set { pr_uid = value; }
    //    }
    //    public string VENDOR_NAME
    //    {
    //        get { return vendor_name; }
    //        set { vendor_name = value; }
    //    }
    //    public DataSet PO_Detail
    //    {
    //        get { return po_detail; }
    //        // set { last_modified_on = value; }
    //    }
    //    public int PO_ID
    //    {
    //        get { return po_id; }
    //        set { po_id = value; po_detail = GetPO_Detail(po_id); }
    //    }
    //    public string PO_UID
    //    {
    //        get { return po_uid; }
    //        set { po_uid = value; }
    //    }
    //    public int PR_ID
    //    {
    //        get { return pr_id; }
    //        set { pr_id = value; }
    //    }
    //    public DateTime GENERATED_ON
    //    {
    //        get { return generated_on; }
    //        set { generated_on = value; }
    //    }
    //    public int VENDOR_ID
    //    {
    //        get { return vendor_id; }
    //        set { vendor_id = value; }
    //    }
    //    public string TOC
    //    {
    //        get { return toc; }
    //        set { toc = value; }
    //    }
    //    public string PO_STATUS
    //    {
    //        get { return po_status; }
    //        set { po_status = value; }
    //    }
    //    public int ORG_ID
    //    {
    //        get { return org_id; }
    //        set { org_id = value; }
    //    }
    //    public int CREATED_BY
    //    {
    //        get { return created_by; }
    //        set { created_by = value; }
    //    }
    //    public DateTime CREATED_ON
    //    {
    //        get { return created_on; }
    //        set { created_on = value; }
    //    }
    //    public int LAST_MODIFIED_BY
    //    {
    //        get { return last_modified_by; }
    //        set { last_modified_by = value; }
    //    }
    //    public DateTime LAST_MODIFIED_ON
    //    {
    //        get { return last_modified_on; }
    //        set { last_modified_on = value; }
    //    }
    //    #endregion 
        
    //    private DataSet GetPO_Detail(int po_id)
    //    {
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_INV_PODTL_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //    new SqlParameter("@PO_ID",po_id)
    //        //    };
    //        //DataSet ds_detail = dbhelper.Run(base.ConnectionString, parameters);
    //        //return ds_detail;
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetPO_Detail(po_id);
    //        return ds;
    //    }
    //}
    //public class Request
    //{
    //    private RequestData _Request_Data;
    //    public RequestData Request_Data
    //    {
    //        get { return _Request_Data; }
    //        set { _Request_Data = value; }
    //    }
    //    private DataSet _dsInsert;
    //    public DataSet dsInsert
    //    {
    //        get { return _dsInsert; }
    //        set { _dsInsert = value; }
    //    }
    //    private DataSet _dsDelete;
    //    public DataSet dsDelete
    //    {
    //        get { return _dsDelete; }
    //        set { _dsDelete = value; }
    //    }
    //    public Request()
    //    {
    //        Request_Data = new RequestData();
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_INV_REQUISITIONDTL_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //    new SqlParameter("@REQUISITION_ID",0)
    //        //    };
    //        //DataSet ds = dbhelper.Run(base.ConnectionString, parameters);
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetRequest();
    //        _dsDelete = ds;
    //        _dsInsert = ds;
    //    }
    //    public void SelectRequest(int request_id)
    //    {
    //        Request_Data = new RequestData();
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_INV_REQUISITION_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //new SqlParameter("@REQUISITION_ID",request_id)
    //        //};
    //        //DataSet ds = new DataSet();
    //        //ds = dbhelper.Run(base.ConnectionString, parameters);
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetSelectRequest(request_id);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            try { Request_Data.REQUISITION_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["REQUISITION_ID"].ToString()); }
    //            catch { }
    //            Request_Data.REQUISITION_UID = ds.Tables[0].Rows[0]["REQUISITION_UID"].ToString();
    //            Request_Data.REQUISITION_TYPE = ds.Tables[0].Rows[0]["REQUISITION_TYPE"].ToString().Trim().ToCharArray()[0];
    //            Request_Data.GENERATE_MODE = ds.Tables[0].Rows[0]["GENERATE_MODE"].ToString();
    //            try {Request_Data.FROM_UNIT = Convert.ToInt32(ds.Tables[0].Rows[0]["FROM_UNIT"].ToString());}
    //            catch { }
    //            try {Request_Data.TO_UNIT = Convert.ToInt32(ds.Tables[0].Rows[0]["TO_UNIT"].ToString());}
    //            catch { }
    //            try {Request_Data.GENERATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["GENERATED_BY"].ToString());}
    //            catch { }
    //            Request_Data.GENERATED_BY_TEXT = ds.Tables[0].Rows[0]["GENERATED_BY_TEXT"].ToString();
    //            try {Request_Data.GENERATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["GENERATED_ON"].ToString());}
    //            catch { }
    //            Request_Data.STATUS = ds.Tables[0].Rows[0]["STATUS"].ToString();
    //            try {Request_Data.ORG_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ORG_ID"].ToString());}
    //            catch { }
    //            try {Request_Data.CREATED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["CREATED_BY"].ToString());}
    //            catch { }
    //            try {Request_Data.CREATED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["CREATED_ON"].ToString());}
    //            catch { }
    //            try {Request_Data.LAST_MODIFIED_BY = Convert.ToInt32(ds.Tables[0].Rows[0]["LAST_MODIFIED_BY"].ToString());}
    //            catch { }
    //            try { Request_Data.LAST_MODIFIED_ON = Convert.ToDateTime(ds.Tables[0].Rows[0]["LAST_MODIFIED_ON"].ToString()); }
    //            catch { }
    //            Request_Data.IS_STAT = ds.Tables[0].Rows[0]["IS_STAT"].ToString();
    //            _dsInsert = Request_Data.RequestDetail;
    //        }
    //    }
    //    //public void dsInsertAdd(int PR_ID, int ITEM_ID, decimal QTY, int ORG_ID, int CREATED_BY, int LAST_MODIFIED_BY)
    //    //{
    //    //    DataRow dr = _dsInsert.Tables[0].NewRow();
    //    //    dr["PR_ID"] = PR_ID;
    //    //    dr["ITEM_ID"] = ITEM_ID;
    //    //    dr["QTY"] = QTY;
    //    //    dr["ORG_ID"] = ORG_ID;
    //    //    dr["CREATED_BY"] = CREATED_BY;
    //    //    dr["LAST_MODIFIED_BY"] = LAST_MODIFIED_BY;

    //    //    _dsInsert.Tables[0].Rows.Add(dr);
    //    //}
    //    public void dsDeleteAdd(DataRow dr)
    //    {
    //        try
    //        {
    //            _dsDelete.Tables[0].Rows.Add(dr.ItemArray);
    //        }
    //        catch { }
    //    }
    //    public bool RequestManagement(SqlType Type)
    //    {
    //        bool retFlag = true;
    //        bool flag = true;
    //        //SqlTransaction tran = null;
    //        //SqlConnection con = null;
    //        DbTransaction tran = null;
    //        DbConnection con = null;
    //        int RecieveID;
    //        //DataTable dtt = dtOrder.Clone();
    //        try
    //        {

    //            //DataAccess.DataAccessBase baseData = new RIS.DataAccess.DataAccessBase();
    //            //con = baseData.GetSQLConnection();
    //            //con.Open();
    //            //tran = con.BeginTransaction();

    //            DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
    //            con = db.Connection();
    //            con.Open();
    //            tran = con.BeginTransaction();

    //            ProcessAddINVRequisition prcAdd = new ProcessAddINVRequisition(tran);
    //            ProcessAddINVRequisitiondtl prcDetailAdd = new ProcessAddINVRequisitiondtl(tran);

    //            ProcessUpdateINVRequisition prcUpdate = new ProcessUpdateINVRequisition(tran);
    //            ProcessUpdateINVRequisitiondtl prcDetailUpdate = new ProcessUpdateINVRequisitiondtl(tran);

    //            ProcessDeleteINVRequisition prcDel = new ProcessDeleteINVRequisition();
    //            ProcessDeleteINVRequisitiondtl prcDetailDel = new ProcessDeleteINVRequisitiondtl(tran);

    //            switch (Type)
    //            {
    //                case SqlType.Insert:
    //                    prcAdd.INV_REQUISITION.REQUISITION_UID = Request_Data.REQUISITION_UID;
    //                    prcAdd.INV_REQUISITION.REQUISITION_TYPE = Request_Data.REQUISITION_TYPE;
    //                    prcAdd.INV_REQUISITION.FROM_UNIT = Request_Data.FROM_UNIT;
    //                    prcAdd.INV_REQUISITION.TO_UNIT = Request_Data.TO_UNIT;
    //                    prcAdd.INV_REQUISITION.GENERATED_BY = Request_Data.GENERATED_BY;
    //                    prcAdd.INV_REQUISITION.ORG_ID = Request_Data.ORG_ID;
    //                    prcAdd.INV_REQUISITION.CREATED_BY = Request_Data.CREATED_BY;
    //                    prcAdd.INV_REQUISITION.LAST_MODIFIED_BY = Request_Data.LAST_MODIFIED_BY;
                        
    //                    prcAdd.Invoke();

    //                    RecieveID = prcAdd.INV_REQUISITION.REQUISITION_ID;
    //                    foreach (DataRow dr in _dsInsert.Tables[0].Rows)
    //                    {
    //                        prcDetailAdd.INV_REQUISITIONDTL.REQUISITION_ID = prcAdd.INV_REQUISITION.REQUISITION_ID;
    //                        prcDetailAdd.INV_REQUISITIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                        prcDetailAdd.INV_REQUISITIONDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                        prcDetailAdd.INV_REQUISITIONDTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
    //                        prcDetailAdd.INV_REQUISITIONDTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
    //                        prcDetailAdd.INV_REQUISITIONDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                        prcDetailAdd.Invoke();

    //                    }
    //                    break;
    //                case SqlType.Update:
    //                    #region Update Master
    //                    prcUpdate.INV_REQUISITION.REQUISITION_UID = Request_Data.REQUISITION_UID;
    //                    prcUpdate.INV_REQUISITION.REQUISITION_ID = Request_Data.REQUISITION_ID;
    //                    prcUpdate.INV_REQUISITION.REQUISITION_TYPE = Request_Data.REQUISITION_TYPE;
    //                    prcUpdate.INV_REQUISITION.FROM_UNIT = Request_Data.FROM_UNIT;
    //                    prcUpdate.INV_REQUISITION.TO_UNIT = Request_Data.TO_UNIT;
    //                    prcUpdate.INV_REQUISITION.LAST_MODIFIED_BY = Request_Data.LAST_MODIFIED_BY;
    //                    prcUpdate.Invoke();
    //                    #endregion

    //                    #region Update Details
    //                    foreach (DataRow dr in _dsInsert.Tables[0].Rows)
    //                    {
    //                        if (dr["CREATED_ON"].ToString() == string.Empty)
    //                        {
    //                            prcDetailAdd.INV_REQUISITIONDTL.REQUISITION_ID = Request_Data.REQUISITION_ID;
    //                            prcDetailAdd.INV_REQUISITIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailAdd.INV_REQUISITIONDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                            prcDetailAdd.INV_REQUISITIONDTL.ORG_ID = Convert.ToInt32(dr["ORG_ID"].ToString());
    //                            prcDetailAdd.INV_REQUISITIONDTL.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"].ToString());
    //                            prcDetailAdd.INV_REQUISITIONDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                            prcDetailAdd.Invoke();
    //                        }
    //                        else
    //                        {
    //                            prcDetailUpdate.INV_REQUISITIONDTL.REQUISITION_ID = Request_Data.REQUISITION_ID;
    //                            prcDetailUpdate.INV_REQUISITIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailUpdate.INV_REQUISITIONDTL.QTY = Convert.ToDecimal(dr["QTY"].ToString());
    //                            prcDetailUpdate.INV_REQUISITIONDTL.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"].ToString());
    //                            prcDetailUpdate.Invoke();
    //                        }
    //                    }
    //                    foreach (DataRow dr in _dsDelete.Tables[0].Rows)
    //                    {
    //                        if (dr["CREATED_ON"].ToString() != string.Empty)
    //                        {
    //                            prcDetailDel.INV_REQUISITIONDTL.REQUISITION_ID = Request_Data.REQUISITION_ID;
    //                            prcDetailDel.INV_REQUISITIONDTL.ITEM_ID = Convert.ToInt32(dr["ITEM_ID"].ToString());
    //                            prcDetailDel.Invoke();
    //                        }
    //                    }
    //                    #endregion
    //                    break;
    //                case SqlType.Delete:
    //                    prcDel.INV_REQUISITION.REQUISITION_ID = Request_Data.REQUISITION_ID;
    //                    prcDel.Invoke();
    //                    break;
    //                default:
    //                    break;
    //            }
    //            tran.Commit();
    //        }
    //        catch (Exception ex)
    //        {
    //            tran.Rollback();
    //            //throw new Exception(ex.Message);
    //            //retFlag = false;//MessageBox.Show(ex.Message);

    //        }
    //        finally
    //        {
    //            if (con.State == ConnectionState.Open)
    //                con.Close();
    //            tran.Dispose();
    //        }
    //        return retFlag;
    //    }
    //}
    //public class RequestData
    //{
    //    #region Member
    //    private int requisition_id;
    //    private string requisition_uid;
    //    private System.Nullable<char> requisition_type;
    //    private string generate_mode;
    //    private int from_unit;
    //    private int to_unit;
    //    private int generated_by;
    //    private DateTime generated_on;
    //    private string status;
    //    private int org_id;
    //    private int created_by;
    //    private DateTime created_on;
    //    private int last_modified_by;
    //    private DateTime last_modified_on;
    //    private DataSet request_detail;
    //    private string is_stat;
    //    private string generated_by_text;
    //    #endregion

    //    #region Property
    //    public string IS_STAT
    //    {
    //        get { return is_stat; }
    //        set { is_stat = value; }
    //    }
    //    public string GENERATED_BY_TEXT
    //    {
    //        get { return generated_by_text; }
    //        set { generated_by_text = value; }
    //    }
    //    public DataSet RequestDetail
    //    {
    //        get { return request_detail; }
    //        set { request_detail = value; }
    //    }
    //    public int REQUISITION_ID
    //    {
    //        get { return requisition_id; }
    //        set { requisition_id = value; request_detail = GetRequest_Detail(requisition_id); }
    //    }
    //    public string REQUISITION_UID
    //    {
    //        get { return requisition_uid; }
    //        set { requisition_uid = value; }
    //    }
    //    public System.Nullable<char> REQUISITION_TYPE
    //    {
    //        get { return requisition_type; }
    //        set { requisition_type = value; }
    //    }
    //    public string GENERATE_MODE
    //    {
    //        get { return generate_mode; }
    //        set { generate_mode = value; }
    //    }
    //    public int FROM_UNIT
    //    {
    //        get { return from_unit; }
    //        set { from_unit = value; }
    //    }
    //    public int TO_UNIT
    //    {
    //        get { return to_unit; }
    //        set { to_unit = value; }
    //    }
    //    public int GENERATED_BY
    //    {
    //        get { return generated_by; }
    //        set { generated_by = value; }
    //    }
    //    public DateTime GENERATED_ON
    //    {
    //        get { return generated_on; }
    //        set { generated_on = value; }
    //    }
    //    public string STATUS
    //    {
    //        get { return status; }
    //        set { status = value; }
    //    }
    //    public int ORG_ID
    //    {
    //        get { return org_id; }
    //        set { org_id = value; }
    //    }
    //    public int CREATED_BY
    //    {
    //        get { return created_by; }
    //        set { created_by = value; }
    //    }
    //    public DateTime CREATED_ON
    //    {
    //        get { return created_on; }
    //        set { created_on = value; }
    //    }
    //    public int LAST_MODIFIED_BY
    //    {
    //        get { return last_modified_by; }
    //        set { last_modified_by = value; }
    //    }
    //    public DateTime LAST_MODIFIED_ON
    //    {
    //        get { return last_modified_on; }
    //        set { last_modified_on = value; }
    //    }
    //    #endregion 
    //    private DataSet GetRequest_Detail(int requisition_id)
    //    {
    //        //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedure.Name.Prc_INV_REQUISITIONDTL_Select.ToString());
    //        //SqlParameter[] parameters ={			
    //        //    new SqlParameter("@REQUISITION_ID",requisition_id)
    //        //    };
    //        //DataSet ds_detail = dbhelper.Run(base.ConnectionString, parameters);
    //        //return ds_detail;
    //        InventoryStockManSelectData inv = new InventoryStockManSelectData();
    //        DataSet ds = inv.GetSelectRequest(requisition_id);
    //        return ds;
    //    }
    //}
}
