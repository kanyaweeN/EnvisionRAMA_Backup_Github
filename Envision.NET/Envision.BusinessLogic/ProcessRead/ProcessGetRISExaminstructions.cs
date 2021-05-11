using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISExaminstructions : IBusinessLogic
    {
        #region members
        private int _examid;
        private int _action;
        #endregion

        #region constructor
        public ProcessGetRISExaminstructions( ) { 
            this._action = 0;
            _examid = 0;
            Result = new DataSet();
        }
        #endregion

        #region property
        private RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION
        {
            get;
            set;
        }
        public DataSet Result
        {
            get;
            set;
        }
        
        #endregion

        public void GetAll()
        {
            this._action = 0;
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
            RIS_EXAMINSTRUCTION.ORG_ID = 1;
        }
        public void GetbyExamUID(string examUID)
        {
            this._action = 1;
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
            RIS_EXAMINSTRUCTION.EXAM_UID = examUID;
            RIS_EXAMINSTRUCTION.ORG_ID = 1;
        }

        public void GetbyINS_UID(string insuid)
        {
            this._action = 2;
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
            RIS_EXAMINSTRUCTION.INS_UID = insuid;
            RIS_EXAMINSTRUCTION.ORG_ID = 1;
        }
        public void GetAll_New()
        {
            this._action = 3;
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
            RIS_EXAMINSTRUCTION.ORG_ID = 1;
        }
        public void GetByEXAM_ID_New(string ExamUID)
        {
            this._action = 4;
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
            RIS_EXAMINSTRUCTION.ORG_ID = 1;
            RIS_EXAMINSTRUCTION.EXAM_UID = ExamUID;
        }
        public void Invoke()
        {


            RISExaminstructionsSelectData _proc = new RISExaminstructionsSelectData(RIS_EXAMINSTRUCTION, this._action);
            Result = _proc.GetData();
        }
	}
}

