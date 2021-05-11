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
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.BusinessLogic.ProcessDelete;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Operational;

public partial class dialogGroupExamAdd : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dsGExamType = Session["GTYPE"] as DataSet;
            cmbGroupExamType.DataTextField = "GTYPE_TEXT";
            cmbGroupExamType.DataValueField = "GTYPE_ID";
            cmbGroupExamType.DataSource = dsGExamType.Tables[0];
            cmbGroupExamType.DataBind();

            DataRow row = Session["rowGExamTypeSelected"] as DataRow;
            cmbGroupExamType.SelectedValue = row["GTYPE_ID"].ToString();
            getMappingExam();
        }
    }
    protected void rtbMain_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        if (string.IsNullOrEmpty(cmbGroupExamType.SelectedValue))
            return;

        switch (e.Item.Value.ToString())
        {
            case "btnSave":
                DataTable dtSelectedData = Session["SelectedData"] as DataTable;
                ProcessDeleteONLGroupExam delExam = new ProcessDeleteONLGroupExam();
                delExam.delete(Convert.ToInt32(cmbGroupExamType.SelectedValue));
                foreach (DataRow row in dtSelectedData.Rows)
                {
                    ProcessAddONLGroupExam prc = new ProcessAddONLGroupExam();
                    prc.Add(Convert.ToInt32(cmbGroupExamType.SelectedValue), Convert.ToInt32(row["EXAM_ID"]));
                }
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('saveGExam');", true);
                break;
        }
    }
    protected void cmbGroupExamType_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        getMappingExam();
        DataTable dtSelectedData = Session["SelectedData"] as DataTable;
        fillDataGrid_Filter(grdDataSelected, dtSelectedData);
    }
    protected void grdDataExam_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dtExam = Application["ExamAllData"] as DataTable;
        fillDataGridDataTable(grdDataExam, dtExam);
    }
    protected void grdDataExam_ItemCommand(object source, GridCommandEventArgs e)
    {
        DataTable dtSelectedData = Session["SelectedData"] as DataTable;
        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        item.ExtractValues(values);
        DataTable dtExam = Application["ExamAllData"] as DataTable;
        DataRow[] rows = dtExam.Select("EXAM_ID=" + values["EXAM_ID"].ToString());
        DataRow[] rowsChk = dtSelectedData.Select("EXAM_ID=" + values["EXAM_ID"].ToString());
        if (rowsChk.Length == 0)
            dtSelectedData.Rows.Add(rows[0].ItemArray);
        fillDataGrid_Filter(grdDataSelected, dtSelectedData);
        Session["SelectedData"] = dtSelectedData;
    }
    protected void grdDataSelected_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        DataTable dtSelectedData = Session["SelectedData"] as DataTable;
        if (dtSelectedData == null)
        {
            DataTable dtExam = Application["ExamAllData"] as DataTable;
            dtSelectedData = dtExam.Clone();
            Session["SelectedData"] = dtSelectedData;
        }
        fillDataGridDataTable(grdDataSelected, dtSelectedData);
    }
    protected void grdDataSelected_ItemCommand(object source, GridCommandEventArgs e)
    {
        GridEditableItem item = e.Item as GridEditableItem;
        if (item == null) return;
        Hashtable values = new Hashtable();
        item.ExtractValues(values);

        DataTable dtSelectedData = Session["SelectedData"] as DataTable;
        DataRow[] rows = dtSelectedData.Select("EXAM_ID=" + values["EXAM_ID"].ToString());
        dtSelectedData.Rows.Remove(rows[0]);
        fillDataGrid_Filter(grdDataSelected, dtSelectedData);
        Session["SelectedData"] = dtSelectedData;
    }
    private void getMappingExam()
    {
        DataTable dtExam = Application["ExamAllData"] as DataTable;
        DataTable temp = new DataTable();
        temp = dtExam.Clone();
        ProcessGetONLGroupExam getGExam = new ProcessGetONLGroupExam();
        getGExam.GetDataByGTypeID(Convert.ToInt32(cmbGroupExamType.SelectedValue));
        DataSet dsGExam = getGExam.Result;
        if (Utilities.IsHaveData(dsGExam))
        {

            foreach (DataRow rowExam in dsGExam.Tables[0].Rows)
            {
                DataRow[] rows = dtExam.Select("EXAM_ID=" + rowExam["EXAM_ID"].ToString());
                if (rows.Length > 0)
                    temp.Rows.Add(rows[0].ItemArray);
            }
        }
        Session["SelectedData"] = temp;
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
