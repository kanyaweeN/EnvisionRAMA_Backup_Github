using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISModalitytype : IBusinessLogic
	{
        private List<RISModalitytype> _rismodalitytype = new List<RISModalitytype>();

		public ProcessAddRISModalitytype(){}

        public void Invoke()
        {
            foreach (RISModalitytype item in _rismodalitytype)
            {
                RISModalitytypeInsertData _proc = new RISModalitytypeInsertData();
                _proc.RISModalitytype = item;
                _proc.Add();
            }
        }

        public List<RISModalitytype> ModalityTypeItem
        {
            get { return _rismodalitytype; }
            set { _rismodalitytype = value; }
        }
	}
}

