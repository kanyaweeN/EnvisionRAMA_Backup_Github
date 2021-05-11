using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class GBLEnvUpdateData : DataAccessBase
    {
        private GBLEnv _gblenv;
        private GBLEnvInsertDataParameters _gblenvinsertdataparameters;

        public GBLEnvUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLEnv_Update.ToString();
        }

        public void Add()
        {
            try
            {
                _gblenvinsertdataparameters = new GBLEnvInsertDataParameters(GBLEnv);
                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                object id = dbhelper.RunScalar(base.ConnectionString, _gblenvinsertdataparameters.Parameters);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public GBLEnv GBLEnv
        {
            get { return _gblenv; }
            set { _gblenv = value; }
        }
    }

    public class GBLEnvInsertDataParameters
    {
        private GBLEnv _gblenv;
        private SqlParameter[] _parameters;

        public GBLEnvInsertDataParameters(GBLEnv gblenv)
        {
            GBLEnv = gblenv;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@OrgUID"         ,   GBLEnv.OrgUID   ),
                new SqlParameter( "@OrgName"        ,   GBLEnv.OrgName  ),
                new SqlParameter( "@OrgAlias"       ,   GBLEnv.OrgAlias ),
                new SqlParameter( "@OrgSlogan1"     ,   GBLEnv.OrgSlogan1   ),
                new SqlParameter( "@OrgSlogan2"     ,   GBLEnv.OrgSlogan2   ),
                new SqlParameter( "@OrgAddr1"       ,   GBLEnv.OrgAddr1 ),
                new SqlParameter( "@OrgAddr2"       ,   GBLEnv.OrgAddr2 ),
                new SqlParameter( "@OrgAddr3"       ,   GBLEnv.OrgAddr3 ),
                new SqlParameter( "@OrgAddr4"       ,   GBLEnv.OrgAddr4 ),
                new SqlParameter( "@OrgTel1"        ,   GBLEnv.OrgTel1  ),
                new SqlParameter( "@OrgTel2"        ,   GBLEnv.OrgTel2  ),
                new SqlParameter( "@OrgTel3"        ,   GBLEnv.OrgTel2  ),
                new SqlParameter( "@OrgFax"         ,   GBLEnv.OrgFax   ),
                new SqlParameter( "@OrgEmail1"      ,   GBLEnv.OrgEmail1    ),
                new SqlParameter( "@OrgWebsite"     ,   GBLEnv.OrgWebsite   ),
                new SqlParameter( "@WelcomeDialog1" ,     GBLEnv.WelcomeDialog1 ),
                new SqlParameter( "@WelcomeDialog2" ,     GBLEnv.WelcomeDialog2 ),
                new SqlParameter( "@RepFooter1"     ,   GBLEnv.RepFooter1   ),
                new SqlParameter( "@RepFooter2"     ,   GBLEnv.RepFooter2   ),
                new SqlParameter( "@DateFormat"     ,   GBLEnv.DateFormat   ),
                new SqlParameter( "@TimeFormat"     ,   GBLEnv.TimeFormat   ),
                new SqlParameter( "@UserDisplayFormat"  ,   GBLEnv.UserDisplayFormat    ),
                new SqlParameter( "@CurrencyFormat" ,   GBLEnv.CurrencyFormat   ),
                new SqlParameter( "@LocalCurrencyName"  ,   GBLEnv.LocalCurrencyName    ),
                new SqlParameter( "@LocalCurrencySymbol"    ,   GBLEnv.LocalCurrencySymbol  ),
                new SqlParameter( "@EmpImageType"   ,   GBLEnv.EmpImageType ),
                new SqlParameter( "@EmpImageMaxSize"    ,   GBLEnv.EmpImageMaxSize  ),
                new SqlParameter( "@ScannedImagePath"   ,   GBLEnv.ScannedImagePath ),
                new SqlParameter( "@BackupPath"     ,   GBLEnv.BackupPath   ),
                new SqlParameter( "@VendorH1"       ,   GBLEnv.VendorH1 ),
                new SqlParameter( "@VendorH2"       ,   GBLEnv.VendorH2 ),
                new SqlParameter( "@VendorLogoPath" ,   GBLEnv.VendorLogoPath   ),
                new SqlParameter( "@RisIP"          ,   GBLEnv.RisIP    ),
                new SqlParameter( "@RisPort"        ,   GBLEnv.RisPort  ),
                new SqlParameter( "@RisUser"        ,   GBLEnv.RisUser  ),
                new SqlParameter( "@RisPass"        ,   GBLEnv.RisPass  ),
                new SqlParameter( "@RisURL"         ,   GBLEnv.RisURL   ),
                new SqlParameter( "@PacsIP"         ,   GBLEnv.PacsIP   ),
                new SqlParameter( "@PacsPort"       ,   GBLEnv.PacsPort ),
                new SqlParameter( "@PacsURL1"       ,   GBLEnv.PacsURL1 ),
                new SqlParameter( "@PacsURL2"       ,   GBLEnv.PacsURL2   ),
                new SqlParameter( "@HisIP"          ,   GBLEnv.HisIP    ),
                new SqlParameter( "@HisPort"        ,   GBLEnv.HisPort  ),
                new SqlParameter( "@HisDBName"      ,   GBLEnv.HisDBName    ),
                new SqlParameter( "@HisUserName"    ,   GBLEnv.HisUserName  ),
                new SqlParameter( "@HisUserPass"    ,   GBLEnv.HisUserPass  ),
                new SqlParameter( "@HisFinFlag"     ,   GBLEnv.HisFinFlag   ),
                new SqlParameter( "@WsIP"           ,   GBLEnv.WsIP ),
                new SqlParameter( "@WsVersion"      ,   GBLEnv.WsVersion    ),
                new SqlParameter( "@Image"          ,   GBLEnv.Image    ),
                new SqlParameter( "@CREATED_BY"          ,   GBLEnv.CREATED_BY    ),

                new SqlParameter( "@PACS_IP_1"          ,   GBLEnv.PacsIP_1    ),
                new SqlParameter( "@PACS_PORT_1"          ,   GBLEnv.PacsPort_1    ),
                new SqlParameter( "@PACS_URL1_1"          ,   GBLEnv.PacsURL1_1    ),
                new SqlParameter( "@PACS_URL2_1"          ,   GBLEnv.PacsURL2_1    ),


                //new SqlParameter( "@OrgEmail2"      ,   GBLEnv.OrgEmail2    ),
                //new SqlParameter( "@OrgEmail3"      ,   GBLEnv.OrgEmail3    ),
                //new SqlParameter( "@DefaultFontFace"    ,   GBLEnv.DefaultFontFace  ),
                //new SqlParameter( "@DefaultFontSize"    ,   GBLEnv.DefaultFontSize  ),
                //new SqlParameter( "@RepServer"      ,   GBLEnv.RepServer    ),
                //new SqlParameter( "@RepFormat"      ,   GBLEnv.RepFormat    ),
                //new SqlParameter( "@OtherMaxFileSize"   ,   GBLEnv.OtherMaxFileSize ),
                //new SqlParameter( "@ResourceImagePath"  ,   GBLEnv.ResourceImagePath    ),
                //new SqlParameter( "@DocumentPath"   ,   GBLEnv.DocumentPath ),
                //new SqlParameter( "@OtherFilePath"  ,   GBLEnv.OtherFilePath    ),
                //new SqlParameter( "@EmpImagePath"   ,   GBLEnv.EmpImagePath ),
                //new SqlParameter( "@LabDataPath"    ,   GBLEnv.LabDataPath  ),
                //new SqlParameter( "@Partner1H1"     ,   GBLEnv.Partner1H1   ),
                //new SqlParameter( "@Partner1H2"     ,   GBLEnv.Partner1H2   ),
                //new SqlParameter( "@Partner1logoPath"   ,   GBLEnv.Partner1LogoPath ),
                //new SqlParameter( "@Partner2H1"     ,   GBLEnv.Partner2H1   ),
                //new SqlParameter( "@Partner2H2"     ,   GBLEnv.Partner2H1   ),
                //new SqlParameter( "@Partner2logoPath"   ,   GBLEnv.Partner2LogoPath ),
                //new SqlParameter( "@PacsDomain"     ,   GBLEnv.PacsDomain   ),
			};

            Parameters = parameters;
        }

        public GBLEnv GBLEnv
        {
            get { return _gblenv; }
            set { _gblenv = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
