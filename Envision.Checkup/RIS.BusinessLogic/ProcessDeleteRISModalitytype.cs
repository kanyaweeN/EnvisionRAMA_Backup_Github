using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISModalitytype : IBusinessLogic
    {
        #region IBusinessLogic Members

        private List<string> _rismodalitytype = new List<string>();

        #endregion

		public ProcessDeleteRISModalitytype(){}

		public void Invoke()
		{
            foreach (string item in _rismodalitytype)
            {
                RISModalitytypeDeleteData _proc = new RISModalitytypeDeleteData();
                _proc.ModalityTypeID = item;
                _proc.Delete();
            }
		}
        public List<string> DeleteItem
        {
            get { return _rismodalitytype; }
            set { _rismodalitytype = value; }
        }
	}
}

