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
using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic;
using System.Collections.Generic;
using EnvisionOnline.BusinessLogic.ProcessRead;

public partial class frmCovidDetail : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RISBaseClass ris_base = new RISBaseClass();
            DataTable dtIndDefault = new DataTable();
            DataSet dsInd = new DataSet();
            DataSet dsIndType = new DataSet();

            #region Preparing Indication Type data
            ProcessGetRISClinicalIndicationType indType = new ProcessGetRISClinicalIndicationType();
            dsIndType = indType.GetDataCovid();
            #endregion

            #region Preparing Indication data
            ProcessGetRISClinicalIndication ind = new ProcessGetRISClinicalIndication();
            dsInd = ind.GetDataCovid();
            #endregion

            treeIndicationTypeView.DataFieldID = "CI_TYPE_ID";
            treeIndicationTypeView.DataFieldParentID = "PARENT_ID";
            treeIndicationTypeView.DataTextField = "CI_DESC";
            treeIndicationTypeView.DataSource = dsIndType.Tables[1];
            treeIndicationTypeView.DataBind();

            treeIndicationView.DataFieldID = "CI_ID";
            treeIndicationView.DataFieldParentID = "CI_PARENT";
            treeIndicationView.DataTextField = "CI_DESC";
            treeIndicationView.DataSource = dsInd.Tables[1];
            treeIndicationView.DataBind();


            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            txtEditor.Text = param.REF_DOC_INSTRUCTION;
        }
    }
    protected void treeIndicationTypeView_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> data = param.TEMP_CLINICALINDICATIONTYPE;
        if (e.Node.Checked)
            data.Remove(e.Node.FullPath);
        else
            data.Add(e.Node.FullPath);
        e.Node.Checked = !e.Node.Checked;

        if (e.Node.Checked)
            fillinEditorType(e.Node);
        else
            txtEditor.Text = txtEditor.Text.Replace(e.Node.FullPath, "");
        param.TEMP_CLINICALINDICATIONTYPE = data;
        Session["ONL_PARAMETER"] = param;
        Session["nodeIndicationTypeFocus"] = e.Node;
    }
    protected void treeIndicationTypeView_NodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> data = param.TEMP_CLINICALINDICATIONTYPE;
        if (e.Node.Checked)
            data.Add(e.Node.FullPath);
        else
            data.Remove(e.Node.FullPath);
        e.Node.Checked = e.Node.Checked;

        if (e.Node.Checked)
            fillinEditorType(e.Node);
        else
            txtEditor.Text = txtEditor.Text.Replace(e.Node.FullPath, "");

        param.TEMP_CLINICALINDICATIONTYPE = data;
        Session["ONL_PARAMETER"] = param;
    }
    protected void treeIndicationTypeView_NodeCreated(object sender, RadTreeNodeEventArgs e)
    {
        RadTreeNode node = e.Node;
        if (node.ParentNode != null)
            node.ParentNode.Checkable = false;

    }
    protected void treeIndicationTypeView_NodeDataBound(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RadTreeNode node = e.Node;
        if (!string.IsNullOrEmpty(node.FullPath))
        {
            node.ExpandParentNodes();
            DataTable dt = treeIndicationTypeView.DataSource as DataTable;
            RISBaseClass baseOrder = new RISBaseClass();
            int ci_type_id = baseOrder.get_CITypeID_ClinicalIndicationType(node.FullPath);
            DataRow[] rowsBold = dt.Select("CI_TYPE_ID=" + ci_type_id.ToString());
            if (rowsBold.Length > 0)
                if (rowsBold[0]["NEED_DETAIL"].ToString() == "Y")
                    e.Node.Font.Bold = true;

            if (param.dvGridDtl.Rows.Count > 0)
                if (param.dtOrderClinicalIndicationType.Rows.Count > 0)
                {
                    DataRow[] rows = param.dtOrderClinicalIndicationType.Select("CI_TYPE_ID=" + ci_type_id.ToString());
                    if (rows.Length > 0)
                    {
                        node.Checked = true;
                        bool flag = true;
                        foreach (string str in param.TEMP_CLINICALINDICATIONTYPE)
                            if (str == node.FullPath)
                                flag = false;
                        if (flag)
                            param.TEMP_CLINICALINDICATIONTYPE.Add(node.FullPath);
                    }
                }
        }
        Session["ONL_PARAMETER"] = param;
    }

    protected void treeIndicationView_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> data = param.TEMP_CLINICALINDICATION;
        if (e.Node.Checked)
            data.Remove(e.Node.FullPath);
        else
            if (e.Node.FullPath == "No Symptom")
            {
                IList<RadTreeNode> list = treeIndicationView.CheckedNodes;
                foreach (RadTreeNode node in list)
                {
                    if (node.FullPath != "No Symptom")
                    {
                        node.Checked = false;
                        data.Remove(node.FullPath);
                    }
                }

                data.Add(e.Node.FullPath);

            }
            else
            {
                IList<RadTreeNode> list = treeIndicationView.CheckedNodes;
                foreach (RadTreeNode node in list)
                {
                    if (node.FullPath == "No Symptom")
                        node.Checked = false;
                }
                data.Remove("No Symptom");
                data.Add(e.Node.FullPath);

                if (e.Node.Text == "Other")
                    lblAlert.Text = "กรุณาใส่รายละเอียดเพิ่มเติม !!!";
            }
        e.Node.Checked = !e.Node.Checked;

        if (e.Node.Checked)
            fillinEditor(e.Node);
        else
            txtEditor.Text = txtEditor.Text.Replace(e.Node.FullPath, "");

        param.TEMP_CLINICALINDICATION = data;
        Session["ONL_PARAMETER"] = param;
        Session["nodeIndicationFocus"] = e.Node;
    }
    protected void treeIndicationView_NodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        List<string> data = param.TEMP_CLINICALINDICATION;
        if (e.Node.Checked)
            if (e.Node.FullPath == "No Symptom")
            {
                IList<RadTreeNode> list = treeIndicationView.CheckedNodes;
                foreach (RadTreeNode node in list)
                {
                    if (node.FullPath != "No Symptom")
                    {
                        node.Checked = false;
                        data.Remove(node.FullPath);
                    }
                }

                data.Add(e.Node.FullPath);
            }
            else
            {
                IList<RadTreeNode> list = treeIndicationView.CheckedNodes;
                foreach (RadTreeNode node in list)
                {
                    if (node.FullPath == "No Symptom")
                        node.Checked = false;
                }
                data.Remove("No Symptom");
                data.Add(e.Node.FullPath);
                if (e.Node.Text == "Other")
                    lblAlert.Text = "กรุณาใส่รายละเอียดเพิ่มเติม !!!";
            }
        else
            data.Remove(e.Node.FullPath);
        e.Node.Checked = e.Node.Checked;

        if (e.Node.Checked)
            fillinEditor(e.Node);
        else
            txtEditor.Text = txtEditor.Text.Replace(e.Node.FullPath, "");

        param.TEMP_CLINICALINDICATION = data;
        Session["ONL_PARAMETER"] = param;
    }
    protected void treeIndicationView_NodeCreated(object sender, RadTreeNodeEventArgs e)
    {
        RadTreeNode node = e.Node;
        if (node.ParentNode != null)
            node.ParentNode.Checkable = false;
    }
    protected void treeIndicationView_NodeDataBound(object sender, RadTreeNodeEventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        RadTreeNode node = e.Node;
        if (!string.IsNullOrEmpty(node.FullPath))
        {
            node.ExpandParentNodes();
            RISBaseClass baseOrder = new RISBaseClass();
            int ci_id = baseOrder.get_CIID_ClinicalIndication(node.FullPath);
            if (param.dvGridDtl.Rows.Count > 0)
                if (param.dtOrderClinicalIndication.Rows.Count > 0)
                {
                    DataRow[] rows = param.dtOrderClinicalIndication.Select("CI_ID=" + ci_id.ToString());
                    if (rows.Length > 0)
                    {
                        node.Checked = true;
                        bool flag = true;
                        foreach (string str in param.TEMP_CLINICALINDICATION)
                            if (str == node.FullPath)
                                flag = false;
                        if (flag)
                            param.TEMP_CLINICALINDICATION.Add(node.FullPath);
                    }
                }
            if (param.dtCLINICALINDICATIONLASTVISIT.Rows.Count > 0)
            {
                DataRow[] rows = param.dtCLINICALINDICATIONLASTVISIT.Select("CI_ID=" + ci_id.ToString());
                if (rows.Length > 0)
                    node.ExpandParentNodes();
            }
        }
        Session["ONL_PARAMETER"] = param;
    }
    private void fillinEditor(RadTreeNode data)
    {
        if (data.Checkable)
        {
            string s = data.FullPath;

            if (string.IsNullOrEmpty(txtEditor.Text))
                txtEditor.Text = s + "  \r\n";
            else
                txtEditor.Text = txtEditor.Text + s + "  \r\n";
        }
    }
    private void fillinEditorType(RadTreeNode data)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        if (data.Checkable)
        {
            string s = data.FullPath;

            RISBaseClass ord = new RISBaseClass();
            DataTable dtCItype = param.dtCLINICALINDICATIONTYPE;
            int ciid = ord.get_CITypeID_ClinicalIndicationType(data.FullPath);

            DataRow[] rowCItype = dtCItype.Select("CI_TYPE_ID=" + ciid.ToString());
            if (rowCItype.Length > 0)
                if (!string.IsNullOrEmpty(rowCItype[0]["DEFAULT_TEXT"].ToString()))
                    s = s + " : " + rowCItype[0]["DEFAULT_TEXT"].ToString();

            if (string.IsNullOrEmpty(txtEditor.Text))
                txtEditor.Text = s + "  \r\n";
            else
                txtEditor.Text = txtEditor.Text + s + "  \r\n";

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        IList<RadTreeNode> listView = treeIndicationView.CheckedNodes;
        IList<RadTreeNode> listViewType = treeIndicationTypeView.CheckedNodes;
        if (listViewType.Count == 0)
            lblAlert.Text = "กรุณาเลือก COVID DOI";
        else if (listView.Count == 0)
            lblAlert.Text = "กรุณาเลือกอาการของคนไข้";
        else
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            param.REF_DOC_INSTRUCTION = txtEditor.Text;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "CloseAndRebind('COVID');", true);
        }
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "OnClientClose();", true);
    }
    
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
    }
}
