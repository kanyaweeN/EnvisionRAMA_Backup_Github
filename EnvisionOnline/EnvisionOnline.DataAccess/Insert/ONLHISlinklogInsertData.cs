using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class ONLHISlinklogInsertData : DataAccessBase
    {
        public ONL_HISLINKLOG ONL_HISLINKLOG { get; set; }
        public ONLHISlinklogInsertData()
        {
            ONL_HISLINKLOG = new ONL_HISLINKLOG();
        }
        public void Add()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_HISLINKLOG_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={		
	             Parameter("@HIS_URL",ONL_HISLINKLOG.HIS_URL)
                ,Parameter("@HN",ONL_HISLINKLOG.HN)
                ,Parameter("@USER_NAME",ONL_HISLINKLOG.USER_NAME)
                ,Parameter("@UNIT",ONL_HISLINKLOG.UNIT)
                ,Parameter("@CLINIC",ONL_HISLINKLOG.CLINIC)
                ,Parameter("@INSR",ONL_HISLINKLOG.INSR)
                ,Parameter("@ROLE",ONL_HISLINKLOG.ROLE)
                ,Parameter("@ENC",ONL_HISLINKLOG.ENC)
                ,Parameter("@FORM",ONL_HISLINKLOG.FORM)
                ,Parameter("@LOG_DESC",ONL_HISLINKLOG.LOG_DESC)
                ,Parameter("@BROWSER_TYPE",ONL_HISLINKLOG.BROWSER_TYPE)
                ,Parameter("@USER_HOST_ADDRESS",ONL_HISLINKLOG.USER_HOST_ADDRESS)
                ,Parameter("@ACCESSION_NO",ONL_HISLINKLOG.ACCESSION_NO)
                ,Parameter("@ZEUS_NO",Config.ZeusIP)
			};
            return parameters;
        }
    }
}
