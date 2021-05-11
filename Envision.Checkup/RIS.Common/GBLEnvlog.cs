//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/06/2009 02:20:54
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class GBLEnvlog
		{
			#region Member 
			private	int log_id;
			private	DateTime effective_dt;
			private	byte[] start_lsn;
			private	byte[] seqval;
			private	int operation;
			private	byte[] update_mask;
			private	int org_id;
			private	string org_uid;
			private	string org_name;
			private	string org_alias;
			private	string org_slogan1;
			private	string org_slogan2;
			private	string org_addr1;
			private	string org_addr2;
			private	string org_addr3;
			private	string org_addr4;
			private	string org_tel1;
			private	string org_tel2;
			private	string org_tel3;
			private	string org_fax;
			private	string org_email1;
			private	string org_email2;
			private	string org_email3;
			private	string org_website;
			private	byte[] org_img;
			private	string welcome_dialog1;
			private	string welcome_dialog2;
			private	string default_font_face;
			private	byte default_font_size;
			private	string rep_server;
			private	string rep_format;
			private	string rep_footer1;
			private	string rep_footer2;
			private	string emp_img_type;
			private	string emp_img_max_size;
			private	int other_max_file_size;
			private	string dt_fmt;
			private	string time_fmt;
			private	string local_currency_name;
			private	string local_currency_symbol;
			private	string currency_fmt;
			private	string resource_image_path;
			private	string scanned_image_path;
			private	string document_path;
			private	string backup_path;
			private	string other_file_path;
			private	string emp_img_path;
			private	string lab_data_path;
			private	string user_display_fmt;
			private	string vendor_h1;
			private	string vendor_h2;
			private	string vendor_logo_path;
			private	string partner1_h1;
			private	string partner1_h2;
			private	string partner1_logo_path;
			private	string partner2_h1;
			private	string partner2_h2;
			private	string partner2_logo_path;
			private	string ris_ip;
			private	string ris_port;
			private	string ris_user;
			private	string ris_pass;
			private	string ris_url;
			private	string pacs_ip;
			private	string pacs_port;
			private	string pacs_url1;
			private	string pacs_url2;
			private	string pacs_url3;
			private	string pacs_domain;
			private	string his_ip;
			private	string his_port;
			private	string his_db_name;
			private	string his_user_name;
			private	string his_user_pass;
			private	string his_fin_flag;
			private	string ws_ip;
			private	string ws_ip_picture;
			private	string ws_version;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private DateTime fromdate;
            private DateTime todate;
			#endregion 


			#region Property 
			public	int LOG_ID
			{
				get{ return log_id;}
				set{ log_id=value;}
			}
			public	DateTime EFFECTIVE_DT
			{
				get{ return effective_dt;}
				set{ effective_dt=value;}
			}
			public	byte[] START_LSN
			{
				get{ return start_lsn;}
				set{ start_lsn=value;}
			}
			public	byte[] SEQVAL
			{
				get{ return seqval;}
				set{ seqval=value;}
			}
			public	int OPERATION
			{
				get{ return operation;}
				set{ operation=value;}
			}
			public	byte[] UPDATE_MASK
			{
				get{ return update_mask;}
				set{ update_mask=value;}
			}
			public	int ORG_ID
			{
				get{ return org_id;}
				set{ org_id=value;}
			}
			public	string ORG_UID
			{
				get{ return org_uid;}
				set{ org_uid=value;}
			}
			public	string ORG_NAME
			{
				get{ return org_name;}
				set{ org_name=value;}
			}
			public	string ORG_ALIAS
			{
				get{ return org_alias;}
				set{ org_alias=value;}
			}
			public	string ORG_SLOGAN1
			{
				get{ return org_slogan1;}
				set{ org_slogan1=value;}
			}
			public	string ORG_SLOGAN2
			{
				get{ return org_slogan2;}
				set{ org_slogan2=value;}
			}
			public	string ORG_ADDR1
			{
				get{ return org_addr1;}
				set{ org_addr1=value;}
			}
			public	string ORG_ADDR2
			{
				get{ return org_addr2;}
				set{ org_addr2=value;}
			}
			public	string ORG_ADDR3
			{
				get{ return org_addr3;}
				set{ org_addr3=value;}
			}
			public	string ORG_ADDR4
			{
				get{ return org_addr4;}
				set{ org_addr4=value;}
			}
			public	string ORG_TEL1
			{
				get{ return org_tel1;}
				set{ org_tel1=value;}
			}
			public	string ORG_TEL2
			{
				get{ return org_tel2;}
				set{ org_tel2=value;}
			}
			public	string ORG_TEL3
			{
				get{ return org_tel3;}
				set{ org_tel3=value;}
			}
			public	string ORG_FAX
			{
				get{ return org_fax;}
				set{ org_fax=value;}
			}
			public	string ORG_EMAIL1
			{
				get{ return org_email1;}
				set{ org_email1=value;}
			}
			public	string ORG_EMAIL2
			{
				get{ return org_email2;}
				set{ org_email2=value;}
			}
			public	string ORG_EMAIL3
			{
				get{ return org_email3;}
				set{ org_email3=value;}
			}
			public	string ORG_WEBSITE
			{
				get{ return org_website;}
				set{ org_website=value;}
			}
			public	byte[] ORG_IMG
			{
				get{ return org_img;}
				set{ org_img=value;}
			}
			public	string WELCOME_DIALOG1
			{
				get{ return welcome_dialog1;}
				set{ welcome_dialog1=value;}
			}
			public	string WELCOME_DIALOG2
			{
				get{ return welcome_dialog2;}
				set{ welcome_dialog2=value;}
			}
			public	string DEFAULT_FONT_FACE
			{
				get{ return default_font_face;}
				set{ default_font_face=value;}
			}
			public	byte DEFAULT_FONT_SIZE
			{
				get{ return default_font_size;}
				set{ default_font_size=value;}
			}
			public	string REP_SERVER
			{
				get{ return rep_server;}
				set{ rep_server=value;}
			}
			public	string REP_FORMAT
			{
				get{ return rep_format;}
				set{ rep_format=value;}
			}
			public	string REP_FOOTER1
			{
				get{ return rep_footer1;}
				set{ rep_footer1=value;}
			}
			public	string REP_FOOTER2
			{
				get{ return rep_footer2;}
				set{ rep_footer2=value;}
			}
			public	string EMP_IMG_TYPE
			{
				get{ return emp_img_type;}
				set{ emp_img_type=value;}
			}
			public	string EMP_IMG_MAX_SIZE
			{
				get{ return emp_img_max_size;}
				set{ emp_img_max_size=value;}
			}
			public	int OTHER_MAX_FILE_SIZE
			{
				get{ return other_max_file_size;}
				set{ other_max_file_size=value;}
			}
			public	string DT_FMT
			{
				get{ return dt_fmt;}
				set{ dt_fmt=value;}
			}
			public	string TIME_FMT
			{
				get{ return time_fmt;}
				set{ time_fmt=value;}
			}
			public	string LOCAL_CURRENCY_NAME
			{
				get{ return local_currency_name;}
				set{ local_currency_name=value;}
			}
			public	string LOCAL_CURRENCY_SYMBOL
			{
				get{ return local_currency_symbol;}
				set{ local_currency_symbol=value;}
			}
			public	string CURRENCY_FMT
			{
				get{ return currency_fmt;}
				set{ currency_fmt=value;}
			}
			public	string RESOURCE_IMAGE_PATH
			{
				get{ return resource_image_path;}
				set{ resource_image_path=value;}
			}
			public	string SCANNED_IMAGE_PATH
			{
				get{ return scanned_image_path;}
				set{ scanned_image_path=value;}
			}
			public	string DOCUMENT_PATH
			{
				get{ return document_path;}
				set{ document_path=value;}
			}
			public	string BACKUP_PATH
			{
				get{ return backup_path;}
				set{ backup_path=value;}
			}
			public	string OTHER_FILE_PATH
			{
				get{ return other_file_path;}
				set{ other_file_path=value;}
			}
			public	string EMP_IMG_PATH
			{
				get{ return emp_img_path;}
				set{ emp_img_path=value;}
			}
			public	string LAB_DATA_PATH
			{
				get{ return lab_data_path;}
				set{ lab_data_path=value;}
			}
			public	string USER_DISPLAY_FMT
			{
				get{ return user_display_fmt;}
				set{ user_display_fmt=value;}
			}
			public	string VENDOR_H1
			{
				get{ return vendor_h1;}
				set{ vendor_h1=value;}
			}
			public	string VENDOR_H2
			{
				get{ return vendor_h2;}
				set{ vendor_h2=value;}
			}
			public	string VENDOR_LOGO_PATH
			{
				get{ return vendor_logo_path;}
				set{ vendor_logo_path=value;}
			}
			public	string PARTNER1_H1
			{
				get{ return partner1_h1;}
				set{ partner1_h1=value;}
			}
			public	string PARTNER1_H2
			{
				get{ return partner1_h2;}
				set{ partner1_h2=value;}
			}
			public	string PARTNER1_LOGO_PATH
			{
				get{ return partner1_logo_path;}
				set{ partner1_logo_path=value;}
			}
			public	string PARTNER2_H1
			{
				get{ return partner2_h1;}
				set{ partner2_h1=value;}
			}
			public	string PARTNER2_H2
			{
				get{ return partner2_h2;}
				set{ partner2_h2=value;}
			}
			public	string PARTNER2_LOGO_PATH
			{
				get{ return partner2_logo_path;}
				set{ partner2_logo_path=value;}
			}
			public	string RIS_IP
			{
				get{ return ris_ip;}
				set{ ris_ip=value;}
			}
			public	string RIS_PORT
			{
				get{ return ris_port;}
				set{ ris_port=value;}
			}
			public	string RIS_USER
			{
				get{ return ris_user;}
				set{ ris_user=value;}
			}
			public	string RIS_PASS
			{
				get{ return ris_pass;}
				set{ ris_pass=value;}
			}
			public	string RIS_URL
			{
				get{ return ris_url;}
				set{ ris_url=value;}
			}
			public	string PACS_IP
			{
				get{ return pacs_ip;}
				set{ pacs_ip=value;}
			}
			public	string PACS_PORT
			{
				get{ return pacs_port;}
				set{ pacs_port=value;}
			}
			public	string PACS_URL1
			{
				get{ return pacs_url1;}
				set{ pacs_url1=value;}
			}
			public	string PACS_URL2
			{
				get{ return pacs_url2;}
				set{ pacs_url2=value;}
			}
			public	string PACS_URL3
			{
				get{ return pacs_url3;}
				set{ pacs_url3=value;}
			}
			public	string PACS_DOMAIN
			{
				get{ return pacs_domain;}
				set{ pacs_domain=value;}
			}
			public	string HIS_IP
			{
				get{ return his_ip;}
				set{ his_ip=value;}
			}
			public	string HIS_PORT
			{
				get{ return his_port;}
				set{ his_port=value;}
			}
			public	string HIS_DB_NAME
			{
				get{ return his_db_name;}
				set{ his_db_name=value;}
			}
			public	string HIS_USER_NAME
			{
				get{ return his_user_name;}
				set{ his_user_name=value;}
			}
			public	string HIS_USER_PASS
			{
				get{ return his_user_pass;}
				set{ his_user_pass=value;}
			}
			public	string HIS_FIN_FLAG
			{
				get{ return his_fin_flag;}
				set{ his_fin_flag=value;}
			}
			public	string WS_IP
			{
				get{ return ws_ip;}
				set{ ws_ip=value;}
			}
			public	string WS_IP_PICTURE
			{
				get{ return ws_ip_picture;}
				set{ ws_ip_picture=value;}
			}
			public	string WS_VERSION
			{
				get{ return ws_version;}
				set{ ws_version=value;}
			}
			public	int CREATED_BY
			{
				get{ return created_by;}
				set{ created_by=value;}
			}
			public	DateTime CREATED_ON
			{
				get{ return created_on;}
				set{ created_on=value;}
			}
			public	int LAST_MODIFIED_BY
			{
				get{ return last_modified_by;}
				set{ last_modified_by=value;}
			}
			public	DateTime LAST_MODIFIED_ON
			{
				get{ return last_modified_on;}
				set{ last_modified_on=value;}
			}
        public DateTime FROMDATE
        {
            get { return fromdate; }
            set { fromdate = value; }
        }
        public DateTime TODATE
        {
            get { return todate; }
            set { todate = value; }
        }
			#endregion 


			#region Constructor 
			public GBLEnvlog(){

			}
			#endregion 


			#region Method 
			public GBLEnvlog Copy()
			{
				return MemberwiseClone() as GBLEnvlog;
			}
			#endregion
		}
}

