using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISSessionMaxapp: IBusinessLogic
	{
		private DataSet result;
        private int _modality_id;
        public ProcessGetRISSessionMaxapp()
        {
        }

        public ProcessGetRISSessionMaxapp(int modality_id)
        {
            _modality_id = modality_id;
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISSessionMaxAppSelectData _proc = new RISSessionMaxAppSelectData(_modality_id);
			result=_proc.GetData();
		}
        public void InvokeGetSetupData()
        {
            RISSessionMaxAppSelectData _proc = new RISSessionMaxAppSelectData();
            result = _proc.GetSetupData();
        }
	}
}

