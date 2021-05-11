//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    25/05/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISTechworks
		{
			#region Constructor 
			public RISTechworks(){

			}
			#endregion 


			#region Member 
			private	string accession_on;
			private	byte take;
			private	DateTime start_time;
			private	DateTime end_time;
			private	string exposure_technique;
			private	string protocol;
			private	string kv;
			private	string ma;
			private	string sec;
			private	string status;
			private	string comments;
			private	int no_of_images;
			private	int org_id;
			private	int created_by;
			private	int performanced_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	string ACCESSION_ON
			{
				get{ return accession_on;}
				set{ accession_on=value;}
			}
			public	byte TAKE
			{
				get{ return take;}
				set{ take=value;}
			}
			public	DateTime START_TIME
			{
				get{ return start_time;}
				set{ start_time=value;}
			}
			public	DateTime END_TIME
			{
				get{ return end_time;}
				set{ end_time=value;}
			}
			public	string EXPOSURE_TECHNIQUE
			{
				get{ return exposure_technique;}
				set{ exposure_technique=value;}
			}
			public	string PROTOCOL
			{
				get{ return protocol;}
				set{ protocol=value;}
			}
			public	string KV
			{
				get{ return kv;}
				set{ kv=value;}
			}
			public	string mA
			{
				get{ return ma;}
				set{ ma=value;}
			}
			public	string SEC
			{
				get{ return sec;}
				set{ sec=value;}
			}
			public	string STATUS
			{
				get{ return status;}
				set{ status=value;}
			}
			public	string COMMENTS
			{
				get{ return comments;}
				set{ comments=value;}
			}
			public	int NO_OF_IMAGES
			{
				get{ return no_of_images;}
				set{ no_of_images=value;}
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
			public	int PERFORMANCED_BY
			{
				get{ return performanced_by;}
				set{ performanced_by=value;}
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
			#endregion 
		}
}

