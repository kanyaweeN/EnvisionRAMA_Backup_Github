using System;
using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbEnv
    {
        public DbEnv()
        {
            dbItem = new GBL_ENV();
            Item = new Env();
        }

        private GBL_ENV dbItem { get; set; }
        public Env Item { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.GBL_ENV.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.ORG_ID;
            }
            return Id;
        }
        public bool? Update()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_ENV.Find(Item.Id);
                if (obj != null)
                {

                    obj.ORG_UID = Item.Code;
                    obj.ORG_NAME = Item.Name;
                    obj.ORG_ALIAS = Item.Alias;
                    obj.ORG_SLOGAN1 = Item.Slogan1;
                    obj.ORG_SLOGAN2 = Item.Slogan2;
                    obj.ORG_ADDR1 = Item.Addr1;
                    obj.ORG_ADDR2 = Item.Addr2;
                    obj.ORG_ADDR3 = Item.Addr3;
                    obj.ORG_ADDR4 = Item.Addr4;
                    obj.ORG_TEL1 = Item.Tel1;
                    obj.ORG_TEL2 = Item.Tel2;
                    obj.ORG_TEL3 = Item.Tel3;
                    obj.ORG_FAX = Item.Fax;
                    obj.ORG_EMAIL1 = Item.Email1;
                    obj.ORG_EMAIL2 = Item.Email2;
                    obj.ORG_EMAIL3 = Item.Email3;
                    obj.ORG_WEBSITE = Item.WebSite;
                    obj.ORG_IMG = Item.Image;
                    obj.WELCOME_DIALOG1 = Item.WelcomeDialog1;
                    obj.WELCOME_DIALOG2 = Item.WelcomeDialog2;
                    obj.DEFAULT_FONT_FACE = Item.FontFace;
                    obj.DEFAULT_FONT_SIZE = Item.FontSize;
                    obj.REP_SERVER = Item.RepServer;
                    obj.REP_FORMAT = Item.RepFormat;
                    obj.REP_FOOTER1 = Item.RepFooter1;
                    obj.REP_FOOTER2 = Item.RepFooter2;
                    obj.EMP_IMG_TYPE = Item.EmpImageType;
                    obj.EMP_IMG_MAX_SIZE = Item.EmpImageMaxSize;
                    obj.OTHER_MAX_FILE_SIZE = Item.OtherMaxFileSize;
                    obj.DT_FMT = Item.DateFormat;
                    obj.TIME_FMT = Item.TimeFormat;
                    obj.LOCAL_CURRENCY_NAME = Item.LocalCurrencyName;
                    obj.LOCAL_CURRENCY_SYMBOL = Item.LocalCurrencySymbol;
                    obj.CURRENCY_FMT = Item.CurrencyFormat;
                    obj.RESOURCE_IMAGE_PATH = Item.ResourceImagePath;
                    obj.SCANNED_IMAGE_PATH = Item.ScannedImagePath;
                    obj.DOCUMENT_PATH = Item.DocumentPath;
                    obj.BACKUP_PATH = Item.BackupPath;
                    obj.OTHER_FILE_PATH = Item.OtherFilePath;
                    obj.EMP_IMG_PATH = Item.EmpImagePath;
                    obj.LAB_DATA_PATH = Item.LabDataPath;
                    obj.USER_DISPLAY_FMT = Item.UserDisplayFormat;
                    obj.VENDOR_H1 = Item.VendorHeader1;
                    obj.VENDOR_H2 = Item.VendorHeader2;
                    obj.VENDOR_LOGO_PATH = Item.VendorLogoPath;
                    obj.PARTNER1_H1 = Item.Partner1Header1;
                    obj.PARTNER1_H2 = Item.Partner1Header2;
                    obj.PARTNER1_LOGO_PATH = Item.Partner1LogoPath;
                    obj.PARTNER2_H1 = Item.Partner2Header1;
                    obj.PARTNER2_H2 = Item.Partner2Header2;
                    obj.PARTNER2_LOGO_PATH = Item.Partner2LogoPath;
                    obj.RIS_IP = Item.RISIP;
                    obj.RIS_PORT = Item.RISPort;
                    obj.RIS_USER = Item.RISUser;
                    obj.RIS_PASS = Item.RISPass;
                    obj.RIS_URL = Item.RISUrl;
                    obj.PACS_IP = Item.PACSIP;
                    obj.PACS_PORT = Item.PACSPort;
                    obj.PACS_URL1 = Item.PACSUrl1;
                    obj.PACS_URL2 = Item.PACSUrl2;
                    obj.PACS_URL3 = Item.PACSUrl3;
                    obj.PACS_DOMAIN = Item.PACSDomain;
                    obj.HIS_IP = Item.HISIP;
                    obj.HIS_PORT = Item.HISPort;
                    obj.HIS_DB_NAME = Item.HISDBName;
                    obj.HIS_USER_NAME = Item.HISUserName;
                    obj.HIS_USER_PASS = Item.HISUserPass;
                    obj.HIS_FIN_FLAG = Item.HISFinFlag;
                    obj.WS_IP = Item.WSIP;
                    obj.WS_IP_PICTURE = Item.WSIPPicture;
                    obj.WS_VERSION = Item.WSVersion;
                    obj.ORM_SYNC_IP = Item.ORMSyncIP;
                    obj.ORM_SYNC_PORT = Item.ORMSyncPort;
                    obj.ORU_SYNC_IP = Item.ORUSyncIP;
                    obj.ORU_SYNC_PORT = Item.ORUSyncPort;
                    obj.HIS_SYNC_IP = Item.HISSyncIP;
                    obj.HIS_SYNC_PORT = Item.HISSyncPort;
                    obj.EDIT_ORDER_UNTIL = Item.EditOrderUntil;
                    obj.SCHEDULE_CONFIRM_TIME = Item.ScheduleConfirmTime;
                    obj.SCHEDULE_APPROVAL_TIME = Item.ScheduleApproveTime;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Env> GetAllData()
        {
            List<Env> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ENV
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Env>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public Env GetById()
        {
            Env obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_ENV.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Env GetByCode()
        {
            Env obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ENV
                                  where data.ORG_ID == Item.OrgId
                                        && data.ORG_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Env();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private GBL_ENV ConvertType(Env item)
        {
            GBL_ENV obj = null;
            if (item != null)
            {
                obj = new GBL_ENV();

                obj.ORG_ID = Item.Id;
                obj.ORG_UID = item.Code;
                obj.ORG_NAME = item.Name;
                obj.ORG_ALIAS = item.Alias;
                obj.ORG_SLOGAN1 = item.Slogan1;
                obj.ORG_SLOGAN2 = item.Slogan2;
                obj.ORG_ADDR1 = item.Addr1;
                obj.ORG_ADDR2 = item.Addr2;
                obj.ORG_ADDR3 = item.Addr3;
                obj.ORG_ADDR4 = item.Addr4;
                obj.ORG_TEL1 = item.Tel1;
                obj.ORG_TEL2 = item.Tel2;
                obj.ORG_TEL3 = item.Tel3;
                obj.ORG_FAX = item.Fax;
                obj.ORG_EMAIL1 = item.Email1;
                obj.ORG_EMAIL2 = item.Email2;
                obj.ORG_EMAIL3 = item.Email3;
                obj.ORG_WEBSITE = item.WebSite;
                obj.ORG_IMG = item.Image;
                obj.WELCOME_DIALOG1 = item.WelcomeDialog1;
                obj.WELCOME_DIALOG2 = item.WelcomeDialog2;
                obj.DEFAULT_FONT_FACE = item.FontFace;
                obj.DEFAULT_FONT_SIZE = item.FontSize;
                obj.REP_SERVER = item.RepServer;
                obj.REP_FORMAT = item.RepFormat;
                obj.REP_FOOTER1 = item.RepFooter1;
                obj.REP_FOOTER2 = item.RepFooter2;
                obj.EMP_IMG_TYPE = item.EmpImageType;
                obj.EMP_IMG_MAX_SIZE = item.EmpImageMaxSize;
                obj.OTHER_MAX_FILE_SIZE = item.OtherMaxFileSize;
                obj.DT_FMT = item.DateFormat;
                obj.TIME_FMT = item.TimeFormat;
                obj.LOCAL_CURRENCY_NAME = item.LocalCurrencyName;
                obj.LOCAL_CURRENCY_SYMBOL = item.LocalCurrencySymbol;
                obj.CURRENCY_FMT = item.CurrencyFormat;
                obj.RESOURCE_IMAGE_PATH = item.ResourceImagePath;
                obj.SCANNED_IMAGE_PATH = item.ScannedImagePath;
                obj.DOCUMENT_PATH = item.DocumentPath;
                obj.BACKUP_PATH = item.BackupPath;
                obj.OTHER_FILE_PATH = item.OtherFilePath;
                obj.EMP_IMG_PATH = item.EmpImagePath;
                obj.LAB_DATA_PATH = item.LabDataPath;
                obj.USER_DISPLAY_FMT = item.UserDisplayFormat;
                obj.VENDOR_H1 = item.VendorHeader1;
                obj.VENDOR_H2 = item.VendorHeader2;
                obj.VENDOR_LOGO_PATH = item.VendorLogoPath;
                obj.PARTNER1_H1 = item.Partner1Header1;
                obj.PARTNER1_H2 = item.Partner1Header2;
                obj.PARTNER1_LOGO_PATH = item.Partner1LogoPath;
                obj.PARTNER2_H1 = item.Partner2Header1;
                obj.PARTNER2_H2 = item.Partner2Header2;
                obj.PARTNER2_LOGO_PATH = item.Partner2LogoPath;
                obj.RIS_IP = item.RISIP;
                obj.RIS_PORT = item.RISPort;
                obj.RIS_USER = item.RISUser;
                obj.RIS_PASS = item.RISPass;
                obj.RIS_URL = item.RISUrl;
                obj.PACS_IP = item.PACSIP;
                obj.PACS_PORT = item.PACSPort;
                obj.PACS_URL1 = item.PACSUrl1;
                obj.PACS_URL2 = item.PACSUrl2;
                obj.PACS_URL3 = item.PACSUrl3;
                obj.PACS_DOMAIN = item.PACSDomain;
                obj.HIS_IP = item.HISIP;
                obj.HIS_PORT = item.HISPort;
                obj.HIS_DB_NAME = item.HISDBName;
                obj.HIS_USER_NAME = item.HISUserName;
                obj.HIS_USER_PASS = item.HISUserPass;
                obj.HIS_FIN_FLAG = item.HISFinFlag;
                obj.WS_IP = item.WSIP;
                obj.WS_IP_PICTURE = item.WSIPPicture;
                obj.WS_VERSION = item.WSVersion;
                obj.ORM_SYNC_IP = item.ORMSyncIP;
                obj.ORM_SYNC_PORT = item.ORMSyncPort;
                obj.ORU_SYNC_IP = item.ORUSyncIP;
                obj.ORU_SYNC_PORT = item.ORUSyncPort;
                obj.HIS_SYNC_IP = item.HISSyncIP;
                obj.HIS_SYNC_PORT = item.HISSyncPort;
                obj.EDIT_ORDER_UNTIL = item.EditOrderUntil;
                obj.SCHEDULE_CONFIRM_TIME = item.ScheduleConfirmTime;
                obj.SCHEDULE_APPROVAL_TIME = item.ScheduleApproveTime;

                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Env ConvertType(GBL_ENV item)
        {
            Env obj = null;
            if (item != null)
            {
                obj = new Env();

                obj.Id = item.ORG_ID;
                obj.Code = item.ORG_UID;
                obj.Name = item.ORG_NAME;
                obj.Alias = item.ORG_ALIAS;
                obj.Slogan1 = item.ORG_SLOGAN1;
                obj.Slogan2 = item.ORG_SLOGAN2;
                obj.Addr1 = item.ORG_ADDR1;
                obj.Addr2 = item.ORG_ADDR2;
                obj.Addr3 = item.ORG_ADDR3;
                obj.Addr4 = item.ORG_ADDR4;
                obj.Tel1 = item.ORG_TEL1;
                obj.Tel2 = item.ORG_TEL2;
                obj.Tel3 = item.ORG_TEL3;
                obj.Fax = item.ORG_FAX;
                obj.Email1 = item.ORG_EMAIL1;
                obj.Email2 = item.ORG_EMAIL2;
                obj.Email3 = item.ORG_EMAIL3;
                obj.WebSite = item.ORG_WEBSITE;
                obj.Image = item.ORG_IMG;
                obj.WelcomeDialog1 = item.WELCOME_DIALOG1;
                obj.WelcomeDialog2 = item.WELCOME_DIALOG2;
                obj.FontFace = item.DEFAULT_FONT_FACE;
                obj.FontSize = item.DEFAULT_FONT_SIZE;
                obj.RepServer = item.REP_SERVER;
                obj.RepFormat = item.REP_FORMAT;
                obj.RepFooter1 = item.REP_FOOTER1;
                obj.RepFooter2 = item.REP_FOOTER2;
                obj.EmpImageType = item.EMP_IMG_TYPE;
                obj.EmpImageMaxSize = item.EMP_IMG_MAX_SIZE;
                obj.OtherMaxFileSize = item.OTHER_MAX_FILE_SIZE;
                obj.DateFormat = item.DT_FMT;
                obj.TimeFormat = item.TIME_FMT;
                obj.LocalCurrencyName = item.LOCAL_CURRENCY_NAME;
                obj.LocalCurrencySymbol = item.LOCAL_CURRENCY_SYMBOL;
                obj.CurrencyFormat = item.CURRENCY_FMT;
                obj.ResourceImagePath = item.RESOURCE_IMAGE_PATH;
                obj.ScannedImagePath = item.SCANNED_IMAGE_PATH;
                obj.DocumentPath = item.DOCUMENT_PATH;
                obj.BackupPath = item.BACKUP_PATH;
                obj.OtherFilePath = item.OTHER_FILE_PATH;
                obj.EmpImagePath = item.EMP_IMG_PATH;
                obj.LabDataPath = item.LAB_DATA_PATH;
                obj.UserDisplayFormat = item.USER_DISPLAY_FMT;
                obj.VendorHeader1 = item.VENDOR_H1;
                obj.VendorHeader2 = item.VENDOR_H2;
                obj.VendorLogoPath = item.VENDOR_LOGO_PATH;
                obj.Partner1Header1 = item.PARTNER1_H1;
                obj.Partner1Header2 = item.PARTNER1_H2;
                obj.Partner1LogoPath = item.PARTNER1_LOGO_PATH;
                obj.Partner2Header1 = item.PARTNER2_H1;
                obj.Partner2Header2 = item.PARTNER2_H2;
                obj.Partner2LogoPath = item.PARTNER2_LOGO_PATH;
                obj.RISIP = item.RIS_IP;
                obj.RISPort = item.RIS_PORT;
                obj.RISUser = item.RIS_USER;
                obj.RISPass = item.RIS_PASS;
                obj.RISUrl = item.RIS_URL;
                obj.PACSIP = item.PACS_IP;
                obj.PACSPort = item.PACS_PORT;
                obj.PACSUrl1 = item.PACS_URL1;
                obj.PACSUrl2 = item.PACS_URL2;
                obj.PACSUrl3 = item.PACS_URL3;
                obj.PACSDomain = item.PACS_DOMAIN;
                obj.HISIP = item.HIS_IP;
                obj.HISPort = item.HIS_PORT;
                obj.HISDBName = item.HIS_DB_NAME;
                obj.HISUserName = item.HIS_USER_NAME;
                obj.HISUserPass = item.HIS_USER_PASS;
                obj.HISFinFlag = item.HIS_FIN_FLAG;
                obj.WSIP = item.WS_IP;
                obj.WSIPPicture = item.WS_IP_PICTURE;
                obj.WSVersion = item.WS_VERSION;
                obj.ORMSyncIP = item.ORM_SYNC_IP;
                obj.ORMSyncPort = item.ORM_SYNC_PORT;
                obj.ORUSyncIP = item.ORU_SYNC_IP;
                obj.ORUSyncPort = item.ORU_SYNC_PORT;
                obj.HISSyncIP = item.HIS_SYNC_IP;
                obj.HISSyncPort = item.HIS_SYNC_PORT;
                obj.EditOrderUntil = item.EDIT_ORDER_UNTIL;
                obj.ScheduleConfirmTime = item.SCHEDULE_CONFIRM_TIME;
                obj.ScheduleApproveTime = item.SCHEDULE_APPROVAL_TIME;
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }
        #endregion
    }
}