using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using EnvisionBreastControl.Lib;
using Envision.NET.Mammogram.ResultEntry.BIRAD.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Popup
{
    /// <summary>
    /// This class use to set marker template
    /// </summary>
    public partial class popupProperties : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private CShapeControl ccircleControl;
        private popupSaveDialog popUpSaveDialog;
        private CProperties _properties;
        private DataSet dsMarkTemplate;
        private int empId;
        private int language;
        private int orgId = 1;
        private MyMessageBox myMsg;
        private enum PropertyModes
        {
            Default, Template, Loader
        }
        private PropertyModes propertyMode = PropertyModes.Default;

        /// <summary>
        /// Get marker properties
        /// </summary>
        public CProperties Properties
        {
            get { return _properties; }
        }

        public popupProperties(int empId, int language)
        {
            this.empId = empId;
            this.language = language;
            this.myMsg = new MyMessageBox();
            InitializeComponent();
            this.ccircleControl = new CShapeControl();
            this.ccircleControl.ReadOnly = true;
            this.elementHost1.Child = this.ccircleControl;
            this.Load += new EventHandler(popupProperties_Load);
            this.InitializeEditor();
            this.chkShowBorder.CheckedChanged += new EventHandler(chkShowBorder_CheckedChanged);
            this.chkFixSize.CheckedChanged += new EventHandler(chkFixSize_CheckedChanged);
            this.cbStyle.SelectedIndexChanged += new EventHandler(cbStyle_SelectedIndexChanged);
            this.ceBackgroundColor.ColorChanged += new EventHandler(ceBackgroundColor_ColorChanged);
            this.ceBorderColor.ColorChanged += new EventHandler(ceBorderColor_ColorChanged);
            this.ceStrokeColor.ColorChanged += new EventHandler(ceStrokeColor_ColorChanged);
            this.ceFontColor.ColorChanged += new EventHandler(ceFontColor_ColorChanged);
           
            this.speBorderThickness.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(speBorderThickness_EditValueChanging);
            this.speDiameter.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(speDiameter_EditValueChanging);
            this.speFontSize.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(speFontSize_EditValueChanging);
            this.feFontFamily.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(feFontFamily_EditValueChanging);
            this.cbUnit.SelectedIndexChanged += new EventHandler(cbUnit_SelectedIndexChanged);
            this.cbMargin.SelectedIndexChanged += new EventHandler(cbShape_SelectedIndexChanged);

            this.btnClose.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
            this.btnSelect.ItemClick += new ItemClickEventHandler(btnSelect_ItemClick);
            this.btnSaveToProfile.ItemClick += new ItemClickEventHandler(btnSaveToProfile_ItemClick);
            this.btnDelete.ItemClick += new ItemClickEventHandler(btnDelete_ItemClick);
            this.btnMarkAsDefault.ItemClick += new ItemClickEventHandler(btnMarkAsDefault_ItemClick);
            this.btnUpdate.ItemClick += new ItemClickEventHandler(btnUpdate_ItemClick);
            this.gridMarkTemplateView1.DoubleClick += new EventHandler(gridMarkTemplateView1_DoubleClick);
            this.btnRestore.ItemClick += new ItemClickEventHandler(btnRestore_ItemClick);
            this.btnOK.ItemClick += new ItemClickEventHandler(btnOK_ItemClick);
        }

        /// <summary>
        /// Confrim 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Restore to system style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.propertyMode = PropertyModes.Default;
            this.SetProperties();
        }

        /// <summary>
        /// Edit Marker Template Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridMarkTemplateView1.FocusedRowHandle > -1)
            {
                string msg_result = myMsg.ShowAlert("UID6044", this.language);
                if (msg_result == "2")
                {
                    DataRow drSelectedRow
                            = this.gridMarkTemplateView1.GetDataRow(this.gridMarkTemplateView1.FocusedRowHandle);
                    DialogResult result = this.popUpSaveDialog.ShowDialog(this.tbTemplateName.Text, drSelectedRow["IS_DEFAULT"].ToString() == "Y" ? true : false);
                    if (result == DialogResult.OK)
                    {
                        ProcessUpdateMGBreastMarkTemplate processUpdateMGBreastMarkTemplate = new ProcessUpdateMGBreastMarkTemplate();
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.BORDER_COLOR = this.ceBorderColor.Color.Name;
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.CAN_RESIZE = this.chkFixSize.Checked == true ? "Y" : "N";
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.LAST_MODIFIED_BY = this.empId;
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.DIMENSION = Convert.ToInt32(this.speDiameter.EditValue);
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.EMP_ID = this.empId;
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.FILL_COLOR = this.ceBackgroundColor.Color.Name;
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.FONT_COLOR = this.ceFontColor.Color.Name;
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.FONT_FAMILY = (string)this.feFontFamily.EditValue;
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.FONT_SIZE = Convert.ToInt32(this.speFontSize.EditValue);
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.ORG_ID = this.orgId;
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.SHAPE = (string)this.cbMargin.EditValue;
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.SHOW_BORDER = this.chkShowBorder.Checked == true ? "Y" : "N";
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.STROKE_COLOR = this.ceStrokeColor.Color.Name;
                        switch (this.cbStyle.EditValue.ToString())
                        {
                            case "Fill": processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.STYLE = "F"; break;
                            case "Outline": processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.STYLE = "O"; break;
                        }
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.THICKNESS = Convert.ToInt32(this.speBorderThickness.EditValue);
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.TPL_NAME = this.popUpSaveDialog.TemplateName;
                        switch (this.cbUnit.EditValue.ToString())
                        {
                            case "Pixel": processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.UNIT = "P"; break;
                            case "Mm": processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.UNIT = "M"; break;
                            case "Cm": processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.UNIT = "C"; break;
                            case "Inch": processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.UNIT = "I"; break;
                        }
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.IS_DEFAULT = this.popUpSaveDialog.IsDefault == true ? "Y" : "N";
                        processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.TPL_ID = Convert.ToInt32(drSelectedRow["TPL_ID"]);
                        processUpdateMGBreastMarkTemplate.Mode = 1;
                        processUpdateMGBreastMarkTemplate.Invoke();

                        //Update Mark as Default
                        if (this.popUpSaveDialog.IsDefault)
                        {
                            processUpdateMGBreastMarkTemplate.Mode = 2;
                            processUpdateMGBreastMarkTemplate.Invoke();
                        }
                        this.LoadMarkTemplate();
                    }
                }
            }
        }
        /// <summary>
        /// Mark as Default Template Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMarkAsDefault_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridMarkTemplateView1.FocusedRowHandle > -1)
            {
                string result = myMsg.ShowAlert("UID6043", this.language);
                if (result == "2")
                {
                    DataRow drSelectedRow
                        = this.gridMarkTemplateView1.GetDataRow(this.gridMarkTemplateView1.FocusedRowHandle);
                    ProcessUpdateMGBreastMarkTemplate processUpdateMGBreastMarkTemplate = new ProcessUpdateMGBreastMarkTemplate();
                    processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.EMP_ID = this.empId;
                    processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.TPL_ID = Convert.ToInt32(drSelectedRow["TPL_ID"]);
                    processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.IS_DEFAULT = "Y";
                    processUpdateMGBreastMarkTemplate.Mode = 2;
                    processUpdateMGBreastMarkTemplate.Invoke();
                    this.LoadMarkTemplate();
                }
            }
        }
        /// <summary>
        /// Delete Marker Template Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridMarkTemplateView1.FocusedRowHandle > -1)
            {
                string result = myMsg.ShowAlert("UID6040", this.language);
                if (result == "2")
                {
                    DataRow drSelectedRow
                        = this.gridMarkTemplateView1.GetDataRow(this.gridMarkTemplateView1.FocusedRowHandle);
                    ProcessDeleteMGBreastMarkTemplate processDeleteMGBreastMarkTemplate = new ProcessDeleteMGBreastMarkTemplate();
                    processDeleteMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.TPL_ID = Convert.ToInt32(drSelectedRow["TPL_ID"]);
                    processDeleteMGBreastMarkTemplate.Invoke();
                    this.LoadMarkTemplate();
                }
            }
        }


        #region Editor Event
        /// <summary>
        /// Shape Combobox selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ccircleControl != null)
            {
                switch (cbMargin.SelectedIndex)
                {
                    case 0: ccircleControl.Shape = CShapeControl.Shapes.Circumscribed; break;
                    case 1: ccircleControl.Shape = CShapeControl.Shapes.Microlobulated; break;
                    case 2: ccircleControl.Shape = CShapeControl.Shapes.Obscured; break;
                    case 3: ccircleControl.Shape = CShapeControl.Shapes.Indistinct; break;
                    case 4: ccircleControl.Shape = CShapeControl.Shapes.Spiculated; break;
                }
                this._properties.Shape = ccircleControl.Shape; //Update Shape Property
            }
        }
        /// <summary>
        /// Unit Conbobox Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ccircleControl != null)
            {
                switch (cbUnit.SelectedIndex)
                {
                    case 0: ccircleControl.Unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Pixel;
                        this.ccircleControl.Margin = new System.Windows.Thickness(-this.ccircleControl.Diameter, -this.ccircleControl.Diameter, 0, 0);                        
                        break;
                    case 1: ccircleControl.Unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Mm;
                        this.ccircleControl.Margin = new System.Windows.Thickness(-EnvisionBreastControl.Lib.Cores.Helper.DipHelper.MmToDip(this.ccircleControl.Diameter), -EnvisionBreastControl.Lib.Cores.Helper.DipHelper.MmToDip(this.ccircleControl.Diameter), 0, 0); 
                        break;
                    case 2: ccircleControl.Unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Cm;
                        this.ccircleControl.Margin = new System.Windows.Thickness(-EnvisionBreastControl.Lib.Cores.Helper.DipHelper.CmToDip(this.ccircleControl.Diameter), -EnvisionBreastControl.Lib.Cores.Helper.DipHelper.CmToDip(this.ccircleControl.Diameter), 0, 0); 
                        break;
                    case 3: ccircleControl.Unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Inch;
                        this.ccircleControl.Margin = new System.Windows.Thickness(-EnvisionBreastControl.Lib.Cores.Helper.DipHelper.InchToDip(this.ccircleControl.Diameter), -EnvisionBreastControl.Lib.Cores.Helper.DipHelper.InchToDip(this.ccircleControl.Diameter), 0, 0); 
                        break;
                }
                this._properties.Unit = ccircleControl.Unit; //Update Unit Property
            }
        }
        /// <summary>
        /// Font Family Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void feFontFamily_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.ccircleControl != null)
            {
                this.ccircleControl.LineScaleTextFontFamily = new System.Windows.Media.FontFamily(e.NewValue.ToString());
                this._properties.FontFamily = e.NewValue.ToString(); //Update Font Family Property                
            }
        }
        /// <summary>
        /// Font Size Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speFontSize_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.ccircleControl != null)
            {
                this.ccircleControl.LineScaleTextFontSize = Convert.ToInt32(e.NewValue);
                this._properties.FontSize = (int)this.ccircleControl.LineScaleTextFontSize; //Update Font Family Property                
            }
        }
        /// <summary>
        /// Diameter Spin Number Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speDiameter_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.ccircleControl != null)
            {
                this.ccircleControl.Diameter = Convert.ToInt32(e.NewValue);
                if (cbUnit.SelectedIndex < 0)
                    cbUnit.SelectedIndex = 0;
                switch (cbUnit.SelectedIndex)
                {
                    case 0:
                        this.ccircleControl.Margin = new System.Windows.Thickness(-this.ccircleControl.Diameter, -this.ccircleControl.Diameter, 0, 0);
                        break;
                    case 1:
                        this.ccircleControl.Margin = new System.Windows.Thickness(-EnvisionBreastControl.Lib.Cores.Helper.DipHelper.MmToDip(this.ccircleControl.Diameter), -EnvisionBreastControl.Lib.Cores.Helper.DipHelper.MmToDip(this.ccircleControl.Diameter), 0, 0);
                        break;
                    case 2:
                        this.ccircleControl.Margin = new System.Windows.Thickness(-EnvisionBreastControl.Lib.Cores.Helper.DipHelper.CmToDip(this.ccircleControl.Diameter), -EnvisionBreastControl.Lib.Cores.Helper.DipHelper.CmToDip(this.ccircleControl.Diameter), 0, 0);
                        break;
                    case 3:
                        this.ccircleControl.Margin = new System.Windows.Thickness(-EnvisionBreastControl.Lib.Cores.Helper.DipHelper.InchToDip(this.ccircleControl.Diameter), -EnvisionBreastControl.Lib.Cores.Helper.DipHelper.InchToDip(this.ccircleControl.Diameter), 0, 0);
                        break;
                }
                this._properties.Diameter = Convert.ToInt32(e.NewValue);//Update Diameter
            }
        }
        /// <summary>
        /// Border Thickness Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speBorderThickness_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.ccircleControl != null)
            {
                this.ccircleControl.ShapeStrokeThickness = Convert.ToInt32(e.NewValue);
                this._properties.BorderThickness = Convert.ToInt32(e.NewValue);//Update Font border thickness
            }
        }

        /// <summary>
        /// Font Color Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ceFontColor_ColorChanged(object sender, EventArgs e)
        {
            if (ccircleControl != null)
            {
                System.Windows.Media.Color mb = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(ceFontColor.Color);
                this.ccircleControl.LineScaleTextForeground = new System.Windows.Media.SolidColorBrush(mb);
                this._properties.FontColor = this.ccircleControl.LineScaleTextForeground; //Update Font forgrond color
            }
        }
        /// <summary>
        /// Stroke Color Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ceStrokeColor_ColorChanged(object sender, EventArgs e)
        {
            if (ccircleControl != null)
            {
                System.Windows.Media.Color mb = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(ceStrokeColor.Color);
                this.ccircleControl.ShapeStrokeColor = new System.Windows.Media.SolidColorBrush(mb);
                this._properties.StrokeColor = this.ccircleControl.ShapeStrokeColor; //Update Storke color
            }
        }
        /// <summary>
        /// Border Color Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ceBorderColor_ColorChanged(object sender, EventArgs e)
        {
            if (ccircleControl != null)
            {
                System.Windows.Media.Color mb = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(ceBorderColor.Color);
                this.ccircleControl.LineScaleColor = new System.Windows.Media.SolidColorBrush(mb);
                this._properties.BorderColor = this.ccircleControl.LineScaleColor; //Update Border Color
            }
        }
        /// <summary>
        /// Background Color Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ceBackgroundColor_ColorChanged(object sender, EventArgs e)
        {
            if (ccircleControl != null)
            {
                System.Windows.Media.Color mb = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(ceBackgroundColor.Color);
                this.ccircleControl.ShapeBackground = new System.Windows.Media.SolidColorBrush(mb);
                this._properties.BackgroundColor = this.ccircleControl.ShapeBackground;//Update Background color
            }
        }
        /// <summary>
        /// Shape Style Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ccircleControl != null)
            {
                if (this.cbStyle.SelectedIndex == 1)
                {
                    this.ccircleControl.ShapeBackground = System.Windows.Media.Brushes.Transparent;
                    this.ceBackgroundColor.Enabled = false;
                    this._properties.Style = CStyles.Outline; //Update Style
                }
                else
                {
                    System.Windows.Media.Color mb = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(ceBackgroundColor.Color);
                    this.ccircleControl.ShapeBackground = new System.Windows.Media.SolidColorBrush(mb);
                    this.ceBackgroundColor.Enabled = true;
                    this._properties.Style = CStyles.Fill; //Update Style
                }
            }
        }
        /// <summary>
        /// Free Size Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFixSize_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ccircleControl != null)
            {
                if (this.chkFixSize.Checked)
                {
                    this.ccircleControl.CanExpand = System.Windows.Visibility.Visible;
                    this._properties.IsFixSize = true;
                }
                else
                {
                    this.ccircleControl.CanExpand = System.Windows.Visibility.Collapsed;
                    this._properties.IsFixSize = false;
                }
            }
        }
        /// <summary>
        /// Show Border Selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkShowBorder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ccircleControl != null)
            {
                if (this.chkShowBorder.Checked)
                {
                    this.ccircleControl.ShowBounder = System.Windows.Visibility.Visible;
                    this._properties.ShowBorder = true;
                }
                else
                {
                    this.ccircleControl.ShowBounder = System.Windows.Visibility.Collapsed;
                    this._properties.ShowBorder = false;
                }
            }
        }
        #endregion

        /// <summary>
        /// Select Marker Template with grid doublie click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridMarkTemplateView1_DoubleClick(object sender, EventArgs e)
        {
            this.SelectMarkerTemplate();
        }
        /// <summary>
        /// Select Marker Template Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.SelectMarkerTemplate();
        }
        private void SelectMarkerTemplate()
        {
            if (this.gridMarkTemplateView1.FocusedRowHandle > -1)
            {
                DataRow drSelectedRow
                    = this.gridMarkTemplateView1.GetDataRow(this.gridMarkTemplateView1.FocusedRowHandle);
                this.cbMargin.EditValue = drSelectedRow["SHAPE"];
                switch (this.cbMargin.EditValue.ToString())
                {
                    case "C": this._properties.Shape = CShapeControl.Shapes.Circumscribed; break;
                    case "M": this._properties.Shape = CShapeControl.Shapes.Microlobulated; break;
                    case "O": this._properties.Shape = CShapeControl.Shapes.Obscured; break;
                    case "I": this._properties.Shape = CShapeControl.Shapes.Indistinct; break;
                    case "S": this._properties.Shape = CShapeControl.Shapes.Spiculated; break;                                       
                }
                //Set Style and Background color(fill)
                switch (drSelectedRow["STYLE"].ToString())
                {
                    case "F":
                        this.ceBackgroundColor.Color = Color.FromName(drSelectedRow["FILL_COLOR"].ToString());
                        this._properties.BackgroundColor = new System.Windows.Media.SolidColorBrush(Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(Color.FromName(drSelectedRow["FILL_COLOR"].ToString())));
                        this._properties.Style = CStyles.Fill;
                        this.cbStyle.SelectedIndex = 0; break;
                    case "O":
                        this.ceBackgroundColor.Color = Color.Transparent;
                        this._properties.BackgroundColor = new System.Windows.Media.SolidColorBrush(Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(Color.Transparent));
                        this._properties.Style = CStyles.Outline;
                        this.cbStyle.SelectedIndex = 1; break;
                }
                this.ceBorderColor.Color = Color.FromName(drSelectedRow["BORDER_COLOR"].ToString());
                this._properties.BorderColor = new System.Windows.Media.SolidColorBrush(Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(Color.FromName(drSelectedRow["BORDER_COLOR"].ToString())));
                this.ceFontColor.Color = Color.FromName(drSelectedRow["FONT_COLOR"].ToString());
                this._properties.FontColor = new System.Windows.Media.SolidColorBrush(Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(Color.FromName(drSelectedRow["FONT_COLOR"].ToString())));                
                this.ceStrokeColor.Color = Color.FromName(drSelectedRow["STROKE_COLOR"].ToString());
                this._properties.StrokeColor = new System.Windows.Media.SolidColorBrush(Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromDrawingColor(Color.FromName(drSelectedRow["STROKE_COLOR"].ToString())));                                
                //Set Diameter
                this.speDiameter.EditValue = Convert.ToInt32(drSelectedRow["DIMENSION"]);
                this._properties.Diameter = Convert.ToInt32(drSelectedRow["DIMENSION"]);
                //Set Unit
                switch (drSelectedRow["UNIT"].ToString())
                {
                    case "P":
                        this._properties.Unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Pixel;
                        this.cbUnit.SelectedIndex = 0; 
                        break;
                    case "M":
                        this._properties.Unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Mm;
                        this.cbUnit.SelectedIndex = 1; 
                        break;
                    case "C":
                        this._properties.Unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Cm;
                        this.cbUnit.SelectedIndex = 2; 
                        break;
                    case "I":
                        this._properties.Unit = EnvisionBreastControl.Lib.Cores.Enumulator.Units.Inch;
                        this.cbUnit.SelectedIndex = 3; 
                        break;
                }
                this.speFontSize.EditValue = Convert.ToInt32(drSelectedRow["FONT_SIZE"]);
                this._properties.FontSize = Convert.ToInt32(drSelectedRow["FONT_SIZE"]);
                this.speBorderThickness.EditValue = Convert.ToInt32(drSelectedRow["THICKNESS"]);
                this._properties.BorderThickness = Convert.ToInt32(drSelectedRow["THICKNESS"]);
                this.feFontFamily.EditValue = drSelectedRow["FONT_FAMILY"].ToString();
                this._properties.FontFamily = drSelectedRow["FONT_FAMILY"].ToString();
                //Set Can Resize
                if (drSelectedRow["CAN_RESIZE"].ToString() == "Y")
                {
                    this.chkFixSize.Checked = true;
                    this._properties.IsFixSize = true;
                }
                else
                {
                    this.chkFixSize.Checked = false;
                    this._properties.IsFixSize = false;
                }
                //Set Show Border
                if (drSelectedRow["SHOW_BORDER"].ToString() == "Y")
                {
                    this.chkShowBorder.Checked = true;
                    this._properties.ShowBorder = true;
                }
                else
                {
                    this.chkShowBorder.Checked = false;
                    this._properties.ShowBorder = false;
                }
            }
        }
        /// <summary>
        /// Close Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// Save To Profile template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveToProfile_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.popUpSaveDialog != null)
            {
                string msg_result = myMsg.ShowAlert("UID6041", this.language);
                if (msg_result == "2")
                {
                    DialogResult result = this.popUpSaveDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        ProcessAddMGBreastMarkTemplate processAddMGBreastMarkTemplate = new ProcessAddMGBreastMarkTemplate();
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.BORDER_COLOR = this.ceBorderColor.Color.Name;
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.CAN_RESIZE = this.chkFixSize.Checked == true ? "Y" : "N";
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.CREATED_BY = this.empId;
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.DIMENSION = Convert.ToInt32(this.speDiameter.EditValue);
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.EMP_ID = this.empId;
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.FILL_COLOR = this.ceBackgroundColor.Color.Name;
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.FONT_COLOR = this.ceFontColor.Color.Name;
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.FONT_FAMILY = (string)this.feFontFamily.EditValue;
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.FONT_SIZE = Convert.ToInt32(this.speFontSize.EditValue);
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.ORG_ID = this.orgId;
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.SHAPE = (string)this.cbMargin.EditValue;
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.SHOW_BORDER = this.chkShowBorder.Checked == true ? "Y" : "N";
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.STROKE_COLOR = this.ceStrokeColor.Color.Name;
                        switch (this.cbStyle.EditValue.ToString())
                        {
                            case "Fill": processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.STYLE = "F"; break;
                            case "Outline": processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.STYLE = "O"; break;
                        }
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.THICKNESS = Convert.ToInt32(this.speBorderThickness.EditValue);
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.TPL_NAME = this.popUpSaveDialog.TemplateName;
                        switch (this.cbUnit.EditValue.ToString())
                        {
                            case "Pixel": processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.UNIT = "P"; break;
                            case "Mm": processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.UNIT = "M"; break;
                            case "Cm": processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.UNIT = "C"; break;
                            case "Inch": processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.UNIT = "I"; break;
                        }
                        processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.IS_DEFAULT = this.popUpSaveDialog.IsDefault == true ? "Y" : "N";
                        processAddMGBreastMarkTemplate.Invoke();
                        //Update Mark as Default
                        if (this.popUpSaveDialog.IsDefault)
                        {
                            if (processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.TPL_ID > 0)
                            {
                                ProcessUpdateMGBreastMarkTemplate processUpdateMGBreastMarkTemplate = new ProcessUpdateMGBreastMarkTemplate();
                                processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.TPL_ID = processAddMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.TPL_ID;
                                processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.EMP_ID = this.empId;
                                processUpdateMGBreastMarkTemplate.MG_BREASTMARKTEMPLATE.IS_DEFAULT = "Y";
                                processUpdateMGBreastMarkTemplate.Mode = 2;
                                processUpdateMGBreastMarkTemplate.Invoke();
                            }
                        }
                        this.LoadMarkTemplate();
                    }
                    else
                    {

                    }
                }
            }
        }

        /// <summary>
        /// First Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popupProperties_Load(object sender, EventArgs e)
        {
            this.popUpSaveDialog = new popupSaveDialog();
        }
        /// <summary>
        /// Load Mark Template
        /// </summary>
        private void LoadMarkTemplate()
        {
            ProcessSelectMGBreastMarkTemplate processor = new ProcessSelectMGBreastMarkTemplate();
            processor.MG_BREASTMARKTEMPLATE.EMP_ID = this.empId;
            processor.MG_BREASTMARKTEMPLATE.ORG_ID = this.orgId;
            processor.Invoke();
            this.dsMarkTemplate = processor.Result;
            this.gridMarkTemplateControl1.DataSource = this.dsMarkTemplate.Tables[0];
            this.tbTemplateName.DataBindings.Clear();
            this.tbTemplateName.DataBindings.Add("TEXT", this.dsMarkTemplate.Tables[0], "TPL_NAME");
        }
        /// <summary>
        /// This method use to initialize editor
        /// </summary>
        private void InitializeEditor()
        {
            //Set Unit ComboBox
            this.cbUnit.Properties.Items.Add(EnvisionBreastControl.Lib.Cores.Enumulator.Units.Pixel);
            this.cbUnit.Properties.Items.Add(EnvisionBreastControl.Lib.Cores.Enumulator.Units.Mm);
            this.cbUnit.Properties.Items.Add(EnvisionBreastControl.Lib.Cores.Enumulator.Units.Cm);
            this.cbUnit.Properties.Items.Add(EnvisionBreastControl.Lib.Cores.Enumulator.Units.Inch);
            //Set Style ComboBox
            this.cbStyle.Properties.Items.Add(CStyles.Fill);
            this.cbStyle.Properties.Items.Add(CStyles.Outline);

            this.cbStyle.SelectedIndex = 0;
            this.cbUnit.SelectedIndex = 0;
            this.cbMargin.SelectedIndex = 0;
        }
        /// <summary>
        /// This method use to set default properties
        /// </summary>
        private void SetProperties()
        {
            if (this.ccircleControl != null)
            {
                //this._properties = null;
                if (propertyMode == PropertyModes.Default)
                    this._properties = new CProperties();
                else if (propertyMode == PropertyModes.Template)
                {
                    this._properties = new CProperties();
                    this.LoadDefaultTemplateProperties(ref _properties);
                    return;
                }
                //Set property to control
                this.ccircleControl.Diameter = this._properties.Diameter;
                this.ccircleControl.ShapeStrokeThickness = this._properties.BorderThickness;
                this.ccircleControl.ShapeStrokeColor = this._properties.StrokeColor;
                this.ccircleControl.LineScaleColor = this._properties.BorderColor;
                this.ccircleControl.OvalWidth = this._properties.Diameter * 0.8;
                this.ccircleControl.Shape = CShapeControl.Shapes.Circumscribed;
                if (this._properties.Style == CStyles.Fill)
                    this.ccircleControl.ShapeBackground = this._properties.BackgroundColor;
                else
                    this.ccircleControl.ShapeBackground = System.Windows.Media.Brushes.Transparent;
                this.ccircleControl.LineScaleTextFontFamily = new System.Windows.Media.FontFamily(_properties.FontFamily);
                this.ccircleControl.LineScaleTextFontSize = this._properties.FontSize;
                if (this._properties.ShowBorder)
                    this.ccircleControl.ShowBounder = System.Windows.Visibility.Visible;
                else
                    this.ccircleControl.ShowBounder = System.Windows.Visibility.Collapsed;

                if (!this._properties.IsFixSize)
                    this.ccircleControl.CanExpand = System.Windows.Visibility.Visible;
                else
                    this.ccircleControl.CanExpand = System.Windows.Visibility.Collapsed;
                this.ccircleControl.Margin = new System.Windows.Thickness(-this.ccircleControl.Diameter, -this.ccircleControl.Diameter, 0, 0);
                this.ccircleControl.Unit = this._properties.Unit;
                this.ccircleControl.LineScaleTextForeground = this._properties.FontColor;
                //Set property to editor
                this.cbStyle.EditValue = this._properties.Style.ToString();
                this.cbUnit.EditValue = this._properties.Unit.ToString();
                this.ceBackgroundColor.EditValue = this._properties.BackgroundColor.ToString();
                this.ceStrokeColor.EditValue = this._properties.StrokeColor.ToString();
                this.ceBorderColor.EditValue = this._properties.BorderColor.ToString();
                this.speBorderThickness.EditValue = this._properties.BorderThickness;
                this.speDiameter.EditValue = this._properties.Diameter;
                this.speFontSize.EditValue = this._properties.FontSize;
                this.feFontFamily.EditValue = this._properties.FontFamily;
                this.chkFixSize.Checked = !this._properties.IsFixSize;
                this.chkShowBorder.Checked = this._properties.ShowBorder;
                this.ceFontColor.EditValue = this._properties.FontColor.ToString();
                switch (this._properties.Shape)
                {
                    case CShapeControl.Shapes.Circumscribed: this.cbMargin.EditValue = "C"; break;
                    case CShapeControl.Shapes.Microlobulated: this.cbMargin.EditValue = "M"; break;
                    case CShapeControl.Shapes.Obscured: this.cbMargin.EditValue = "O"; break;
                    case CShapeControl.Shapes.Indistinct: this.cbMargin.EditValue = "I"; break;
                    case CShapeControl.Shapes.Spiculated: this.cbMargin.EditValue = "S"; break;                
                }
            }
        }
        /// <summary>
        /// Show Dialog with template
        /// </summary>
        /// <param name="isLoadTemplate"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(bool isLoadTemplate)
        {
            if (isLoadTemplate)
            {
                if(dsMarkTemplate == null)
                    this.LoadMarkTemplate();
                this.SetProperties();
                this.propertyMode = PropertyModes.Template;
                this.SetProperties();
            }
            else
            {
                this.propertyMode = PropertyModes.Default;
                this.SetProperties();
            }
            return this.ShowDialog();
        }
        /// <summary>
        /// Show Dialog with template and original properties
        /// </summary>
        /// <param name="isLoadTemplate"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(bool isLoadTemplate, CProperties originalProperties)
        {
            if (isLoadTemplate)
            {
                if (dsMarkTemplate == null)
                    this.LoadMarkTemplate();
                this.propertyMode = PropertyModes.Loader;
                this._properties = originalProperties;
                this.LoadProperties();
            }
            else
            {
                this.propertyMode = PropertyModes.Loader;
                this._properties = originalProperties;
                this.LoadProperties();
            }
            return this.ShowDialog();
        }
        /// <summary>
        /// Load properties form original
        /// </summary>
        private void LoadProperties()
        {
            if (this._properties == null)
                this._properties = new CProperties();
            //Shape
            switch (this._properties.Shape)
            {
                case CShapeControl.Shapes.Circumscribed: this.cbMargin.SelectedIndex = 0; break;
                case CShapeControl.Shapes.Microlobulated: this.cbMargin.SelectedIndex = 1; break;
                case CShapeControl.Shapes.Obscured: this.cbMargin.SelectedIndex = 2; break;
                case CShapeControl.Shapes.Indistinct: this.cbMargin.SelectedIndex = 3; break;
                case CShapeControl.Shapes.Spiculated: this.cbMargin.SelectedIndex = 4; break;
                case CShapeControl.Shapes.Calcification: this.cbMargin.SelectedIndex = 5; break;
                case CShapeControl.Shapes.Angular: this.cbMargin.SelectedIndex = 0; break;
                default: this.cbMargin.SelectedIndex = 0; break;
            }
            //Style
            switch (this._properties.Style)
            {
                case CStyles.Fill: this.cbStyle.SelectedIndex = 0; break;
                case CStyles.Outline: this.cbStyle.SelectedIndex = 1; break;
            }
            //Unit
            switch (this._properties.Unit)
            {
                case EnvisionBreastControl.Lib.Cores.Enumulator.Units.Pixel: this.cbUnit.SelectedIndex = 0; break;
                case EnvisionBreastControl.Lib.Cores.Enumulator.Units.Mm: this.cbUnit.SelectedIndex = 1; break;
                case EnvisionBreastControl.Lib.Cores.Enumulator.Units.Cm: this.cbUnit.SelectedIndex = 2; break;
                case EnvisionBreastControl.Lib.Cores.Enumulator.Units.Inch: this.cbUnit.SelectedIndex = 3; break;
            }
            this.speBorderThickness.EditValue = this._properties.BorderThickness;
            this.speDiameter.EditValue = this._properties.Diameter;
            this.speFontSize.EditValue = this._properties.FontSize;
            this.feFontFamily.EditValue = this._properties.FontFamily;
            //Background color
            System.Windows.Media.Color cl = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(this._properties.BackgroundColor.ToString());
            this.ceBackgroundColor.Color = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromMediaColor(cl);
            System.Windows.Media.Color cl1 = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(this._properties.BorderColor.ToString());
            this.ceBorderColor.Color = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromMediaColor(cl1);
            System.Windows.Media.Color cl2 = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(this._properties.StrokeColor.ToString());
            this.ceStrokeColor.Color = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromMediaColor(cl2);
            System.Windows.Media.Color cl3 = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(this._properties.FontColor.ToString());
            this.ceFontColor.Color = Envision.NET.Mammogram.ResultEntry.BIRAD.Helper.ColorHelper.ColorFromMediaColor(cl3);
        }
        /// <summary>
        /// Load Default marker form marker template
        /// </summary>
        /// <param name="properties"></param>
        private void LoadDefaultTemplateProperties(ref CProperties properties)
        {
            if (this.dsMarkTemplate != null)
            {
                DataRow[] dr = this.dsMarkTemplate.Tables[0].Select("IS_DEFAULT = 'Y'");
                if (dr.Length > 0)
                {
                    this.gridMarkTemplateView1.FocusedRowHandle = this.dsMarkTemplate.Tables[0].Rows.IndexOf(dr[0]);
                    this.SelectMarkerTemplate();
                }
                else
                {
                    this.propertyMode = PropertyModes.Default;
                    this.SetProperties();
                }
            }
        }
        /// <summary>
        /// This method use to get properties
        /// </summary>
        /// <returns></returns>
        public CProperties GetProperties(bool useTemplate)
        {
            if (useTemplate)
            {
                if (dsMarkTemplate == null)
                    this.LoadMarkTemplate();
                this.SetProperties();
                this.propertyMode = PropertyModes.Template;
                this.SetProperties();
            }
            else
            {
                this.propertyMode = PropertyModes.Default;
                this.SetProperties();
            }

            return this._properties;
        }
    }
}