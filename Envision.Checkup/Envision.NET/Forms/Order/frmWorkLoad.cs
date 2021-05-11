using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.BusinessLogic;
using DevExpress.XtraCharts;

namespace RIS.Forms.Order
{
    public partial class frmWorkLoad : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private ViewPerformance perform;

        public frmWorkLoad(UUL.ControlFrame.Controls.TabControl tab)
        {
            this.Cursor = Cursors.WaitCursor;
            CloseControl = tab;
            InitializeComponent();
            SetComboBox();
            SetInitialControl();
            this.Cursor = Cursors.Default;
        }

        private void cboDisplayBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(perform!=null)
                CreateMyChart();
        }

        #region Menu Tab 
        private void btnModify_Click(object sender, EventArgs e)
        {
            RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Edit", this.CloseControl);
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            frm.BackColor = c;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtOrderNo.Focus();
        }
        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("New", this.CloseControl);
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            frm.BackColor = c;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtHN.Focus();
        }
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            RIS.Forms.Schedule.frmScheduleWorkList frm = new RIS.Forms.Schedule.frmScheduleWorkList(this.CloseControl);
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            frm.BackColor = c;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void btnPatient_Click(object sender, EventArgs e)
        {
            RIS.Forms.Order.frmArrivalWorkList frm = new RIS.Forms.Order.frmArrivalWorkList(this.CloseControl);
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            frm.BackColor = c;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void btnRepeat_Click(object sender, EventArgs e)
        {

        }
        private void btnReprint_Click(object sender, EventArgs e)
        {

        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CloseControl.TabPages.Count; i++)
            {
                if (CloseControl.TabPages[i].Title == "Home")
                {
                    CloseControl.TabPages[i].Selected = true;
                    return;
                }
            }
            RIS.Forms.Main.frmMainTab frm = new RIS.Forms.Main.frmMainTab(this.CloseControl);
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            frm.BackColor = c;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void btnViewPerformance_Click(object sender, EventArgs e)
        {
            RIS.Forms.Order.frmViewPerformance frm = new frmViewPerformance(this.CloseControl);
            System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            frm.BackColor = c;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        #endregion

        private void SetComboBox() {
            cboDisplayBy.Items.Clear();
            cboDisplayBy.Items.Add("Week");
            cboDisplayBy.Items.Add("Month");
            cboDisplayBy.SelectedIndex = 0;
        }
        private void SetInitialControl() {
            nGroupOrder.Expanded = true;
            nGroupExam.Expanded = false;
            
        
            //perform = new ViewPerformance(DateTime.Now);
            //txtName.Text = perform.FullName;
            //txtLastOrderTook.Text = perform.LastOrderTook;
            //txtMinOrder.Text = perform.MinOrderToday;
            //txtMaxOrder.Text = perform.MaxOrderToday;
            //txtMinOrderAll.Text = perform.MinOrderAll;
            //txtMaxOrderAll.Text = perform.MaxOrderToday;
            //CreateMyChart();
        }

        private void ClearSeries() {
            chartOrderWeek.Series.Clear();
            chartOrderWeek.Titles.Clear();
            chartOrderWeek.Refresh();

            chartExamWeek.Series.Clear();
            chartExamWeek.Titles.Clear();
            chartExamWeek.Refresh();

            chartOrderMonth.Series.Clear();
            chartOrderMonth.Titles.Clear();
            chartOrderMonth.Refresh();

            chartExamMonth.Series.Clear();
            chartExamMonth.Titles.Clear();
            chartExamMonth.Refresh();
        }
        private void CreateMyChart()
        {
            ClearSeries();
            if (cboDisplayBy.SelectedIndex == 0)
            {
                CreateChartOrderByWeek();
                CreateChartExamByWeek();
                CreateChartOrderCompareByWeek();
                CreateChartExamCompareByWeek();
            }
            else
            {
                CreateChartOrderByMonth();
                CreateChartExamByMonth();
            }
        
        }

        private void CreateChartOrderByWeek() {
            XYDiagram xyDiagram1 = new XYDiagram();
            StackedBarSeriesView stackedBarSeriesView4 = new DevExpress.XtraCharts.StackedBarSeriesView();
            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();

            Series s1 = new Series();
            PointOptions pointOptions1 = new PointOptions();
            StackedBarSeriesLabel stackedBarSeriesLabel1 = new StackedBarSeriesLabel();
            StackedBarSeriesView stackedBarSeriesView1 = new StackedBarSeriesView();
            s1.DataSource = perform.DataOrderWeek();
            s1.ArgumentScaleType = ScaleType.Qualitative;
            s1.ValueScaleType = ScaleType.Numerical;
            s1.ArgumentDataMember = "Day";
            s1.ValueDataMembers.AddRange(new string[] { "Amt" });
            ((System.ComponentModel.ISupportInitialize)(chartOrderWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();

            xyDiagram1.Rotated = true;
            xyDiagram1.AxisY.GridLines.MinorVisible = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Title.Visible = true;
            xyDiagram1.AxisY.Title.Text = "จำนวนคนไข้";
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 10F);
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Title.Text = "วันที่";
            chartOrderWeek.Diagram = xyDiagram1;
            s1.ShowInLegend = false;
            chartOrderWeek.SeriesSerializable = new Series[] { s1 };
            chartOrderWeek.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chartOrderWeek.SeriesTemplate.View = stackedBarSeriesView4;
            chartTitle1.Text = "รายงานแสดงผลการทำงานประจำสัปดาห์";
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 10F);
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle2.Text = "www.miracle.com";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            chartOrderWeek.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1, chartTitle2 });

            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartOrderWeek)).EndInit();
       
        }
        private void CreateChartOrderByMonth() {
            XYDiagram xyDiagram1 = new XYDiagram();
            StackedBarSeriesView stackedBarSeriesView4 = new DevExpress.XtraCharts.StackedBarSeriesView();
            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();

            Series s1 = new Series();
            PointOptions pointOptions1 = new PointOptions();
            StackedBarSeriesLabel stackedBarSeriesLabel1 = new StackedBarSeriesLabel();
            StackedBarSeriesView stackedBarSeriesView1 = new StackedBarSeriesView();
            s1.DataSource = perform.DataOrderMonth();
            s1.ArgumentScaleType = ScaleType.Qualitative;
            s1.ValueScaleType = ScaleType.Numerical;
            s1.ArgumentDataMember = "Week";
            s1.ValueDataMembers.AddRange(new string[] { "Amt" });
            ((System.ComponentModel.ISupportInitialize)(chartOrderWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();

            xyDiagram1.Rotated = true;
            xyDiagram1.AxisY.GridLines.MinorVisible = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Title.Visible = true;
            xyDiagram1.AxisY.Title.Text = "จำนวนคนไข้";
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 10F);
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Title.Text = "วันที่";
            chartOrderWeek.Diagram = xyDiagram1;
            s1.ShowInLegend = false;
            chartOrderWeek.SeriesSerializable = new Series[] { s1 };
            chartOrderWeek.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chartOrderWeek.SeriesTemplate.View = stackedBarSeriesView4;
            chartTitle1.Text = "รายงานแสดงผลการทำงาน 1 เดือน";
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 10F);
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle2.Text = "www.miracle.com";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            chartOrderWeek.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1, chartTitle2 });

            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartOrderWeek)).EndInit();
        }
        private void CreateChartOrderCompareByWeek() {
            XYDiagram3D xyDiagram3D1 = new XYDiagram3D();
            Series series1 = new Series();
            Line3DSeriesLabel line3DSeriesLabel1 = new Line3DSeriesLabel();
            Line3DSeriesView line3DSeriesView1 = new Line3DSeriesView();

            Series series2 = new Series();
            Bar3DSeriesLabel bar3DSeriesLabel1 = new Bar3DSeriesLabel();
            ManhattanBarSeriesView manhattanBarSeriesView1 = new ManhattanBarSeriesView();

            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();

            ((System.ComponentModel.ISupportInitialize)(chartOrderMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(line3DSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(bar3DSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(manhattanBarSeriesView1)).BeginInit();

            series1.DataSource = perform.DataOrderWeekCompareSummary();
            series1.ArgumentScaleType = ScaleType.Qualitative;
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ArgumentDataMember = "Week";
            series1.ValueDataMembers.AddRange(new string[] { "Amt" });

            series2.DataSource = perform.DataOrderWeekCompare();
            series2.ArgumentScaleType = ScaleType.Qualitative;
            series2.ValueScaleType = ScaleType.Numerical;
            series2.ArgumentDataMember = "Week";
            series2.ValueDataMembers.AddRange(new string[] { "Amt" });

            xyDiagram3D1.SeriesDistance = 0.1;
            xyDiagram3D1.RotationMatrixSerializable = "0.866025403784439;0.171010071662834;-0.469846310392954;0;0;0.939692620785908;0.34" +
                "2020143325669;0;0.5;-0.296198132726024;0.813797681349374;0;0;0;0;1";
            xyDiagram3D1.RuntimeRotation = true;
            xyDiagram3D1.AxisY.Name = "PrimaryAxisY";
            xyDiagram3D1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram3D1.AxisX.Name = "PrimaryAxisX";
            xyDiagram3D1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram3D1.AxisX.DateTimeOptions.FormatString = "yyyy";
            xyDiagram3D1.AxisX.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.Custom;
            xyDiagram3D1.AxisX.DateTimeMeasureUnit = DevExpress.XtraCharts.DateTimeMeasurementUnit.Year;
            xyDiagram3D1.ZoomPercent = 140;
            xyDiagram3D1.VerticalScrollPercent = 4;
            xyDiagram3D1.RuntimeScrolling = true;
            xyDiagram3D1.RuntimeZooming = true;
            chartOrderMonth.Diagram = xyDiagram3D1;
            series1.PointOptionsTypeName = "PointOptions";
            line3DSeriesLabel1.HiddenSerializableString = "to be serialized";
            line3DSeriesLabel1.Visible = true;
            series1.Label = line3DSeriesLabel1;
            series1.View = line3DSeriesView1;
            series1.Name = "ยอดรวม";

            series2.PointOptionsTypeName = "PointOptions";
            bar3DSeriesLabel1.HiddenSerializableString = "to be serialized";
            bar3DSeriesLabel1.Visible = true;
            series2.Label = bar3DSeriesLabel1;
            manhattanBarSeriesView1.BarDepth = 0.9;
            series2.View = manhattanBarSeriesView1;
            series2.Name = "จำนวนที่ทำ";
            chartOrderMonth.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2 };
            chartOrderMonth.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chartTitle1.Text = "เปรียบเทียบการทำงานประจำสัปดาห์";
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 10F);
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle2.Text = "www.miracle.com";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            chartOrderMonth.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {chartTitle1,chartTitle2});
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(line3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(bar3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(manhattanBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartOrderMonth)).EndInit();
        }
        private void CreateChartOrderCompareByMonth() {

        }

        private void CreateChartExamByWeek() {
            XYDiagram xyDiagram1 = new XYDiagram();
            StackedBarSeriesView stackedBarSeriesView4 = new DevExpress.XtraCharts.StackedBarSeriesView();
            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();

            Series s1 = new Series();
            PointOptions pointOptions1 = new PointOptions();
            StackedBarSeriesLabel stackedBarSeriesLabel1 = new StackedBarSeriesLabel();
            StackedBarSeriesView stackedBarSeriesView1 = new StackedBarSeriesView();
            s1.DataSource = perform.DataExamWeek();
            s1.ArgumentScaleType = ScaleType.Qualitative;
            s1.ValueScaleType = ScaleType.Numerical;
            s1.ArgumentDataMember = "Day";
            s1.ValueDataMembers.AddRange(new string[] { "Amt" });
            ((System.ComponentModel.ISupportInitialize)(chartExamWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();

            xyDiagram1.Rotated = true;
            xyDiagram1.AxisY.GridLines.MinorVisible = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Title.Visible = true;
            xyDiagram1.AxisY.Title.Text = "จำนวนคนไข้";
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 10F);
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Title.Text = "วันที่";
            chartExamWeek.Diagram = xyDiagram1;
            s1.ShowInLegend = false;
            chartExamWeek.SeriesSerializable = new Series[] { s1 };
            chartExamWeek.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chartExamWeek.SeriesTemplate.View = stackedBarSeriesView4;
            chartTitle1.Text = "รายงานแสดงผลการทำงานประจำสัปดาห์";
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 10F);
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle2.Text = "www.miracle.com";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            chartExamWeek.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1, chartTitle2 });

            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartExamWeek)).EndInit();
        }
        private void CreateChartExamByMonth() {
            XYDiagram xyDiagram1 = new XYDiagram();
            StackedBarSeriesView stackedBarSeriesView4 = new DevExpress.XtraCharts.StackedBarSeriesView();
            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();

            Series s1 = new Series();
            PointOptions pointOptions1 = new PointOptions();
            StackedBarSeriesLabel stackedBarSeriesLabel1 = new StackedBarSeriesLabel();
            StackedBarSeriesView stackedBarSeriesView1 = new StackedBarSeriesView();
            s1.DataSource = perform.DataExamMonth();
            s1.ArgumentScaleType = ScaleType.Qualitative;
            s1.ValueScaleType = ScaleType.Numerical;
            s1.ArgumentDataMember = "Week";
            s1.ValueDataMembers.AddRange(new string[] { "Amt" });
            ((System.ComponentModel.ISupportInitialize)(chartExamWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();

            xyDiagram1.Rotated = true;
            xyDiagram1.AxisY.GridLines.MinorVisible = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Title.Visible = true;
            xyDiagram1.AxisY.Title.Text = "จำนวนคนไข้";
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 10F);
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Title.Text = "วันที่";
            chartExamWeek.Diagram = xyDiagram1;
            s1.ShowInLegend = false;
            chartExamWeek.SeriesSerializable = new Series[] { s1 };
            chartExamWeek.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chartExamWeek.SeriesTemplate.View = stackedBarSeriesView4;
            chartTitle1.Text = "รายงานแสดงผลการทำงาน 1 เดือน";
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 10F);
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle2.Text = "From www.miracle.com";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            chartExamWeek.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1, chartTitle2 });

            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartExamWeek)).EndInit();
        }
        private void CreateChartExamCompareByWeek() {
            XYDiagram3D xyDiagram3D1 = new XYDiagram3D();
            Series series1 = new Series();
            Line3DSeriesLabel line3DSeriesLabel1 = new Line3DSeriesLabel();
            Line3DSeriesView line3DSeriesView1 = new Line3DSeriesView();

            Series series2 = new Series();
            Bar3DSeriesLabel bar3DSeriesLabel1 = new Bar3DSeriesLabel();
            ManhattanBarSeriesView manhattanBarSeriesView1 = new ManhattanBarSeriesView();

            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();

            ((System.ComponentModel.ISupportInitialize)(chartExamMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(line3DSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(bar3DSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(manhattanBarSeriesView1)).BeginInit();

            series1.DataSource = perform.DataExamWeekCompareSummary();
            series1.ArgumentScaleType = ScaleType.Qualitative;
            series1.ValueScaleType = ScaleType.Numerical;
            series1.ArgumentDataMember = "Week";
            series1.ValueDataMembers.AddRange(new string[] { "Amt" });

            series2.DataSource = perform.DataExamWeekCompare();
            series2.ArgumentScaleType = ScaleType.Qualitative;
            series2.ValueScaleType = ScaleType.Numerical;
            series2.ArgumentDataMember = "Week";
            series2.ValueDataMembers.AddRange(new string[] { "Amt" });

            xyDiagram3D1.SeriesDistance = 0.1;
            xyDiagram3D1.RotationMatrixSerializable = "0.866025403784439;0.171010071662834;-0.469846310392954;0;0;0.939692620785908;0.34" +
                "2020143325669;0;0.5;-0.296198132726024;0.813797681349374;0;0;0;0;1";
            xyDiagram3D1.RuntimeRotation = true;
            xyDiagram3D1.AxisY.Name = "PrimaryAxisY";
            xyDiagram3D1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram3D1.AxisX.Name = "PrimaryAxisX";
            xyDiagram3D1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram3D1.AxisX.DateTimeOptions.FormatString = "yyyy";
            xyDiagram3D1.AxisX.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.Custom;
            xyDiagram3D1.AxisX.DateTimeMeasureUnit = DevExpress.XtraCharts.DateTimeMeasurementUnit.Year;
            xyDiagram3D1.ZoomPercent = 140;
            xyDiagram3D1.VerticalScrollPercent = 4;
            xyDiagram3D1.RuntimeScrolling = true;
            xyDiagram3D1.RuntimeZooming = true;
            chartExamMonth.Diagram = xyDiagram3D1;
            series1.PointOptionsTypeName = "PointOptions";
            line3DSeriesLabel1.HiddenSerializableString = "to be serialized";
            line3DSeriesLabel1.Visible = true;
            series1.Label = line3DSeriesLabel1;
            series1.View = line3DSeriesView1;
            series1.Name = "ยอดรวม";

            series2.PointOptionsTypeName = "PointOptions";
            bar3DSeriesLabel1.HiddenSerializableString = "to be serialized";
            bar3DSeriesLabel1.Visible = true;
            series2.Label = bar3DSeriesLabel1;
            manhattanBarSeriesView1.BarDepth = 0.9;
            series2.View = manhattanBarSeriesView1;
            series2.Name = "จำนวนที่ทำ";
            chartExamMonth.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2 };
            chartExamMonth.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chartTitle1.Text = "เปรียบเทียบการทำงานประจำสัปดาห์";
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 10F);
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle2.Text = "www.miracle.com";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            chartExamMonth.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1, chartTitle2 });
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(line3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(bar3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(manhattanBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chartExamMonth)).EndInit();
        }
        private void CreateChartExamCompareByByMonth() { 
        
        }

        private void mmnuRestore_Click(object sender, EventArgs e)
        {
            chartOrderMonth.Series.Clear();
            chartOrderMonth.Titles.Clear();
            chartOrderMonth.Refresh();
            CreateChartOrderCompareByWeek();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartExamMonth.Series.Clear();
            chartExamMonth.Titles.Clear();
            chartExamMonth.Refresh();
            CreateChartExamCompareByWeek();
        }
    }
}