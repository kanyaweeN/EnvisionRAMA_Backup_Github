//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class MISBiopsyresult
		{
			#region Member 
			private	string accession_no;
			private	DateTime result_dt;
			private	int radiologist_id;
			private	string loc_no_r;
        private string loc_no_l;
			private	string tissue_type;
			private	string depth_type_r;
        private string depth_type_l;
			private	string width;
			private	string length;
			private	string depth;
			private	string procedure_type;
			private	byte no_of_core;
			private	byte calcium_pcs;
			private	string is_satisfactory;
			private	string is_surgery;
			private	string comments;
			private	string is_palpable;
			private	int lesion_type_id;
			private	int asessment_type_id;
			private	int technique_type_id;
			private	string lab_data;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
        private byte biopsy_result_id;
        private string status;
        private int assigned_to;
			#endregion 


			#region Property 
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	DateTime RESULT_DT
			{
				get{ return result_dt;}
				set{ result_dt=value;}
			}
			public	int RADIOLOGIST_ID
			{
				get{ return radiologist_id;}
				set{ radiologist_id=value;}
			}
			public	string LOC_NO_R
			{
				get{ return loc_no_r;}
				set{ loc_no_r=value;}
			}
        public string LOC_NO_L
        {
            get { return loc_no_l; }
            set { loc_no_l = value; }
        }
			public	string TISSUE_TYPE
			{
				get{ return tissue_type;}
				set{ tissue_type=value;}
			}
			public	string DEPTH_TYPE_R
			{
				get{ return depth_type_r;}
				set{ depth_type_r=value;}
			}
        public string DEPTH_TYPE_L
        {
            get { return depth_type_l; }
            set { depth_type_l = value; }
        }
			public	string WIDTH
			{
				get{ return width;}
				set{ width=value;}
			}
			public	string LENGTH
			{
				get{ return length;}
				set{ length=value;}
			}
			public	string DEPTH
			{
				get{ return depth;}
				set{ depth=value;}
			}
			public	string PROCEDURE_TYPE
			{
				get{ return procedure_type;}
				set{ procedure_type=value;}
			}
			public	byte NO_OF_CORE
			{
				get{ return no_of_core;}
				set{ no_of_core=value;}
			}
			public	byte CALCIUM_PCS
			{
				get{ return calcium_pcs;}
				set{ calcium_pcs=value;}
			}
			public	string IS_SATISFACTORY
			{
				get{ return is_satisfactory;}
				set{ is_satisfactory=value;}
			}
			public	string IS_SURGERY
			{
				get{ return is_surgery;}
				set{ is_surgery=value;}
			}
			public	string COMMENTS
			{
				get{ return comments;}
				set{ comments=value;}
			}
			public	string IS_PALPABLE
			{
				get{ return is_palpable;}
				set{ is_palpable=value;}
			}
			public	int LESION_TYPE_ID
			{
				get{ return lesion_type_id;}
				set{ lesion_type_id=value;}
			}
			public	int ASESSMENT_TYPE_ID
			{
				get{ return asessment_type_id;}
				set{ asessment_type_id=value;}
			}
			public	int TECHNIQUE_TYPE_ID
			{
				get{ return technique_type_id;}
				set{ technique_type_id=value;}
			}
			public	string LAB_DATA
			{
				get{ return lab_data;}
				set{ lab_data=value;}
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
        public byte BIOPSY_RESULT_ID
        {
            get { return biopsy_result_id; }
            set { biopsy_result_id = value; }
        }
        public string STATUS
        {
            get { return status; }
            set { status = value; }
        }
        public int ASSINGED_TO
        {
            get { return assigned_to; }
            set { assigned_to = value; }
        }
			#endregion 


			#region Constructor 
			public MISBiopsyresult(){

			}
			#endregion 


			#region Method 
			public MISBiopsyresult Copy()
			{
				return MemberwiseClone() as MISBiopsyresult;
			}
			#endregion
		}
}

