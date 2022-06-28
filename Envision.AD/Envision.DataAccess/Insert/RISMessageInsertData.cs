using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISMessageInsertData: DataAccessBase
    {
        public RIS_MESSAGE RIS_MESSAGE { get; set; }
        public RISMessageInsertData()
        {
            RIS_MESSAGE = new RIS_MESSAGE();
            StoredProcedureName = StoredProcedure.Prc_RIS_MESSAGE_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@SENDER_ID"	, RIS_MESSAGE.SENDER_ID ) ,
                Parameter( "@MSG_TEXT"	, RIS_MESSAGE.MSG_TEXT ) ,
                Parameter( "@MSG_STATUS"	, RIS_MESSAGE.MSG_STATUS ) ,
                Parameter( "@ACCESSION_NO"	, RIS_MESSAGE.ACCESSION_NO ) ,
            };
            return parameters;
        }
    }
}
