using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.Common;
using RIS.BusinessLogic;
using DevExpress.XtraCharts;
namespace RIS.Forms.Order
{
    public partial class frmViewPerformance : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private ViewPerformance perform;
        GBLEnvVariable env = new GBLEnvVariable();

        public frmViewPerformance(UUL.ControlFrame.Controls.TabControl tab)
        {
            this.Cursor = Cursors.WaitCursor;
            CloseControl = tab;
            InitializeComponent();
            SetInitialControl();
            this.Cursor = Cursors.Default;
        }
        private void frmViewPerformance_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White;
        }


        private void SetInitialControl() {
            nGroupOrder.Expanded = true;
            perform = new ViewPerformance(DateTime.Today);
            txtName.Text = perform.FullName;
            txtLastOrderTook.Text = perform.LastOrderTook;
            txtMinOrder.Text = perform.MinOrderToday;
            txtMaxOrder.Text = perform.MaxOrderToday;
            txtMinOrderAll.Text = perform.MinOrderAll;
            txtMaxOrderAll.Text = perform.MaxOrderAll;
            Create7DaysChart();
            Create7DaysCompareChart();
        }
        private void Create7DaysChart() {
            chart7days.Series.Clear();
            chart7days.Titles.Clear();

            XYDiagram xyDiagram1 = new XYDiagram();
            StackedBarSeriesView stackedBarSeriesView4 = new DevExpress.XtraCharts.StackedBarSeriesView();
            ChartTitle chartTitle1 = new ChartTitle();
            ChartTitle chartTitle2 = new ChartTitle();

            Series s1 = new Series();
            PointOptions pointOptions1 = new PointOptions();
            StackedBarSeriesLabel stackedBarSeriesLabel1 = new StackedBarSeriesLabel();
            StackedBarSeriesView stackedBarSeriesView1 = new StackedBarSeriesView();
            s1.DataSource = perform.In7Days(env.UserID);
            s1.ArgumentScaleType = ScaleType.Qualitative;
            s1.ValueScaleType = ScaleType.Numerical;
            s1.ArgumentDataMember = "Day";
            s1.ValueDataMembers.AddRange(new string[] { "Amt" });

            Series s2 = new Series();
            PointOptions pointOptions2 = new PointOptions();
            StackedBarSeriesLabel stackedBarSeriesLabel2 = new StackedBarSeriesLabel();
            StackedBarSeriesView stackedBarSeriesView2 = new StackedBarSeriesView();
            s2.DataSource = perform.In7Days(0);
            s2.ArgumentScaleType = ScaleType.Qualitative;
            s2.ValueScaleType = ScaleType.Numerical;
            s2.ArgumentDataMember = "Day";
            s2.ValueDataMembers.AddRange(new string[] { "Amt" });



            ((System.ComponentModel.ISupportInitialize)(chart7days)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(s2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView2)).BeginInit();

            xyDiagram1.Rotated = true;
            xyDiagram1.AxisY.GridLines.MinorVisible = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Title.Visible = true;
            xyDiagram1.AxisY.Title.Text = "";
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 10F);
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Title.Text = "";
            chart7days.Diagram = xyDiagram1;
            s1.Name = "You.";
            s2.Name = "All.";
            s1.ShowInLegend = true;
            s2.ShowInLegend = true;

            s1.Label = stackedBarSeriesLabel1;
            s1.View = stackedBarSeriesView1;
            s2.Label = stackedBarSeriesLabel2;
            s2.View = stackedBarSeriesView2;

            chart7days.SeriesSerializable = new Series[] { s1 ,s2};
            chart7days.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chart7days.SeriesTemplate.View = stackedBarSeriesView4;
            chartTitle1.Text = "You Performance in 7 Days.";
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 10F);
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle2.Text = "www.miracle.com";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            chart7days.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle1, chartTitle2 });

        
           

            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(s1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(s2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chart7days)).EndInit();
        
        }
        private void Create7DaysCompareChart()
        {
            try
            {
                chartCompare7days.Series.Clear();
                chartCompare7days.Titles.Clear();

                //DataSet ds = perform.In7DaysCompare(env.UserID);
                DataSet ds = perform.In7DaysComparable();
                XYDiagram3D xyDiagram3D1 = new XYDiagram3D();

                Series series1 = new Series();
                Line3DSeriesLabel line3DSeriesLabel1 = new Line3DSeriesLabel();
                Line3DSeriesView line3DSeriesView1 = new Line3DSeriesView();

                Series series2 = new Series();
                Line3DSeriesLabel line3DSeriesLabel2 = new Line3DSeriesLabel();
                Line3DSeriesView line3DSeriesView2 = new Line3DSeriesView();

                Series series3 = new Series();
                Line3DSeriesLabel line3DSeriesLabel3 = new Line3DSeriesLabel();
                Line3DSeriesView line3DSeriesView3 = new Line3DSeriesView();

                Series series4 = new Series();
                Line3DSeriesLabel line3DSeriesLabel4 = new Line3DSeriesLabel();
                Line3DSeriesView line3DSeriesView4 = new Line3DSeriesView();

                ChartTitle chartTitle1 = new ChartTitle();
                ChartTitle chartTitle2 = new ChartTitle();

                ((System.ComponentModel.ISupportInitialize)(chartCompare7days)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).BeginInit();

                ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesView1)).BeginInit();

                ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel2)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesView2)).BeginInit();

                ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel3)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesView3)).BeginInit();

                ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel4)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesView4)).BeginInit();
                
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
                xyDiagram3D1.ZoomPercent = 100;//140;
                xyDiagram3D1.VerticalScrollPercent = 4;
                xyDiagram3D1.RuntimeScrolling = true;
                xyDiagram3D1.RuntimeZooming = true;
                chartCompare7days.Diagram = xyDiagram3D1;

                chartTitle1.Text = "Your Comp. Avg. Performance in 7 Days";
                chartTitle1.Font = new System.Drawing.Font("Tahoma", 10F);
                chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
                chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
                chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
                chartTitle2.Text = "www.miracle.com";
                chartTitle2.TextColor = System.Drawing.Color.Gray;

                //series1.DataSource = ds.Tables["7DaysCompare"];
                series1.DataSource = ds.Tables["YouMin"];
                series1.ArgumentScaleType = ScaleType.Qualitative;
                series1.ValueScaleType = ScaleType.Numerical;
                series1.ArgumentDataMember = "Day";
                series1.ValueDataMembers.AddRange(new string[] { "Min" });
                series1.PointOptionsTypeName = "PointOptions";
                line3DSeriesLabel1.HiddenSerializableString = "to be serialized";
                line3DSeriesLabel1.Visible = true;
                series1.Label = line3DSeriesLabel1;
                series1.View = line3DSeriesView1;
                series1.Name = "You(min)";

                //series2.DataSource = ds.Tables["7DaysCompare"];
                series2.DataSource = ds.Tables["YouMax"];
                series2.ArgumentScaleType = ScaleType.Qualitative;
                series2.ValueScaleType = ScaleType.Numerical;
                series2.ArgumentDataMember = "Day";
                series2.ValueDataMembers.AddRange(new string[] { "Max" });
                line3DSeriesLabel2.HiddenSerializableString = "to be serialized";
                line3DSeriesLabel2.Visible = true;
                series2.Label = line3DSeriesLabel2;
                series2.View = line3DSeriesView2;
                series2.Name = "You(max)";

                //series3.DataSource = ds.Tables["7DaysCompareAll"];
                series3.DataSource = ds.Tables["AllMin"];
                series3.ArgumentScaleType = ScaleType.Qualitative;
                series3.ValueScaleType = ScaleType.Numerical;
                series3.ArgumentDataMember = "Day";
                series3.ValueDataMembers.AddRange(new string[] { "Min" });
                line3DSeriesLabel3.HiddenSerializableString = "to be serialized";
                line3DSeriesLabel3.Visible = true;
                series3.Label = line3DSeriesLabel3;
                series3.View = line3DSeriesView3;
                series3.Name = "All(min)";

                //series4.DataSource = ds.Tables["7DaysCompareAll"];
                series4.DataSource = ds.Tables["AllMax"];
                series4.ArgumentScaleType = ScaleType.Qualitative;
                series4.ValueScaleType = ScaleType.Numerical;
                series4.ArgumentDataMember = "Day";
                series4.ValueDataMembers.AddRange(new string[] { "Max" });
                line3DSeriesLabel4.HiddenSerializableString = "to be serialized";
                line3DSeriesLabel4.Visible = true;
                series4.Label = line3DSeriesLabel4;
                series4.View = line3DSeriesView4;
                series4.Name = "All(max)";

                chartCompare7days.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2,series3,series4 };
                chartCompare7days.SeriesTemplate.PointOptionsTypeName = "PointOptions";
                chartCompare7days.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[]{ chartTitle1, chartTitle2 });

                ((System.ComponentModel.ISupportInitialize)(xyDiagram3D1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesView1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesView2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel3)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesView3)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesLabel4)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(line3DSeriesView4)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(chartCompare7days)).EndInit();
            }
            catch (Exception ex) { 
            
            }
        }

        #region Manu Tab
        private void barPatient_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmArrivalWorkList frm = new RIS.Forms.Order.frmArrivalWorkList(this.CloseControl);
            ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            ////frm.BackColor = c;
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barCreateNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("New", this.CloseControl);
            ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            ////frm.BackColor = c;
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Edit", this.CloseControl);
            ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            ////frm.BackColor = c;
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtOrderNo.Focus();
        }
        private void barSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Schedule.frmScheduleWorkList frm = new RIS.Forms.Schedule.frmScheduleWorkList(this.CloseControl);
            ////System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            ////frm.BackColor = c;
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barLastOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Last", this.CloseControl);
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtHN.Focus();
        }
        private void barPrintLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmReprint frm = new RIS.Forms.Order.frmReprint(this.CloseControl);
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmViewPerformance frm = new frmViewPerformance(this.CloseControl);
            //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            //frm.BackColor = c;
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            //System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0xd4, /* G */ 0xd0, /* B */ 0xc8);
            //frm.BackColor = c;
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
        }
        private void barManul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("Manual", this.CloseControl);
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);
            //frm.txtInsurace.Focus();
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }
        #endregion

        private void mnuRestore_Click(object sender, EventArgs e)
        {
            Create7DaysCompareChart();
        }

        
    }
}

