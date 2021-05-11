using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Helper
{
    public class EditValueConvertor
    {
        /// <summary>
        /// Get patient type value
        /// </summary>
        /// <param name="index">index of patient type combobox</param>
        /// <returns>converted value</returns>
        public static string GetPatientTypeValue(int index)
        {
            switch (index)
            {
                case 1: return "A";
                case 2: return "B";
                case 3: return "C";
                case 4: return "D";
                case 5: return "E";
                case 6: return "F";
                case 7: return "G";
                case 8: return "H";
                case 9: return "I";
                default: return string.Empty;
            }
        }
        /// <summary>
        /// Get patient type combobox index
        /// </summary>
        /// <param name="value">value of patient type</param>
        /// <returns>index</returns>
        public static int GetPatientTypeIndex(string value)
        {
            switch (value)
            {
                case "A": return 1;
                case "B": return 2;
                case "C": return 3;
                case "D": return 4;
                case "E": return 5;
                case "F": return 6;
                case "G": return 7;
                case "H": return 8;
                case "I": return 9;
                default: return 0;
            }
        }
        /// <summary>
        /// Get Breast Composition value
        /// </summary>
        /// <param name="index">value of breast composition</param>
        /// <returns>convertor value</returns>
        public static string GetBreastCompositionValue(int index)
        {
            switch (index)
            {
                case 1: return "A";
                case 2: return "B";
                case 3: return "C";
                case 4: return "D";
                default: return string.Empty;
            }
        }
        /// <summary>
        /// Get Breast Composition combobox index
        /// </summary>
        /// <param name="value">value of breast composition</param>
        /// <returns>index</returns>
        public static int GetBreastCompositionIndex(string value)
        {
            switch (value)
            {
                case "A": return 1;
                case "B": return 2;
                case "C": return 3;
                case "D": return 4;
                default: return 0;
            }
        }

        /// <summary>
        /// Get finding type combobox value
        /// </summary>
        /// <param name="index">index of finding type combobox</param>
        /// <returns>value</returns>
        public static string GetFindingTypeValue(int index)
        {
            switch (index)
            {
                case 1: return "B";
                case 2: return "D";
                case 3: return "E";
                //case 4: return "E";
                default: return "A";
            }
        }

        /// <summary>
        /// Get finding type combobox index
        /// </summary>
        /// <param name="value">value of finding type</param>
        /// <returns>index</returns>
        public static int GetFindingTypeIndex(string value)
        {
            switch (value)
            {
                case "B": return 1;
                case "D": return 2;
                case "E": return 3;
                //case "E": return 4;
                default: return 0;
            }
        }

        /// <summary>
        /// Get Final Assessment type value
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetFinalAssessmentTypeValue(int index)
        {
            switch (index)
            {
                case 1: return "B";
                case 2: return "C";
                case 3: return "D";
                case 4: return "E";
                case 5: return "F";
                case 6: return "G";
                case 7: return "H";
                case 8: return "I";
                default: return "A";
            }
        }
        /// <summary>
        /// Get Final Assessment type combobox index
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetFinalAssessmentTypeIndex(string value)
        {
            switch (value)
            {
                case "B": return 1;
                case "C": return 2;
                case "D": return 3;
                case "E": return 4;
                case "F": return 5;
                case "G": return 6;
                case "H": return 7;
                case "I": return 8;
                default: return 0;
            }
        }

        /// <summary>
        /// Get Recommendation Type Vaule
        /// </summary>
        /// <param name="index">index</param>
        /// <returns></returns>
        public static string GetRecommendationTypeValue(int index)
        {
            switch (index)
            {
                case 1: return "B";
                case 2: return "C";
                case 3: return "D";
                case 4: return "E";
                case 5: return "F";
                case 6: return "G";
                case 7: return "H";
                default: return "A";
            }
        }

        /// <summary>
        /// Get Recommendation Type combobox index
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetRecommendationTypeeIndex(string value)
        {
            switch (value)
            {
                case "B": return 1;
                case "C": return 2;
                case "D": return 3;
                case "E": return 4;
                case "F": return 5;
                case "G": return 6;
                case "H": return 7;
                default: return 0;
            }
        }
    }
}
