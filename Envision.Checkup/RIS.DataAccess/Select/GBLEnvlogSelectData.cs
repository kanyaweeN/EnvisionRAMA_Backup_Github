//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/06/2009 02:20:56
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class GBLEnvlogSelectData : DataAccessBase 
	{
		private GBLEnvlog	_gblenvlog;
		private GBLEnvlogSelectDataParameters param;
		public  GBLEnvlogSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_GBL_ENVLOG_Select.ToString();
		}
		public  GBLEnvlog	GBLEnvlog
		{
			get{return _gblenvlog;}
			set{_gblenvlog=value;}
		}
		public DataSet GetData()
		{
			param = new GBLEnvlogSelectDataParameters(GBLEnvlog);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class GBLEnvlogSelectDataParameters 
	{
		private GBLEnvlog _gblenvlog;
		private SqlParameter[] _parameters;
		public GBLEnvlogSelectDataParameters(GBLEnvlog gblenvlog)
		{
			GBLEnvlog=gblenvlog;
			Build();
		}
		public  GBLEnvlog	GBLEnvlog
		{
			get{return _gblenvlog;}
			set{_gblenvlog=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@LOG_ID",GBLEnvlog.LOG_ID)
//,new SqlParameter("@EFFECTIVE_DT",GBLEnvlog.EFFECTIVE_DT)
//,new SqlParameter("@START_LSN",GBLEnvlog.START_LSN)
//,new SqlParameter("@SEQVAL",GBLEnvlog.SEQVAL)
//,new SqlParameter("@OPERATION",GBLEnvlog.OPERATION)
			
//,new SqlParameter("@UPDATE_MASK",GBLEnvlog.UPDATE_MASK)
//,new SqlParameter("@ORG_ID",GBLEnvlog.ORG_ID)
//,new SqlParameter("@ORG_UID",GBLEnvlog.ORG_UID)
//,new SqlParameter("@ORG_NAME",GBLEnvlog.ORG_NAME)
//,new SqlParameter("@ORG_ALIAS",GBLEnvlog.ORG_ALIAS)
			
//,new SqlParameter("@ORG_SLOGAN1",GBLEnvlog.ORG_SLOGAN1)
//,new SqlParameter("@ORG_SLOGAN2",GBLEnvlog.ORG_SLOGAN2)
//,new SqlParameter("@ORG_ADDR1",GBLEnvlog.ORG_ADDR1)
//,new SqlParameter("@ORG_ADDR2",GBLEnvlog.ORG_ADDR2)
//,new SqlParameter("@ORG_ADDR3",GBLEnvlog.ORG_ADDR3)
			
//,new SqlParameter("@ORG_ADDR4",GBLEnvlog.ORG_ADDR4)
//,new SqlParameter("@ORG_TEL1",GBLEnvlog.ORG_TEL1)
//,new SqlParameter("@ORG_TEL2",GBLEnvlog.ORG_TEL2)
//,new SqlParameter("@ORG_TEL3",GBLEnvlog.ORG_TEL3)
//,new SqlParameter("@ORG_FAX",GBLEnvlog.ORG_FAX)
			
//,new SqlParameter("@ORG_EMAIL1",GBLEnvlog.ORG_EMAIL1)
//,new SqlParameter("@ORG_EMAIL2",GBLEnvlog.ORG_EMAIL2)
//,new SqlParameter("@ORG_EMAIL3",GBLEnvlog.ORG_EMAIL3)
//,new SqlParameter("@ORG_WEBSITE",GBLEnvlog.ORG_WEBSITE)
//,new SqlParameter("@ORG_IMG",GBLEnvlog.ORG_IMG)
			
//,new SqlParameter("@WELCOME_DIALOG1",GBLEnvlog.WELCOME_DIALOG1)
//,new SqlParameter("@WELCOME_DIALOG2",GBLEnvlog.WELCOME_DIALOG2)
//,new SqlParameter("@DEFAULT_FONT_FACE",GBLEnvlog.DEFAULT_FONT_FACE)
//,new SqlParameter("@DEFAULT_FONT_SIZE",GBLEnvlog.DEFAULT_FONT_SIZE)
//,new SqlParameter("@REP_SERVER",GBLEnvlog.REP_SERVER)
			
//,new SqlParameter("@REP_FORMAT",GBLEnvlog.REP_FORMAT)
//,new SqlParameter("@REP_FOOTER1",GBLEnvlog.REP_FOOTER1)
//,new SqlParameter("@REP_FOOTER2",GBLEnvlog.REP_FOOTER2)
//,new SqlParameter("@EMP_IMG_TYPE",GBLEnvlog.EMP_IMG_TYPE)
//,new SqlParameter("@EMP_IMG_MAX_SIZE",GBLEnvlog.EMP_IMG_MAX_SIZE)
			
//,new SqlParameter("@OTHER_MAX_FILE_SIZE",GBLEnvlog.OTHER_MAX_FILE_SIZE)
//,new SqlParameter("@DT_FMT",GBLEnvlog.DT_FMT)
//,new SqlParameter("@TIME_FMT",GBLEnvlog.TIME_FMT)
//,new SqlParameter("@LOCAL_CURRENCY_NAME",GBLEnvlog.LOCAL_CURRENCY_NAME)
//,new SqlParameter("@LOCAL_CURRENCY_SYMBOL",GBLEnvlog.LOCAL_CURRENCY_SYMBOL)
			
//,new SqlParameter("@CURRENCY_FMT",GBLEnvlog.CURRENCY_FMT)
//,new SqlParameter("@RESOURCE_IMAGE_PATH",GBLEnvlog.RESOURCE_IMAGE_PATH)
//,new SqlParameter("@SCANNED_IMAGE_PATH",GBLEnvlog.SCANNED_IMAGE_PATH)
//,new SqlParameter("@DOCUMENT_PATH",GBLEnvlog.DOCUMENT_PATH)
//,new SqlParameter("@BACKUP_PATH",GBLEnvlog.BACKUP_PATH)
			
//,new SqlParameter("@OTHER_FILE_PATH",GBLEnvlog.OTHER_FILE_PATH)
//,new SqlParameter("@EMP_IMG_PATH",GBLEnvlog.EMP_IMG_PATH)
//,new SqlParameter("@LAB_DATA_PATH",GBLEnvlog.LAB_DATA_PATH)
//,new SqlParameter("@USER_DISPLAY_FMT",GBLEnvlog.USER_DISPLAY_FMT)
//,new SqlParameter("@VENDOR_H1",GBLEnvlog.VENDOR_H1)
			
//,new SqlParameter("@VENDOR_H2",GBLEnvlog.VENDOR_H2)
//,new SqlParameter("@VENDOR_LOGO_PATH",GBLEnvlog.VENDOR_LOGO_PATH)
//,new SqlParameter("@PARTNER1_H1",GBLEnvlog.PARTNER1_H1)
//,new SqlParameter("@PARTNER1_H2",GBLEnvlog.PARTNER1_H2)
//,new SqlParameter("@PARTNER1_LOGO_PATH",GBLEnvlog.PARTNER1_LOGO_PATH)
			
//,new SqlParameter("@PARTNER2_H1",GBLEnvlog.PARTNER2_H1)
//,new SqlParameter("@PARTNER2_H2",GBLEnvlog.PARTNER2_H2)
//,new SqlParameter("@PARTNER2_LOGO_PATH",GBLEnvlog.PARTNER2_LOGO_PATH)
//,new SqlParameter("@RIS_IP",GBLEnvlog.RIS_IP)
//,new SqlParameter("@RIS_PORT",GBLEnvlog.RIS_PORT)
			
//,new SqlParameter("@RIS_USER",GBLEnvlog.RIS_USER)
//,new SqlParameter("@RIS_PASS",GBLEnvlog.RIS_PASS)
//,new SqlParameter("@RIS_URL",GBLEnvlog.RIS_URL)
//,new SqlParameter("@PACS_IP",GBLEnvlog.PACS_IP)
//,new SqlParameter("@PACS_PORT",GBLEnvlog.PACS_PORT)
			
//,new SqlParameter("@PACS_URL1",GBLEnvlog.PACS_URL1)
//,new SqlParameter("@PACS_URL2",GBLEnvlog.PACS_URL2)
//,new SqlParameter("@PACS_URL3",GBLEnvlog.PACS_URL3)
//,new SqlParameter("@PACS_DOMAIN",GBLEnvlog.PACS_DOMAIN)
//,new SqlParameter("@HIS_IP",GBLEnvlog.HIS_IP)
			
//,new SqlParameter("@HIS_PORT",GBLEnvlog.HIS_PORT)
//,new SqlParameter("@HIS_DB_NAME",GBLEnvlog.HIS_DB_NAME)
//,new SqlParameter("@HIS_USER_NAME",GBLEnvlog.HIS_USER_NAME)
//,new SqlParameter("@HIS_USER_PASS",GBLEnvlog.HIS_USER_PASS)
//,new SqlParameter("@HIS_FIN_FLAG",GBLEnvlog.HIS_FIN_FLAG)
			
//,new SqlParameter("@WS_IP",GBLEnvlog.WS_IP)
//,new SqlParameter("@WS_IP_PICTURE",GBLEnvlog.WS_IP_PICTURE)
//,new SqlParameter("@WS_VERSION",GBLEnvlog.WS_VERSION)
//,new SqlParameter("@CREATED_BY",GBLEnvlog.CREATED_BY)
//,new SqlParameter("@CREATED_ON",GBLEnvlog.CREATED_ON)
			
//,new SqlParameter("@LAST_MODIFIED_BY",GBLEnvlog.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",GBLEnvlog.LAST_MODIFIED_ON)

                new SqlParameter("@FROMDATE",GBLEnvlog.FROMDATE)
                ,new SqlParameter("@TODATE",GBLEnvlog.TODATE)
			};
			_parameters=parameters;
		}
	}
}

