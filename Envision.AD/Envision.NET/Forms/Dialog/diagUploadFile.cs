using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.Operational.Scanner;
using Envision.WebService;
using Miracle.Util;
using DevExpress.XtraGrid;
using System.Drawing;
using Envision.Operational.Scanner.Common;

namespace Envision.NET.Forms.Dialog
{
    public partial class diagUploadFile : Form
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private WiaScanner wia_scanner;
        private ScanConfig scan_config = new ScanConfig();

        private List<string> image_extensions = new List<string>() { "bmp", "tif", "tiff", "gif", "jpeg", "jpg", "png" };
        private bool view_only = true;

        public DataView OrderImages { get; private set; }

        public diagUploadFile(DataView orderImages, bool viewOnly)
        {
            InitializeComponent();

            OrderImages = orderImages;
            view_only = viewOnly;
        }

        private void diagUoloadFile_Load(object sender, EventArgs e) {
            initClass();
        }
        private void diagUploadFile_Shown(object sender, EventArgs e) { initForm(); }

        private void initClass()
        {
            if (view_only)
            {
                pnlUploadFile.Visible = false;
                pnlControl.Visible = false;
            }
            else
            {
                wia_scanner = new WiaScanner();
                pnlUploadFile.Visible = true;
                pnlControl.Visible = true;

                if (wia_scanner.ScannerDeviceList.Count == 0)
                {
                    btnScan.Enabled = false;
                    if (!view_only)
                    {
                        this.DialogResult = DialogResult.Abort;
                        this.Close();
                        return;
                    }
                }
                else
                {
                    btnScan.Enabled = true;

                    loadDefaultControlScanner();
                    loadDefaultControlPaperKind();
                    loadDefaultControlColorFormat();
                }
            }

            addColumnsGrid();
            addFormatConditionGird();
        }
        private void initForm()
        {
            grid.DataSource = OrderImages.ToTable().DefaultView;
            view.BestFitColumns();

            if (OrderImages.Count > 0)
            {
                List<string> filter_extensions = new List<string>();

                image_extensions.ForEach(delegate(string x)
                {
                    filter_extensions.Add(string.Format("IMAGE_NAME like '%{0}'", x));
                });

                OrderImages.RowFilter = string.Join(" or ", filter_extensions.ToArray());

                if (OrderImages.Count > 0)
                    openFile(OrderImages[OrderImages.Count - 1]["IMAGE_NAME"].ToString());

                OrderImages.RowFilter = string.Empty;
            }
        }

        #region Grid
        private void addColumnsGrid()
        {
            view.Columns.Add(new GridColumn() { FieldName = "btnDelete", Caption = " " });
            view.Columns.Add(new GridColumn() { FieldName = "IMAGE_NAME", Caption = "Image Name" });
            view.Columns.Add(new GridColumn() { FieldName = "IS_DELETED", Caption = " " });

            int length = 0;

            foreach (GridColumn col in view.Columns)
            {
                col.VisibleIndex = length++;
                col.Visible = true;
                col.OptionsColumn.AllowEdit = false;
                col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }

            if (view.Columns.ColumnByFieldName("IS_DELETED") != null)
            {
                view.Columns["IS_DELETED"].Visible = false;
                view.Columns["IS_DELETED"].OptionsColumn.ShowInCustomizationForm = false;
            }

            if (view.Columns.ColumnByFieldName("btnDelete") != null)
            {
                RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
                btnDelete.AutoHeight = false;
                btnDelete.ButtonsStyle = BorderStyles.Simple;
                btnDelete.TextEditStyle = TextEditStyles.HideTextEditor;
                btnDelete.Buttons[0].Caption = string.Empty;
                btnDelete.Buttons[0].Kind = ButtonPredefines.Delete;
                btnDelete.Click += new EventHandler(view_btnDelete_Click);
                view.Columns["btnDelete"].MinWidth = 25;
                view.Columns["btnDelete"].MaxWidth = 25;
                view.Columns["btnDelete"].ColumnEdit = btnDelete;
                view.Columns["btnDelete"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
                view.Columns["btnDelete"].OptionsColumn.AllowSort = DefaultBoolean.False;
                view.Columns["btnDelete"].OptionsColumn.AllowEdit = true;
                view.Columns["btnDelete"].OptionsFilter.AllowFilter = false;
                view.Columns["btnDelete"].OptionsFilter.AllowAutoFilter = false;
            }

            if (view.Columns.ColumnByFieldName("CREATED_ON") != null)
            {
                view.Columns["CREATED_ON"].MinWidth = 95;
                view.Columns["CREATED_ON"].MaxWidth = 95;
                view.Columns["CREATED_ON"].DisplayFormat.FormatType = FormatType.Custom;
                view.Columns["CREATED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                view.Columns["CREATED_ON"].OptionsFilter.AllowAutoFilter = false;
                view.Columns["CREATED_ON"].OptionsFilter.AllowFilter = false;
            }
        }
        private void addFormatConditionGird()
        {
            view.FormatConditions.Clear();

            view.FormatConditions.Add(new StyleFormatCondition(FormatConditionEnum.Equal, view.Columns["IS_DELETED"], "IS_DELETED", "Y") { ApplyToRow = true });
            view.FormatConditions["IS_DELETED"].Appearance.ForeColor = Color.Red;
        }

        private void view_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow dr = view.GetFocusedDataRow();

            if (dr != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        switch (e.Clicks)
                        {
                            case 1:
                                openFile(dr["IMAGE_NAME"].ToString());
                                break;
                        }
                        break;
                }
            }
        }

        private void view_btnDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = view.GetFocusedDataRow();

            if (dr == null)
                return;

            if (Convert.ToInt32(dr["ORDER_IMAGE_ID"]) == 0)
            {
                new EnvisionWebService(env.WebServiceIP).DeleteFile(string.Format("{0}{1}", env.ScannedImagePath, dr["IMAGE_NAME"].ToString()));

                dr.Delete();
            }
            else
            {
                dr.BeginEdit();
                dr["IS_DELETED"] = "Y";
                dr.EndEdit();
            }
        }
        #endregion

        private void lookUpScanner_EditValueChanged(object sender, EventArgs e)
        {
            ScannerDevice scanner_device = wia_scanner.ScannerDeviceList.Find(x => x.DeviceId.Equals(lookUpScanner.EditValue.ToString()));

            if (scanner_device == null)
                return;

            ScannerItem scanner_item = null;

            scanner_item = null;
            scanner_item = scanner_device.Items.Find(x => x.ItemId == WiaScannerPropertyName.HorizontalResolution);

            cmbResolutionDPI.Enabled = false;

            if (!(scanner_item == null || scanner_item.IsReadOnly))
            {
                switch (scanner_item.SubType)
                {
                    case ScannerItemSubType.Range:
                        cmbResolutionDPI.Enabled = true;

                        for (int i = scanner_item.SubTypeMin; i <= scanner_item.SubTypeMax; i = i + scanner_item.SubTypeStep)
                            cmbResolutionDPI.Properties.Items.Add(i);

                        cmbResolutionDPI.EditValue = cmbResolutionDPI.Properties.Items.IndexOf(scan_config.ResolutionDPI) == -1
                            ? scanner_item.SubTypeDefault
                            : scan_config.ResolutionDPI;
                        break;
                    case ScannerItemSubType.List:
                        cmbResolutionDPI.Enabled = true;
                        cmbResolutionDPI.Properties.Items.AddRange(scanner_item.SubTypeValues);

                        cmbResolutionDPI.EditValue = cmbResolutionDPI.Properties.Items.IndexOf(scan_config.ResolutionDPI) == -1
                            ? scanner_item.SubTypeDefault
                            : scan_config.ResolutionDPI;
                        break;
                    case ScannerItemSubType.Flag:
                        cmbResolutionDPI.EditValue = scanner_item.SubTypeDefault;
                        break;
                    case ScannerItemSubType.Unspecified:
                    default:
                        break;
                }
            }

            scanner_item = null;
            scanner_item = scanner_device.Items.Find(x => x.ItemId == WiaScannerPropertyName.Brightness);

            spinBrightness.Enabled =
            trackBarBrightness.Enabled = false;

            if (!(scanner_item == null || scanner_item.IsReadOnly))
            {
                switch (scanner_item.SubType)
                {
                    case ScannerItemSubType.Range:
                        spinBrightness.Enabled =
                        trackBarBrightness.Enabled = true;
                        spinBrightness.Properties.MaxValue =
                        trackBarBrightness.Properties.Maximum = scanner_item.SubTypeMax;
                        spinBrightness.Properties.MinValue =
                        trackBarBrightness.Properties.Minimum = scanner_item.SubTypeMin;
                        spinBrightness.Properties.Increment =
                        trackBarBrightness.Properties.SmallChange = scanner_item.SubTypeStep;
                        spinBrightness.EditValue =
                        trackBarBrightness.EditValue = scan_config.Brightness;
                        break;
                    case ScannerItemSubType.List:
                    case ScannerItemSubType.Flag:
                        trackBarBrightness.Value =
                        trackBarBrightness.Value = scanner_item.SubTypeDefault;
                        break;
                    case ScannerItemSubType.Unspecified:
                    default:
                        break;
                }
            }

            scanner_item = null;
            scanner_item = scanner_device.Items.Find(x => x.ItemId == WiaScannerPropertyName.Contrast);

            spinContrast.Enabled =
            trackBarContrast.Enabled = false;

            if (!(scanner_item == null || scanner_item.IsReadOnly))
            {
                switch (scanner_item.SubType)
                {
                    case ScannerItemSubType.Range:
                        spinContrast.Enabled =
                        trackBarContrast.Enabled = true;
                        spinContrast.Properties.MaxValue =
                        trackBarContrast.Properties.Maximum = scanner_item.SubTypeMax;
                        spinContrast.Properties.MinValue =
                        trackBarContrast.Properties.Minimum = scanner_item.SubTypeMin;
                        spinContrast.Properties.Increment =
                        trackBarContrast.Properties.SmallChange = scanner_item.SubTypeStep;
                        spinContrast.EditValue =
                        trackBarContrast.EditValue = scan_config.Contrast;
                        break;
                    case ScannerItemSubType.List:
                    case ScannerItemSubType.Flag:
                        spinContrast.Value =
                        trackBarContrast.Value = scanner_item.Value;
                        break;
                    case ScannerItemSubType.Unspecified:
                    default:
                        break;
                }
            }
        }
        private void trackBarBrightness_EditValueChanged(object sender, EventArgs e) { spinBrightness.Value = trackBarBrightness.Value; }
        private void spinBrightness_EditValueChanged(object sender, EventArgs e) { trackBarBrightness.Value = Convert.ToInt32(spinBrightness.Value); }
        private void trackBarContrast_EditValueChanged(object sender, EventArgs e) { spinContrast.Value = trackBarContrast.Value; }
        private void spinContrast_EditValueChanged(object sender, EventArgs e) { trackBarContrast.Value = Convert.ToInt32(spinContrast.Value); }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (openUploadFile.ShowDialog() == DialogResult.OK)
                uploadFile(openUploadFile.FileName);

            view.RefreshData();
            view.SelectRow(view.RowCount - 1);
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            List<byte[]> images_buffer = wia_scanner.Scan(
                lookUpScanner.EditValue.ToString(),
                cmbPaperKind.EditValue.ToString(),
                cmbColorFormat.EditValue.ToString(),
                Convert.ToInt32(cmbResolutionDPI.EditValue),
                Convert.ToInt32(spinBrightness.Value),
                Convert.ToInt32(spinContrast.Value));

            if (images_buffer.Count > 0)
            {
                foreach (byte[] buffer in images_buffer)
                    saveFileToServer(".jpg", buffer);
            }

            view.RefreshData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            OrderImages = ((DataView)grid.DataSource).ToTable().DefaultView;

            scan_config.DeviceId = lookUpScanner.EditValue.ToString();
            scan_config.PageKind = cmbPaperKind.EditValue.ToString();
            scan_config.ColorFormat = cmbColorFormat.EditValue.ToString();
            scan_config.ResolutionDPI = Convert.ToInt32(cmbResolutionDPI.EditValue);
            scan_config.Brightness = Convert.ToInt32(spinBrightness.Value);
            scan_config.Contrast = Convert.ToInt32(spinContrast.Value);

            DialogResult = DialogResult.OK;
        }

        private void openFile(string imageName)
        {
            string _url = string.Format("{0}/{1}", env.PacsUrl2, imageName);
            Uri uri = new Uri(_url);
            web.Url = uri;
        }
        private void uploadFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (!file.Exists)
                return;

            if (file.Length > 12000000)
            {
                MessageBox.Show("File maximum request length exceeded over 10 MB", "Upload File Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            byte[] buffer = null;

            try
            {
                using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            catch { }

            if (buffer == null)
                return;

            saveFileToServer(string.Format("_{0}", file.Name), buffer);
        }

        private string saveFileToServer(string fileName, byte[] fileIn)
        {
            string file_full_name = string.Format(
                CultureInfo.GetCultureInfo("th-TH"),
                "temp\\{0}\\{1:yyyyMMddHHmmssfff}{2}",
                Utilities.IPAddress().ToString().Replace('.', '_'),
                DateTime.Now,
                fileName);

            int index_extension = file_full_name.LastIndexOf('.') + 1;
            string file_extension = file_full_name.Substring(index_extension, file_full_name.Length - index_extension);

            if (image_extensions.Contains(file_extension))
            {
                EnvisionWebService ws = new EnvisionWebService(env.WebServiceIP);
                ws.SavePicture(string.Format("{0}{1}", env.ScannedImagePath, file_full_name), fileIn);

                openFile(file_full_name);

                Application.DoEvents();
            }
            else
                new EnvisionWebService(env.WebServiceIP).SaveFile(string.Format("{0}{1}", env.ScannedImagePath, file_full_name), fileIn);

            DataView dv = (DataView)grid.DataSource;
            DataRowView drv_new = dv.AddNew();
            drv_new.BeginEdit();
            drv_new["ORDER_IMAGE_ID"] = 0;
            drv_new["IMAGE_NAME"] = file_full_name;
            drv_new["IS_DELETED"] = "N";
            drv_new.EndEdit();

            view.BestFitColumns();

            return file_full_name;
        }

        private void loadDefaultControlScanner()
        {
            if (wia_scanner.ScannerDeviceList.Count > 0)
            {
                lookUpScanner.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Name", "Scanner", 20, FormatType.None, string.Empty, true, HorzAlignment.Default, ColumnSortOrder.None) });
                lookUpScanner.Properties.DisplayMember = "Name";
                lookUpScanner.Properties.ValueMember = "DeviceId";
                lookUpScanner.Properties.NullText = string.Empty;
                lookUpScanner.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                lookUpScanner.Properties.DataSource = wia_scanner.ScannerDeviceList;

                ScannerDevice scanner_device = wia_scanner.ScannerDeviceList.Find(x => x.DeviceId.Equals(scan_config.DeviceId));

                lookUpScanner.EditValue = scanner_device == null ? wia_scanner.ScannerDeviceList[0].DeviceId : scanner_device.DeviceId;
            }
        }
        private void loadDefaultControlPaperKind()
        {
            List<string> item = new List<string>(new string[] { "Default", "A4" });

            item.ForEach(x => cmbPaperKind.Properties.Items.Add(x));

            string value = item.Find(x => x == scan_config.PageKind);

            cmbPaperKind.EditValue = string.IsNullOrEmpty(value) ? item[0] : value;
        }
        private void loadDefaultControlColorFormat()
        {
            List<string> item = new List<string>(new string[] { "Color", "Grayscale" });

            item.ForEach(x => cmbColorFormat.Properties.Items.Add(x));

            string value = item.Find(x => x == scan_config.ColorFormat);

            cmbColorFormat.EditValue = string.IsNullOrEmpty(value) ? item[0] : value;
        }
    }
}