using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SynapseSearchByHN
{
    public class XMLClass
    {
        public string XmlSymbolPath { get; set; }
        public DataTable SymbolData { get; set; }

        public string XmlPath { get; set; }
        public string SynapseURL { get; set; }
        public string SynapseDomain { get; set; }
        public string LinkSynapse { get; set; }
        public string IPDomain { get; set; }
        public string SynapseServer { get; set; }
        public string LoginMode { get; set; }
        public bool IsLinkAuthen { get; set; }
        public string SynapseManualPath { get; set; }
        public string EnvisionWebservice { get; set; }
        public bool IsReplaceURL { get; set; }

        public string UrlText { get; set; }
        public string UrlLink { get; set; }

        public Image HospitalLogo { get; set; }
        public string HospitalName { get; set; }
        public ContentAlignment HospitalAlign { get; set; }
        public float HospitalFontSize { get; set; }

        public HorizontalAlignment HNAlign { get; set; }
        public float HNFontSize { get; set; }
        public int HNValue { get; set; }
        public string HNType { get; set; }
        public string HNSymbolText { get; set; }
        public int HNSymbolPosition { get; set; }
        public string HNSymbolStartFrom { get; set; }
        public string HNCharacterBoundary { get; set; }

        public string HNAllUpper { get; set; }
        public string HNFreeText { get; set; }

        public string SuggestionText { get; set; }
        public ContentAlignment SuggestionAlign { get; set; }
        public float SuggestionFontSize { get; set; }

        public string FooterText { get; set; }
        public ContentAlignment FooterAlign { get; set; }
        public float FooterFontSize { get; set; }

        public string AlwaysOnTop { get; set; }
        public bool IsComplete;
        public string DisableStatus { get; set; }

        private DataSet SchemaTable;
        public DataSet ConfigData { get; set; }

        public XMLClass()
        {
            XmlPath = @"C:\Program Files\SynapseSearchByHN\AppConfig.xml";
            XmlSymbolPath = @"C:\Program Files\SynapseSearchByHN\SymbolConfig.xml";
            SchemaTable = LoadSchemaTable();
        }
        public DataSet LoadSchemaTable()
        {
            DataSet dsTemp = new DataSet("AppConfigSet");
            DataTable dtTemp = new DataTable("AppConfigTable");

            dtTemp.Columns.Add("SynapseURL", typeof(string));
            dtTemp.Columns.Add("SynapseDomain", typeof(string));
            dtTemp.Columns.Add("LinkSynapse", typeof(string));
            dtTemp.Columns.Add("IsReplaceURL", typeof(bool));
            
            dtTemp.Columns.Add("IPDomain", typeof(string));
            dtTemp.Columns.Add("SynapseServer", typeof(string));
            dtTemp.Columns.Add("SynapseManualPath", typeof(string));
            dtTemp.Columns.Add("EnvisionWebservice", typeof(string));
            dtTemp.Columns.Add("LoginMode", typeof(string));
            dtTemp.Columns.Add("IsLinkAuthen", typeof(bool));
            dtTemp.Columns.Add("UrlText", typeof(string));
            dtTemp.Columns.Add("UrlLink", typeof(string));

            dtTemp.Columns.Add("HospitalName", typeof(string));
            dtTemp.Columns.Add("HospitalAlign", typeof(string));
            dtTemp.Columns.Add("HospitalFontSize", typeof(string));

            dtTemp.Columns.Add("HNAlign", typeof(string));
            dtTemp.Columns.Add("HNFontSize", typeof(string));
            dtTemp.Columns.Add("HNValue", typeof(string));
            dtTemp.Columns.Add("HNType", typeof(string));
            dtTemp.Columns.Add("HNSymbolText", typeof(string));
            dtTemp.Columns.Add("HNSymbolPosition", typeof(string));
            dtTemp.Columns.Add("HNSymbolStartFrom", typeof(string));
            dtTemp.Columns.Add("HNAllUpper", typeof(string));
            dtTemp.Columns.Add("HNFreeText", typeof(string));

            dtTemp.Columns.Add("SuggestionText", typeof(string));
            dtTemp.Columns.Add("SuggestionAlign", typeof(string));
            dtTemp.Columns.Add("SuggestionFontSize", typeof(string));

            dtTemp.Columns.Add("FooterText", typeof(string));
            dtTemp.Columns.Add("FooterAlign", typeof(string));
            dtTemp.Columns.Add("FooterFontSize", typeof(string));

            dtTemp.Columns.Add("AlwaysOnTop", typeof(string));
            dtTemp.Columns.Add("HospitalLogo", typeof(string));
            dtTemp.Columns.Add("DisableStatus", typeof(string));


            dtTemp.AcceptChanges();
            dsTemp.Tables.Add(dtTemp);
            dsTemp.AcceptChanges();

            return dsTemp;
        }
        public DataSet LoadSchemaSymbol()
        {
            DataSet dsTemp = new DataSet("AppConfigSet");
            DataTable dtTemp = new DataTable("AppConfigTable");

            dtTemp.Columns.Add("Symbol");
            dtTemp.Columns.Add("Unicode");
            dtTemp.AcceptChanges();

            dtTemp.AcceptChanges();
            dsTemp.Tables.Add(dtTemp);
            dsTemp.AcceptChanges();

            return dsTemp;
        }
        public void LoadData()
        {
            try
            {
                IsComplete = false;

                DataSet ds = SchemaTable;
                ds.ReadXml(XmlPath);
                ConfigData = ds.Copy();

                SynapseServer = ds.Tables[0].Rows[0]["SynapseServer"].ToString();
                SynapseDomain = ds.Tables[0].Rows[0]["SynapseDomain"].ToString();
                SynapseManualPath = ds.Tables[0].Rows[0]["SynapseManualPath"].ToString();
                EnvisionWebservice = ds.Tables[0].Rows[0]["EnvisionWebservice"].ToString();
                IPDomain = ds.Tables[0].Rows[0]["IPDomain"].ToString();
                LoginMode = ds.Tables[0].Rows[0]["LoginMode"].ToString();
                IsLinkAuthen = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IsLinkAuthen"].ToString()) ? false : Convert.ToBoolean(ds.Tables[0].Rows[0]["IsLinkAuthen"]);
                IsReplaceURL = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsReplaceURL"]);

                int ie_version = decimal.ToInt32(Convert.ToDecimal(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Version Vector", "IE", 0)));
                switch (ie_version)
                {
                    case 6:
                    case 7:
                    case 8:
                        setSynapseURL(IsLinkAuthen);
                        break;
                    default :
                        setSynapseURL(false);
                        break;
                }

                UrlLink = ds.Tables[0].Rows[0]["UrlLink"].ToString();
                UrlText = ds.Tables[0].Rows[0]["UrlText"].ToString();
                LinkSynapse = ds.Tables[0].Rows[0]["LinkSynapse"].ToString();

                HospitalLogo = Base64ToImage(ds.Tables[0].Rows[0]["HospitalLogo"].ToString());
                HospitalName = ds.Tables[0].Rows[0]["HospitalName"].ToString();
                HospitalAlign = StringToContentAlignment(ds.Tables[0].Rows[0]["HospitalAlign"].ToString());
                HospitalFontSize = Convert.ToSingle(ds.Tables[0].Rows[0]["HospitalFontSize"].ToString());

                HNAlign = StringToHorizontalAlignment(ds.Tables[0].Rows[0]["HNAlign"].ToString());
                HNFontSize = Convert.ToSingle(ds.Tables[0].Rows[0]["HNFontSize"].ToString());
                HNValue = Convert.ToInt32(ds.Tables[0].Rows[0]["HNValue"].ToString());
                HNType = ds.Tables[0].Rows[0]["HNType"].ToString();
                HNSymbolText = ds.Tables[0].Rows[0]["HNSymbolText"].ToString();
                HNSymbolPosition = Convert.ToInt32(ds.Tables[0].Rows[0]["HNSymbolPosition"].ToString());
                HNSymbolStartFrom = ds.Tables[0].Rows[0]["HNSymbolStartFrom"].ToString();
                HNAllUpper = ds.Tables[0].Rows[0]["HNAllUpper"].ToString();
                HNFreeText = ds.Tables[0].Rows[0]["HNFreeText"].ToString();

                SuggestionText = ds.Tables[0].Rows[0]["SuggestionText"].ToString();
                SuggestionAlign = StringToContentAlignment(ds.Tables[0].Rows[0]["SuggestionAlign"].ToString());
                SuggestionFontSize = Convert.ToSingle(ds.Tables[0].Rows[0]["SuggestionFontSize"].ToString());

                FooterText = ds.Tables[0].Rows[0]["FooterText"].ToString();
                FooterAlign = StringToContentAlignment(ds.Tables[0].Rows[0]["FooterAlign"].ToString());
                FooterFontSize = Convert.ToSingle(ds.Tables[0].Rows[0]["FooterFontSize"].ToString());

                AlwaysOnTop = ds.Tables[0].Rows[0]["AlwaysOnTop"].ToString();

                IsComplete = true;
                DisableStatus = ds.Tables[0].Rows[0]["DisableStatus"].ToString();

                DataSet dsSymbol = new DataSet();
                dsSymbol.ReadXml(XmlSymbolPath);
                if (dsSymbol.Tables.Count > 0)
                    SymbolData = dsSymbol.Tables[0].Copy();
                else
                    SymbolData = LoadSchemaSymbol().Tables[0].Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new LogFile().SaveLogFile(ex.Message, ex.Source);
            }
        }
        public void BindingData(int i_site)
        {
            try
            {
                IsComplete = false;

                DataSet ds = SchemaTable;
                ds.ReadXml(XmlPath);
                ConfigData = ds.Copy();

                SynapseServer = ds.Tables[0].Rows[i_site]["SynapseServer"].ToString();
                SynapseDomain = ds.Tables[0].Rows[i_site]["SynapseDomain"].ToString();
                SynapseManualPath = ds.Tables[0].Rows[i_site]["SynapseManualPath"].ToString();
                EnvisionWebservice = ds.Tables[0].Rows[i_site]["EnvisionWebservice"].ToString();
                IPDomain = ds.Tables[0].Rows[i_site]["IPDomain"].ToString();
                LoginMode = ds.Tables[0].Rows[i_site]["LoginMode"].ToString();
                IsLinkAuthen = string.IsNullOrEmpty(ds.Tables[0].Rows[i_site]["IsLinkAuthen"].ToString()) ? false : Convert.ToBoolean(ds.Tables[0].Rows[i_site]["IsLinkAuthen"]);
                IsReplaceURL = Convert.ToBoolean(ds.Tables[0].Rows[i_site]["IsReplaceURL"]);

                int ie_version = decimal.ToInt32(Convert.ToDecimal(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Version Vector", "IE", 0)));
                switch (ie_version)
                {
                    case 6:
                    case 7:
                    case 8:
                        setSynapseURL(IsLinkAuthen);
                        break;
                    default:
                        setSynapseURL(false);
                        break;
                }

                UrlLink = ds.Tables[0].Rows[i_site]["UrlLink"].ToString();
                UrlText = ds.Tables[0].Rows[i_site]["UrlText"].ToString();
                LinkSynapse = ds.Tables[0].Rows[i_site]["LinkSynapse"].ToString();

                HospitalLogo = Base64ToImage(ds.Tables[0].Rows[i_site]["HospitalLogo"].ToString());
                HospitalName = ds.Tables[0].Rows[i_site]["HospitalName"].ToString();
                HospitalAlign = StringToContentAlignment(ds.Tables[0].Rows[i_site]["HospitalAlign"].ToString());
                HospitalFontSize = Convert.ToSingle(ds.Tables[0].Rows[i_site]["HospitalFontSize"].ToString());

                HNAlign = StringToHorizontalAlignment(ds.Tables[0].Rows[i_site]["HNAlign"].ToString());
                HNFontSize = Convert.ToSingle(ds.Tables[0].Rows[i_site]["HNFontSize"].ToString());
                HNValue = Convert.ToInt32(ds.Tables[0].Rows[i_site]["HNValue"].ToString());
                HNType = ds.Tables[0].Rows[i_site]["HNType"].ToString();
                HNSymbolText = ds.Tables[0].Rows[i_site]["HNSymbolText"].ToString();
                HNSymbolPosition = Convert.ToInt32(ds.Tables[0].Rows[i_site]["HNSymbolPosition"].ToString());
                HNSymbolStartFrom = ds.Tables[0].Rows[i_site]["HNSymbolStartFrom"].ToString();
                HNAllUpper = ds.Tables[0].Rows[i_site]["HNAllUpper"].ToString();
                HNFreeText = ds.Tables[0].Rows[i_site]["HNFreeText"].ToString();

                SuggestionText = ds.Tables[0].Rows[i_site]["SuggestionText"].ToString();
                SuggestionAlign = StringToContentAlignment(ds.Tables[0].Rows[i_site]["SuggestionAlign"].ToString());
                SuggestionFontSize = Convert.ToSingle(ds.Tables[0].Rows[i_site]["SuggestionFontSize"].ToString());

                FooterText = ds.Tables[0].Rows[i_site]["FooterText"].ToString();
                FooterAlign = StringToContentAlignment(ds.Tables[0].Rows[i_site]["FooterAlign"].ToString());
                FooterFontSize = Convert.ToSingle(ds.Tables[0].Rows[i_site]["FooterFontSize"].ToString());

                AlwaysOnTop = ds.Tables[0].Rows[i_site]["AlwaysOnTop"].ToString();

                IsComplete = true;
                DisableStatus = ds.Tables[0].Rows[i_site]["DisableStatus"].ToString();

                DataSet dsSymbol = new DataSet();
                dsSymbol.ReadXml(XmlSymbolPath);
                if (dsSymbol.Tables.Count > 0)
                    SymbolData = dsSymbol.Tables[0].Copy();
                else
                    SymbolData = LoadSchemaSymbol().Tables[0].Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new LogFile().SaveLogFile(ex.Message, ex.Source);
            }
        }
        
        public void setSynapseURL(bool flag)
        {
            string url = "";
            if (flag)
            {
                //url = @"{0}{1}/explore.asp?path=/All%20Patients/InternalPatientUID=";
                url = @"{0}{1}/" + LinkSynapse;
                //Url pattern is "[domain\username:password]url". Prefix don't have "http://".
                SynapseURL = string.Format(url,
                                string.Format("[{0}{1}:{2}]",
                                string.IsNullOrEmpty(SynapseDomain) ? string.Empty : SynapseDomain + @"\",
                                    Common.CommonDetails.pacsUser,
                                    Common.CommonDetails.pacsPassword),
                                    SynapseServer);
            }
            else
            {
                url = @"http://{0}/" + LinkSynapse;
                SynapseURL = string.Format(url, SynapseServer);
            }
        }
        public void SaveData()
        {
            try
            {
                IsComplete = false;

                DataSet ds = SchemaTable;
                DataRow row = ds.Tables[0].NewRow();

                row["SynapseURL"] = SynapseURL;
                row["SynapseDomain"] = SynapseDomain;
                row["LinkSynapse"] = LinkSynapse;
                row["IPDomain"] = IPDomain;
                row["SynapseServer"] = SynapseServer;
                row["SynapseManualPath"] = SynapseManualPath;
                row["EnvisionWebservice"] = EnvisionWebservice;
                row["LoginMode"] = LoginMode;
                row["IsLinkAuthen"] = IsLinkAuthen;
                row["UrlText"] = UrlText;
                row["UrlLink"] = UrlLink;
                row["IsReplaceURL"] = IsReplaceURL;

                row["HospitalLogo"] = ImageToBase64(HospitalLogo);
                row["HospitalName"] = HospitalName;
                row["HospitalAlign"] = ContentAlignmentToString(HospitalAlign);
                row["HospitalFontSize"] = HospitalFontSize.ToString();

                row["HNAlign"] = HorizontalAlignmentToString(HNAlign);
                row["HNFontSize"] = HNFontSize.ToString();
                row["HNValue"] = HNValue.ToString();
                row["HNType"] = HNType.ToString();
                row["HNSymbolText"] = HNSymbolText.ToString();
                row["HNSymbolPosition"] = HNSymbolPosition.ToString();
                row["HNSymbolStartFrom"] = HNSymbolStartFrom.ToString();
                row["HNAllUpper"] = HNAllUpper.ToString();
                row["HNFreeText"] = HNFreeText.ToString();

                row["SuggestionText"] = SuggestionText;
                row["SuggestionAlign"] = ContentAlignmentToString(SuggestionAlign);
                row["SuggestionFontSize"] = SuggestionFontSize.ToString();

                row["FooterText"] = FooterText;
                row["FooterAlign"] = ContentAlignmentToString(FooterAlign);
                row["FooterFontSize"] = FooterFontSize.ToString();

                row["AlwaysOnTop"] = AlwaysOnTop;
                row["DisableStatus"] = DisableStatus;
                ds.Tables[0].Rows.Add(row);

                ds.AcceptChanges();
                ds.WriteXml(XmlPath);

                DataSet dsSymbol = new DataSet();
                dsSymbol.Tables.Add(SymbolData.Copy());
                dsSymbol.WriteXml(XmlSymbolPath);

                IsComplete = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new LogFile().SaveLogFile(ex.Message, ex.Source);                
            }
        }

        public string ImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes);
            return Image.FromStream(ms, true);
        }
        public string ContentAlignmentToString(ContentAlignment align)
        {
            string strValue = "center";

            if(align == ContentAlignment.MiddleCenter)
                strValue = "center";
            else if (align == ContentAlignment.MiddleLeft)
                strValue = "left";
            else if(align == ContentAlignment.MiddleRight)
                strValue = "right";

            return strValue;
        }
        public ContentAlignment StringToContentAlignment(string strAlign)
        {
            ContentAlignment retValue = ContentAlignment.MiddleCenter;

            if (strAlign == "center")
                retValue = ContentAlignment.MiddleCenter;
            else if (strAlign == "left")
                retValue = ContentAlignment.MiddleLeft;
            else if (strAlign == "right")
                retValue = ContentAlignment.MiddleRight;

            return retValue;
        }
        public string HorizontalAlignmentToString(HorizontalAlignment align)
        {
            string strValue = "center";

            if (align == HorizontalAlignment.Center)
                strValue = "center";
            else if (align == HorizontalAlignment.Left)
                strValue = "left";
            else if (align == HorizontalAlignment.Right)
                strValue = "right";

            return strValue;
        }
        public HorizontalAlignment StringToHorizontalAlignment(string strAlign)
        {
            HorizontalAlignment retValue = HorizontalAlignment.Center;

            if (strAlign == "center")
                retValue = HorizontalAlignment.Center;
            else if (strAlign == "left")
                retValue = HorizontalAlignment.Left;
            else if (strAlign == "right")
                retValue = HorizontalAlignment.Right;

            return retValue;
        }
    }
}
