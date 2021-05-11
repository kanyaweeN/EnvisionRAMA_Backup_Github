///
/// PJ. Miracle (Ton) 4/12/2010
/// 
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
using EnvisionBreastControl.Lib.Cores.Enumulator;
using EnvisionBreastControl.Lib.Cores.Events;
using EnvisionBreastControl.Lib.Cores.Helper;

namespace EnvisionBreastControl.Lib
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFControlLib"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFControlLib;assembly=WPFControlLib"
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
    ///     <MyNamespace:CCircleControl/>
    ///
    /// </summary>
    /// 
    [TemplatePart(Name = CCircleControl.ELEMENT_EXP, Type = typeof(CCircleControl))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU, Type = typeof(ContextMenu))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_ARCH, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_ASSO, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_CALC, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_MESS, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_SPCC, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_MI_DELETE, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_MI_DIAMETER, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_MI_FIX_SIZE, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_CONTEXT_MENU_MI_PROPERTIES, Type = typeof(MenuItem))]
    [TemplatePart(Name = CCircleControl.ELEMENT_EXP, Type = typeof(CExpandDiameterControl))]
    public class CCircleControl : Control
    {
        private const string ELEMENT_EXP = "C_EXPANDER";
        private const string ELEMENT_CONTEXT_MENU = "CONTEXT_MENU";
        private const string ELEMENT_CONTEXT_MENU_ITEM_MESS = "MI_MESS";
        private const string ELEMENT_CONTEXT_MENU_ITEM_CALC = "MI_CALC";
        private const string ELEMENT_CONTEXT_MENU_ITEM_ARCH = "MI_ARCH";
        private const string ELEMENT_CONTEXT_MENU_ITEM_SPCC = "MI_SPCC";
        private const string ELEMENT_CONTEXT_MENU_ITEM_ASSO = "MI_ASSO";
        private const string ELEMENT_CONTEXT_MENU_MI_DIAMETER = "MI_DIAMETER";
        private const string ELEMENT_CONTEXT_MENU_MI_FIX_SIZE = "MI_FIX_SIZE";
        private const string ELEMENT_CONTEXT_MENU_MI_PROPERTIES = "MI_PROPERTIES";
        private const string ELEMENT_CONTEXT_MENU_MI_DELETE = "MI_DELETE";
        private const Visibility DEFAULT_CAN_EXPAND = Visibility.Visible;
        private const Visibility DEFAULT_SHOW_BOUNDER = Visibility.Visible;
        private const double DEFAULT_RULER_OFFSET = 12.0; //default ruler offset
        private const double DEFAULT_CONTENT_OFFSET = 1.0; //default content offset
        private const double DEFAULT_BOUNDER_DIAMETER = 52;
        private static readonly double DEFAULT_DIAMITER = 50.0; //Default diameter
        public Point CenterPos { get; set; }

        ContextMenu contextMenu;
        MenuItem miMess;
        MenuItem miCalc;
        MenuItem miArch;
        MenuItem miSpcc;
        MenuItem miAsso;
        MenuItem miDiameter;
        MenuItem miFixSize;
        MenuItem miProperties;
        MenuItem miDelete;
        CExpandDiameterControl expander;

        #region Attach Expander Property
        public static readonly DependencyProperty DiameterProperty
            = DependencyProperty.Register(
            "Diameter", typeof(double), typeof(CCircleControl),
            new FrameworkPropertyMetadata(CCircleControl.DEFAULT_DIAMITER, FrameworkPropertyMetadataOptions.AffectsMeasure));


        public double Diameter
        {
            get { return (double)this.GetValue(DiameterProperty); }
            set
            {
                this.SetValue(DiameterProperty, value);
            }
        }

        public static DependencyProperty ContentOffsetProperty
            = DependencyProperty.Register("ContentOffset", typeof(double), typeof(CCircleControl),
            new FrameworkPropertyMetadata(CCircleControl.DEFAULT_CONTENT_OFFSET, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double ContentOffset
        {
            get { return (double)this.GetValue(ContentOffsetProperty); }
            set { this.SetValue(ContentOffsetProperty, value); }
        }

        public static DependencyProperty CanExpandProperty
            = DependencyProperty.Register("CanExpand", typeof(Visibility), typeof(CCircleControl),
            new FrameworkPropertyMetadata(CCircleControl.DEFAULT_CAN_EXPAND, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Visibility CanExpand
        {
            get { return (Visibility)this.GetValue(CanExpandProperty); }
            set { this.SetValue(CanExpandProperty, value); }
        }

        public static DependencyProperty ShowBounderProperty
            = DependencyProperty.Register("ShowBounder", typeof(Visibility), typeof(CCircleControl),
            new FrameworkPropertyMetadata(CCircleControl.DEFAULT_SHOW_BOUNDER, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Visibility ShowBounder
        {
            get { return (Visibility)this.GetValue(ShowBounderProperty); }
            set { this.SetValue(ShowBounderProperty, value); }
        }

        #region SCALE DIAMETER RULER PROPERIES
        public static readonly DependencyProperty LineScaleColorProperty
            = DependencyProperty.Register("LineScaleColor", typeof(Brush), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(Brushes.SteelBlue, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush LineScaleColor
        {
            get { return (Brush)this.GetValue(LineScaleColorProperty); }
            set { this.SetValue(LineScaleColorProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextForegroundProperty
            = DependencyProperty.Register("LineScaleTextForeground", typeof(Brush), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(Brushes.SteelBlue, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush LineScaleTextForeground
        {
            get { return (Brush)this.GetValue(LineScaleTextForegroundProperty); }
            set { this.SetValue(LineScaleTextForegroundProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextBackgroundProperty
            = DependencyProperty.Register("LineScaleTextBackground", typeof(Brush), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(Brushes.White, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush LineScaleTextBackground
        {
            get { return (Brush)this.GetValue(LineScaleTextBackgroundProperty); }
            set { this.SetValue(LineScaleTextBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LineThicknessProperty
            = DependencyProperty.Register("LineThickness", typeof(double), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(3.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public double LineThickness
        {
            get { return (double)this.GetValue(LineThicknessProperty); }
            set { this.SetValue(LineThicknessProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextFontSizeProperty
            = DependencyProperty.Register("LineScaleTextFontSize", typeof(double), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(9.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public double LineScaleTextFontSize
        {
            get { return (double)this.GetValue(LineScaleTextFontSizeProperty); }
            set { this.SetValue(LineScaleTextFontSizeProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextFontFamilyProperty
            = DependencyProperty.Register("LineScaleTextFontFamily", typeof(FontFamily), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(new FontFamily("Arial"), FrameworkPropertyMetadataOptions.AffectsRender));
        public FontFamily LineScaleTextFontFamily
        {
            get { return (FontFamily)this.GetValue(LineScaleTextFontFamilyProperty); }
            set { this.SetValue(LineScaleTextFontFamilyProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextWidthProperty
            = DependencyProperty.Register("LineScaleTextWidth", typeof(double), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(26.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public double LineScaleTextWidth
        {
            get { return (double)this.GetValue(LineScaleTextWidthProperty); }
            set { this.SetValue(LineScaleTextWidthProperty, value); }
        }

        public static readonly DependencyProperty LineScaleTextAlginmentProperty
            = DependencyProperty.Register("LineScaleTextAlginment", typeof(TextAlignment), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(TextAlignment.Center, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public TextAlignment LineScaleTextAlginment
        {
            get { return (TextAlignment)this.GetValue(LineScaleTextAlginmentProperty); }
            set { this.SetValue(LineScaleTextAlginmentProperty, value); }
        }
        #endregion

        public static DependencyProperty UnitProperty
            = DependencyProperty.Register("Unit", typeof(Units), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(Units.Pixel, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Units Unit
        {
            get { return (Units)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }
        #endregion

        public static readonly DependencyProperty CircleBackgroundProperty
            = DependencyProperty.Register("CircleBackground", typeof(Brush), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(Brushes.Transparent, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush CircleBackground
        {
            get { return (Brush)this.GetValue(CircleBackgroundProperty); }
            set { this.SetValue(CircleBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CircleStrokeColorProperty
            = DependencyProperty.Register("CircleStrokeColor", typeof(Brush), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));
        public Brush CircleStrokeColor
        {
            get { return (Brush)this.GetValue(CircleStrokeColorProperty); }
            set { this.SetValue(CircleStrokeColorProperty, value); }
        }

        public static readonly DependencyProperty CircleStrokeThicknessProperty
            = DependencyProperty.Register("CircleStrokeThickness", typeof(double), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public double CircleStrokeThickness
        {
            get { return (double)this.GetValue(CircleStrokeThicknessProperty); }
            set { this.SetValue(CircleStrokeThicknessProperty, value); }
        }

        public static DependencyProperty MaximunProperty
            = DependencyProperty.RegisterAttached("Maximun", typeof(double), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(200.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public double Maximun
        {
            get { return (double)this.GetValue(MaximunProperty); }
            set { this.SetValue(MaximunProperty, value); }
        }

        public static DependencyProperty MinimunProperty
            = DependencyProperty.Register("Minimun", typeof(double), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double Minimun
        {
            get { return (double)this.GetValue(MinimunProperty); }
            set { this.SetValue(MinimunProperty, value); }
        }

        public static DependencyProperty ReadOnlyProperty
            = DependencyProperty.Register("ReadOnly", typeof(bool), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(CExpandDiameterControl.OnReadOnlyChanged)));

        public static void OnReadOnlyChanged(DependencyObject denpendencyObj, DependencyPropertyChangedEventArgs args)
        {

        }

        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set
            {
                SetValue(ReadOnlyProperty, value);
            }
        }

        #region MenuContextItem
        public static DependencyProperty ContextMenuItemProperty
            = DependencyProperty.Register("ContextMenuItem", typeof(ContextMenuItemHepler), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(new ContextMenuItemHepler(), new PropertyChangedCallback(CCircleControl.OnItemSourceChanged), new CoerceValueCallback(CCircleControl.CoecreMenuItemSource)));

        public static void OnItemSourceChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {

        }
        public static object CoecreMenuItemSource(DependencyObject dependencyObj, object obj)
        {
            return obj;
        }

        public static DependencyProperty ShowContextMenuProperty
            = DependencyProperty.Register("ShowContextMenu", typeof(Visibility), typeof(CCircleControl)
            , new FrameworkPropertyMetadata(Visibility.Visible, new PropertyChangedCallback(CCircleControl.OnShowContextMenuChanged), new CoerceValueCallback(CCircleControl.CoecreOnShowContextMenu)));

        public static void OnShowContextMenuChanged(DependencyObject dependencyObj, DependencyPropertyChangedEventArgs args)
        {

        }
        public static object CoecreOnShowContextMenu(DependencyObject dependencyObj, object obj)
        {
            return obj;
        }

        public Visibility ShowContextMenu
        {
            get { return (Visibility)this.GetValue(ShowContextMenuProperty); }
            set { this.SetValue(ShowContextMenuProperty, value); }
        }

        public static RoutedEvent ContextMenuClickEvent
            = EventManager.RegisterRoutedEvent("ContextMenuClick"
            , RoutingStrategy.Bubble
            , typeof(RoutedEventArgs)
            , typeof(CCircleControl));

        public event RoutedEventHandler ContextMenuClick
        {
            add { base.AddHandler(ContextMenuClickEvent, value); }
            remove { base.RemoveHandler(ContextMenuClickEvent, value); }
        }

        public static RoutedEvent OnExpandedEvent
            = EventManager.RegisterRoutedEvent("OnExpanded"
            , RoutingStrategy.Bubble
            , typeof(RoutedEventArgs)
            , typeof(CCircleControl));

        public event RoutedEventHandler OnExpanded
        {
            add { base.AddHandler(OnExpandedEvent, value); }
            remove { base.RemoveHandler(OnExpandedEvent, value); }
        }

        public static RoutedEvent OnExpandingEvent
            = EventManager.RegisterRoutedEvent("OnExpanding"
            , RoutingStrategy.Bubble
            , typeof(RoutedEventArgs)
            , typeof(CCircleControl));

        public event RoutedEventHandler OnExpanding
        {
            add { base.AddHandler(OnExpandingEvent, value); }
            remove { base.RemoveHandler(OnExpandingEvent, value); }
        }

        public static RoutedEvent OnDiameterChangedEvent
            = EventManager.RegisterRoutedEvent("OnDiameterChanged", RoutingStrategy.Bubble
            , typeof(RoutedPropertyChangedEventHandler<double>), typeof(CCircleControl));

        public event RoutedPropertyChangedEventHandler<double> OnDiameterChanged
        {
            add { base.AddHandler(OnDiameterChangedEvent, value); }
            remove { base.RemoveHandler(OnDiameterChangedEvent, value); }
        }
          
        #endregion

        static CCircleControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CCircleControl), new FrameworkPropertyMetadata(typeof(CCircleControl)));
        }

        public CCircleControl()
        {
            //this.CenterPos = new Point(0, 0);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            contextMenu = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU) as ContextMenu;
            miArch = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_ARCH) as MenuItem;
            miAsso = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_ASSO) as MenuItem;
            miCalc = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_CALC) as MenuItem;
            miDelete = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_MESS) as MenuItem;
            miDiameter = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_ITEM_SPCC) as MenuItem;
            miFixSize = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_MI_DELETE) as MenuItem;
            miMess = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_MI_DIAMETER) as MenuItem;
            miProperties = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_MI_FIX_SIZE) as MenuItem;
            miSpcc = GetTemplateChild(CCircleControl.ELEMENT_CONTEXT_MENU_MI_PROPERTIES) as MenuItem;
            if (miArch != null)
                miArch.Click += OnContextMenuClick;
            if (miAsso != null)
                miAsso.Click += OnContextMenuClick;
            if (miCalc != null)
                miCalc.Click += OnContextMenuClick;
            if (miDelete != null)
                miDelete.Click += OnContextMenuClick;
            if (miDiameter != null)
                miDiameter.Click += OnContextMenuClick;
            if (miFixSize != null)
                miFixSize.Click += OnContextMenuClick;
            if (miMess != null)
                miMess.Click += OnContextMenuClick;
            if (miProperties != null)
                miProperties.Click += OnContextMenuClick;
            if (miSpcc != null)
                miSpcc.Click += OnContextMenuClick;

            expander = GetTemplateChild(CCircleControl.ELEMENT_EXP) as CExpandDiameterControl;
            expander.CenterChanged += CenterChanged;
            expander.DiameterChanged += DiameterChanged;
            expander.Expanding += Expanding;
            expander.Expanded += Expanded;
            expander.ReadOnly = this.ReadOnly;
            this.CenterPos = expander.Center;
        }

        public void  OnContextMenuClick(object sender, RoutedEventArgs args)
        {
            RoutedEventArgs e = new RoutedEventArgs(ContextMenuClickEvent, sender);
            base.RaiseEvent(e);
        }

        public void Expanding(object sender, RoutedEventArgs args)
        {
            RoutedEventArgs e = new RoutedEventArgs(OnExpandingEvent, sender);
            base.RaiseEvent(e);
        }

        public void Expanded(object sender, RoutedEventArgs args)
        {
            RoutedEventArgs e = new RoutedEventArgs(OnExpandedEvent, sender);
            base.RaiseEvent(e);
        }
        public void DiameterChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            RoutedPropertyChangedEventArgs<double> e = new RoutedPropertyChangedEventArgs<double>(args.OldValue, args.NewValue);
            e.RoutedEvent = OnDiameterChangedEvent;
            base.RaiseEvent(e);
        }

        public void CenterChanged(object sender, RoutedPropertyChangedEventArgs<Point> args)
        {
            this.CenterPos = args.NewValue;
        }
    }
}
