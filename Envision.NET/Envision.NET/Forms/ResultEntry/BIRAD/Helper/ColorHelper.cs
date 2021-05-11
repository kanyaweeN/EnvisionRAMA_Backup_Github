using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Helper
{
    public class ColorHelper
    {
        #region Color Converter
        /// <summary>
        /// System.Windows.Media --> System.Drawing.Color
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static System.Drawing.Color ColorFromMediaColor(System.Windows.Media.Color clr)
        {
            return System.Drawing.Color.FromArgb(clr.A, clr.R, clr.G, clr.B);
        }
        /// <summary>
        /// System.Drawing.Color --> System.Windows.Media  
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static System.Windows.Media.Color ColorFromDrawingColor(System.Drawing.Color clr)
        {
            return System.Windows.Media.Color.FromArgb(clr.A, clr.R, clr.G, clr.B);
        }
        #endregion

        public static System.Windows.Media.Color ColorFromDrawingColor(string strColor)
        {
            System.Windows.Media.Color mColor = System.Windows.Media.Colors.Black;
            if (strColor.Length > 0)
            {
                if (strColor.StartsWith("#"))
                {
                    //string _sub = strColor.Substring(3, 2);
                    byte a = GetByteColor(strColor.Substring(1, 2));
                    byte r = GetByteColor(strColor.Substring(3, 2));
                    byte g = GetByteColor(strColor.Substring(5, 2));
                    byte b = GetByteColor(strColor.Substring(7, 2));

                    return System.Windows.Media.Color.FromArgb(a, r, g, b);
                }
                else
                    return ColorFromDrawingColor(System.Drawing.Color.FromName(strColor)); // Color Form Name
            }
            else
                return mColor;

            //return mColor;
        }

        /// <summary>
        /// Get Byte Color Value
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte GetByteColor(string color)
        {
            int result = 1;
            if (color.Length > 0)
            {
                int strValue = 0;
                foreach (char c in color.ToCharArray())
                {
                    switch (c)
                    {
                        case 'A': strValue = 11; break;
                        case 'B': strValue = 12; break;
                        case 'C': strValue = 13; break;
                        case 'D': strValue = 14; break;
                        case 'E': strValue = 15; break;
                        case 'F': strValue = 16; break;
                        default: strValue = Convert.ToInt32(c.ToString() + 1); break;
                    }

                    result *= strValue;
                }
            }
            return (byte)(result - 1);
        }
    }
}
