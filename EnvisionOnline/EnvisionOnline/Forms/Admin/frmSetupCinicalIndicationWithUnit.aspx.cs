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
using System.Collections.Generic;

public partial class frmSetupCinicalIndicationWithUnit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getClinicalIndicationWithUnit(0);
            BindingTreeview();
        }
    }
    private void getClinicalIndicationWithUnit(int unit_id)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass ris_base = new RISBaseClass();
        Session["dtClinicalIndicationWithUnit"] = ris_base.get_RIS_CLINICALINDICATION_WITH_UNIT(env.OrgID, unit_id);
    }
    protected void rtbMain_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
        RISBaseClass ris_base = new RISBaseClass();
        DataTable dt = Session["dtClinicalIndication"] as DataTable;
        if (cmbRefUnit.Text.Trim() == "")
            return;
        if (e.Item.Value == "btnSave")
        {
            
            ris_base.RIS_CLINICALINDICATION.UNIT_ID = Convert.ToInt32(cmbRefUnit.SelectedValue);
            ris_base.RIS_CLINICALINDICATION.ORG_ID = env.OrgID;
            ris_base.RIS_CLINICALINDICATION.CREATED_BY = env.UserID;

            ris_base.set_RIS_CLINICALINDICATIONWITHUNIT_DeleteAll();
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
                    ris_base.RIS_CLINICALINDICATION.CI_ID = Convert.ToInt32(rows[0]["CI_ID"]);
                    ris_base.set_RIS_CLINICALINDICATIONWITHUNIT_Insert();
                    strParent = rows[0]["CI_ID"].ToString();
                }
            }
        }
        getClinicalIndicationWithUnit(Convert.ToInt32(cmbRefUnit.SelectedValue));
        BindingTreeview();
    }
    protected void cmbRefUnit_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dtUnit = Application["UnitData"] as DataTable;
        cmbRefUnit.Items.Clear();

        string text = e.Text;
        DataRow[] rows = dtUnit.Select("UNIT_UID + UNIT_NAME LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbRefUnit.Items.Add(new RadComboBoxItem(rows[i]["UNIT_UID"].ToString() + " : " + rows[i]["UNIT_NAME"].ToString(),rows[i]["UNIT_ID"].ToString()));

    }
    protected void cmbRefUnit_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        getClinicalIndicationWithUnit(Convert.ToInt32(e.Value));
        BindingTreeview();
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
            DataTable dtClinicalIndicationWithUnit = Session["dtClinicalIndicationWithUnit"] as DataTable;
            DataTable dtClinicalIndication = Session["dtClinicalIndication"] as DataTable;
            if (dtClinicalIndicationWithUnit.Rows.Count > 0)
            {
                RISBaseClass baseOrder = new RISBaseClass();
                int ci_id = baseOrder.get_CIID_ClinicalIndication(node.FullPath);
                DataRow[] rows = dtClinicalIndicationWithUnit.Select("CI_ID=" + ci_id.ToString());
                if (rows.Length > 0)
                {
                    node.Checked = true;
                    node.ExpandParentNodes();
                }
            }
        }
    }

}
