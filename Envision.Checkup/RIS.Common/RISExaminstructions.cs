//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//         Modifier   :    Sitti Borisuit
//         Modified   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RIS.Common
{
	public class RISExaminstructions
		{
		#region Constructor 
        public RISExaminstructions() { }
        public RISExaminstructions(int id, string examuid, string uid, string text, string inherit)
        {
			_ins_id = id;
			_exam_uid = examuid;
			_ins_uid = uid;
			_ins_text = text;
			_inherit_group = inherit;
            //private	string is_updated;
            //private	string is_deleted;
        }
		#endregion 


		#region Member
        private int _sp_type;
		private	int _ins_id;
		private	int _exam_id;
        private string _exam_uid;
        private int _unit_id;
        private string _unit_ins;
        private int _exam_type_id;
        private string _exam_type_ins;
        private string _exam_type_ins_kid;
		private	string _ins_uid;
		private	string _ins_text;
		private	string _inherit_group;
		private	string _is_updated;
		private	string _is_deleted;
		private	int _org_id;
		private	int _created_by;
		private	DateTime _created_on;
		private	int _last_modified_by;
		private	DateTime _last_modified_on;
		#endregion 


		#region Property 
        public int SP_TYPE
        {
            get { return _sp_type; }
            set { _sp_type = value; }
        }
		public	int INS_ID
		{
			get{ return _ins_id;}
			set{ _ins_id=value;}
		}
        public int UNIT_ID
        {
            get { return _unit_id; }
            set { _unit_id = value; }
        }
        public string UNIT_INS
        {
            get { return _unit_ins; }
            set { _unit_ins = value; }
        }
        public int EXAM_TYPE_ID
        {
            get { return _exam_type_id; }
            set { _exam_type_id = value; }
        }
        public string EXAM_TYPE_INS
        {
            get { return _exam_type_ins; }
            set { _exam_type_ins = value; }
        }
        public string EXAM_TYPE_INS_KID
        {
            get { return _exam_type_ins_kid; }
            set { _exam_type_ins_kid = value; }
        }
		public	string INS_UID
		{
			get{ return _ins_uid;}
			set{ _ins_uid=value;}
		}
        public int EXAM_ID
        {
            get { return _exam_id; }
            set { _exam_id = value; }
        }
        public string EXAM_UID
        {
            get { return _exam_uid; }
            set { _exam_uid = value; }
        }
		public	string INS_TEXT
		{
			get{ return _ins_text;}
			set{ _ins_text=value;}
		}
		public	string INHERIT_GROUP
		{
			get{ return _inherit_group;}
			set{ _inherit_group=value;}
		}
		public	string IS_UPDATED
		{
			get{ return _is_updated;}
			set{ _is_updated=value;}
		}
		public	string IS_DELETED
		{
			get{ return _is_deleted;}
			set{ _is_deleted=value;}
		}
		public	int ORG_ID
		{
			get{ return _org_id;}
			set{ _org_id=value;}
		}
		public	int CREATED_BY
		{
			get{ return _created_by;}
			set{ _created_by=value;}
		}
		public	DateTime CREATED_ON
		{
			get{ return _created_on;}
			set{ _created_on=value;}
		}
		public	int LAST_MODIFIED_BY
		{
			get{ return _last_modified_by;}
			set{ _last_modified_by=value;}
		}
		public	DateTime LAST_MODIFIED_ON
		{
			get{ return _last_modified_on;}
			set{ _last_modified_on=value;}
		}
			#endregion 
		}

    #region collections
    public class RISExamInstructionsObjectCollection : CollectionBase
    {
        public void Add(RISExaminstructions _examinstructionsObject)
        {
            this.List.Add(_examinstructionsObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public RISExam this[int index]
        {
            get
            {
                return (RISExam)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }
    #endregion
}

