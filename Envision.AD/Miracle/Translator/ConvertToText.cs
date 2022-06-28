using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Translator
{
    public static class ConvertToText
    {
        #region BahtToTextFormat.
        private static string s1 = "";
        private static string s2 = "";
        private static string s3 = "";
        private static string[] suffix = { "", "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
        private static string[] numSpeak = { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
        private static string Speak(string s)
        {
            int L, c;
            string result;

            if (s == "") return ("");

            result = "";
            L = s.Length;
            for (int i = 0; i < L; i++)
            {
                if ((s.Substring(i, 1) == "-"))
                {
                    result = result + "ติดลบ";
                }
                else
                {
                    c = System.Convert.ToInt32(s.Substring(i, 1));
                    if ((i == L - 1) && (c == 1))
                    {
                        if (L == 1)
                        {
                            return ("หนึ่ง");
                        }
                        if ((L > 1) && (s.Substring(L - 1, 1) == "0"))
                        {
                            result = result + "หนึ่ง";
                        }
                        else
                        {
                            result = result + "เอ็ด";
                        }
                    }
                    else if ((i == L - 2) && (c == 2))
                    {
                        result = result + "ยี่สิบ";
                    }
                    else if ((i == L - 2) && (c == 1))
                    {
                        result = result + "สิบ";
                    }
                    else
                    {
                        if (c != 0)
                        {
                            result = result + numSpeak[c] + suffix[L - i];
                        }
                    }
                }
            }
            return (result);
        }
        private static string speakStang(string s)
        {
            int L, c;
            string result;

            L = s.Length;

            if (L == 0) return ("");

            if (L == 1)
            {
                s = s + "0";
                L = 2;
            }
            if (L > 2)
            {
                s = s.Substring(0, 2);
                L = 2;
            }
            result = "";
            for (int i = 0; i < 2; i++)
            {
                c = Convert.ToInt32(s.Substring(i, 1));
                if ((i == L - 1) && (c == 1))
                {
                    if (Convert.ToInt32(s.Substring(0, 1)) == 0)
                        result = result + "หนึ่ง";
                    else
                        result = result + "เอ็ด";
                }
                else if ((i == L - 2) && (c == 2))
                {
                    result = result + "ยี่สิบ";
                }
                else if ((i == L - 2) && (c == 1))
                {
                    result = result + "สิบ";
                }
                else
                {
                    if (c != 0)
                    {
                        result = result + numSpeak[c] + suffix[L - i];
                    }
                }
            }

            return (result);
        }
        private static void splitCurr(double m)
        {
            string s;
            int L;
            int position;

            s = System.Convert.ToString(m);
            position = s.IndexOf(".");
            if ((position >= 0))
            {
                s1 = s.Substring(0, position);
                s3 = s.Substring(position + 1);
                if (s3 == "00")
                {
                    s3 = "";
                }
            }
            else
            {
                s1 = s;
                s3 = "";
            }
            L = s1.Length;
            if ((L > 6))
            {
                s2 = s1.Substring(L - 6);
                s1 = s1.Substring(0, L - 6);
            }
            else
            {
                s2 = s1;
                s1 = "";
            }

            if ((s1 != "") && (Convert.ToInt32(s1) == 0)) s1 = "";
            if ((s2 != "") && (Convert.ToInt32(s2) == 0)) s2 = "";
        }  
        #endregion

        public static string HtmlToTextFormat(string htmlSource)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = htmlSource.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                return htmlSource;
            }
        }
        public static string BahtToTextFormat(double m)
        {
            string result;
            string beforeresult = "";

            if (m == 0) return ("");
            //-------------------
            if (m < 0)
            {
                string tmp = m.ToString();
                if ((tmp.Substring(0, 1) == "-"))
                {
                    tmp = tmp.Remove(0, 1);
                    beforeresult = "ติดลบ";
                    m = Convert.ToDouble(tmp);
                }
            }
            //-------------------
            splitCurr(m);
            result = "";
            if (s1.Length > 0)
            {
                result = result + Speak(s1) + "ล้าน";
            }
            if (s2.Length > 0)
            {
                result = result + Speak(s2) + "บาท";
            }
            if (s3.Length > 0)
            {
                result = result + speakStang(s3) + "สตางค์";
            }
            else
            {
                result = result + "ถ้วน";
            }
            return (beforeresult + result); 
        }
    }
}
