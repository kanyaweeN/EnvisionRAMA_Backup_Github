using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EnvisionInterfaceEngine.Common;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Common.Miracle;
using EnvisionInterfaceEngine.Operational.Translator;
using NHapi.Base.Model;
using NHapi.Base.Parser;

namespace EnvisionInterfaceEngine.Operational.HL7
{
    public class HL7Manager
    {
        public const string title_log = "EnvisionInterfaceEngine.Operational.HL7.HL7Manager";

        public static string minimalSeparator(string value, string separator)
        {
            return value.TrimEnd(Delimiter.StringFieldSeparate.ToCharArray());
        }
        public static string minimalComponentSeparator(string value)
        {
            return value.TrimEnd(Delimiter.StringComponentSeparate.ToCharArray());
        }
        public static string[] splitSegmentTerminator(string value)
        {
            return value.Split(new string[] { Delimiter.StringSegmentTerminator }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string[] splitFieldSeparator(string value)
        {
            return value.Split(new string[] { Delimiter.StringFieldSeparate }, StringSplitOptions.None);
        }
        public static string[] splitComponentSeparator(string value)
        {
            return value.Split(new string[] { Delimiter.StringComponentSeparate }, StringSplitOptions.None);
        }

        public static string cleanHL7Text(string hl7Text)
        {
            return hl7Text.ToString()
                .Replace(Convert.ToChar(0x0d).ToString() + Convert.ToChar(0x0a).ToString(), Delimiter.StringSegmentTerminator)
                .Replace(Convert.ToChar(0x00).ToString(), string.Empty)
                .Trim();
        }

        public static string encodeAlphanumeric(string value, string type)
        {
            return string.Empty;

            //switch (type)
            //{
            //    case "FT": return value
            //        .Replace("\\E\\", "\\") //Escape character
            //        .Replace("\\F\\", "|") //Field separator
            //        .Replace("\\R\\", "~") //Repetition separator
            //        .Replace("\\S\\", "^") //Component separator
            //        .Replace("\\T\\", "&") //Subcomponent separator
            //        .Replace("\\H\\", string.Empty) //Start highlighting
            //        .Replace("\\N\\", string.Empty); //Normal text (end highlighting)
            //    case "TX": return value
            //        .Remove
            //}
        }
        public static string decodeAlphanumeric(string value) { return decodeAlphanumeric(value, "PLAIN"); }
        public static string decodeAlphanumeric(string value, string type)
        {
            switch (type)
            {
                case "HTML": return value
                    .Replace("\\X0026\\", "&")
                    .Replace("\\X000d\\", " <br> ");
                case "RTF": return value;
                default: return value
                    .Replace("\\X0026\\", "&")
                        //.Replace("\\X000d\\", "\\.br\\");
                    .Replace("\\X000d\\", " ~ ")
                    .Replace(Convert.ToChar(0x0a).ToString(), string.Empty);
            }
        }

        /// <summary>
        /// <para>object[0] is flag ("AA", "AR", "AE").</para>
        /// <para>object[1] is message type name.</para>
        /// <para>object[2] is value or message.</para>
        /// </summary>
        public static object[] ConvertHL7ToObject(string hl7Text)
        {
            object[] obj = new object[3];

            try
            {
                IMessage msg = new PipeParser().Parse(hl7Text);

                obj[1] = msg.GetStructureName();

                switch (obj[1].ToString())
                {
                    case "ADT_A08":
                        switch (msg.Version)
                        {
                            case "2.3":
                                obj[0] = "AA";
                                obj[2] = GenerateADT.ConvertToObject((NHapi.Model.V23.Message.ADT_A08)msg);
                                break;
                            default:
                                obj[0] = "AR";
                                obj[2] = "System not support version.";
                                break;
                        }
                        break;
                    case "ADT_A18":
                        switch (msg.Version)
                        {
                            case "2.3":
                                obj[0] = "AA";
                                obj[2] = GenerateADT.ConvertToObject((NHapi.Model.V23.Message.ADT_A18)msg);
                                break;
                            default:
                                obj[0] = "AR";
                                obj[2] = "System not support version.";
                                break;
                        }
                        break;
                    case "ORM_O01":
                        switch (msg.Version)
                        {
                            case "2.3":
                                HL7ORM hl7_orm = GenerateORM.ConvertToObject((NHapi.Model.V23.Message.ORM_O01)msg);

                                if (hl7_orm.ORDER_CONTROL == "SC"
                                    && (hl7_orm.ORDER_DETAIL.STATUS == 'C' || hl7_orm.ORDER_DETAIL.STATUS == 'S'))
                                {
                                    obj[1] = "ORM_BDR";
                                }

                                obj[0] = "AA";
                                obj[2] = hl7_orm;
                                break;
                            default:
                                obj[0] = "AR";
                                obj[2] = "System not support version.";
                                break;
                        }
                        break;
                    default:
                        obj[0] = "AR";
                        obj[2] = "System not support messate type.";
                        break;
                }
            }
            catch (Exception ex)
            {
                obj[0] = "AE";
                obj[1] = string.Empty;
                obj[2] = Utilities.ToCleanString(ex.Message);
            }

            return obj;
        }

        public static string[] ConvertObjectToText(NHapi.Model.V23.Datatype.XAD value)
        {
            string result = Utilities.ToCleanString(
                string.Join(" ", new string[] {
                    value.StreetAddress.Value,
                    value.OtherDesignation.Value,
                    value.City.Value,
                    value.StateOrProvince.Value,
                    value.ZipOrPostalCode.Value,
                    value.Country.Value,
                    value.AddressType.Value,
                    value.OtherGeographicDesignation.Value,
                    value.CountyParishCode.Value,
                    value.CensusTract.Value}));

            //Split address to 100 character per 1 array.
            List<string> result_list = new List<string>(Regex.Split(result, @"(?<=\G.{100})"));

            return result_list.ToArray();
        }
        public static HR_EMP ConvertObject(NHapi.Model.V23.Datatype.XCN value)
        {
            return ConvertObject(new NHapi.Model.V23.Datatype.XCN[] { value });
        }
        public static HR_EMP ConvertObject(NHapi.Model.V23.Datatype.XCN[] values)
        {
            HR_EMP result = new HR_EMP();

            if (Utilities.HasData(values))
            {
                switch (values.Length)
                {
                    case 0:
                        break;
                    case 1:
                        if (!string.IsNullOrEmpty(values[0].IDNumber.Value))
                        {
                            result.EMP_UID = values[0].IDNumber.Value;
                            result.SALUTATION = values[0].FamilyName.Value;
                            if (!string.IsNullOrEmpty(values[0].GivenName.Value))
                            {
                                using (MIStringArray temp = new MIStringArray(values[0].GivenName.Value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)))
                                {
                                    result.FNAME = temp[0];
                                    result.LNAME = temp[1];
                                }
                            }

                            result.TITLE_ENG = TransToEnglish.TransSalutation(result.SALUTATION);
                            result.FNAME_ENG = TransToEnglish.Trans(result.FNAME);
                            result.LNAME_ENG = TransToEnglish.Trans(result.LNAME);
                        }
                        break;
                    default:
                        if (!string.IsNullOrEmpty(values[0].IDNumber.Value))
                        {
                            result.EMP_UID = values[0].IDNumber.Value;
                            result.TITLE_ENG = values[0].FamilyName.Value;
                            if (!string.IsNullOrEmpty(values[0].GivenName.Value))
                            {
                                using (MIStringArray temp = new MIStringArray(values[0].GivenName.Value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)))
                                {
                                    result.FNAME_ENG = temp[0];
                                    result.LNAME_ENG = temp[1];
                                }
                            }

                            if (!string.IsNullOrEmpty(values[1].IDNumber.Value))
                            {
                                result.EMP_UID = values[1].IDNumber.Value;
                                result.SALUTATION = values[1].FamilyName.Value;
                                if (!string.IsNullOrEmpty(values[1].GivenName.Value))
                                {
                                    using (MIStringArray temp = new MIStringArray(values[1].GivenName.Value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)))
                                    {
                                        result.FNAME = temp[0];
                                        result.LNAME = temp[1];
                                    }
                                }
                            }
                        }
                        else if (!string.IsNullOrEmpty(values[1].IDNumber.Value))
                        {
                            result.EMP_UID = values[1].IDNumber.Value;
                            result.SALUTATION = values[1].FamilyName.Value;
                            if (!string.IsNullOrEmpty(values[1].GivenName.Value))
                            {
                                using (MIStringArray temp = new MIStringArray(values[1].GivenName.Value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)))
                                {
                                    result.FNAME = temp[0];
                                    result.LNAME = temp[1];
                                }
                            }

                            result.TITLE_ENG = TransToEnglish.TransSalutation(result.SALUTATION);
                            result.FNAME_ENG = TransToEnglish.Trans(result.FNAME);
                            result.LNAME_ENG = TransToEnglish.Trans(result.LNAME);
                        }
                        break;
                }
            }

            return result;
        }

        public static string DecodeText(string value, string type)
        {
            string result = value;

            if (string.IsNullOrEmpty(result))
                return string.Empty;

            switch (type.ToLower())
            {
                case "html":
                    return value
                        .Replace("\\X0026\\", "&");
                case "rtf":
                    return value;
                default:
                    return value
                        .Replace("\\X0026\\", "&")
                        .Replace(" <br> ", Convert.ToChar(0x0d).ToString() + Convert.ToChar(0x0a).ToString());
            }
        }
    }
}