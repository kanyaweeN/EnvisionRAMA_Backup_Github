using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using RIS.Forms.GBLMessage;
using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Common.UtilityClass;
using RIS.Forms.Main;
namespace RIS.Forms.Admin
{
    public partial class GBL_LF01 : Form
    {
        DBUtility dbu = new DBUtility();
        MyMessageBox msg = new MyMessageBox();
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        
        public GBL_LF01(UUL.ControlFrame.Controls.TabControl clsCtl)
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

        private void FavouriteMenu()
        {
            ProcessGetGBLFavourite fav = new ProcessGetGBLFavourite("1");
            fav.Invoke();
            DataTable dt = fav.ResultSet.Tables[0];
            int i = 0;

            ProcessGetGBLFavourite fav2 = new ProcessGetGBLFavourite("2");
            fav2.Invoke();
            DataTable dt2 = fav2.ResultSet.Tables[0];
            int j = 0;

            ProcessGetGBLFavourite fav3 = new ProcessGetGBLFavourite("3");
            fav3.Invoke();
            DataTable dt3 = fav3.ResultSet.Tables[0];
            int k = 0;

            treeView3.Nodes.Clear();
            while (i < dt.Rows.Count)
            {
                TreeNode newNode = new TreeNode(dt.Rows[i]["MENU_NAME"].ToString());
                newNode.Tag = dt.Rows[i]["MENU_ID"].ToString();

                treeView3.Nodes.Add(newNode);

                j = 0;
                while (j < dt2.Rows.Count)
                {

                    if (dt.Rows[i]["MENU_ID"].ToString() == dt2.Rows[j]["MENU_ID"].ToString())
                    {
                        TreeNode newNode1 = new TreeNode(dt2.Rows[j]["SUBMENU_NAME_USER"].ToString());
                        newNode1.Tag = dt2.Rows[j]["SUBMENU_ID"].ToString();
                        treeView3.Nodes[i].Nodes.Add(newNode1);
                        k = 0;
                        while (k < dt3.Rows.Count)
                        {
                            if ((dt2.Rows[j]["SUBMENU_ID"].ToString() == dt3.Rows[k]["SUBMENU_ID"].ToString()) && (dt3.Rows[k]["IS_ACTIVE"].ToString() == "A"))
                            {
                                newNode1.Checked = true;
                            }

                            k++;
                        }
                    }

                    j++;
                }
                i++;
            }
        }



        private void Favourite_Load(object sender, EventArgs e)
        {
            FavouriteMenu();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                //--Save/Update user previlege information
                //--Check that previlege already set for this employee or not
                ProcessGetGBLFavourite fav3 = new ProcessGetGBLFavourite("3");
                fav3.Invoke();
                DataTable dt4 = fav3.ResultSet.Tables[0];


                if (dt4.Rows.Count == 0)
                {
                    //--Not created previously
                    int x = 0;
                    while (x < treeView3.Nodes.Count)
                    {
                        int y = 0;
                        while (y < treeView3.Nodes[x].Nodes.Count)
                        {
                            string stat = "I";
                            if (treeView3.Nodes[x].Nodes[y].Checked)
                            {
                                stat = "A";
                            }
                            ProcessAddMyMenu mymenu = new ProcessAddMyMenu(Convert.ToInt32(treeView3.Nodes[x].Nodes[y].Tag.ToString()), stat);
                            mymenu.Invoke();
                            y++;
                        }
                        x++;
                    }
                }
                else
                {
                    //--Already created
                    int x = 0;
                    while (x < treeView3.Nodes.Count)
                    {
                        int y = 0;
                        while (y < treeView3.Nodes[x].Nodes.Count)
                        {
                            string stat = "I";
                            if (treeView3.Nodes[x].Nodes[y].Checked)
                            {
                                stat = "A";
                            }

                            ProcessGetGBLFavourite fav5 = new ProcessGetGBLFavourite("3");
                            fav5.Invoke();
                            DataTable dt5 = fav3.ResultSet.Tables[0];
                            int kk = 0;
                            int found = 0;
                            while (kk < dt5.Rows.Count)
                            {
                                if (dt5.Rows[kk]["SUBMENU_ID"].ToString() == treeView3.Nodes[x].Nodes[y].Tag.ToString())
                                {
                                    found = 1;
                                }
                                kk++;
                            }
                            if (found == 1)
                            {
                                ProcessUpdateMyMenu upmy = new ProcessUpdateMyMenu(Convert.ToInt32(treeView3.Nodes[x].Nodes[y].Tag.ToString()), stat);
                                upmy.Invoke();
                            }
                            else if (found == 0)
                            {
                                ProcessAddMyMenu mm = new ProcessAddMyMenu(Convert.ToInt32(treeView3.Nodes[x].Nodes[y].Tag.ToString()), stat);
                                mm.Invoke();
                            }
                            y++;
                        }
                        x++;
                    }

                }
                frmMainTab frm = new frmMainTab();
                //frm.MyForms();
                frm.Refresh();
                
                string id = msg.ShowAlert("UID005", new GBLEnvVariable().CurrentLanguageID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}