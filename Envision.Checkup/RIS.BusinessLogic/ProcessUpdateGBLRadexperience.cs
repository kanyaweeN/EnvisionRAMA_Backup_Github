//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2009 05:03:16
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateGBLRadexperience : IBusinessLogic
	{
		private GBLRadexperience _gblradexperience;
		private bool useTran;
		public ProcessUpdateGBLRadexperience()
		{
			_gblradexperience = new GBLRadexperience();
			useTran=false;
		}
		public GBLRadexperience GBLRadexperience		{
			get{return _gblradexperience;}
			set{_gblradexperience=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			GBLRadexperienceUpdateData _proc=new GBLRadexperienceUpdateData();
			_proc.GBLRadexperience=this.GBLRadexperience;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
        public void UpdateGridWorklist(int RadID, string XMLGridWL)
        {
            GBLRadexperienceUpdateData _proc = new GBLRadexperienceUpdateData();
            _proc.UpdateGridWorklist(RadID, XMLGridWL);
        }
        public void UpdateGridHistory(int RadID, string XMLGridHistory)
        {
            GBLRadexperienceUpdateData _proc = new GBLRadexperienceUpdateData();
            _proc.UpdateGridHistory(RadID, XMLGridHistory);
        }
	}
}

