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
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Common;
using System.Collections.Generic;
using EnvisionOnline.Common.Common;

public partial class frmClinicalIndicationTypeWithParameter : System.Web.UI.Page 
{
    private bool has_value(object source)
    {
        bool flag;
        if (source != null)
        {
            if (string.IsNullOrEmpty(source.ToString()))
                flag = false;
            else
                flag = true;
        }
        else
        {
            flag = false;
        }
        return flag;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string _param = "MRPC";
            if (has_value(Request.Params["PARAM1"]))
                _param = Request.Params["PARAM1"].Trim();

            RISBaseClass ris_base = new RISBaseClass();
            DataTable dtIndDefault = new DataTable();
            DataSet dsIndType = new DataSet();

            #region Preparing Indication Type data
            ProcessGetRISClinicalIndicationType indType = new ProcessGetRISClinicalIndicationType();
            dsIndType = indType.GetDataWithParameter(_param);
            #endregion

            treeIndicationTypeView.DataFieldID = "CI_TYPE_ID";
            treeIndicationTypeView.DataFieldParentID = "PARENT_ID";
            treeIndicationTypeView.DataTextField = "CI_DESC";
            treeIndicationTypeView.DataSource = dsIndType.Tables[1];
            treeIndicationTypeView.DataBind();

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
        IList<RadTreeNode> listViewType = treeIndicationTypeView.CheckedNodes;
        if (listViewType.Count == 0)
            lblAlert.Text = "กรุณาเลือก clinical indication";
        else
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            param.REF_DOC_INSTRUCTION = txtEditor.Text;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "CloseAndRebind('ClinicalIndicationWithParam');", true);
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
