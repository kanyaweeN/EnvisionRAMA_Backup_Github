using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracle.Util;
using Envision.Common;
using Envision.Common.Linq;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
namespace Envision.NET.Forms.Main
{
    public partial class MasterForm : Form
    {
        private int menu_id;
        private DevExpress.Utils.WaitDialogForm dlg;
        private static GBLEnvVariable env = new GBLEnvVariable();
        protected List<GBL_SUBMENUOBJECT> objList = new List<GBL_SUBMENUOBJECT>();
        protected List<GBL_SUBMENUOBJECTLABEL> objLableList = new List<GBL_SUBMENUOBJECTLABEL>();

        public int Menu_ID
        {
            get { return menu_id; }
            set
            {
                menu_id = value;
                loadObjectLabel();
            }
        }

        public int      Submenu_ID              { get; set; }
        public int      Role_ID                 { get; set; }
        public string   Menu_Name_Class         { get; set; }
        public string   Menu_Name_User          { get; set; }
        public string   Menu_Namespace          { get; set; }
        public string   Menu_FullNamespace      { get; set; }
        public string   ReportingSerivce_URL    { get; set; }
        public string   ISOpenwebOutside        { get; set; } 

        public static int    OrderSubMenuID     { get; set; }
        public static string DefaultFontName    { get; set; }
        public static string DefaultFontSize    { get; set; }
        public static string DateTimeFormat     { get; set; }
        public static string TimeFormat         { get; set; }
        public static string CurrencyName       { get; set; }
        public static string CurrencySymbol     { get; set; }
        public static string CurrencyFormat     { get; set; }
        public static string DefaultSkinName    { get; set; }
        public static DataSet MenuInfo
        {
            get
            {
                ProcessGetGBLMenu process = new ProcessGetGBLMenu();
                DataSet menu = process.GetMenuEMP(env.UserID);
                return menu;
            }
        }

        public MasterForm()
        {
            InitializeComponent();
        }

        public void ShowWaitDialog()
        {
            Size s = new Size(250, 50);
            if (dlg != null)
                dlg.Close();
            dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", Menu_Name_User, s);
            env.DialogForm = dlg;
        }
        public void LabelWaitDialog(string waiting_label)
        {
            Size s = new Size(250, 50);
            if (dlg != null)
            {
                dlg.Close();
                dlg = new DevExpress.Utils.WaitDialogForm(waiting_label, Menu_Name_User, s);
                env.DialogForm = dlg;
            }
        }
        public void CloseWaitDialog() {
            if(dlg!=null) dlg.Close();
        }
        public virtual void ChangeLanguage() {
            if (objList.Count == 0) return;
            if (objLableList.Count == 0) return;
        }

        private void loadObjectLabel() {
            EnvisionDataContext db = new EnvisionDataContext();
            IQueryable<GBL_SUBMENUOBJECT> objQuery=from obj in db.GBL_SUBMENUOBJECTs select obj;
            IQueryable<GBL_SUBMENUOBJECTLABEL> objLabel = from lbl in db.GBL_SUBMENUOBJECTLABELs select lbl;

            IEnumerable<GBL_SUBMENUOBJECT> objQueryFrom = from obj in objQuery where obj.SUBMENU_ID == Submenu_ID select obj;
            objList = objQueryFrom.ToList();

            IEnumerable<GBL_SUBMENUOBJECTLABEL> objQueryLabel = from obj in objLabel where obj.SUBMENU_ID == Submenu_ID select obj;
            objLableList = objQueryLabel.ToList();
        }
        public void ShowWaitDialog(string msg, string title)
        {
            Size s = new Size(250, 50);
            if (dlg != null)
                dlg.Close();
            dlg = new DevExpress.Utils.WaitDialogForm(msg, title, s);
        }
        public void ShowWaitDialog(string msg, string title, Form parent)
        {
            Size s = new Size(250, 50);
            if (dlg != null)
                dlg.Close();
            dlg = new DevExpress.Utils.WaitDialogForm(msg, title, s, parent);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (dlg != null) dlg.Dispose();
            this.Dispose();
            System.GC.SuppressFinalize(this);
            System.GC.Collect();
            Miracle.Util.Utilities.FlushMemory();
        }
    }
}
