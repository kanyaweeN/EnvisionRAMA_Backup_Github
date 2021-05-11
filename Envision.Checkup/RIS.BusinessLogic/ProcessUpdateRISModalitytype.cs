using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISModalitytype : IBusinessLogic
    {
        #region Class members
        private List<RISModalitytype> _rismodalitytype = new List<RISModalitytype>();
        #endregion

        public ProcessUpdateRISModalitytype(){}

		public void Invoke()
		{
            foreach (RISModalitytype item in _rismodalitytype)
            {
                RISModalitytypeUpdateData _proc = new RISModalitytypeUpdateData();
                _proc.RISModalitytype = item;
                _proc.Update();
            }
		}

        public List<RISModalitytype> ModalityTypeItem
        {
            get { return _rismodalitytype; }
            set { _rismodalitytype = value; }
        }
	}
}

