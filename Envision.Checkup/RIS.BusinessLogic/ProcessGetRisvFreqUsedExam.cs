using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;

namespace RIS.BusinessLogic
{
    public class ProcessGetRisvFreqUsedExam : IBusinessLogic
    {
        DataSet resultSet = new DataSet();

        public ProcessGetRisvFreqUsedExam()
        { 
        }

        public void Invoke()
        {
            RisvFreqUsedExam sel = new RisvFreqUsedExam();
            ResultSet = sel.Select();
        }

        public DataSet ResultSet
        {
            get { return resultSet; }
            set { resultSet = value; }
        }
    }
}
