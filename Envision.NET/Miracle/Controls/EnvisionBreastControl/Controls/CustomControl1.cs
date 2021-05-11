using System;
using System.Collections.Generic;
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
using EnvisionBreastControl.Enums;
using EnvisionBreastControl.Events;
using EnvisionBreastControl.Helper;

namespace EnvisionBreastControl
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFControl2"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFControl2;assembly=WPFControl2"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    /// 
    [TemplatePart(Name= CustomControl1.ELM_BOUNDING_NAME, Type = typeof(Rectangle))]
    [TemplatePart(Name = CustomControl1.ELM_SHAPE_ELLIPSE_NAME, Type = typeof(Ellipse))]
    [TemplatePart(Name = CustomControl1.ELM_COORDINATE_X_TOOTIP_NAME, Type = typeof(TextBlock))]
    [TemplatePart(Name = CustomControl1.ELM_COORDINATE_Y_TOOTIP_NAME, Type = typeof(TextBlock))]    
  
    public class CustomControl1 : Control
    {
        public struct Location
        {
            public Point Coordinate { get; set; }
            public int Clock { get; set; }
        }
        public delegate void onContextMenuItemClick(object sender, ItemEventArgs args);
        private const string ELM_BOUNDING_NAME = "elmBd1";
        private const string ELM_SHAPE_ELLIPSE_NAME = "elmSp1";
        private const string ELM_COORDINATE_X_TOOTIP_NAME = "elmTtpCoorX";
        private const string ELM_COORDINATE_Y_TOOTIP_NAME = "elmTtpCoorY";
        //STATIC DEFAULT VALUE FOR EACH PROPERTY
        private const double PPY_DIMENSION = 40.0; //DIMENSION
        private const double PPY_THICKNESS = 1.0; //DIMENSION
        private const Visibility PPY_SHOW_BOUNDING =  Visibility.Hidden; //BOUNDING
        private const Visibility PPY_SHOW_SELECTED_BOUNDING = Visibility.Hidden; //BOUNDING
        private const Visibility PPY_SHOW_COORDINATE = Visibility.Hidden; //COORDINATE
        private const int PPY_COORDINATE_X = 0;
        private const int PPY_COORDINATE_Y = 0;
        private static readonly string[] contextMenuItems = { 
                                                    "Mess",
                                                    "Calcification",
                                                    "Architectural Distortion",
                                                    "Special Case",
                                                    "Associate Finding",
                                                    "Delete"
                                                  };

        Ellipse ellipse;

        #region PROPERTIES
        public static readonly DependencyProperty ShapeDimensionProperty = 
            DependencyProperty.Register("ShapeDimension", typeof(double), typeof(CustomControl1), 
            new FrameworkPropertyMetadata(CustomControl1.PPY_DIMENSION, FrameworkPropertyMetadataOptions.AffectsMeasure));
        
        
        public double ShapeDimension
        {
            get { return (double)this.GetValue(ShapeDimensionProperty); }
            set { this.SetValue(ShapeDimensionProperty, value); }
        }

        public static readonly DependencyProperty ShapeThicknessProperty =
            DependencyProperty.Register("ShapeThickness", typeof(double), typeof(CustomControl1),
            new FrameworkPropertyMetadata(CustomControl1.PPY_THICKNESS, FrameworkPropertyMetadataOptions.AffectsMeasure));


        public double ShapeThickness
        {
            get { return (double)this.GetValue(ShapeThicknessProperty); }
            set { this.SetValue(ShapeThicknessProperty, value); }
        }

        public static readonly DependencyProperty ShapeStrokeColorProperty =
            DependencyProperty.Register("ShapeStrokeColor", typeof(Brush), typeof(CustomControl1),
            new FrameworkPropertyMetadata(Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush ShapeStrokeColor
        {
            get { return (Brush)this.GetValue(ShapeStrokeColorProperty); }
            set { this.SetValue(ShapeStrokeColorProperty, value); }
        }

        public static readonly DependencyProperty ShapeFillColorProperty =
            DependencyProperty.Register("ShapeFillColor", typeof(Brush), typeof(CustomControl1),
            new FrameworkPropertyMetadata(Brushes.PaleGreen, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush ShapeFillColor
        {
            get { return (Brush)this.GetValue(ShapeFillColorProperty); }
            set { this.SetValue(ShapeFillColorProperty, value); }
        }

        public static readonly DependencyProperty SelectingBoundColorProperty =
           DependencyProperty.Register("SelectingBoundColor", typeof(Brush), typeof(CustomControl1),
           new FrameworkPropertyMetadata(Brushes.Orange, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush SelectingBoundColor
        {
            get { return (Brush)this.GetValue(SelectingBoundColorProperty); }
            set { this.SetValue(SelectingBoundColorProperty, value); }
        }

        public static readonly DependencyProperty ShowBoundingProperty =
           DependencyProperty.Register("ShowBounding", typeof(Visibility), typeof(CustomControl1),
           new FrameworkPropertyMetadata(CustomControl1.PPY_SHOW_BOUNDING, FrameworkPropertyMetadataOptions.AffectsRender));

        public Visibility ShowBounding
        {
            get { return (Visibility)this.GetValue(ShowBoundingProperty); }
            set { this.SetValue(ShowBoundingProperty, value); }
        }

        public static readonly DependencyProperty ShowShapeCoordinateProperty =
         DependencyProperty.Register("ShowShapeCoordinate", typeof(Visibility), typeof(CustomControl1),
         new FrameworkPropertyMetadata(CustomControl1.PPY_SHOW_COORDINATE, FrameworkPropertyMetadataOptions.AffectsRender));

        public Visibility ShowCoordinate
        {
            get { return (Visibility)this.GetValue(ShowShapeCoordinateProperty); }
            set { this.SetValue(ShowShapeCoordinateProperty, value); }
        }

        public static readonly DependencyProperty ShapeLocationProperty =
            DependencyProperty.Register("ShapeLocation", typeof(Location), typeof(CustomControl1),
            new FrameworkPropertyMetadata(new Location(), new PropertyChangedCallback(CustomControl1.OnCoordinateChange)
                , new CoerceValueCallback(CustomControl1.CoerceCoordinateChanage)));

        public Location ShapeLocation
        {
            get { return (Location)this.GetValue(ShapeLocationProperty); }
            set { this.SetValue(ShapeLocationProperty, value); }
        }
          
        public static void OnCoordinateChange(DependencyObject dpo, DependencyPropertyChangedEventArgs args)
        {

        }

        public static object CoerceCoordinateChanage(DependencyObject dpo, object obj)
        {
            return obj;
        }

        public static readonly DependencyProperty ShowSelectedBoundingProperty =
         DependencyProperty.Register("ShowSelectedBounding", typeof(Visibility), typeof(CustomControl1),
         new FrameworkPropertyMetadata(CustomControl1.PPY_SHOW_SELECTED_BOUNDING, FrameworkPropertyMetadataOptions.AffectsRender));

        public Visibility ShowSelectedBounding
        {
            get { return (Visibility)this.GetValue(ShowSelectedBoundingProperty); }
            set 
            { 
                this.SetValue(ShowSelectedBoundingProperty, value);
                if (value == Visibility.Visible)
                    this.ShowBounding = Visibility.Hidden;
                //else
                //    this.ShowBounding = Visibility.Visible;
            }
        }

        #endregion

        #region Event
        public event onContextMenuItemClick OnContextMenuItemClick;
        //{
        //    add { base.AddHandler(ContextMenuHandle, value); }
        //    remove { base.RemoveHandler(ContextMenuHandle, value); }
        //}
        public static readonly RoutedEvent ContextMenuHandle =
            EventManager.RegisterRoutedEvent(
            "OnContextMenuItemClick", 
            RoutingStrategy.Bubble,
            typeof(onContextMenuItemClick), 
            typeof(CustomControl1));

        #endregion

        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }
        public CustomControl1()
        {
            CreateMenuContext();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ellipse = this.GetTemplateChild(CustomControl1.ELM_SHAPE_ELLIPSE_NAME) as Ellipse;
            if (ellipse != null)
            {
                ellipse.MouseEnter += new MouseEventHandler(ellipse_MouseEnter);
                ellipse.MouseLeave += new MouseEventHandler(ellipse_MouseLeave);
                
            }
        }

        #region Mouse Event
        protected void ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            this.ShowCoordinate = Visibility.Hidden;
            if (this.ShowSelectedBounding == Visibility.Visible)
                return;
            this.ShowBounding = Visibility.Hidden;
        }

        protected void ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            this.ShowCoordinate = Visibility.Visible;
            if (this.ShowSelectedBounding == Visibility.Visible)
                return;
            this.ShowBounding = Visibility.Visible;
        }

        #region Menu Context
        private void CreateMenuContext()
        {
            ContextMenu contextmenu = new ContextMenu();
            contextmenu.Background = Brushes.White;
            foreach (string item in contextMenuItems)
            {
                MenuItem mItem = new MenuItem();
                mItem.Icon = GetMenuIcon(item);
                mItem.Header = item;
                mItem.Click += new RoutedEventHandler(mItem_Click);
                contextmenu.Items.Add(mItem);
            }

            this.ContextMenu = contextmenu;
        }

        protected void mItem_Click(object sender, RoutedEventArgs e)
        {
            if (OnContextMenuItemClick != null)
            {
                OnContextMenuItemClick(this, new ItemEventArgs() { Item = this, ContextMenuItem = sender });
            }
        }
        /// <summary>
        /// This method use to get meny icon
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Image GetMenuIcon(string name)
        {
            System.Drawing.Bitmap bmp = null;
            switch (name)
            {
                case "Delete": bmp = Miracle.Properties.Resources.Delete; break;
                default: bmp = Miracle.Properties.Resources.bullet; break;
            }

            if (bmp == null)
                return null;
            Image img = new Image();
            img.Source = ImageSourceHepler.CreateBitmapSource(bmp);
            img.Stretch = Stretch.Uniform;
            img.Width = 16;
            img.Height = 16;
            return img;
        }
        #endregion

        #endregion
    }
}
