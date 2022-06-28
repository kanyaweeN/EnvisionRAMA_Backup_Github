using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections; 


/// <summary>
/// Summary description for Class1
/// </summary>

namespace Cpp.Diagram.Rounded
{
    abstract class CornersItem
    {
        private bool visible;
        public CornersItem() 
        {
            visible = true;
        }
        public abstract void addToPath(GraphicsPath path);
        public bool Visible
        {
            get { return visible;}
            set { visible = value; }
        }
    }

    class CornersLine : CornersItem
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double newX1;
        private double newY1;
        private double newX2;
        private double newY2;

        public double X1
        {
            get { return x1; }
            set { x1 = value; newX1 = value;}
        }
        public double Y1
        {
            get { return y1; }
            set { y1 = value; newY1 = value; }
        }
        public double X2
        {
            get { return x2; }
            set { x2 = value; newX2 = value; }
        }
        public double Y2
        {
            get { return y2; }
            set { y2 = value; newY2 = value; }
        }
        public double NewX1
        {
            get { return newX1; }
            set { newX1 = value; }
        }
        public double NewY1
        {
            get { return newY1; }
            set { newY1 = value; }
        }
        public double NewX2
        {
            get { return newX2; }
            set { newX2 = value; }
        }
        public double NewY2
        {
            get { return newY2; }
            set { newY2 = value; }
        }
        public override void addToPath(GraphicsPath path)
        {
            if (Visible) {
                if (Math.Sqrt(Math.Pow(newX1 - newX2, 2) + Math.Pow(newY1 - newY2, 2)) > 0.01)
                {
                    path.AddLine((float) newX1, (float)newY1, (float)newX2, (float)newY2);
                }
            }
        }

    }

    class CornersArc : CornersItem
    {
        private double x;
        private double y;
        private double width;
        private double height;
        private double startAngle;
        private double sweepAngle;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }

        public double SweepAngle
        {
            get { return sweepAngle; }
            set { sweepAngle = value; }
        }

        public override void addToPath(GraphicsPath path)
        {
            if (Visible)
            {
                try
                {
                    path.AddArc((float)x, (float)y, (float)width, (float)height, (float)startAngle, (float)(sweepAngle));
                }
                catch (Exception ex)
                {
                    //path.AddArc(0, 0, 0, 0, -90, 0);
                }
            }
        }
    }


    public class Corners
    {
        private PointF[] points;
        private double radius;
        private ArrayList list = new ArrayList();

        private void fillList()
        {
            CornersLine line;
            switch (points.Length)
            {
                case 2:
                    line = new CornersLine();
                    list.Add(line);
                    line.X1 = points[0].X;
                    line.Y1 = points[0].Y;
                    line.X2 = points[1].X;
                    line.Y2 = points[1].Y;
                    break;
                default:
                    PointF firstPoint = new PointF(points[0].X,points[0].Y);
                    for (int i = 1, j = 0; i < points.Length; i++)
                    {
                            line = new CornersLine();
                            list.Add(line);
                            line.X1 = points[j].X;
                            line.Y1 = points[j].Y;
                            ++j;
                            line.X2 = points[j].X;
                            line.Y2 = points[j].Y;
                            if (i != points.Length - 1)
                            {
                                CornersArc arc = new CornersArc();
                                list.Add(arc);
                            }
                            else
                            {
                                if ((firstPoint.X == points[j].X) && (firstPoint.Y == points[j].Y))
                                {
                                    CornersArc arc = new CornersArc();
                                    list.Add(arc);
                                }

                            }
                        
                    }
                    break;
            }
        }

        public Corners(PointF[] points, double radius)
        {
            this.points = points;
            this.radius = radius;
            fillList();
        }

        public void Execute(GraphicsPath path) 
        {
            CornersLine line1,line2;
            CornersArc arc;

            int i = 0;
            while (true)
            {
                if (i == list.Count) break;
                line1 = list[i] as CornersLine;
                i++;
                if (i == list.Count) break;
                arc = list[i] as CornersArc;
                i++;
                if (i == list.Count)
                    line2 = list[0] as CornersLine;
                else
                    line2 = list[i] as CornersLine;
                CalculateRoundLines(line1, line2, arc);
            }

            for (int j = 0; j < list.Count; j++) 
            {
                (list[j] as CornersItem).addToPath(path);
            }
        }

        private void CalculateRoundLines(CornersLine line1, CornersLine line2, 
            CornersArc arc)
        {
            double f1 = Math.Atan2(line1.Y1 - line1.Y2, line1.X1 - line1.X2);
            double f2 = Math.Atan2(line2.Y2 - line2.Y1, line2.X2 - line2.X1);
            double alfa = f2 - f1;
            if ((alfa == 0) || (Math.Abs(alfa) == Math.PI)) 
                addWithoutArc(arc);
            else
                addWithArc(line1, line2, arc, f1, f2, alfa);
        }

        private static void addWithoutArc(CornersArc arc)
        {
            arc.Visible = false;
        }

        private void addWithArc(CornersLine line1, CornersLine line2, CornersArc arc, double f1, double f2, double alfa)
        {
            double s = radius / Math.Tan(alfa / 2);
            double line1Length = Math.Sqrt(Math.Pow(line1.X1 - line1.X2, 2) + Math.Pow(line1.Y1 - line1.Y2, 2));
            double line2Length = Math.Sqrt(Math.Pow(line2.X1 - line2.X2, 2) + Math.Pow(line2.Y1 - line2.Y2, 2));
            double newRadius = radius;

            if ((Math.Abs(s) > line1Length / 2) || (Math.Abs(s) > line2Length / 2))
            {
                if (s < 0)
                    s = -Math.Min(line1Length / 2, line2Length / 2);
                else
                    s = Math.Min(line1Length / 2, line2Length / 2);
                newRadius = s * Math.Tan(alfa / 2);
            }

            line1.NewX2 = line1.X2 + Math.Abs(s) * Math.Cos(f1);
            line1.NewY2 = line1.Y2 + Math.Abs(s) * Math.Sin(f1);
            line2.NewX1 = line2.X1 + Math.Abs(s) * Math.Cos(f2);
            line2.NewY1 = line2.Y1 + Math.Abs(s) * Math.Sin(f2);

            double circleCenterAngle = f1 + alfa / 2;
            double cs = newRadius / Math.Sin(alfa / 2);
            PointF circleCenter = new PointF();
            if (s > 0)
            {
                circleCenter.X = (float)(line1.X2 + cs * Math.Cos(circleCenterAngle));
                circleCenter.Y = (float)(line1.Y2 + cs * Math.Sin(circleCenterAngle));
            }
            else
            {
                circleCenter.X = (float)(line1.X2 - cs * Math.Cos(circleCenterAngle));
                circleCenter.Y = (float)(line1.Y2 - cs * Math.Sin(circleCenterAngle));
            }

            double firstAngle = Math.Atan2(line1.NewY2 - circleCenter.Y, line1.NewX2 - circleCenter.X);
            double secondAngle = Math.Atan2(line2.NewY1 - circleCenter.Y, line2.NewX1 - circleCenter.X);
            double startAngle = firstAngle;
            double sweepAngle = secondAngle - firstAngle;
            if (sweepAngle > Math.PI)
                sweepAngle = -(2 * Math.PI - sweepAngle);
            else
            {
                if (sweepAngle < -Math.PI)
                    sweepAngle = (2 * Math.PI + sweepAngle);
            }
            arc.X = circleCenter.X - newRadius;
            arc.Y = circleCenter.Y - newRadius;
            arc.Width = newRadius * 2;
            arc.Height = newRadius * 2;
            arc.StartAngle = startAngle * (180 / Math.PI);
            arc.SweepAngle = sweepAngle * (180 / Math.PI);
        }


    }
}
