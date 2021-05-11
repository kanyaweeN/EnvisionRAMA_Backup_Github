//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2009 05:03:15
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class GBLRadexperience
		{
			#region Member 
			private	int radiologist_id;
			private	short auto_refresh_wl_sec;
			private	string dashboard_def_search;
			private	bool load_finalized_exams;
			private	bool all_exam_visible;
			private	bool load_all_exam;
			private	bool auto_start_order_img;
			private	bool auto_start_pacs_img;
			private	string def_date_range;
			private	bool remember_grid_order;
			private	string grid_dbl_click_to;
			private	string finish_writing_refer_to;
			private	bool allow_othersto_finalize;
			private	string font_face;
			private	byte font_size;
			private	string signature_text;
			private	byte[] signature_scan;
			private	string used_signature;
			private	string when_group_sign_use;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
            private DateTime last_modified_on;
            private string signature_rtf;
            private string signature_html;
        private string worklist_grid_order;
            private string history_grid_order;
            private int minimize_character;
			#endregion 


			#region Property 
			public	int RADIOLOGIST_ID
			{
				get{ return radiologist_id;}
				set{ radiologist_id=value;}
			}
			public	short AUTO_REFRESH_WL_SEC
			{
				get{ return auto_refresh_wl_sec;}
				set{ auto_refresh_wl_sec=value;}
			}
			public	string DASHBOARD_DEF_SEARCH
			{
				get{ return dashboard_def_search;}
				set{ dashboard_def_search=value;}
			}
        public string WORKLIST_GRID_ORDER
        {
            get { return worklist_grid_order; }
            set { worklist_grid_order = value; }
        }
        public string HISTORY_GRID_ORDER
        {
            get { return history_grid_order; }
            set { history_grid_order = value; }
        }
			public	bool LOAD_FINALIZED_EXAMS
			{
				get{ return load_finalized_exams;}
				set{ load_finalized_exams=value;}
			}
			public	bool ALL_EXAM_VISIBLE
			{
				get{ return all_exam_visible;}
				set{ all_exam_visible=value;}
			}
			public	bool LOAD_ALL_EXAM
			{
				get{ return load_all_exam;}
				set{ load_all_exam=value;}
			}
			public	bool AUTO_START_ORDER_IMG
			{
				get{ return auto_start_order_img;}
				set{ auto_start_order_img=value;}
			}
			public	bool AUTO_START_PACS_IMG
			{
				get{ return auto_start_pacs_img;}
				set{ auto_start_pacs_img=value;}
			}
			public	string DEF_DATE_RANGE
			{
				get{ return def_date_range;}
				set{ def_date_range=value;}
			}
			public	bool REMEMBER_GRID_ORDER
			{
				get{ return remember_grid_order;}
				set{ remember_grid_order=value;}
			}
			public	string GRID_DBL_CLICK_TO
			{
				get{ return grid_dbl_click_to;}
				set{ grid_dbl_click_to=value;}
			}
			public	string FINISH_WRITING_REFER_TO
			{
				get{ return finish_writing_refer_to;}
				set{ finish_writing_refer_to=value;}
			}
			public	bool ALLOW_OTHERSTO_FINALIZE
			{
				get{ return allow_othersto_finalize;}
				set{ allow_othersto_finalize=value;}
			}
			public	string FONT_FACE
			{
				get{ return font_face;}
				set{ font_face=value;}
			}
			public	byte FONT_SIZE
			{
				get{ return font_size;}
				set{ font_size=value;}
			}
			public	string SIGNATURE_TEXT
			{
				get{ return signature_text;}
				set{ signature_text=value;}
			}
			public	byte[] SIGNATURE_SCAN
			{
				get{ return signature_scan;}
				set{ signature_scan=value;}
			}
			public	string USED_SIGNATURE
			{
				get{ return used_signature;}
				set{ used_signature=value;}
			}
			public	string WHEN_GROUP_SIGN_USE
			{
				get{ return when_group_sign_use;}
				set{ when_group_sign_use=value;}
			}
			public	int ORG_ID
			{
				get{ return org_id;}
				set{ org_id=value;}
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
            public string SIGNATURE_RTF 
            {
                get { return signature_rtf; }
                set { signature_rtf = value; }
            }
            public string SIGNATURE_HTML
            {
                get { return signature_html; }
                set { signature_html = value; }
            }
            public int MINIMIZE_CHARACTER
            {
                get { return minimize_character; }
                set { minimize_character = value; }
            }
			#endregion 


			#region Constructor 
			public GBLRadexperience(){

			}
			#endregion 


			#region Method 
			public GBLRadexperience Copy()
			{
				return MemberwiseClone() as GBLRadexperience;
			}
			#endregion
		}
}

