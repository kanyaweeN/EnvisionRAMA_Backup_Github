using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using System.Xml;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using DevExpress.XtraBars.Docking;

namespace Envision.NET.Forms.Main
{
    public partial class Home : Envision.NET.Forms.Main.MasterForm 
    {
        const string DockingLayoutFile ="HomeLayout.xml";

        public Home()
        {
            InitializeComponent();
            loadFirst = true;

            #region DocPanel.
            //createDockPanels();
            //restoreSettings(); 
            #endregion
        }
        #region DocPanel.
        private void restoreSettings()
        {
            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {

                IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("Envision.NET\\" + DockingLayoutFile, FileMode.Open, iso);
                dockManager1.RestoreLayoutFromStream(isolatedStorageFileStream);
                isolatedStorageFileStream.Dispose();
            }
            catch (Exception ex)
            {
                if (ex.Message == @"Could not find file 'Envision.NET\HomeLayout.xml'.")
                {

                    IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("Envision.NET\\" + DockingLayoutFile, FileMode.Create, iso);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(createXMLLayout());
                    streamWriter.Close();
                    fileStream.Close();

                    IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("Envision.NET\\" + DockingLayoutFile, FileMode.Open, iso);
                    dockManager1.RestoreLayoutFromStream(isolatedStorageFileStream);
                    isolatedStorageFileStream.Dispose();
                }
            }
            finally
            {
                iso.Dispose();
            }

        }
        private void saveSettings()
        {
            try
            {
                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                try
                {
                    string[] str = iso.GetFileNames("Envision.NET\\" + DockingLayoutFile);
                    if (str.Length > 0)
                        iso.DeleteFile("Envision.NET\\" + DockingLayoutFile);
                    str = iso.GetDirectoryNames("Envision.NET\\");
                    if (str.Length == 0) iso.CreateDirectory("Envision.NET\\");
                }
                catch (Exception exx)
                {
                    if (exx.Message == @"Could not find a part of the path 'Envision.NET\HomeLayout.xml'.")
                        iso.CreateDirectory("Envision.NET\\");
                }
                IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("Envision.NET\\" + DockingLayoutFile, FileMode.Create, iso);
                dockManager1.SaveLayoutToStream(fileStream);
                fileStream.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private void createDockPanels()
        {
            DockPanel panel1 = dockManager1.AddPanel(DockingStyle.Left);
            panel1.Text = "Favorites";
            panel1.ID = new Guid("{00000000-0000-0000-0000-000000000001}");
            panel1.Options.ShowCloseButton = false;
            panel1.Options.ShowMaximizeButton = true;
            panel1.Controls.Add(new View.Favorites());

            DockPanel panel2 = dockManager1.AddPanel(DockingStyle.Left);
            panel2.Text = "User CP";
            panel2.ID = new Guid("{00000000-0000-0000-0000-000000000002}");
            panel2.Options.ShowCloseButton = false;
            panel2.Options.ShowMaximizeButton = true;
            panel2.Controls.Add(new View.UserCP());

            DockPanel panel3 = dockManager1.AddPanel(DockingStyle.Left);
            panel3.Text = "Message";
            panel3.ID = new Guid("{00000000-0000-0000-0000-000000000003}");
            panel3.Options.ShowCloseButton = false;
            panel3.Options.ShowMaximizeButton = true;
            panel3.Controls.Add(new View.Messages());

            DockPanel panel4 = dockManager1.AddPanel(DockingStyle.Left);
            panel4.Text = "Tasks";
            panel4.ID = new Guid("{00000000-0000-0000-0000-000000000004}");
            panel4.Options.ShowCloseButton = false;
            panel4.Options.ShowMaximizeButton = true;
            panel4.Controls.Add(new View.Tasks());
        }
        private string createXMLLayout()
        {
            string str = string.Empty;
            str = "<XtraSerializer version=\"1.0\" application=\"DockManager\">";
            str += "  <property name=\"#LayoutVersion\" />";
            str += "  <property name=\"TopZIndexControls\" iskey=\"true\" value=\"4\">";
            str += "      <property name=\"Item1\">DevExpress.XtraBars.BarDockControl</property>";
            str += "      <property name=\"Item2\">System.Windows.Forms.StatusBar</property>";
            str += "      <property name=\"Item3\">DevExpress.XtraBars.Ribbon.RibbonStatusBar</property>";
            str += "      <property name=\"Item4\">DevExpress.XtraBars.Ribbon.RibbonControl</property>";
            str += "  </property>";
            str += "  <property name=\"AutoHideContainers\" iskey=\"true\" value=\"0\" />";
            str += "      <property name=\"DockingOptions\" isnull=\"true\" iskey=\"true\">";
            str += "      <property name=\"ShowAutoHideButton\">true</property>";
            str += "      <property name=\"ShowMaximizeButton\">true</property>";
            str += "      <property name=\"FloatOnDblClick\">true</property>";
            str += "      <property name=\"ShowCloseButton\">true</property>";
            str += "      <property name=\"ShowCaptionImage\">false</property>";
            str += "      <property name=\"HideImmediatelyOnAutoHide\">false</property>";
            str += "      <property name=\"CursorFloatCanceled\" isnull=\"true\" />";
            str += "      <property name=\"ShowCaptionOnMouseHover\">false</property>";
            str += "      <property name=\"CloseActiveTabOnly\">true</property>";
            str += "  </property>";
            str += "  <property name=\"ActivePanelID\">3</property>";
            str += "  <property name=\"Panels\" iskey=\"true\" value=\"7\">";
            str += "  <property name=\"Item1\" isnull=\"true\" iskey=\"true\">";
            str += "  <property name=\"FloatSize\">@3,Width=200@3,Height=200</property>";
            str += "  <property name=\"FloatVertical\">true</property>";
            str += "  <property name=\"DockVertical\">Default</property>";
            str += "  <property name=\"TabText\" />";
            str += "  <property name=\"XtraParentID\">5</property>";
            str += "  <property name=\"Options\" isnull=\"true\" iskey=\"true\">";
            str += "  <property name=\"ShowMaximizeButton\">true</property>";
            str += "  <property name=\"AllowDockFill\">true</property>";
            str += "  <property name=\"ShowAutoHideButton\">true</property>";
            str += "  <property name=\"FloatOnDblClick\">true</property>";
            str += "  <property name=\"ShowCloseButton\">false</property>";
            str += "  <property name=\"AllowDockLeft\">true</property>";
            str += "  <property name=\"AllowFloating\">true</property>";
            str += "  <property name=\"AllowDockRight\">true</property>";
            str += "  <property name=\"AllowDockBottom\">true</property>";
            str += "  <property name=\"AllowDockTop\">true</property>";
            str += "  </property>";
            str += "  <property name=\"Text\">Favorites</property>";
            str += "  <property name=\"TabsPosition\">Bottom</property>";
            str += "  <property name=\"TabsScroll\">false</property>";
            str += "  <property name=\"ImageIndex\">-1</property>";
            str += "  <property name=\"Tabbed\">false</property>";
            str += "  <property name=\"FloatLocation\">@1,X=0@1,Y=0</property>";
            str += "  <property name=\"Dock\">Fill</property>";
            str += "  <property name=\"Visibility\">Visible</property>";
            str += "  <property name=\"XtraID\">0</property>";
            str += "  <property name=\"Count\">0</property>";
            str += "  <property name=\"ID\">00000000-0000-0000-0000-000000000001</property>";
            str += "      <property name=\"XtraActiveChildID\">-1</property>";
            str += "      <property name=\"Hint\" />";
            str += "      <property name=\"XtraZIndex\">0</property>";
            str += "      <property name=\"XtraBounds\">@1,X=0@1,Y=0@3,Width=408@3,Height=318</property>";
            str += "      <property name=\"SavedIndex\">-1</property>";
            str += "      <property name=\"XtraSavedParentID\">-1</property>";
            str += "      <property name=\"SavedTabbed\">false</property>";
            str += "      <property name=\"SavedDock\">Float</property>";
            str += "      <property name=\"XtraAutoHideContainerDock\">Float</property>";
            str += "  </property>";
            str += "  <property name=\"Item2\" isnull=\"true\" iskey=\"true\">";
            str += "  <property name=\"FloatSize\">@3,Width=200@3,Height=200</property>";
            str += "  <property name=\"FloatVertical\">true</property>";
            str += "  <property name=\"DockVertical\">Default</property>";
            str += "  <property name=\"TabText\" />";
            str += "  <property name=\"XtraParentID\">5</property>";
            str += "  <property name=\"Options\" isnull=\"true\" iskey=\"true\">";
            str += "  <property name=\"ShowMaximizeButton\">true</property>";
            str += "  <property name=\"AllowDockFill\">true</property>";
            str += "  <property name=\"ShowAutoHideButton\">true</property>";
            str += "  <property name=\"FloatOnDblClick\">true</property>";
            str += "  <property name=\"ShowCloseButton\">false</property>";
            str += "  <property name=\"AllowDockLeft\">true</property>";
            str += "  <property name=\"AllowFloating\">true</property>";
            str += "  <property name=\"AllowDockRight\">true</property>";
            str += "  <property name=\"AllowDockBottom\">true</property>";
            str += "  <property name=\"AllowDockTop\">true</property>";
            str += "  </property>";
            str += "  <property name=\"Text\">User CP</property>";
            str += "  <property name=\"TabsPosition\">Bottom</property>";
            str += "  <property name=\"TabsScroll\">false</property>";
            str += "  <property name=\"ImageIndex\">-1</property>";
            str += "  <property name=\"Tabbed\">false</property>";
            str += "  <property name=\"FloatLocation\">@1,X=0@1,Y=0</property>";
            str += "  <property name=\"Dock\">Fill</property>";
            str += "  <property name=\"Visibility\">Visible</property>";
            str += "  <property name=\"XtraID\">1</property>";
            str += "  <property name=\"Count\">0</property>";
            str += "  <property name=\"ID\">00000000-0000-0000-0000-000000000002</property>";
            str += "  <property name=\"XtraActiveChildID\">-1</property>";
            str += "  <property name=\"Hint\" />";
            str += "  <property name=\"XtraZIndex\">1</property>";
            str += "  <property name=\"XtraBounds\">@3,X=408@1,Y=0@3,Width=409@3,Height=318</property>";
            str += "  <property name=\"SavedIndex\">-1</property>";
            str += "  <property name=\"XtraSavedParentID\">-1</property>";
            str += "  <property name=\"SavedTabbed\">false</property>";
            str += "  <property name=\"SavedDock\">Float</property>";
            str += "  <property name=\"XtraAutoHideContainerDock\">Float</property>";
            str += "  </property>";
            str += "  <property name=\"Item3\" isnull=\"true\" iskey=\"true\">";
            str += "  <property name=\"FloatSize\">@3,Width=200@3,Height=200</property>";
            str += "  <property name=\"FloatVertical\">true</property>";
            str += "  <property name=\"DockVertical\">Default</property>";
            str += "  <property name=\"TabText\" />";
            str += "  <property name=\"XtraParentID\">6</property>";
            str += "  <property name=\"Options\" isnull=\"true\" iskey=\"true\">";
            str += "  <property name=\"ShowMaximizeButton\">true</property>";
            str += "  <property name=\"AllowDockFill\">true</property>";
            str += "  <property name=\"ShowAutoHideButton\">true</property>";
            str += "  <property name=\"FloatOnDblClick\">true</property>";
            str += "  <property name=\"ShowCloseButton\">false</property>";
            str += "  <property name=\"AllowDockLeft\">true</property>";
            str += "  <property name=\"AllowFloating\">true</property>";
            str += "  <property name=\"AllowDockRight\">true</property>";
            str += "  <property name=\"AllowDockBottom\">true</property>";
            str += "  <property name=\"AllowDockTop\">true</property>";
            str += "  </property>";
            str += "  <property name=\"Text\">Message</property>";
            str += "  <property name=\"TabsPosition\">Bottom</property>";
            str += "  <property name=\"TabsScroll\">false</property>";
            str += "  <property name=\"ImageIndex\">-1</property>";
            str += "  <property name=\"Tabbed\">false</property>";
            str += "  <property name=\"FloatLocation\">@1,X=0@1,Y=0</property>";
            str += "  <property name=\"Dock\">Fill</property>";
            str += "  <property name=\"Visibility\">Visible</property>";
            str += "  <property name=\"XtraID\">2</property>";
            str += "  <property name=\"Count\">0</property>";
            str += "  <property name=\"ID\">00000000-0000-0000-0000-000000000003</property>";
            str += "  <property name=\"XtraActiveChildID\">-1</property>";
            str += "  <property name=\"Hint\" />";
            str += "  <property name=\"XtraZIndex\">0</property>";
            str += "  <property name=\"XtraBounds\">@1,X=0@1,Y=0@3,Width=408@3,Height=319</property>";
            str += "  <property name=\"SavedIndex\">-1</property>";
            str += "  <property name=\"XtraSavedParentID\">-1</property>";
            str += "  <property name=\"SavedTabbed\">false</property>";
            str += "  <property name=\"SavedDock\">Float</property>";
            str += "  <property name=\"XtraAutoHideContainerDock\">Float</property>";
            str += "  </property>";
            str += "  <property name=\"Item4\" isnull=\"true\" iskey=\"true\">";
            str += "  <property name=\"FloatSize\">@3,Width=200@3,Height=200</property>";
            str += "  <property name=\"FloatVertical\">false</property>";
            str += "  <property name=\"DockVertical\">Default</property>";
            str += "  <property name=\"TabText\" />";
            str += "  <property name=\"XtraParentID\">6</property>";
            str += "  <property name=\"Options\" isnull=\"true\" iskey=\"true\">";
            str += "  <property name=\"ShowMaximizeButton\">true</property>";
            str += "  <property name=\"AllowDockFill\">true</property>";
            str += "  <property name=\"ShowAutoHideButton\">true</property>";
            str += "  <property name=\"FloatOnDblClick\">true</property>";
            str += "  <property name=\"ShowCloseButton\">false</property>";
            str += "  <property name=\"AllowDockLeft\">true</property>";
            str += "  <property name=\"AllowFloating\">true</property>";
            str += "  <property name=\"AllowDockRight\">true</property>";
            str += "  <property name=\"AllowDockBottom\">true</property>";
            str += "  <property name=\"AllowDockTop\">true</property>";
            str += "</property>";
            str += "<property name=\"Text\">Tasks</property>";
            str += "<property name=\"TabsPosition\">Bottom</property>";
            str += "<property name=\"TabsScroll\">false</property>";
            str += "<property name=\"ImageIndex\">-1</property>";
            str += "<property name=\"Tabbed\">false</property>";
            str += "<property name=\"FloatLocation\">@1,X=0@1,Y=0</property>";
            str += "<property name=\"Dock\">Fill</property>";
            str += "<property name=\"Visibility\">Visible</property>";
            str += "<property name=\"XtraID\">3</property>";
            str += "<property name=\"Count\">0</property>";
            str += "<property name=\"ID\">00000000-0000-0000-0000-000000000004</property>";
            str += "<property name=\"XtraActiveChildID\">-1</property>";
            str += "<property name=\"Hint\" />";
            str += "<property name=\"XtraZIndex\">1</property>";
            str += "<property name=\"XtraBounds\">@3,X=408@1,Y=0@3,Width=409@3,Height=319</property>";
            str += "<property name=\"SavedIndex\">-1</property>";
            str += "<property name=\"XtraSavedParentID\">-1</property>";
            str += "<property name=\"SavedTabbed\">false</property>";
            str += "<property name=\"SavedDock\">Float</property>";
            str += "<property name=\"XtraAutoHideContainerDock\">Float</property>";
            str += "</property>";
            str += "   <property name=\"Item5\" isnull=\"true\" iskey=\"true\">";
            str += "     <property name=\"FloatSize\">@3,Width=200@3,Height=200</property>";
            str += "      <property name=\"FloatVertical\">false</property>";
            str += "<property name=\"DockVertical\">Default</property>";
            str += "     <property name=\"TabText\" />";
            str += "      <property name=\"XtraParentID\">-1</property>";
            str += "     <property name=\"Options\" isnull=\"true\" iskey=\"true\">";
            str += "       <property name=\"ShowMaximizeButton\">true</property>";
            str += "      <property name=\"AllowDockFill\">true</property>";
            str += "       <property name=\"ShowAutoHideButton\">true</property>";
            str += "       <property name=\"FloatOnDblClick\">true</property>";
            str += "       <property name=\"ShowCloseButton\">true</property>";
            str += "       <property name=\"AllowDockLeft\">true</property>";
            str += "       <property name=\"AllowFloating\">true</property>";
            str += "       <property name=\"AllowDockRight\">true</property>";
            str += "       <property name=\"AllowDockBottom\">true</property>";
            str += "      <property name=\"AllowDockTop\">true</property>";
            str += "    </property>";
            str += "    <property name=\"Text\">panelContainer1</property>";
            str += "     <property name=\"TabsPosition\">Bottom</property>";
            str += "    <property name=\"TabsScroll\">false</property>";
            str += "     <property name=\"ImageIndex\">-1</property>";
            str += "     <property name=\"Tabbed\">false</property>";
            str += "     <property name=\"FloatLocation\">@1,X=0@1,Y=0</property>";
            str += "     <property name=\"Dock\">Left</property>";
            str += "      <property name=\"Visibility\">Visible</property>";
            str += "      <property name=\"XtraID\">4</property>";
            str += "     <property name=\"Count\">2</property>";
            str += "     <property name=\"ID\">9a2dfbcd-bb55-4a3d-9812-fa0e471d8245</property>";
            str += "      <property name=\"XtraActiveChildID\">-1</property>";
            str += "      <property name=\"Hint\" />";
            str += "     <property name=\"XtraZIndex\">0</property>";
            str += "     <property name=\"XtraBounds\">@1,X=0@1,Y=0@3,Width=817@3,Height=637</property>";
            str += "     <property name=\"SavedIndex\">-1</property>";
            str += "     <property name=\"XtraSavedParentID\">-1</property>";
            str += "     <property name=\"SavedTabbed\">false</property>";
            str += "     <property name=\"SavedDock\">Float</property>";
            str += "     <property name=\"XtraAutoHideContainerDock\">Float</property>";
            str += "   </property>";
            str += "    <property name=\"Item6\" isnull=\"true\" iskey=\"true\">";
            str += "     <property name=\"FloatSize\">@3,Width=200@3,Height=200</property>";
            str += "     <property name=\"FloatVertical\">true</property>";
            str += "     <property name=\"DockVertical\">Default</property>";
            str += "     <property name=\"TabText\" />";
            str += "   <property name=\"XtraParentID\">4</property>";
            str += "    <property name=\"Options\" isnull=\"true\" iskey=\"true\">";
            str += "     <property name=\"ShowMaximizeButton\">true</property>";
            str += "     <property name=\"AllowDockFill\">true</property>";
            str += "     <property name=\"ShowAutoHideButton\">true</property>";
            str += "    <property name=\"FloatOnDblClick\">true</property>";
            str += "    <property name=\"ShowCloseButton\">true</property>";
            str += "     <property name=\"AllowDockLeft\">true</property>";
            str += "     <property name=\"AllowFloating\">true</property>";
            str += "     <property name=\"AllowDockRight\">true</property>";
            str += "     <property name=\"AllowDockBottom\">true</property>";
            str += "     <property name=\"AllowDockTop\">true</property>";
            str += "   </property>";
            str += "    <property name=\"Text\">panelContainer2</property>";
            str += "    <property name=\"TabsPosition\">Bottom</property>";
            str += "    <property name=\"TabsScroll\">false</property>";
            str += "    <property name=\"ImageIndex\">-1</property>";
            str += "    <property name=\"Tabbed\">false</property>";
            str += "    <property name=\"FloatLocation\">@1,X=0@1,Y=0</property>";
            str += "    <property name=\"Dock\">Fill</property>";
            str += "    <property name=\"Visibility\">Visible</property>";
            str += "    <property name=\"XtraID\">5</property>";
            str += "    <property name=\"Count\">2</property>";
            str += "    <property name=\"ID\">5e0f02a4-3b30-47a6-9790-99d9754f41d4</property>";
            str += "    <property name=\"XtraActiveChildID\">-1</property>";
            str += "    <property name=\"Hint\" />";
            str += "    <property name=\"XtraZIndex\">0</property>";
            str += "    <property name=\"XtraBounds\">@1,X=0@1,Y=0@3,Width=817@3,Height=318</property>";
            str += "    <property name=\"SavedIndex\">-1</property>";
            str += "    <property name=\"XtraSavedParentID\">-1</property>";
            str += "    <property name=\"SavedTabbed\">false</property>";
            str += "    <property name=\"SavedDock\">Float</property>";
            str += "    <property name=\"XtraAutoHideContainerDock\">Float</property>";
            str += "  </property>";
            str += "  <property name=\"Item7\" isnull=\"true\" iskey=\"true\">";
            str += "     <property name=\"FloatSize\">@3,Width=200@3,Height=200</property>";
            str += "     <property name=\"FloatVertical\">true</property>";
            str += "     <property name=\"DockVertical\">Default</property>";
            str += "     <property name=\"TabText\" />";
            str += "     <property name=\"XtraParentID\">4</property>";
            str += "     <property name=\"Options\" isnull=\"true\" iskey=\"true\">";
            str += "       <property name=\"ShowMaximizeButton\">true</property>";
            str += "       <property name=\"AllowDockFill\">true</property>";
            str += "       <property name=\"ShowAutoHideButton\">true</property>";
            str += "       <property name=\"FloatOnDblClick\">true</property>";
            str += "      <property name=\"ShowCloseButton\">true</property>";
            str += "       <property name=\"AllowDockLeft\">true</property>";
            str += "       <property name=\"AllowFloating\">true</property>";
            str += "       <property name=\"AllowDockRight\">true</property>";
            str += "       <property name=\"AllowDockBottom\">true</property>";
            str += "       <property name=\"AllowDockTop\">true</property>";
            str += "     </property>";
            str += "     <property name=\"Text\">panelContainer3</property>";
            str += "     <property name=\"TabsPosition\">Bottom</property>";
            str += "     <property name=\"TabsScroll\">false</property>";
            str += "     <property name=\"ImageIndex\">-1</property>";
            str += "     <property name=\"Tabbed\">false</property>";
            str += "     <property name=\"FloatLocation\">@1,X=0@1,Y=0</property>";
            str += "     <property name=\"Dock\">Fill</property>";
            str += "     <property name=\"Visibility\">Visible</property>";
            str += "     <property name=\"XtraID\">6</property>";
            str += "     <property name=\"Count\">2</property>";
            str += "     <property name=\"ID\">ff9ff04f-251b-4f5d-9692-6ada7ce2ee57</property>";
            str += "     <property name=\"XtraActiveChildID\">-1</property>";
            str += "     <property name=\"Hint\" />";
            str += "     <property name=\"XtraZIndex\">1</property>";
            str += "     <property name=\"XtraBounds\">@1,X=0@3,Y=318@3,Width=817@3,Height=319</property>";
            str += "     <property name=\"SavedIndex\">-1</property>";
            str += "     <property name=\"XtraSavedParentID\">-1</property>";
            str += "     <property name=\"SavedTabbed\">false</property>";
            str += "     <property name=\"SavedDock\">Float</property>";
            str += "     <property name=\"XtraAutoHideContainerDock\">Float</property>";
            str += "   </property>";
            str += " </property>";
            str += "</XtraSerializer>";
            return str;
        }
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //saveSettings();
        } 
        #endregion


        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private XmlTextReader rssReader;
        private XmlDocument rssDoc;
        private XmlNode nodeRss;
        private XmlNode nodeChannel;
        private XmlNode nodeItem;
        private ListViewItem rowNews;
        private bool loadFirst;
        
        private DataSet dsChannel;
        private string xmlPath = @"FeedFav.xml";
        private string feedName;
        private string feedUrl;

        private void bindDataToFeed() {
            lstChannel.DisplayMember = "title";
            lstChannel.ValueMember = "link";
            try
            {
                lstChannel.DataSource = dsChannel.Tables[0];
            }
            catch { }
        }
        private void visibleAddNewFeed(bool flag) {
            if (flag)
                lctNew.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
            {
                txtUrl.Text = string.Empty;
                lctNew.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        private void clearContext()
        {
            lstNews.Items.Clear();
            rssWeb.DocumentText = string.Empty;
        }
        private void createSaveFeed()
        {
            dsChannel = new DataSet();
            DataTable dtt = new DataTable();
            dtt.Columns.Add("title", typeof(string));
            dtt.Columns.Add("link", typeof(string));
            dtt.AcceptChanges();
            dsChannel.Tables.Add(dtt);
            dsChannel.AcceptChanges();
        }
        private void loadFavFeed()
        {
            try
            {

                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("Envision.NET\\" + xmlPath, FileMode.Open, iso);
                dsChannel = new DataSet();
                dsChannel.ReadXml(isolatedStorageFileStream);


                isolatedStorageFileStream.Dispose();
                iso.Dispose();
                
                
            }
            catch(Exception ex)
            {
                createSaveFeed();
            }

        }
        private void saveFavFeedIsolate() {
            try
            {
                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
                try
                {
                    string[] str = iso.GetFileNames("Envision.NET\\" + xmlPath);
                    if (str.Length > 0)
                        iso.DeleteFile("Envision.NET\\" + xmlPath);
                    str = iso.GetDirectoryNames("Envision.NET\\");
                    if (str.Length == 0) iso.CreateDirectory("Envision.NET\\");
                }
                catch (Exception exx)
                {
                    if (exx.Message == @"Could not find a part of the path 'Envision.NET\FeedFav.xml'.")
                        iso.CreateDirectory("Envision.NET\\");
                }
                IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("Envision.NET\\" + xmlPath, FileMode.Create, iso);
                dsChannel.WriteXml(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception ex){
                //MessageBox.Show("Error from saveFavFeedIsolate() : " + ex.Message);
            }
        }
        private void saveFavFeed()
        {
            DataRow row = dsChannel.Tables[0].NewRow();
            row[0] = feedName;
            row[1] = feedUrl;
            dsChannel.Tables[0].Rows.Add(row);
            dsChannel.AcceptChanges();
            saveFavFeedIsolate();
        }
        private void deleteFeed(string url)
        {
            int index = 0;
            for (; index < dsChannel.Tables[0].Rows.Count; index++)
                if (dsChannel.Tables[0].Rows[index]["link"].ToString().Trim() == url)
                    break;
            if (index < dsChannel.Tables[0].Rows.Count)
            {
                dsChannel.Tables[0].Rows[index].Delete();
                dsChannel.AcceptChanges();
                saveFavFeedIsolate();
            }
        }
        private void Home_Load(object sender, EventArgs e)
        {
            loadFavFeed();
            bindDataToFeed();
            loadFirst = false;
        }
        private void Home_Activated(object sender, EventArgs e)
        {
            if (lstChannel.SelectedIndex > -1) {
                string url = lstChannel.SelectedValue.ToString();
                if (string.IsNullOrEmpty(url)) return;
                clearContext();
                getRSSFeedXMLData(url);
            }
        }

        private void getRSSFeedXMLData(string url)
        {
            clearContext();
            this.Cursor = Cursors.WaitCursor;
            rssReader = new XmlTextReader(url);
            rssDoc = new XmlDocument();
            rssDoc.Load(rssReader);
            for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
            {
                if (rssDoc.ChildNodes[i].Name == "rss")
                    nodeRss = rssDoc.ChildNodes[i];
            }
            for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
            {
                if (nodeRss.ChildNodes[i].Name == "channel")
                    nodeChannel = nodeRss.ChildNodes[i];
            }
            feedName = nodeChannel["title"].InnerText;
            feedUrl = url;

            for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
            {
                if (nodeChannel.ChildNodes[i].Name == "item")
                {
                    nodeItem = nodeChannel.ChildNodes[i];
                    rowNews = new ListViewItem();
                    rowNews.Text = nodeItem["title"].InnerText;
                    rowNews.SubItems.Add(nodeItem["link"].InnerText);
                    lstNews.Items.Add(rowNews);
                }
            }
            this.Cursor = Cursors.Default;
        }
        private void lstNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadFirst) return;
            if (lstNews.SelectedItems.Count == 1)
            {
                string txt = string.Empty;
                for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
                {
                    if (nodeChannel.ChildNodes[i].Name == "item")
                    {
                        nodeItem = nodeChannel.ChildNodes[i];
                        if (nodeItem["title"].InnerText == lstNews.SelectedItems[0].Text)
                        {
                            txt = "<a href='" + nodeItem["link"].InnerText + "'><font size=\"4\" face=\"Tahoma\">" + nodeItem["title"].InnerText + "</font></a><br/>";
                            txt += "<font color=\"gray\" size=\"1\" face=\"Tahoma\">" + nodeItem["pubDate"].InnerText;
                            txt += "</font><br/><br/>";
                            txt += "<font color=\"gray\" size=\"2\" face=\"Tahoma\">";
                            txt += nodeItem["description"].InnerText;
                            txt += "</font>";
                            break;
                        }
                    }
                }
                rssWeb.DocumentText = txt;
            }
        }
        private void lstNews_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            rssWeb.DocumentText = string.Empty;
            Uri link = new Uri(lstNews.SelectedItems[0].SubItems[1].Text);
            rssWeb.Url = link;
            this.Cursor = Cursors.Default;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                getRSSFeedXMLData(txtUrl.Text);
                visibleAddNewFeed(false);
                saveFavFeed();
                bindDataToFeed();
                lstChannel.SelectedIndex = dsChannel.Tables[0].Rows.Count - 1;
            }
            catch (Exception ex)
            {
                msg.ShowAlert("UID009", env.CurrentLanguageID);
                this.Cursor = Cursors.Default;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            feedUrl = string.Empty;
            visibleAddNewFeed(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUrl.Text = string.Empty;
            visibleAddNewFeed(true);
            txtUrl.Focus();
        }
        private void lstChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadFirst) return;
            if (lstChannel.SelectedIndex == -1) return;
            string url = lstChannel.SelectedValue.ToString();
            if (string.IsNullOrEmpty(url)) return;
            if (url == feedUrl) return;
            clearContext();
            getRSSFeedXMLData(url);
        }
        private void lstChannel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                //UID1025
                
                //if (DialogResult.Yes == MessageBox.Show("Do you want to delete news", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                if(msg.ShowAlert("UID1025",env.CurrentLanguageID)=="2")
                {
                    deleteFeed(lstChannel.SelectedValue.ToString());
                    if (lstChannel.Items.Count == 0) clearContext();
                    bindDataToFeed();
                }
            }
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.Focus();
        }

        
    }
}
