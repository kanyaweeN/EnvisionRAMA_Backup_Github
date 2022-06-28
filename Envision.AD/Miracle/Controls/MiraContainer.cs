using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Miracle.UserControls
{
    public enum SetCorners { none, LeftUp, LeftDown, RightUp, RightDown, LeftUpDown, RightUpDown, LeftRightUp, LeftRightDown }
    public partial class MiraContainer : UserControl
    {
        
        private Color _MainHilightColor = Color.Gainsboro;
        private Color _SubHilightColor = Color.WhiteSmoke;
        private Color Default_MainHilightColor = Color.Orange;
        private Color Default_SubHilightColor = Color.White;
        private Color _MainLineColor = Color.Gray;
        private Color _ShadowColor = Color.Transparent;
        private int _Round = 0;
        //private int _StepText = 3;
        private Color _ForeColor;
        private Font _font;
        private string _str;
        #region Properties
        private SetCorners _SetCorners;
        public SetCorners SettingCorners
        {
            get { return _SetCorners; }
            set { _SetCorners = value; }
        }
        public Color MainHilightColor
        {
            get { return _MainHilightColor; }
            set
            {
                _MainHilightColor = value;
                Switch_MainHilightColor = value;
                //lbName.ForeColor = value;
            }
        }
        public Color SubHilightColor
        {
            get { return _SubHilightColor; }
            set
            {
                _SubHilightColor = value;
                Switch_SubHilightColor = value;
                //lbName.ForeColor = value;
            }
        }
        public Color LineColor
        {
            get { return _MainLineColor; }
            set
            {
                _MainLineColor = value;
                //lbName.ForeColor = value;
            }
        }
        public Color ShadowColor
        {
            get { return _ShadowColor; }
            set
            {
                _ShadowColor = value;
                //lbName.ForeColor = value;
            }
        }
        public int Round
        {
            get { return _Round; }
            set
            {
                if (value > 0)
                {
                    _Round = value;
                    //Point pt = new Point(value, 0);
                    //lbName.Location = pt;
                }
                else
                {
                    _Round = 1;
                }

                //lbName.ForeColor = value;
            }
        }
        //public int StepText
        //{
        //    get { return _StepText; }
        //    set
        //    {
        //        if (value > 0)
        //        {
        //            _StepText = value;
        //            SetLabelStep(true);
        //            //for (int i = 0:i<value:
        //            //Point pt = new Point(value, 0);
        //            //lbName.Location = pt;
        //        }
        //        else
        //        {
        //            _StepText = 0;
        //        }

        //        //lbName.ForeColor = value;
        //    }
        //}
        public Color ContainerForeColor
        {
            get { return _ForeColor; }
            set
            {
                _ForeColor = value;
                lbName.ForeColor = value;
            }
        }
        public Font ContainerFont
        {
            get { return _font; }
            set
            {
                _font = value;
                lbName.Font = value;
            }
        }
        public string ContainerText
        {
            get { return _str; }
            set
            {
                _str = value;
                lbName.Text = value;
            }
        }
        #endregion

        private Color Switch_MainHilightColor;
        private Color Switch_SubHilightColor;
        public MiraContainer()
        {
            InitializeComponent();
        }
  
        private void MiraContainer_Load(object sender, EventArgs e)
        {
            //_ColorText = label1.BackColor;
            _ForeColor = lbName.ForeColor;
            _font = lbName.Font;
            //_ContainerStyles = global::MiraController.Properties.Resources.LightBlue_White;
            _str = lbName.Text;
        }
        private void MiraContainer_SizeChanged(object sender, EventArgs e)
        {
            System.Drawing.Size sz1 = new Size(this.Size.Width - 2, this.Size.Height - 2);
            System.Drawing.Size sz2 = new Size(this.Size.Width - 3, this.Size.Height - 3);
            panel1.Size = sz2;
            lbName.Size = sz2;
            //lbName.ForeColor
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void MiraContainer_Paint(object sender, PaintEventArgs e)
        {
            GraphicsContainer containerState = e.Graphics.BeginContainer();
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Graphics g = this.CreateGraphics();
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            SetBackGround(e,this._MainHilightColor,this._SubHilightColor,this.LineColor,this.ShadowColor,this.Round);
            e.Graphics.EndContainer(containerState);
        }
        private PointF[] SettingRectangle(float X1,float X2,float Y1,float Y2)
        {
            PointF[] Rectangle = new PointF[5];
            //string str = this.SettingCorners.ToString();
            switch (this.SettingCorners.ToString())
            {
                case ("LeftUp"):
                    Rectangle[0].X = X1;
                    Rectangle[0].Y = Y1;
                    Rectangle[1].X = X2;
                    Rectangle[1].Y = Y1;
                    Rectangle[2].X = X2;
                    Rectangle[2].Y = Y2;
                    Rectangle[3].X = X1;
                    Rectangle[3].Y = Y2;
                    Rectangle[4].X = X1;
                    Rectangle[4].Y = 1;
                    break;
                case ("LeftDown"):
                    Rectangle[0].X = X1;
                    Rectangle[0].Y = Y2;
                    Rectangle[1].X = X1;
                    Rectangle[1].Y = Y1;
                    Rectangle[2].X = X2;
                    Rectangle[2].Y = Y1;
                    Rectangle[3].X = X2;
                    Rectangle[3].Y = Y2;
                    Rectangle[4].X = X1;
                    Rectangle[4].Y = Y2 - 1;
                    break;
                case ("RightUp"):
                    Rectangle[0].X = X2;
                    Rectangle[0].Y = Y1;
                    Rectangle[1].X = X2;
                    Rectangle[1].Y = Y2;
                    Rectangle[2].X = X1;
                    Rectangle[2].Y = Y2;
                    Rectangle[3].X = X1;
                    Rectangle[3].Y = Y1;
                    Rectangle[4].X = X2;
                    Rectangle[4].Y = Y1 - 1;
                    break;
                case ("RightDown"):
                    Rectangle[0].X = X2;
                    Rectangle[0].Y = Y2;
                    Rectangle[1].X = X1;
                    Rectangle[1].Y = Y2;
                    Rectangle[2].X = X1;
                    Rectangle[2].Y = Y1;
                    Rectangle[3].X = X2;
                    Rectangle[3].Y = Y1;
                    Rectangle[4].X = X2;
                    Rectangle[4].Y = Y2 - 1;
                    break;
                case ("LeftRightUp"):
                    Rectangle[0].X = X2;
                    Rectangle[0].Y = Y1;
                    Rectangle[1].X = X2;
                    Rectangle[1].Y = Y2;
                    Rectangle[2].X = X1;
                    Rectangle[2].Y = Y2;
                    Rectangle[3].X = X1;
                    Rectangle[3].Y = Y1;
                    Rectangle[4].X = X1;
                    Rectangle[4].Y = Y1;
                    break;
                case ("LeftRightDown"):
                    Rectangle[0].X = X1;
                    Rectangle[0].Y = Y2;
                    Rectangle[1].X = X1;
                    Rectangle[1].Y = Y1;
                    Rectangle[2].X = X2;
                    Rectangle[2].Y = Y1;
                    Rectangle[3].X = X2;
                    Rectangle[3].Y = Y2;
                    Rectangle[4].X = X2;
                    Rectangle[4].Y = Y2;
                    break;
                case ("LeftUpDown"):
                    Rectangle[0].X = X1;
                    Rectangle[0].Y = Y1;
                    Rectangle[1].X = X2;
                    Rectangle[1].Y = Y1;
                    Rectangle[2].X = X2;
                    Rectangle[2].Y = Y2;
                    Rectangle[3].X = X1;
                    Rectangle[3].Y = Y2;
                    Rectangle[4].X = X1;
                    Rectangle[4].Y = Y2;
                    break;
                case ("RightUpDown"):
                    Rectangle[0].X = X2;
                    Rectangle[0].Y = Y2;
                    Rectangle[1].X = X1;
                    Rectangle[1].Y = Y2;
                    Rectangle[2].X = X1;
                    Rectangle[2].Y = Y1;
                    Rectangle[3].X = X2;
                    Rectangle[3].Y = Y1;
                    Rectangle[4].X = X2;
                    Rectangle[4].Y = Y1;
                    break;
                default:
                    Rectangle[0].X = X1;
                    Rectangle[0].Y = Y1;
                    Rectangle[1].X = X2;
                    Rectangle[1].Y = Y1;
                    Rectangle[2].X = X2;
                    Rectangle[2].Y = Y2;
                    Rectangle[3].X = X1;
                    Rectangle[3].Y = Y2;
                    Rectangle[4].X = X1;
                    Rectangle[4].Y = Y1;
                    break;
            }
            return Rectangle;
           
        }
        private void SetBackGround(PaintEventArgs e,Color MainHilight,Color SubHilight,Color MainLine,Color Shadow,int Round)
        {
            Pen ShaowPen = new Pen(Shadow, 2);
            GraphicsPath ShadowPath = new GraphicsPath();
            PointF[] ShadowRectangle = new PointF[5];
            //ShadowRectangle[0].X = 5;
            //ShadowRectangle[0].Y = 1;
            //ShadowRectangle[1].X = panel1.Size.Width;
            //ShadowRectangle[1].Y = 1;
            //ShadowRectangle[2].X = panel1.Size.Width;
            //ShadowRectangle[2].Y = panel1.Size.Height + 1;
            //ShadowRectangle[3].X = 5;
            //ShadowRectangle[3].Y = panel1.Size.Height + 1;
            //ShadowRectangle[4].X = 5;
            //ShadowRectangle[4].Y = 1;
            Cpp.Diagram.Rounded.Corners ShadowRound = new Cpp.Diagram.Rounded.Corners(SettingRectangle(5, panel1.Size.Width, 1, panel1.Size.Height + 1), Round);
            ShadowRound.Execute(ShadowPath);
            ShadowPath.CloseFigure();

            LinearGradientBrush ShadowBrush = new LinearGradientBrush(ShadowPath.GetBounds(),Shadow, Shadow, LinearGradientMode.Vertical);

            e.Graphics.FillPath(ShadowBrush, ShadowPath);
            e.Graphics.DrawPath(ShaowPen, ShadowPath);

            ShadowPath.Dispose();
            ShadowBrush.Dispose();
            ShaowPen.Dispose();


            Pen pen = new Pen(MainLine, 1);
            GraphicsPath path = new GraphicsPath();
            PointF[] roundedRectangle = new PointF[5];
            //P1
            //roundedRectangle[0].X = 0;
            //roundedRectangle[0].Y = 0;
            //roundedRectangle[1].X = panel1.Size.Width - 1;
            //roundedRectangle[1].Y = 0;
            //roundedRectangle[2].X = panel1.Size.Width - 1;
            //roundedRectangle[2].Y = panel1.Size.Height - 1;
            //roundedRectangle[3].X = 0;
            //roundedRectangle[3].Y = panel1.Size.Height - 1;
            //roundedRectangle[4].X = 0;
            //roundedRectangle[4].Y = 0;

            //P2
            //roundedRectangle[0].X = panel1.Size.Width - 1;
            //roundedRectangle[0].Y = 0;
            //roundedRectangle[1].X = panel1.Size.Width - 1;
            //roundedRectangle[1].Y = panel1.Size.Height - 1;
            //roundedRectangle[2].X = 0;
            //roundedRectangle[2].Y = panel1.Size.Height - 1;
            //roundedRectangle[3].X = 0;
            //roundedRectangle[3].Y = 0;
            //roundedRectangle[4].X = panel1.Size.Width - 1;
            //roundedRectangle[4].Y = 0;

            //P3
            //roundedRectangle[0].X = panel1.Size.Width - 1;
            //roundedRectangle[0].Y = panel1.Size.Height - 1;
            //roundedRectangle[1].X = 0;
            //roundedRectangle[1].Y = panel1.Size.Height - 1;
            //roundedRectangle[2].X = 0;
            //roundedRectangle[2].Y = 0;
            //roundedRectangle[3].X = panel1.Size.Width - 1;
            //roundedRectangle[3].Y = 0;
            //roundedRectangle[4].X = panel1.Size.Width - 1;
            //roundedRectangle[4].Y = panel1.Size.Height - 1;

            //P4
            //roundedRectangle[0].X = 0;
            //roundedRectangle[0].Y = panel1.Size.Height - 1;
            //roundedRectangle[1].X = 0;
            //roundedRectangle[1].Y = 0;
            //roundedRectangle[2].X = panel1.Size.Width - 1;
            //roundedRectangle[2].Y = 0;
            //roundedRectangle[3].X = panel1.Size.Width - 1;
            //roundedRectangle[3].Y = panel1.Size.Height - 1;
            //roundedRectangle[4].X = 0;
            //roundedRectangle[4].Y = panel1.Size.Height - 1;

            Cpp.Diagram.Rounded.Corners r = new Cpp.Diagram.Rounded.Corners(SettingRectangle(0, panel1.Size.Width - 1, 0, panel1.Size.Height - 1), Round);
            r.Execute(path);
            path.CloseFigure();

            LinearGradientBrush brush = new LinearGradientBrush(path.GetBounds(), MainHilight, SubHilight, LinearGradientMode.Vertical);

            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(pen, path);

            brush.Dispose();
            pen.Dispose();
            path.Dispose();
        }
        public void SetLabelStep(bool tf)
        {
            //string strNull = " ";
            //string str = "";
            //if (tf == true)
            //{
            //    for (int i = 0; i < _StepText; i++)
            //    {
            //        str = str + strNull;
            //    }
            //    lbName.Text = str + lbName.Text;
            //}
            //else
            //{
            //    string OldText = lbName.Text;
            //    lbName.Text = " " + lbName.Text;
            //    lbName.Text = OldText;
            //}
        }
        private void lbName_MouseHover(object sender, EventArgs e)
        {
            SetLabelStep(false);
            _MainHilightColor = Default_MainHilightColor;
            _SubHilightColor = Default_SubHilightColor;
        }

        private void lbName_MouseLeave(object sender, EventArgs e)
        {
            SetLabelStep(false);
            _MainHilightColor = Switch_MainHilightColor;
            _SubHilightColor = Switch_SubHilightColor;
        }
    }
}
