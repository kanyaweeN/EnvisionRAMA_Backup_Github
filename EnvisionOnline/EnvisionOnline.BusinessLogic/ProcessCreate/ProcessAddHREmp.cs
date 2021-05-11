using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddHREmp: IBusinessLogic
    {
        public HR_EMP HR_EMP { get; set; }
        private string strQuery;
        public ProcessAddHREmp()
        {
            HR_EMP = new HR_EMP();
        }
        public ProcessAddHREmp(string query)
        {
            HR_EMP = new HR_EMP();
            strQuery = query;
        }
        public void AddFromHis()
        {
            HREmpInsertData _proc = new HREmpInsertData();
            _proc.HR_EMP = this.HR_EMP;
            _proc.HR_EMP.EMP_ID = _proc.AddFromHIS();
        }
        public void Invoke()
        {
            HREmpInsertData insert = new HREmpInsertData();
            insert.HR_EMP = this.HR_EMP;
            insert.GetData(strQuery);
        }
    }
}
