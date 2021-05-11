///
/// PJ. Miracle (Ton) 4/12/2010
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnvisionBreastControl.Lib.Cores.Helper
{
    public class ContextMenuItemHepler
    {
        public static string[] ContextMenuItemNames = {
                                                         "Diameter",
                                                         "Fix Size",
                                                         "Copy",
                                                         "Properties",
                                                         "Delete"
                                                     };
        public struct Item
        {
            public string Name { get; set; }
            public string IconPath { get; set; }
        }
        //Specific menu
        public Item MessItem { get; set; }
        public Item CalcificationItem { get; set; }
        public Item ArchitecturalItem { get; set; }
        public Item SpecialItem { get; set; }
        public Item AssociateItem { get; set; }

        public Item DiameterItem { get; set; }
        public Item FixSizeItem { get; set; }
        public Item PropertyItem { get; set; }
        public Item DeleteItem { get; set; }

        public ContextMenuItemHepler()
            : base() 
        {
            DiameterItem = new Item() { Name = "Diameter", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/circle.png" };
            FixSizeItem = new Item() { Name = "Fix Size", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/snap-bounding-box.png" };
            PropertyItem = new Item() { Name = "Properties", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/styleL.png" };
            DeleteItem = new Item() { Name = "Delete", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/Delete.png" };
            MessItem = new Item() { Name = "Significant Finding", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/bullet.png" };
            CalcificationItem = new Item() { Name = "Calcification", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/bullet.png" };
            ArchitecturalItem = new Item() { Name = "Architectural Distortion", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/bullet.png" };
            AssociateItem = new Item() { Name = "Associate Finding", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/bullet.png" };
            SpecialItem = new Item() { Name = "Impression", IconPath = "/EnvisionBreastControl.Lib;Component/Resources/bullet.png" };
        }
 
    }
}
