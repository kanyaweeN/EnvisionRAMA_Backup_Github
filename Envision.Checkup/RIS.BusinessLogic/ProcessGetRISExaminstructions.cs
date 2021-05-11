using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISExaminstructions : IBusinessLogic
    {
        #region members
        private DataSet _result;
        private int _examid;
        private int _action;
        private RISExaminstructions _risexaminstructions;
        #endregion

        #region constructor
        public ProcessGetRISExaminstructions( ) { this._action = 0; }

        //public ProcessGetRISExaminstructions(int byExamID)
        //{
        //    RISExaminstructions.EXAM_ID = byExamID;
        //    this._action = 1;
        //}
        #endregion

        #region property
        private RISExaminstructions RISExaminstructions
        {
            get { return _risexaminstructions; }
            set { _risexaminstructions = value; }
        }
        public DataSet Result
		{
			get{return _result;}
			set{_result=value;}
        }
        
        #endregion

        public void GetAll()
        {
            this._action = 0;
            RISExaminstructions = new RISExaminstructions();

            RISExaminstructions.ORG_ID = 1;
        }
        public void GetbyExamUID(string examUID)
        {
            this._action = 1;
            RISExaminstructions = new RISExaminstructions();
            RISExaminstructions.EXAM_UID = examUID;
            RISExaminstructions.ORG_ID = 1;
        }

        public void GetbyINS_UID(string insuid)
        {
            this._action = 2;
            RISExaminstructions = new RISExaminstructions();
            RISExaminstructions.INS_UID = insuid;
            RISExaminstructions.ORG_ID = 1;
        }
        public void GetAll_New()
        {
            this._action = 3;
            RISExaminstructions = new RISExaminstructions();
            RISExaminstructions.ORG_ID = 1;
        }
        public void GetByEXAM_ID_New(string ExamUID)
        {
            this._action = 4;
            RISExaminstructions = new RISExaminstructions();
            RISExaminstructions.ORG_ID = 1;
            RISExaminstructions.EXAM_UID = ExamUID;
        }
        public void Invoke()
        {
            RISExaminstructionsSelectData _proc = new RISExaminstructionsSelectData(RISExaminstructions,this._action);
            _result = _proc.GetData();
        }
        //public void Invoke()
        //{
        //    //RISExaminstructionsSelectData _proc=new RISExaminstructionsSelectData();
        //    //_result=_proc.GetData();
        //    RISExaminstructionsSelectData _proc = null;
        //    switch (this._action)
        //    {
        //        case 0:
        //            _proc = new RISExaminstructionsSelectData();
        //            break;
        //        case 1:
        //            _proc = new RISExaminstructionsSelectData(this._examid);
        //            break;
        //    }
        //    _result = _proc.GetData();
        //}

	}
}

