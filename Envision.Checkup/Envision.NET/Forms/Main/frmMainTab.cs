using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using RIS.Common.UtilityClass;
using RIS.Common.DBConnection;
using UUL.ControlFrame.Controls;
using RIS.BusinessLogic;
using RIS.Forms.Main.Trees;
using RIS.Forms.GBLMessage;
using RIS.Common.Common;
namespace RIS.Forms.Main
{
    public partial class frmMainTab : Form
    {

        DBUtility dbu = new DBUtility();
        MyMessageBox msg = new MyMessageBox();
        private UUL.ControlFrame.Controls.TabControl CloseControl;

        public frmMainTab()
        {
            
           
        }

        public frmMainTab(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            CloseControl = clsCtl;
        }

        private void MyLookup_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }

        public void MyForms()
        {
            #region oldCode
            //ProcessGetGBLFavourite fav2 = new ProcessGetGBLFavourite("2");
            //fav2.Invoke();
            //DataTable dt2 = fav2.ResultSet.Tables[0];
            //int j = 0;

            //ProcessGetGBLFavourite fav3 = new ProcessGetGBLFavourite("3");
            //fav3.Invoke();
            //DataTable dt = fav3.ResultSet.Tables[0];
            ////treeView1.Nodes.Clear();
            //int i=0;
            //while (i < dt.Rows.Count)
            //{
            //    if (dt.Rows[i]["IS_ACTIVE"].ToString() == "A")
            //    {
            //        j = 0;
            //        while(j<dt2.Rows.Count)
            //        {
            //            string str1 = dt2.Rows[j]["SUBMENU_ID"].ToString();
            //            string str2 = dt.Rows[i]["SUBMENU_ID"].ToString();
            //            if (dt2.Rows[j]["SUBMENU_ID"].ToString() == dt.Rows[i]["SUBMENU_ID"].ToString())
            //            {
            //                TreeNode newNode = new TreeNode(dt2.Rows[j]["SUBMENU_NAME_USER"].ToString());
            //                newNode.Tag = dt2.Rows[j]["MENU_NAMESPACE"].ToString() + "." + dt2.Rows[j]["SUBMENU_CLASS_NAME"].ToString();

            //                treeView4.Nodes.Add(newNode);



            //            }
            //            j++;
            //        }
            //    }
            //    i++;
            //}
            #endregion

            ProcessGetGBLMymenu gm = new ProcessGetGBLMymenu();
            gm.GBLMymenu.EMP_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
            gm.Invoke();

            DataTable dt = gm.Result.Tables[0];

            treeView4.Nodes.Clear();
            treeView3.Nodes.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                TreeNode newNode = new TreeNode(dr["SUBMENU_NAME_USER"].ToString());
                newNode.Tag = dr["MENU_NAMESPACE"].ToString() + "." + dr["SUBMENU_CLASS_NAME"].ToString();

                treeView4.Nodes.Add(newNode);
            }
        }


       
        private void frmMainTab_Load(object sender, EventArgs e)
        {
            
            MyForms();
            
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
           // SubMenuTree stree = new SubMenuTree(CloseControl);
            //stree.form(this.treeView1.SelectedNode.Tag.ToString(), this.treeView1.SelectedNode.Text.ToString());
        }




        private void treeView4_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            treeView4.ForeColor = Color.Blue;
            //treeView4.SelectedNode.ForeColor = Color.Blue;
            //treeView4.SelectedNode.ForeColor = Color.Blue;
        }

        private void treeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SubMenuTree stree = new SubMenuTree(CloseControl);
            new GBLEnvVariable().CurrentTag = this.treeView4.SelectedNode.Tag.ToString();
            new GBLEnvVariable().CurrentText = this.treeView4.SelectedNode.Text.ToString();
            stree.form(this.treeView4.SelectedNode.Tag.ToString(), this.treeView4.SelectedNode.Text.ToString());
            CloseControl.SelectedTab.Tag = this.treeView4.SelectedNode.Tag.ToString();
        }

        private void treeView4_DoubleClick(object sender, EventArgs e)
        {
            SubMenuTree stree = new SubMenuTree(CloseControl);
            new GBLEnvVariable().CurrentTag = this.treeView4.SelectedNode.Tag.ToString();
            new GBLEnvVariable().CurrentText = this.treeView4.SelectedNode.Text.ToString();
            stree.form(this.treeView4.SelectedNode.Tag.ToString(), this.treeView4.SelectedNode.Text.ToString());
            CloseControl.SelectedTab.Tag = this.treeView4.SelectedNode.Tag.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            treeView4.Nodes.Clear();
            MyForms();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SubMenuTree stree = new SubMenuTree(CloseControl);
            stree.form("RIS.Forms.Admin.GBL_LF01", "Favourite");
        }
        
       
        
       
    }
}