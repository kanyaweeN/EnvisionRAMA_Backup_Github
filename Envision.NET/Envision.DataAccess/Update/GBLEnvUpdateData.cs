using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLEnvUpdateData : DataAccessBase
    {
        public GBL_ENV GBL_ENV { get; set; }

        public GBLEnvUpdateData()
        {
            GBL_ENV = new GBL_ENV();
            StoredProcedureName = StoredProcedure.GBLEnv_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@OrgUID"         ,   GBL_ENV.ORG_UID   ),
                Parameter( "@OrgName"        ,   GBL_ENV.ORG_NAME  ),
                Parameter( "@OrgAlias"       ,   GBL_ENV.ORG_ALIAS ),
                Parameter( "@OrgSlogan1"     ,   GBL_ENV.ORG_SLOGAN1   ),
                Parameter( "@OrgSlogan2"     ,   GBL_ENV.ORG_SLOGAN2   ),
                Parameter( "@OrgAddr1"       ,   GBL_ENV.ORG_ADDR1 ),
                Parameter( "@OrgAddr2"       ,   GBL_ENV.ORG_ADDR2 ),
                Parameter( "@OrgAddr3"       ,   GBL_ENV.ORG_ADDR3 ),
                Parameter( "@OrgAddr4"       ,   GBL_ENV.ORG_ADDR4 ),
                Parameter( "@OrgTel1"        ,   GBL_ENV.ORG_TEL1  ),
                Parameter( "@OrgTel2"        ,   GBL_ENV.ORG_TEL2  ),
                Parameter( "@OrgTel3"        ,   GBL_ENV.ORG_TEL3  ),
                Parameter( "@OrgFax"         ,   GBL_ENV.ORG_FAX   ),
                Parameter( "@OrgEmail1"      ,   GBL_ENV.ORG_EMAIL1    ),
                Parameter( "@OrgWebsite"     ,   GBL_ENV.ORG_WEBSITE   ),
                Parameter( "@WelcomeDialog1" ,     GBL_ENV.WELCOME_DIALOG1 ),
                Parameter( "@WelcomeDialog2" ,     GBL_ENV.WELCOME_DIALOG2 ),
                Parameter( "@RepFooter1"     ,   GBL_ENV.REP_FOOTER1   ),
                Parameter( "@RepFooter2"     ,   GBL_ENV.REP_FOOTER2   ),
                Parameter( "@DateFormat"     ,   GBL_ENV.DT_FMT   ),
                Parameter( "@TimeFormat"     ,   GBL_ENV.TIME_FMT   ),
                Parameter( "@UserDisplayFormat"  ,   GBL_ENV.USER_DISPLAY_FMT    ),
                Parameter( "@CurrencyFormat" ,   GBL_ENV.CURRENCY_FMT   ),
                Parameter( "@LocalCurrencyName"  ,   GBL_ENV.LOCAL_CURRENCY_NAME    ),
                Parameter( "@LocalCurrencySymbol"    ,   GBL_ENV.LOCAL_CURRENCY_SYMBOL  ),
                Parameter( "@EmpImageType"   ,   GBL_ENV.EMP_IMG_TYPE ),
                Parameter( "@EmpImageMaxSize"    ,   GBL_ENV.EMP_IMG_MAX_SIZE  ),
                Parameter( "@ScannedImagePath"   ,   GBL_ENV.SCANNED_IMAGE_PATH ),
                Parameter( "@BackupPath"     ,   GBL_ENV.BACKUP_PATH   ),
                Parameter( "@VendorH1"       ,   GBL_ENV.VENDOR_H1 ),
                Parameter( "@VendorH2"       ,   GBL_ENV.VENDOR_H2 ),
                Parameter( "@VendorLogoPath" ,   GBL_ENV.VENDOR_LOGO_PATH   ),
                Parameter( "@RisIP"          ,   GBL_ENV.RIS_IP    ),
                Parameter( "@RisPort"        ,   GBL_ENV.RIS_PORT  ),
                Parameter( "@RisUser"        ,   GBL_ENV.RIS_USER  ),
                Parameter( "@RisPass"        ,   GBL_ENV.RIS_PASS  ),
                Parameter( "@RisURL"         ,   GBL_ENV.RIS_URL   ),
                Parameter( "@PacsIP"         ,   GBL_ENV.PACS_IP   ),
                Parameter( "@PacsPort"       ,   GBL_ENV.PACS_PORT ),
                Parameter( "@PacsURL1"       ,   GBL_ENV.PACS_URL1 ),
                Parameter( "@PacsURL2"       ,   GBL_ENV.PACS_URL2   ),
                Parameter( "@HisIP"          ,   GBL_ENV.HIS_IP    ),
                Parameter( "@HisPort"        ,   GBL_ENV.HIS_PORT  ),
                Parameter( "@HisDBName"      ,   GBL_ENV.HIS_DB_NAME    ),
                Parameter( "@HisUserName"    ,   GBL_ENV.HIS_USER_NAME  ),
                Parameter( "@HisUserPass"    ,   GBL_ENV.HIS_USER_PASS  ),
                Parameter( "@HisFinFlag"     ,   GBL_ENV.HIS_FIN_FLAG   ),
                Parameter( "@WsIP"           ,   GBL_ENV.WS_IP ),
                Parameter( "@WsVersion"      ,   GBL_ENV.WS_VERSION    ),
                Parameter( "@Image"          ,   GBL_ENV.PICTURE_FORSAVE    ),
                Parameter( "@CREATED_BY"          ,   GBL_ENV.CREATED_BY    ),
                                      };
            return parameters;
        }
    }
}
