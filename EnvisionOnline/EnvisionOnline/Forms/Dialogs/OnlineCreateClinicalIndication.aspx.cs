using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;

public partial class OnlineCreateClinicalIndication : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["FROM"].ToString() == "Indication")
                setClinicalIndicationData();
            else
                setClinicalIndicationTypeData();
        }
    }
    private void setClinicalIndicationData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("LV", typeof(int));
        dt.Columns.Add("DISPLAY", typeof(string));
        dt.Columns.Add("SEARCH", typeof(string));
        dt.AcceptChanges();
        int id = 0;
        RadTreeView treeIndicationView = Session["treeIndicationView"] as RadTreeView;
        RadTreeNode nodeIndicationFocus = Session["nodeIndicationFocus"] as RadTreeNode;
        foreach (RadTreeNode data in treeIndicationView.GetAllNodes())
        {
            string strDisplay = data.Text;
            string strSearch = data.Text;
            RadTreeNode currentObject = data.ParentNode;

            if (data.Level == 0)
            {
                strDisplay = "[" + id + "]" + strDisplay;
                dt.Rows.Add(id, data.Level, strDisplay, strSearch);
                id++;
                if (nodeIndicationFocus != null)
                    if (strSearch == nodeIndicationFocus.FullPath)
                        cmbClinical.Text = strDisplay;
            }
            else
            {
                string _tab = "";
                for (int i = 0; i < data.Level; i++)
                    _tab += "---";
                strDisplay = "[" + id + "]" + _tab + strDisplay;
                strSearch = currentObject.Text + "/" + strSearch;
                dt.Rows.Add(id, data.Level, strDisplay, strSearch);
                id++;
                if (nodeIndicationFocus != null)
                    if (strSearch == nodeIndicationFocus.FullPath)
                        cmbClinical.Text = strDisplay;
            }
        }
        dt.AcceptChanges();
        Session["dataAddData"] = dt;



    }
    private void setClinicalIndicationTypeData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("LV", typeof(int));
        dt.Columns.Add("DISPLAY", typeof(string));
        dt.Columns.Add("SEARCH", typeof(string));
        dt.AcceptChanges();
        int id = 0;

        lblIndicationGroup.Visible = false;
        cmbClinical.Visible = false;

        RadTreeView treeIndicationTypeView = Session["treeIndicationTypeView"] as RadTreeView;
        RadTreeNode nodeIndicationTypeFocus = Session["nodeIndicationTypeFocus"] as RadTreeNode;
        foreach (RadTreeNode data in treeIndicationTypeView.GetAllNodes())
        {
            string strDisplay = data.Text;
            string strSearch = data.Text;
            RadTreeNode currentObject = data.ParentNode;

            if (data.Level == 0)
            {
                strDisplay = "[" + id + "]" + strDisplay;
                dt.Rows.Add(id, data.Level, strDisplay, strSearch);
                id++;
                if (nodeIndicationTypeFocus != null)
                    if (strSearch == nodeIndicationTypeFocus.FullPath)
                        cmbClinical.Text = strDisplay;
            }
            else
            {
                string _tab = "";
                for (int i = 0; i < data.Level; i++)
                    _tab += "---";
                strDisplay = "[" + id + "]" + _tab + strDisplay;
                strSearch = currentObject.Text + "/" + strSearch;
                dt.Rows.Add(id, data.Level, strDisplay, strSearch);
                id++;
                if (nodeIndicationTypeFocus != null)
                    if (strSearch == nodeIndicationTypeFocus.FullPath)
                        cmbClinical.Text = strDisplay;
            }
        }
        dt.AcceptChanges();
        Session["dataAddData"] = dt;


    }
    protected void cmbClinical_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dt = Session["dataAddData"] as DataTable;
        cmbClinical.Items.Clear();

        for (int i = 0; i < dt.Rows.Count; i++)
            cmbClinical.Items.Add(new RadComboBoxItem(dt.Rows[i]["DISPLAY"].ToString()));

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        if (Request.Params["FROM"].ToString() == "Indication")
        {
            if (string.IsNullOrEmpty(cmbClinical.Text))
            {
                createClinicalIndicationType();
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('createdClinicalIndicationType');", true);
            }
            else
            {
                createClinicalIndication();
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('createdClinicalIndication');", true);
            }
        }
        else
        {
            createClinicalIndicationType();
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('createdClinicalIndicationType');", true);
        }
       
    }
    private void createClinicalIndication()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass ris_base = new RISBaseClass();
        int ciid = 0;
        int _lv = 0;
        if (!string.IsNullOrEmpty(cmbClinical.Text))
        {
            DataTable dt = Session["dataAddData"] as DataTable;
            DataRow[] row = dt.Select("ID=" + cmbClinical.Text.Substring(1, cmbClinical.Text.LastIndexOf(']') - 1));//.ToString());
            DataSet dsInd = ris_base.get_RIS_CLINICALINDICATION(env.OrgID, env.UserID);
            DataTable dtInd = dsInd.Tables[1];
            dtInd.Merge(dsInd.Tables[2].Copy());//Add by user
            ciid = ris_base.get_CIID_ClinicalIndication(row[0]["SEARCH"].ToString());
            DataRow[] rowData = dtInd.Select("CI_ID=" + ciid.ToString());
            _lv = Convert.ToInt32(row[0]["LV"]) + 1;
        }
        ProcessAddRISClinicalIndication add = new ProcessAddRISClinicalIndication();
        add.RIS_CLINICALINDICATION.CI_UID = DateTime.Now.ToString("yyMMddHHmm");
        add.RIS_CLINICALINDICATION.CI_DESC = txtNewLabel.Text.Trim();
        add.RIS_CLINICALINDICATION.CI_LEVEL = Convert.ToByte(_lv);
        add.RIS_CLINICALINDICATION.CI_PARENT = ciid;
        add.RIS_CLINICALINDICATION.IS_USER_DEFINED = "Y";
        add.RIS_CLINICALINDICATION.ORG_ID = env.OrgID;
        add.RIS_CLINICALINDICATION.CREATED_BY = env.UserID;
        add.Invoke();
    }
    private void createClinicalIndicationType()
    {

        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass ris_base = new RISBaseClass();
        int ciTyid = 0;
        int _lv = 0;
        if (!string.IsNullOrEmpty(cmbClinical.Text))
        {
            DataTable dt = Session["dataAddData"] as DataTable;
            DataRow[] row = dt.Select("ID=" + cmbClinical.Text.Substring(1, cmbClinical.Text.LastIndexOf(']') - 1));//.ToString());
            DataSet dsIndType = ris_base.get_RIS_CLINICALINDICATIONTYPE(env.OrgID, env.UserID);
            DataTable dtIndType = dsIndType.Tables[1];
            dtIndType.Merge(dsIndType.Tables[2].Copy());//Add by user
            ciTyid = ris_base.get_CITypeID_ClinicalIndicationType(row[0]["SEARCH"].ToString());
            DataRow[] rowData = dtIndType.Select("CI_TYPE_ID=" + ciTyid.ToString());
            _lv = Convert.ToInt32(row[0]["LV"]) + 1;
        }
        ProcessAddRISClinicalIndicationType add = new ProcessAddRISClinicalIndicationType();
        add.RIS_CLINICALINDICATIONTYPE.CI_UID = DateTime.Now.ToString("yyMMddHHmm");
        add.RIS_CLINICALINDICATIONTYPE.CI_DESC = txtNewLabel.Text.Trim();
        add.RIS_CLINICALINDICATIONTYPE.LEVEL = Convert.ToByte(_lv);
        add.RIS_CLINICALINDICATIONTYPE.PARENT_ID = ciTyid;
        add.RIS_CLINICALINDICATIONTYPE.IS_USER_DEFINED = "Y";
        add.RIS_CLINICALINDICATIONTYPE.ORG_ID = env.OrgID;
        add.RIS_CLINICALINDICATIONTYPE.CREATED_BY = env.UserID;
        add.Invoke();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "OnClientClose('');", true);
    }
}
