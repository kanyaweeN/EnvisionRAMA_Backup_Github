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
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISFilmtracker : IBusinessLogic
	{
        private RIS_FILMTRACKER _risfilmtracker;
		private bool useTran;
		public ProcessUpdateRISFilmtracker()
		{
            _risfilmtracker = new RIS_FILMTRACKER();
			useTran=false;
		}
        public RIS_FILMTRACKER RISFilmtracker
        {
			get{return _risfilmtracker;}
			set{_risfilmtracker=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISFilmtrackerUpdateData _proc=new RISFilmtrackerUpdateData();
			_proc.RISFilmtracker=this.RISFilmtracker;
			_proc.Update();
		}
	}
}

