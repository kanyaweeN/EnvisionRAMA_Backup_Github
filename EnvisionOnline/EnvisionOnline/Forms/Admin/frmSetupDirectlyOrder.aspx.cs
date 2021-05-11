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
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.BusinessLogic.ProcessDelete;

public partial class frmSetupDirectlyOrder : System.Web.UI.Page
{
    private int unit_id, clinic_type_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            unit_id = 0;
            clinic_type_id = 0;
        }

    }
    protected void rtbMain_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        DataTable dtSelectedData = Session["SelectedData"] as DataTable;
        if (string.IsNullOrEmpty(cmbClinicType.SelectedValue))
            return;
        if (string.IsNullOrEmpty(cmbRefUnit.SelectedValue))
            return;
        ProcessDeleteONLDirectlyOrder del = new ProcessDeleteONLDirectlyOrder(
                Convert.ToInt32(cmbRefUnit.SelectedValue),
                    Convert.ToInt32(cmbClinicType.SelectedValue)
                    );
        del.Invoke();
        if (Utilities.IsHaveData(dtSelectedData))
        {
            foreach (DataRow rows in dtSelectedData.Rows)
            {
                ProcessAddONLDirectlyOrder add = new ProcessAddONLDirectlyOrder(
                    Convert.ToInt32(cmbRefUnit.SelectedValue),
                    Convert.ToInt32(cmbClinicType.SelectedValue),
                    Convert.ToInt32(rows["EXAM_ID"])
                    );
                add.Invoke();
            }
        }
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
            cmbRefUnit.Items.Add(new RadComboBoxItem(rows[i]["UNIT_UID"].ToString() + " : " + rows[i]["UNIT_NAME"].ToString(), rows[i]["UNIT_ID"].ToString()));

    }
    protected void cmbRefUnit_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        getMappingData();
    }
    protected void cmbClinicType_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
    {
        DataTable dtClinic = Application["ClinicTypeData"] as DataTable;
        cmbClinicType.Items.Clear();

        string text = e.Text;
        DataRow[] rows = dtClinic.Select("CLINIC_TYPE_TEXT LIKE '%" + text + "%'");

        int itemsPerRequest = 10;
        int itemOffset = e.NumberOfItems;
        int endOffset = itemOffset + itemsPerRequest;
        if (endOffset > rows.Length)
            endOffset = rows.Length;

        for (int i = itemOffset; i < endOffset; i++)
            cmbClinicType.Items.Add(new RadComboBoxItem(rows[i]["CLINIC_TYPE_TEXT"].ToString(), rows[i]["CLINIC_TYPE_ID"].ToString()));

    }
    protected void cmbClinicType_SelectedIndexChanged(object source, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        getMappingData();
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

    private void getMappingData()
    {
        DataTable dtExam = Application["ExamAllData"] as DataTable;
        bool flag = true;
        DataTable dtSelectedData = Session["SelectedData"] as DataTable;
        dtSelectedData = dtExam.Clone();
        if (string.IsNullOrEmpty(cmbRefUnit.SelectedValue))
            flag = false;
        if (string.IsNullOrEmpty(cmbClinicType.SelectedValue))
            flag = false;
        if (flag)
        {
            ProcessGetONLDirectlyOrder chkDirect = new ProcessGetONLDirectlyOrder(
                    Convert.ToInt32(cmbRefUnit.SelectedValue),
                    Convert.ToInt32(cmbClinicType.SelectedValue));
            chkDirect.Invoke();
            DataSet ds = chkDirect.Result;
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                DataRow[] row = dtExam.Select("EXAM_ID=" + rows["EXAM_ID"].ToString());
                dtSelectedData.Rows.Add(row[0].ItemArray);
            }
        }
        fillDataGrid_Filter(grdDataSelected, dtSelectedData);
        Session["SelectedData"] = dtSelectedData;
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
