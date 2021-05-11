using System;
using System.Collections.Generic;
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
using EnvisionBreastControl.Events;
using EnvisionBreastControl.Helper;
using EnvisionBreastControl.Lib;
using EnvisionBreastControl.Lib.Cores.Events;
using EnvisionBreastControl.Lib.Cores.Enumulator;
using System.IO;

namespace EnvisionBreastControl
{
    /// <summary>
    /// Interaction logic for BreastScreen.xaml
    /// </summary>
    public partial class BreastControl : UserControl
    {
        public enum Views
        {
            Right, Left
        }
        private Modes _mode;
        public Modes Mode
        {
            get { return _mode; }
            set { this.SetMode(value); }
        }
        //private CShapeControl.Shapes _shapeStyle = CShapeControl.Shapes.Round;
        //public CShapeControl.Shapes ShapeStyle
        //{
        //    get { return _shapeStyle; }
        //    set { _shapeStyle = value; }
        //}
        private bool IsDragging = false;
        private Point startPoint;
        private bool _IsMark = false;
        private bool IsExpand = false;
        private int currentClockLocation = 0;
        private BreastControl _relativeTo;
        internal delegate void onAckFromChild(object sender, SyncItemsArgs args);
        private Collection<object> ItemContrainer { get; set; }
        public delegate void onAddItemCompleted(object sender, ItemsArgs args);
        public delegate void onRemoveItemCompleted(object sender, ItemsArgs args);
        public delegate void onSelectedItemChanged(object sender, ItemsArgs args);
        public delegate void onMenuContextSelected(object sender, ItemEventArgs args);
        public event onExportImageCompleted OnExportImageCompleted;
        public event onImportImageCompleted OnImportImageCompleted;
        internal event onAckFromChild OnAckFromChild;
        public event onMenuContextSelected OnMenuContextSelected;
        public event onAddItemCompleted OnAddItemCompleted;
        public event onRemoveItemCompleted OnRemoveItemCompleted;
        public event onSelectedItemChanged OnSelectedItemChanged;
        private object _selectedItem;
        private ShapeProperties _properties;
        public ShapeProperties Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
        public object SelectedItem
        {
            get { return _selectedItem; }
            set 
            {
                this.SetSelectedItem(value);
            }
        }
        private bool _isReadOnly = false;
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { _isReadOnly = value; }
        }
        public static DependencyProperty ViewProperty
            = DependencyProperty.Register("View", typeof(Views), typeof(BreastControl)
            , new FrameworkPropertyMetadata(Views.Left, new PropertyChangedCallback(BreastControl.OnViewChanged), new CoerceValueCallback(CoerceValueChanged)));

        public static void OnViewChanged(DependencyObject dpObj, DependencyPropertyChangedEventArgs args)
        {
            BreastControl bc = dpObj as BreastControl;
            if ((Views)args.NewValue == Views.Left)
            {
                bc.lbViewL.Text = "Left";
                bc.lbViewL.Foreground = Brushes.Red;
                bc.lbViewL.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else
            {
                bc.lbViewL.Text = "Right";
                bc.lbViewL.Foreground = Brushes.Blue;
                bc.lbViewL.HorizontalAlignment = HorizontalAlignment.Right;
            }
        }
        public static object CoerceValueChanged(DependencyObject dpObj, object obj) { return obj; }

        public Views View
        {
            get { return (Views)this.GetValue(ViewProperty); }
            set { this.SetValue(ViewProperty, value); }
        }
        
        private List<object> _itemSource;
        /// <summary>
        /// Get or set breast mark item source
        /// </summary>
        public List<object> ItemSource
        {
            get { return _itemSource; }
            set 
            {
                _itemSource = value;
                this.SetItemSource();
            }
        }

        public BreastControl RelativeTo
        {
            get { return _relativeTo; }
            set
            {
                _relativeTo = value;
                if (_relativeTo != null)
                {
                    this.ItemContrainer = new Collection<object>();
                    _relativeTo.OnAckFromChild += new onAckFromChild(_relativeTo_OnAckFromChild);
                }
            }
        }

        public bool IsMark
        {
            get { return _IsMark; }
            set { _IsMark = value; }
        }
        public BreastControl()
        {
            InitializeComponent();
            this.Properties = new ShapeProperties();
            this.ItemSource = new List<object>();
            CreateOffsetLine();
            CreateCircleBounding();
        }

        //public static DependencyProperty ScreenLenghtProperty
        //    = DependencyProperty.Register("ScreenLenght", typeof(double), typeof(BreastControl),
        //    new FrameworkPropertyMetadata(250.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
        private double _screenLength;
        public double ScreenLenght
        {
            get { return _screenLength; }
            set
            {
                _screenLength = value;
                this.c1.Width = value;
                this.c1.Height = value;
            }
        }

        private void rect1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.IsMark)
                startPoint = e.GetPosition(this.c1);
            else
            {
                //add mark
                Point p = e.GetPosition(this.c1);
                CShapeControl _CShapeControl = new CShapeControl();
                //_CShapeControl.ShapeDimension = 40.0;
                Point coor = new Point((int)p.X, (int)p.Y);
                CShapeControl.Location location = new CShapeControl.Location();
                location.Coordinate = coor;
                location.Clock = this.currentClockLocation;
                _CShapeControl.ShapeLocation = location;
                _CShapeControl.MouseLeftButtonDown += new MouseButtonEventHandler(ep_MouseLeftButtonDown);
                _CShapeControl.MouseLeftButtonUp += new MouseButtonEventHandler(ep_MouseLeftButtonUp);
                _CShapeControl.ContextMenuClick += new RoutedEventHandler(_CShapeControl_ContextMenuClick);
                _CShapeControl.KeyUp += new KeyEventHandler(ep_KeyUp);
                _CShapeControl.OnExpanding += new RoutedEventHandler(_CShapeControl_OnExpanding);
                _CShapeControl.OnExpanded += new RoutedEventHandler(_CShapeControl_OnExpanded);
                _CShapeControl.OnDiameterChanged += new RoutedPropertyChangedEventHandler<double>(_CShapeControl_OnDiameterChanged);
                _CShapeControl.Diameter = this.Properties.Diameter;
                _CShapeControl.Shape = this.Properties.Shape;
                _CShapeControl.OvalWidth = this.Properties.OvalWidth;
                _CShapeControl.LineScaleColor = this.Properties.BorderColor;
                _CShapeControl.LineScaleTextFontFamily = new FontFamily(this.Properties.FontFamily);
                _CShapeControl.LineScaleTextFontSize = this.Properties.FontSize;
                _CShapeControl.LineScaleTextForeground = this.Properties.FontColor;
                _CShapeControl.ShowBounder = this.Properties.ShowBorder == true ? Visibility.Visible : Visibility.Collapsed;
                _CShapeControl.CanExpand = this.Properties.IsFixSize == true ? Visibility.Visible : Visibility.Collapsed;

                if (this.Properties.Style == ShapeStyles.Fill)
                    _CShapeControl.ShapeBackground = this.Properties.BackgroundColor;
                else
                    _CShapeControl.ShapeBackground = Brushes.Transparent;
                _CShapeControl.ShapeStrokeColor = this.Properties.StrokeColor;
                _CShapeControl.ShapeStrokeThickness = this.Properties.BorderThickness;
                _CShapeControl.Unit = this.Properties.Unit;
                //Set relative view
                _CShapeControl.Name = "m" + View.ToString() + _CShapeControl.GetHashCode();
                _CShapeControl.Tag = View;
               
                this.UnSelectItem();
                _CShapeControl.ShowBounder = Visibility.Visible;
                this.ItemSource.Add(_CShapeControl);
                this.c1.Children.Add(_CShapeControl);
                Canvas.SetLeft(_CShapeControl, p.X - ((_CShapeControl.Diameter + 8) / 2));
                Canvas.SetTop(_CShapeControl, p.Y - ((_CShapeControl.Diameter + 8) / 2));
                this.currentClockLocation = 0; //Clear
                _CShapeControl.Focus();
                //ADD TO MASTER ITEM COLLECTION
                if (this.ItemContrainer != null)
                {
                    this.ItemContrainer.Add(_CShapeControl);
                }
                if (this.OnAddItemCompleted != null)
                    this.OnAddItemCompleted(this, new ItemsArgs() { AddedItem = _CShapeControl });
                if (this.OnSelectedItemChanged != null)
                    this.OnSelectedItemChanged(this, new ItemsArgs() { NewItem = _CShapeControl, OldItem = this.SelectedItem });
                if (this.OnAckFromChild != null)
                    this.OnAckFromChild(this, new SyncItemsArgs() { Item = _CShapeControl, SyncState = SyncAckFormStates.Added });
            }

        }

        private void _CShapeControl_OnDiameterChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((CShapeControl)this.SelectedItem).Diameter = e.NewValue;
        }

        /// <summary>
        /// Expanded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _CShapeControl_OnExpanded(object sender, RoutedEventArgs e)
        {
            this.IsExpand = false;
        }
        /// <summary>
        /// Expanding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _CShapeControl_OnExpanding(object sender, RoutedEventArgs e)
        {
            this.IsExpand = true;
        }


        private void _CShapeControl_ContextMenuClick(object sender, RoutedEventArgs e)
        {
            if (this.OnMenuContextSelected != null)
            {
                this.OnMenuContextSelected(this, new ItemEventArgs()
                {
                    Item = e.Source,
                    ContextMenuItem = e.OriginalSource
                });
            }
        }

        protected void ep_OnContextMenuItemClick(object sender, ItemEventArgs args)
        {
            if (args.ContextMenuItem is MenuItem)
            {
                MenuItem mi = args.ContextMenuItem as MenuItem;
                switch (mi.Header.ToString())
                {
                    case "Delete": this.DeleteItem(args.Item); break;
                    default: if (this.OnMenuContextSelected != null)
                        {
                            this.OnMenuContextSelected(sender, args);
                        }
                        break;
                }
            }
        }

        #region Delete Item
        protected void ep_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                this.DeleteItem(sender);
            }
        }

        public void DeleteItem(object sender)
        {
            CShapeControl cc1 = sender as CShapeControl;
            this.c1.Children.Remove(cc1);
            this.ItemSource.Remove(cc1);
            if (this.ItemContrainer != null)
                this.ItemContrainer.Remove(sender);
            if (this.OnRemoveItemCompleted != null)
                this.OnRemoveItemCompleted(this, new ItemsArgs() { RemovedItem = cc1 });
            //if (this.ItemContrainer != null)
            //    this.ItemContrainer.Remove(sender);
            if (this.OnAckFromChild != null)
                this.OnAckFromChild(this, new SyncItemsArgs() { Item = cc1, SyncState = SyncAckFormStates.Removed });
            this.SetRedirectSelectionItem();
        }
        #endregion

        protected void ep_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.IsDragging = false;
        }

        protected void ep_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.UnSelectItem();
            if(!_isReadOnly)
                this.IsDragging = true;
            CShapeControl cc = sender as CShapeControl;
            object oldItem = this.SelectedItem;
            SelectedItem = cc;
            ((CShapeControl)SelectedItem).ShowBounder = Visibility.Visible;
            ((CShapeControl)SelectedItem).Opacity = 1.0;
            if(!_isReadOnly)
                ((CShapeControl)SelectedItem).CanExpand = Visibility.Visible;
            else
                ((CShapeControl)SelectedItem).CanExpand = Visibility.Collapsed;
            ((CShapeControl)SelectedItem).Focus();
            if (this.OnSelectedItemChanged != null)
                this.OnSelectedItemChanged(this, new ItemsArgs() { NewItem = cc, OldItem = oldItem });
            oldItem = null;
        }

        private void UnSelectItem()
        {
            foreach (UIElement ui in c1.Children)
            {
                if (ui is CShapeControl)
                {
                    CShapeControl acc = ui as CShapeControl;
                    acc.ShowBounder = Visibility.Hidden;
                    acc.Opacity = 0.5;
                    acc.CanExpand = Visibility.Collapsed;
                }
            }
            if (this._relativeTo != null)
                this._relativeTo.UnSelectItem();
            //Sync event back to parent
            if (this.OnAckFromChild != null)
                this.OnAckFromChild(this, new SyncItemsArgs() { Item = null, SyncState = SyncAckFormStates.Selection });
        }

        private void c1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.IsExpand)
            {
                if (this.IsDragging)
                {
                    Point currentPos = e.GetPosition(this.c1);
                    Point coor = new Point((int)currentPos.X, (int)currentPos.Y);
                    //CShapeControl.Location location = new CShapeControl.Location();
                    //location.Coordinate = coor;
                    //((CShapeControl)SelectedItem).ShapeLocation = location;

                    Canvas.SetLeft(((CShapeControl)SelectedItem), currentPos.X - (((CShapeControl)SelectedItem).CenterPos.X));
                    Canvas.SetTop(((CShapeControl)SelectedItem), currentPos.Y - (((CShapeControl)SelectedItem).CenterPos.Y));
                }
            }
        }

        #region Bounding Circle
        private void CreateCircleBounding()
        {
            int l = 4;
            for (int i = 0; i <= 360; i += 30)
            {
                if (l > 12)
                    l = 1;
                CreatePie(i, l++);
            }
        }
        private void CreatePie(double ag, int i)
        {
            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
            Canvas.SetLeft(path, (c1.Width / 2));
            Canvas.SetTop(path, (c1.Height / 2));

            path.Fill = Brushes.Transparent;
            path.Stroke = Brushes.LightGray;

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(0, 0);
            pathFigure.IsClosed = true;

            Double radius = (c1.Width / 2) - 20;
            Double angle = 30.0;

            // Starting Point

            LineSegment lineSegment = new LineSegment(new Point(radius, 0), true);
            // Arc

            ArcSegment arcSegment = new ArcSegment();
            arcSegment.IsLargeArc = angle >= 180.0;
            arcSegment.Point = new Point(Math.Cos(angle * Math.PI / 180) * radius, Math.Sin(angle * Math.PI / 180) * radius);
            arcSegment.Size = new Size(radius, radius);
            arcSegment.SweepDirection = SweepDirection.Clockwise;

            pathFigure.Segments.Add(lineSegment);
            pathFigure.Segments.Add(arcSegment);
            pathGeometry.Figures.Add(pathFigure);

            path.Data = pathGeometry;
            path.Tag = i;
            path.ToolTip = "Clock " + i;
            RotateTransform rotate = new RotateTransform(ag, 0, 0);
            path.RenderTransform = rotate;
            path.MouseEnter += new MouseEventHandler(path_MouseEnter);
            path.MouseLeave += new MouseEventHandler(path_MouseLeave);
            path.MouseLeftButtonDown += new MouseButtonEventHandler(path_MouseLeftButtonDown);
            
            c1.Children.Add(path);
        }
        private void CreateOffsetLine()
        {
            for (int i = 0; i <= 360; i += 30)
            {
                Line line = new Line();
                line.Name = "x" + i;
                line.Tag = i;
                line.Y1 = 0;
                line.X1 = line.X2 = c1.Width / 2;
                line.Y2 = c1.Height / 2;
                line.Stroke = Brushes.LightGray;
                RotateTransform r = new RotateTransform(i, c1.Width / 2, c1.Height / 2);
                line.RenderTransform = r;
                this.c1.Children.Add(line);
            }
        }
        #endregion

        #region Pie Mouse Event

        protected void path_MouseLeave(object sender, MouseEventArgs e)
        {
            System.Windows.Shapes.Path p = sender as System.Windows.Shapes.Path;
            p.Fill = Brushes.Transparent;
        }

        protected void path_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Windows.Shapes.Path p = sender as System.Windows.Shapes.Path;
            p.Fill = Brushes.LightYellow;
        }

        protected void path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Path p = sender as System.Windows.Shapes.Path;
            this.currentClockLocation = (int)p.Tag;
        }

        #endregion

        protected override Size MeasureOverride(Size constraint)
        {
            return base.MeasureOverride(constraint);
        }

        #region Relative Event
        protected void _relativeTo_OnAckFromChild(object sender, SyncItemsArgs args)
        {
            if (args.Item == null && args.SyncState == SyncAckFormStates.Selection)
            {
                //CLEAR PARENT CONTROL
                foreach (UIElement ui in c1.Children)
                {
                    if (ui is CShapeControl)
                    {
                        CShapeControl acc = ui as CShapeControl;
                        acc.ShowBounder = Visibility.Hidden;
                        acc.Opacity = 0.5;
                        acc.CanExpand = Visibility.Collapsed;
                    }
                }
            }
            else if (args.Item != null && args.SyncState == SyncAckFormStates.Added)
            {
                if(this.ItemContrainer != null)
                    this.ItemContrainer.Add(args.Item);
            }
            else if (args.Item != null && args.SyncState == SyncAckFormStates.Removed)
            {
                if (this.ItemContrainer != null)
                    this.ItemContrainer.Remove(args.Item);
                this.SetRedirectSelectionItem();
            }
            else if (args.Item == null && args.SyncState == SyncAckFormStates.Removed)
            {
                
            }
        }
        #endregion

        private void SetItemSource()
        {
            this.RemoveItemSource();
            foreach (object item in _itemSource)
            {
                if (item is CShapeControl)
                {
                    CShapeControl cc1 = item as CShapeControl;
                    if (((Views)cc1.Tag) == View)
                    {
                        if(!c1.Children.Contains(cc1))
                            this.c1.Children.Add(cc1);
                    }
                }
            }
        }

        private void RemoveItemSource()
        {
            this.c1.Children.Clear();
            CreateOffsetLine();
            CreateCircleBounding();
        }

        /// <summary>
        /// This method use to set selected item
        /// </summary>
        /// <param name="value"></param>
        private void SetSelectedItem(object value)
        {
            if (value == null)
                return;
            CShapeControl cc1 = value as CShapeControl;
            if (cc1 != null)
            {
                if (this.ItemContrainer != null)
                {
                    foreach (object item in this.ItemContrainer)
                    {
                        if (item.Equals(cc1))
                        {
                            this.UnSelectItem();
                            object oldItem = this._selectedItem;
                            this._selectedItem = item;
                            ((CShapeControl)item).ShowBounder = Visibility.Visible;
                            ((CShapeControl)item).Opacity = 1.0;
                            if (!_isReadOnly)
                                ((CShapeControl)item).CanExpand = Visibility.Visible;
                            else
                                ((CShapeControl)item).CanExpand = Visibility.Collapsed;
                            ((CShapeControl)item).Focus();
                            if (this.OnSelectedItemChanged != null)
                                this.OnSelectedItemChanged(this, new ItemsArgs() { NewItem = this._selectedItem, OldItem = oldItem });
                        }
                    }
                }
                else
                {
                    foreach (object item in this.ItemSource)
                    {
                        if (item.Equals(cc1))
                        {
                            this.UnSelectItem();
                            object oldItem = this._selectedItem;
                            this._selectedItem = item;
                            ((CShapeControl)item).ShowBounder = Visibility.Visible;
                            ((CShapeControl)item).Opacity = 1.0;
                            if (!_isReadOnly)
                                ((CShapeControl)item).CanExpand = Visibility.Visible;
                            else
                                ((CShapeControl)item).CanExpand = Visibility.Collapsed;
                            ((CShapeControl)item).Focus();
                            if (this.OnSelectedItemChanged != null)
                                this.OnSelectedItemChanged(this, new ItemsArgs() { NewItem = this._selectedItem, OldItem = oldItem });
                        }
                    }
                }
            }
        }

        private void SetMode(Modes value)
        {
            this._mode = value;
            if (value == Modes.Selection)
                this.IsMark = false;
            else
                this.IsMark = true;
        }

        private void SetRedirectSelectionItem()
        {
            if (this.RelativeTo != null)
            {
                if (this.ItemContrainer.Count <= 0)
                    return;
                object item = this.ItemContrainer.Last();
                CShapeControl cc1 = item as CShapeControl;
                if (((Views)cc1.Tag) == View)
                {
                    this.SelectedItem = item;
                }
                else
                {
                    this.RelativeTo.SelectedItem = item;
                }
            }
            else
            {
                if (this.ItemSource.Count <= 0)
                    return;
                object item = this.ItemSource.Last();
                CShapeControl cc1 = item as CShapeControl;
                if (((Views)cc1.Tag) == View)
                {
                    this.SelectedItem = item;
                }
                if (this.OnAckFromChild != null)
                    this.OnAckFromChild(this, new SyncItemsArgs() { Item = null, SyncState = SyncAckFormStates.Removed });
                //this.SelectedItem = this.ItemSource.Last();
            }
        }

        #region Export Image
        /// <summary>
        /// Save To Jpeg format
        /// </summary>
        /// <param name="savePath">save file path</param>
        public void ExportToJpeg(string savePath)
        {
            //SetPermission(System.IO.Path.GetDirectoryName(savePath));
            ExportImageArgs args = new ExportImageArgs();
            args.FileName = System.IO.Path.GetFileName(savePath);
            try
            {
                FileStream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
                Canvas canvas_image = this.c1;
                RenderTargetBitmap bmp
                    = new RenderTargetBitmap(
                        (int)canvas_image.Width
                        , (int)canvas_image.Height
                        , DipHelper.Dip
                        , DipHelper.Dip
                        , PixelFormats.Pbgra32
                        );
                bmp.Render(canvas_image);
                args.ImageSize = new Size(canvas_image.Width, canvas_image.Height);
                BitmapEncoder encode = new JpegBitmapEncoder();
                encode.Frames.Add(BitmapFrame.Create(bmp));
                encode.Save(stream);
                stream.Close();
                args.IsCompleted = true;
            }
            catch (Exception ex)
            {
                args.IsCompleted = false;
                args.ErrorMessage = ex.Message;
            }
            if (this.OnExportImageCompleted != null)
            {
                this.OnExportImageCompleted(this, args);
            }
        }
        /// <summary>
        /// Save to Png format
        /// </summary>
        /// <param name="savePath">save file path</param>
        public void ExportToPng(string savePath)
        {
            ExportImageArgs args = new ExportImageArgs();
            args.FileName = System.IO.Path.GetFileName(savePath);
            try
            {
                FileStream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
                Canvas canvas_image = this.c1;
                RenderTargetBitmap bmp
                    = new RenderTargetBitmap(
                        (int)canvas_image.Width
                        , (int)canvas_image.Height
                        , DipHelper.Dip
                        , DipHelper.Dip
                        , PixelFormats.Pbgra32
                        );
                bmp.Render(canvas_image);
                args.ImageSize = new Size(canvas_image.Width, canvas_image.Height);
                BitmapEncoder encode = new PngBitmapEncoder();
                encode.Frames.Add(BitmapFrame.Create(bmp));
                encode.Save(stream);
                stream.Close();
                args.IsCompleted = true;
            }
            catch (Exception ex)
            {
                args.IsCompleted = false;
                args.ErrorMessage = ex.Message;
            }
            if (this.OnExportImageCompleted != null)
            {
                this.OnExportImageCompleted(this, args);
            }
        }
        /// <summary>
        /// Save to Tif Format
        /// </summary>
        /// <param name="savePath">save file path</param>
        public void ExportToTif(string savePath)
        {
            ExportImageArgs args = new ExportImageArgs();
            args.FileName = System.IO.Path.GetFileName(savePath);
            try
            {
                FileStream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
                Canvas canvas_image = this.c1;
                RenderTargetBitmap bmp
                    = new RenderTargetBitmap(
                        (int)canvas_image.Width
                        , (int)canvas_image.Height
                        , DipHelper.Dip
                        , DipHelper.Dip
                        , PixelFormats.Pbgra32
                        );
                bmp.Render(canvas_image);
                args.ImageSize = new Size(canvas_image.Width, canvas_image.Height);
                BitmapEncoder encode = new TiffBitmapEncoder();
                encode.Frames.Add(BitmapFrame.Create(bmp));
                encode.Save(stream);
                stream.Close();
                
                args.IsCompleted = true;
            }
            catch (Exception ex)
            {
                args.IsCompleted = false;
                args.ErrorMessage = ex.Message;
            }
            if (this.OnExportImageCompleted != null)
            {
                this.OnExportImageCompleted(this, args);
            }
        }
        /// <summary>
        /// Save to Gif format
        /// </summary>
        /// <param name="savePath"></param>
        public void ExportToGif(string savePath)
        {
            ExportImageArgs args = new ExportImageArgs();
            args.FileName = System.IO.Path.GetFileName(savePath);
            try
            {
                FileStream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
                Canvas canvas_image = this.c1;
                RenderTargetBitmap bmp
                    = new RenderTargetBitmap(
                        (int)canvas_image.Width
                        , (int)canvas_image.Height
                        , DipHelper.Dip
                        , DipHelper.Dip
                        , PixelFormats.Pbgra32
                        );
                bmp.Render(canvas_image);
                args.ImageSize = new Size(canvas_image.Width, canvas_image.Height);
                BitmapEncoder encode = new GifBitmapEncoder();
                encode.Frames.Add(BitmapFrame.Create(bmp));
                encode.Save(stream);
                stream.Close();
                args.IsCompleted = true;
            }
            catch (Exception ex)
            {
                args.IsCompleted = false;
                args.ErrorMessage = ex.Message;
            }
            if (this.OnExportImageCompleted != null)
            {
                this.OnExportImageCompleted(this, args);
            }
        }

        public Stream ExportImageToStream()
        {
            MemoryStream stream = new MemoryStream();
            Canvas canvas_image = this.c1;
            RenderTargetBitmap bmp
                = new RenderTargetBitmap(
                    (int)canvas_image.Width
                    , (int)canvas_image.Height
                    , DipHelper.Dip
                    , DipHelper.Dip
                    , PixelFormats.Pbgra32
                    );
            bmp.Render(canvas_image);
            BitmapEncoder encode = new GifBitmapEncoder();
            encode.Frames.Add(BitmapFrame.Create(bmp));
            encode.Save(stream);

            return stream;
        }
        #endregion

        #region Load Marker
        /// <summary>
        /// This method use to load shape control to breast screen
        /// </summary>
        /// <param name="shapeControlList"></param>
        public void LoadMarker(List<CShapeControl> shapeControlList)
        {
            string filter = this.View.ToString();
            foreach (CShapeControl control in shapeControlList)
            {
                if (control.Name.Contains(filter))
                {
                    control.Tag = View;
                    if (!_isReadOnly)
                    {
                        control.ContextMenuClick += new RoutedEventHandler(_CShapeControl_ContextMenuClick);
                        control.KeyUp += new KeyEventHandler(ep_KeyUp);
                        control.OnExpanding += new RoutedEventHandler(_CShapeControl_OnExpanding);
                        control.OnExpanded += new RoutedEventHandler(_CShapeControl_OnExpanded);
                        control.OnDiameterChanged += new RoutedPropertyChangedEventHandler<double>(_CShapeControl_OnDiameterChanged);
                    }

                    control.MouseLeftButtonDown += new MouseButtonEventHandler(ep_MouseLeftButtonDown);
                    control.MouseLeftButtonUp += new MouseButtonEventHandler(ep_MouseLeftButtonUp);

                    Canvas.SetLeft(control, control.ShapeLocation.Coordinate.X - ((control.Diameter + 8) / 2));
                    Canvas.SetTop(control, control.ShapeLocation.Coordinate.Y - ((control.Diameter + 8) / 2));
                    this.ItemSource.Add(control);
                    this.c1.Children.Add(control);

                    if (this.ItemContrainer != null)
                    {
                        this.ItemContrainer.Add(control);
                    }
                }
            }
        }
        #endregion
    }
}
