using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Operational.Translator
{
    public static class ConvertHNtoKKU
    {
        private static string CharToNumber(string str)
        {
            string ret = string.Empty;

            switch (str.ToUpper())
            {
                case "A":
                    ret = "01";
                    break;
                case "B":
                    ret = "02";
                    break;
                case "C":
                    ret = "03";
                    break;
                case "D":
                    ret = "04";
                    break;
                case "E":
                    ret = "05";
                    break;
                case "F":
                    ret = "06";
                    break;
                case "G":
                    ret = "07";
                    break;
                case "H":
                    ret = "08";
                    break;
                case "I":
                    ret = "09";
                    break;
                case "J":
                    ret = "10";
                    break;
                case "K":
                    ret = "11";
                    break;
                case "L":
                    ret = "12";
                    break;
                case "M":
                    ret = "13";
                    break;
                case "N":
                    ret = "14";
                    break;
                case "O":
                    ret = "15";
                    break;
                case "P":
                    ret = "16";
                    break;
                case "Q":
                    ret = "17";
                    break;
                case "R":
                    ret = "18";
                    break;
                case "S":
                    ret = "19";
                    break;
                case "T":
                    ret = "20";
                    break;
                case "U":
                    ret = "21";
                    break;
                case "V":
                    ret = "22";
                    break;
                case "W":
                    ret = "23";
                    break;
                case "X":
                    ret = "24";
                    break;
                case "Y":
                    ret = "25";
                    break;
                case "Z":
                    ret = "26";
                    break;
                case "00":
                    ret = "00";
                    break;
            }
            return ret;
        }
        private static string NumberToChar(string str) {
            string ret = string.Empty;

            switch (str.ToUpper())
            {
                case "01":
                    ret = "A";
                    break;
                case "02":
                    ret = "B";
                    break;
                case "03":
                    ret = "C";
                    break;
                case "04":
                    ret = "D";
                    break;
                case "05":
                    ret = "E";
                    break;
                case "06":
                    ret = "F";
                    break;
                case "07":
                    ret = "G";
                    break;
                case "08":
                    ret = "H";
                    break;
                case "09":
                    ret = "I";
                    break;
                case "10":
                    ret = "J";
                    break;
                case "11":
                    ret = "K";
                    break;
                case "12":
                    ret = "L";
                    break;
                case "13":
                    ret = "M";
                    break;
                case "14":
                    ret = "N";
                    break;
                case "15":
                    ret = "O";
                    break;
                case "16":
                    ret = "P";
                    break;
                case "17":
                    ret = "Q";
                    break;
                case "18":
                    ret = "R";
                    break;
                case "19":
                    ret = "S";
                    break;
                case "20":
                    ret = "T";
                    break;
                case "21":
                    ret = "U";
                    break;
                case "22":
                    ret = "V";
                    break;
                case "23":
                    ret = "W";
                    break;
                case "24":
                    ret = "X";
                    break;
                case "25":
                    ret = "Y";
                    break;
                case "26":
                    ret = "Z";
                    break;
                case "00":
                    ret = "0";
                    break;
            }
            return ret;
        }


        public static string HN_KKU(string HN)
        {
            if (HN.Length < 2)
            {
                return HN;
            }
            char ch1 = HN[0];
            char ch2 = HN[1];
            if (Char.IsDigit(ch1) || Char.IsDigit(ch2))
                return HN;
            string number = CharToNumber(ch1.ToString());
            number += CharToNumber(ch2.ToString());
            HN = HN.Substring(2);
            return number + HN;
        }
        public static string HN_Normal(string HN_KKU) {
            if (HN_KKU.Length != 9)
                throw new Exception("HN Convert Error");
            string hn = HN_KKU.Substring(1);
            string code1 = hn[0].ToString() + hn[1].ToString();
            string code2 = hn[2].ToString() + hn[3].ToString() ;
            code1 = NumberToChar(code1);
            code2 = NumberToChar(code2);
            hn = hn.Substring(4);
            return code1 + code2 + hn;
        }
        public static bool IsUseHn (string HN) {
            //if (HN.Length != 8)
            //    return false;
            //int ret;
            //return int.TryParse(HN, out ret);


            long id;
            return long.TryParse(HN, out id);
        }

        
    }
}
