using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class XrayAndScheduleArrivalWorkListSelect : DataAccessBase
    {
        public XrayAndScheduleArrivalWorkListSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_XRAY_Schedule_GetArrivalWorkList_4;
            //this.StoredProcedureName = StoredProcedure.Prc_XRAY_Schedule_GetArrivalWorkList_TEST;
        }

        public DataSet GetArrivalWorkList(string HN, DateTime From, DateTime To, string Filter, int OrgId, int Mode, bool isShowAll, int ShowMode, string examTypeFilter)
        {
            DbParameter paramIsShowAll = this.Parameter();
            paramIsShowAll.Direction = ParameterDirection.Input;
            paramIsShowAll.ParameterName = "IS_SHOWALL";
            if (isShowAll)
                paramIsShowAll.Value = "Y";
            else
                paramIsShowAll.Value = "N";

            this.ParameterList = new DbParameter[] { 
                Parameter("@HN", HN),
                Parameter("@FROM", From),
                Parameter("@TO", To),
                Parameter("@FILTER", Filter),
                Parameter("@ORG_ID", OrgId),
                Parameter("@MODE", Mode),
                Parameter("@SHOW_MODE", ShowMode),
                paramIsShowAll,
                Parameter("@EXAM_TYPE_FILTER", examTypeFilter)
            };
            return this.ExecuteDataSet();
        }
    }
}
