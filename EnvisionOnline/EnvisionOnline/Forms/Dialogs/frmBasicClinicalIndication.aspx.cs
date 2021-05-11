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
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common;
using System.Collections.Generic;

public partial class frmBasicClinicalIndication : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindingTreeview();
        }
    }
    protected void rtoolResult_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        if (e.Item.Value == "btnSave")
        {
            saveData();
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('RebindBasicClinicalIndication');", true);
        }
        else if (e.Item.Value == "btnCancel")
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('CancelBasicClinicalIndication');", true);
    }
    private void saveData()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass risbase = new RISBaseClass();
        risbase.RIS_CLINICALINDICATION.EMP_ID = env.UserID;
        risbase.RIS_CLINICALINDICATION.ORG_ID = env.OrgID;
        risbase.RIS_CLINICALINDICATION.CREATED_BY = env.UserID;

        risbase.set_RIS_CLINICALINDICATIONFAVORITE_DeleteAll();

        DataTable dt = Session["dtClinicalIndication"] as DataTable;

        IList<RadTreeNode> nodeCollection = treeIndicationView.CheckedNodes;
        foreach (RadTreeNode node in nodeCollection)
        {
            string[] strNode = node.FullPath.Split('/');
            string strParent = "";
            for (int i = 0; i < strNode.Length; i++)
            {
                DataRow[] rows;
                if (i == 0)
                    rows = dt.Select("CI_DESC='" + strNode[i].ToString() + "'");
                else
                    rows = dt.Select("CI_DESC='" + strNode[i].ToString() + "' and CI_PARENT='" + strParent + "'");
                risbase.RIS_CLINICALINDICATION.CI_ID = Convert.ToInt32(rows[0]["CI_ID"]);
                risbase.set_RIS_CLINICALINDICATIONFAVORITE_Insert();
                strParent = rows[0]["CI_ID"].ToString();
            }
        }
    }
    private void BindingTreeview()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass ris_base = new RISBaseClass();
        DataSet dsInd = new DataSet();
        DataTable dtInd = new DataTable();

        ris_base.RIS_CLINICALINDICATION.EMP_ID = env.UserID;
        ris_base.RIS_CLINICALINDICATION.ORG_ID = env.OrgID;

        dsInd = ris_base.get_RIS_CLINICALINDICATION(env.OrgID, env.UserID);
        dtInd = dsInd.Tables[1];

        treeIndicationView.DataFieldID = "CI_ID";
        treeIndicationView.DataFieldParentID = "CI_PARENT";
        treeIndicationView.DataTextField = "CI_DESC";
        treeIndicationView.DataSource = dtInd;
        treeIndicationView.DataBind();

        Session["dtClinicalIndication"] = dtInd;
    }
    private DataTable getClinicalIndicationWithUnit()
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RISBaseClass ris_base = new RISBaseClass();
        int ref_unit_id = param.REF_UNIT_ID == null ? 0 : param.REF_UNIT_ID;

        return ris_base.get_RIS_CLINICALINDICATION_WITH_UNIT(env.OrgID, ref_unit_id);
    }
    protected void treeIndicationView_NodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        e.Node.Checked = e.Node.Checked;
    }
    protected void treeIndicationView_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        e.Node.Checked = !e.Node.Checked;
    }
    protected void treeIndicationView_NodeCreated(object sender, RadTreeNodeEventArgs e)
    {
        //RadTreeNode node = e.Node;
        //if (node.ParentNode != null)
        //    node.ParentNode.Checkable = false;
    }
    protected void treeIndicationView_NodeDataBound(object sender, RadTreeNodeEventArgs e)
    {
        RadTreeNode node = e.Node;
        if (!string.IsNullOrEmpty(node.FullPath))
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            DataTable dtClinicalIndicationCheck = param.dtCLINICALINDICATION;//Session["dtClinicalIndicationWithUnit"] as DataTable;
            DataTable dtClinicalIndication = Session["dtClinicalIndication"] as DataTable;
            if (dtClinicalIndicationCheck.Rows.Count > 0)
            {
                RISBaseClass baseOrder = new RISBaseClass();
                int ci_id = baseOrder.get_CIID_ClinicalIndication(node.FullPath);
                DataRow[] rows = dtClinicalIndicationCheck.Select("CI_ID=" + ci_id.ToString());
                if (rows.Length > 0)
                {
                    node.Checked = true;
                    node.ExpandParentNodes();
                }
            }
        }
    }

}
