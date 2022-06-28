using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Envision.Plugin.DirectPrint
{
    public partial class dialogPrintersList : Form
    {
        public PrinterVariable PrinterSelected;
        public List<string> NamePageStyle { get; set; }

        public dialogPrintersList()
        {
            InitializeComponent();

            PrinterSelected = new PrinterVariable();
            NamePageStyle = new List<string>();
        }

        private void dialogPrintersList_Load(object sender, EventArgs e)
        {
            initForm();
            MaximumSize = MinimumSize = Size;
        }

        private void initForm()
        {
            foreach (string _item in PrinterSettings.InstalledPrinters)
            {
                cmbPrintersList.Properties.Items.Add(_item);
            }

            try
            {
                if (string.IsNullOrEmpty(PrinterSelected.PrinterName))
                {
                    cmbPrintersList.Text = new PrinterSettings().PrinterName;
                }
                else
                {
                    cmbPrintersList.Text = PrinterSelected.PrinterName;
                }
            }
            catch { }

            createButtonPageStyle();
        }
        private void createButtonPageStyle()
        {
            SimpleButton _btn;

            int _counter;

            if (NamePageStyle == null)
            {
                _btn = new SimpleButton();
                _btn.Name = "btnPageStyleDefault";
                _btn.Text = "Default";
                _btn.Dock = DockStyle.Fill;
                _btn.Click += new EventHandler(ButtonPageStyle_Click);

                layoutButton.Controls.Add(_btn, 0, 0);
            }
            else
            {
                _counter = 0;

                foreach (string _item in NamePageStyle)
                {
                    _btn = new SimpleButton();
                    _btn.Name = string.Format("btnPageStyle_{0:00}", _counter);
                    _btn.Text = _item;
                    _btn.Dock = DockStyle.Fill;
                    _btn.Click += new EventHandler(ButtonPageStyle_Click);

                    layoutButton.Controls.Add(_btn, 0, _counter);

                    _counter++;
                }
            }

            layoutButton.AutoSize = true;
        }

        protected void ButtonPageStyle_Click(object sender, EventArgs e)
        {
            PrinterSettings _print_setting;

            //string _paper_style;

            PrinterSelected.PrinterName = cmbPrintersList.Text;

            _print_setting = new PrinterSettings()
            {
                PrinterName = PrinterSelected.PrinterName
            };

            PrinterSelected.PaperStyle = ((SimpleButton)sender).Text;
            //_paper_style = ((Button)sender).Text;

            //foreach (PaperSize _item in _print_setting.PaperSizes)
            //{
            //    if (_item.PaperName == _paper_style)
            //    {
            //        PrinterSelected.PaperSize = _item;
            //        break;
            //    }
            //}

            DialogResult = DialogResult.OK;
        }
    }
}
