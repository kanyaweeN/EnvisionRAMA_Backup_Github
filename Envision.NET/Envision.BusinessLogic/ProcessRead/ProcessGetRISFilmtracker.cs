//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2553 01:30:46
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISFilmtracker : IBusinessLogic
	{
		private DataSet result;
        private RIS_FILMTRACKER _risfilmtracker;
        int mode;
		public ProcessGetRISFilmtracker(int mode)
		{
            this.mode = mode;
            _risfilmtracker = new RIS_FILMTRACKER();
		}
        public RIS_FILMTRACKER RISFilmtracker
		{
			get{return _risfilmtracker;}
			set{_risfilmtracker=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISFilmtrackerSelectData _proc = new RISFilmtrackerSelectData(mode);
            _proc.RIS_FILMTRACKER = this.RISFilmtracker;
			result=_proc.GetData();
		}
	}
}

