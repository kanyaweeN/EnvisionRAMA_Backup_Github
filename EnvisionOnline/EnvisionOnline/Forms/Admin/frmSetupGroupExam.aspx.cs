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
using System.Collections;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Operational;
using EnvisionOnline.BusinessLogic.ProcessDelete;

public partial class frmSetupGroupExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProcessGetONLGroupDepartment getGDept = new ProcessGetONLGroupDepartment();
            getGDept.GetDataByGDeptType("OR");
            DataSet dsGDept = getGDept.Result;

            ProcessGetONLGroupExamtype getGType = new ProcessGetONLGroupExamtype();
            getGType.GetDataByGDeptID(Convert.ToInt32(dsGDept.Tables[0].Rows[0]["GDEPT_ID"]));
            DataSet dsGType = getGType.Result;

            ProcessGetONLGroupExam getGExam = new ProcessGetONLGroupExam();
            getGExam.GetDataByGTypeID(Convert.ToInt32(dsGType.Tables[0].Rows[0]["GTYPE_ID"]));
            DataSet dsGExam = getGExam.Result;

            Session["GDeptTypeSelected"] = "OR";
            Session["rowTabHeaderSelected"] = dsGDept.Tables[0].Rows.Count > 0 ? dsGDept.Tables[0].Rows[0] : null;
            Session["rowGExamTypeSelected"] = dsGType.Tables[0].Rows.Count > 0 ? dsGType.Tables[0].Rows[0] : null;
            Session["GDEPT"] = dsGDept;
            Session["GTYPE"] = dsGType;
            Session["GEXAM"] = dsGExam;

        }
    }
    protected void rtbMain_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        if (string.IsNullOrEmpty(cmbButtomFix.SelectedValue))
            return;

        switch (e.Item.Value.ToString())
        {
            case "btnSaveTabHearder":
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openSaveTabHeader", "showpopupSaveTabHeader();", true);
                break;
            case "btnSaveGroupExam":
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openSaveGExamType", "showpopupSaveGroupExamType();", true);
                break;
            case "btnSaveExam":
                DataSet dsGExamType = Session["GTYPE"] as DataSet;
                if (!Utilities.IsHaveData(dsGExamType))
                    return;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openSaveGExam", "showpopupSaveGroupExam('New');", true);
                break;
        }
    }
    protected void cmbButtomFix_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ProcessGetONLGroupDepartment getGDept = new ProcessGetONLGroupDepartment();
        getGDept.GetDataByGDeptType(cmbButtomFix.SelectedValue);
        DataSet dsGDept = getGDept.Result;

        ProcessGetONLGroupExamtype getGType = new ProcessGetONLGroupExamtype();
        int gDeptID = dsGDept.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dsGDept.Tables[0].Rows[0]["GDEPT_ID"]) : 0;
        getGType.GetDataByGDeptID(gDeptID);
        DataSet dsGType = getGType.Result;

        ProcessGetONLGroupExam getGExam = new ProcessGetONLGroupExam();
        int gTypeID = dsGType.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dsGType.Tables[0].Rows[0]["GTYPE_ID"]) : 0;
        getGExam.GetDataByGTypeID(gTypeID);
        DataSet dsGExam = getGExam.Result;

        fillDataGrid_Filter(grdTabHearder, dsGDept.Tables[0]);
        fillDataGrid_Filter(grdExamGroup, dsGType.Tables[0]);
        fillDataGrid_Filter(grdExam, dsGExam.Tables[0]);

        Session["GDeptTypeSelected"] = cmbButtomFix.SelectedValue;
        Session["rowTabHeaderSelected"] = dsGDept.Tables[0].Rows.Count > 0 ? dsGDept.Tables[0].Rows[0] : null;
        Session["rowGExamTypeSelected"] = dsGType.Tables[0].Rows.Count > 0 ? dsGType.Tables[0].Rows[0] : null;
        Session["GDEPT"] = dsGDept;
        Session["GTYPE"] = dsGType;
        Session["GEXAM"] = dsGExam;
    }
    protected void grdTabHearder_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataSet ds = Session["GDEPT"] as DataSet;
        fillDataGridDataTable(grdTabHearder, ds.Tables[0]);
    }
    protected void grdTabHearder_ItemCommand(object source, GridCommandEventArgs e)
    {
        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        item.ExtractValues(values);
        DataSet ds = Session["GDEPT"] as DataSet;
        DataRow[] rows = ds.Tables[0].Select("GDEPT_ID=" + values["GDEPT_ID"].ToString());
        Session["rowTabHeaderSelected"] = rows[0];
        if (e.CommandName == "delTabHeader")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openDeleteTabHeader", "showpopupDeleteTabHeader();", true);
        }
        else if (e.CommandName == "editTabHeader")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openEditTabHeader", "showpopupEditTabHeader();", true);
        }
    }
    protected void grdTabHearder_SelectedIndexChanged(object source, EventArgs e)
    {
        GridEditableItem item = grdTabHearder.SelectedItems[0] as GridEditableItem;
        if (!string.IsNullOrEmpty(item["colGDEPT_ID"].Text))
        {
            if (Convert.ToInt32(item["colGDEPT_ID"].Text) > 0)
            {
                ProcessGetONLGroupExamtype getGType = new ProcessGetONLGroupExamtype();
                getGType.GetDataByGDeptID(Convert.ToInt32(item["colGDEPT_ID"].Text));
                DataSet dsGType = getGType.Result;

                ProcessGetONLGroupExam getGExam = new ProcessGetONLGroupExam();
                int gTypeID = dsGType.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dsGType.Tables[0].Rows[0]["GTYPE_ID"]) : 0;
                getGExam.GetDataByGTypeID(gTypeID);
                DataSet dsGExam = getGExam.Result;

                fillDataGrid_Filter(grdExamGroup, dsGType.Tables[0]);
                fillDataGrid_Filter(grdExam, dsGExam.Tables[0]);

                DataSet ds = Session["GDEPT"] as DataSet;
                DataRow[] rows = ds.Tables[0].Select("GDEPT_ID=" + item["colGDEPT_ID"].Text);
                Session["rowTabHeaderSelected"] = rows[0];
                Session["rowGExamTypeSelected"] = dsGType.Tables[0].Rows.Count > 0 ? dsGType.Tables[0].Rows[0] : null;
                Session["GTYPE"] = dsGType;
                Session["GEXAM"] = dsGExam;
            }
        }
    }

    protected void grdExamGroup_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataSet ds = Session["GTYPE"] as DataSet;
        fillDataGridDataTable(grdExamGroup, ds.Tables[0]);
    }
    protected void grdExamGroup_ItemCommand(object source, GridCommandEventArgs e)
    {
        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        item.ExtractValues(values);
        DataSet ds = Session["GTYPE"] as DataSet;
        DataRow[] rows = ds.Tables[0].Select("GTYPE_ID=" + values["GTYPE_ID"].ToString());
        Session["rowGExamTypeSelected"] = rows[0];

        if (e.CommandName == "delGroupExam")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openDeleteGExamType", "showpopupDeleteGroupExamType();", true);
        }
        else if (e.CommandName == "editGroupExam")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "openEditGExamType", "showpopupEditGroupExamType();", true);
        }
    }
    protected void grdExamGroup_SelectedIndexChanged(object source, EventArgs e)
    {
        GridEditableItem item = grdExamGroup.SelectedItems[0] as GridEditableItem;
        if (!string.IsNullOrEmpty(item["colGTYPE_ID"].Text))
        {
            if (Convert.ToInt32(item["colGTYPE_ID"].Text) > 0)
            {
                ProcessGetONLGroupExam getGExam = new ProcessGetONLGroupExam();
                getGExam.GetDataByGTypeID(Convert.ToInt32(item["colGTYPE_ID"].Text));
                DataSet dsGExam = getGExam.Result;

                fillDataGrid_Filter(grdExam, dsGExam.Tables[0]);

                DataSet ds = Session["GTYPE"] as DataSet;
                DataRow[] rows = ds.Tables[0].Select("GTYPE_ID=" + item["colGTYPE_ID"].Text);
                Session["rowGExamTypeSelected"] = rows[0];
                Session["GEXAM"] = dsGExam;
            }
        }
    }

    protected void grdExam_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataSet ds = Session["GEXAM"] as DataSet;
        fillDataGridDataTable(grdExam, ds.Tables[0]);
    }
    protected void grdExam_ItemCommand(object source, GridCommandEventArgs e)
    {
        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        item.ExtractValues(values);

        if (e.CommandName == "delExam")
        {
            ProcessDeleteONLGroupExam prc = new ProcessDeleteONLGroupExam();
            prc.deleteByGExamID(Convert.ToInt32(values["GEXAM_ID"].ToString()));

            DataSet dsGExam = Session["GEXAM"] as DataSet;
            DataRow[] rowGExam = dsGExam.Tables[0].Select("GEXAM_ID=" + values["GEXAM_ID"].ToString());
            ProcessGetONLGroupExam getGExam = new ProcessGetONLGroupExam();
            getGExam.GetDataByGTypeID(Convert.ToInt32(rowGExam[0]["GTYPE_ID"].ToString()));
            DataSet dsGE = getGExam.Result;
            Session["GEXAM"] = dsGE;

            fillDataGrid_Filter(grdExam, dsGE.Tables[0]);
        }

    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "saveTabHeader":
            case "saveGExamType":
            case "saveGExam":
                ProcessGetONLGroupDepartment getGDept = new ProcessGetONLGroupDepartment();
                getGDept.GetDataByGDeptType(cmbButtomFix.SelectedValue);
                DataSet dsGDept = getGDept.Result;

                ProcessGetONLGroupExamtype getGType = new ProcessGetONLGroupExamtype();
                int gDeptID = dsGDept.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dsGDept.Tables[0].Rows[0]["GDEPT_ID"]) : 0;
                getGType.GetDataByGDeptID(gDeptID);
                DataSet dsGType = getGType.Result;

                ProcessGetONLGroupExam getGExam = new ProcessGetONLGroupExam();
                int gTypeID = dsGType.Tables[0].Rows.Count > 0 ? Convert.ToInt32(dsGType.Tables[0].Rows[0]["GTYPE_ID"]) : 0;
                getGExam.GetDataByGTypeID(gTypeID);
                DataSet dsGExam = getGExam.Result;

                fillDataGrid_Filter(grdTabHearder, dsGDept.Tables[0]);
                fillDataGrid_Filter(grdExamGroup, dsGType.Tables[0]);
                fillDataGrid_Filter(grdExam, dsGExam.Tables[0]);

                Session["GDeptTypeSelected"] = cmbButtomFix.SelectedValue;
                Session["rowTabHeaderSelected"] = dsGDept.Tables[0].Rows.Count > 0 ? dsGDept.Tables[0].Rows[0] : null;
                Session["rowGExamTypeSelected"] = dsGType.Tables[0].Rows.Count > 0 ? dsGType.Tables[0].Rows[0] : null;
                Session["GDEPT"] = dsGDept;
                Session["GTYPE"] = dsGType;
                Session["GEXAM"] = dsGExam;
                break;
        }
    }
    private void fillDataGridDataTable(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
    private void fillDataGrid_Filter(RadGrid radGridData, DataTable dt)
    {
        radGridData.DataSource = dt;
        radGridData.Rebind();
        for (int i = 0; i < radGridData.Columns.Count; i++)
            radGridData.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
}
