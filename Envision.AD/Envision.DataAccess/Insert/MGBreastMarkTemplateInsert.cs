using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.Common.Linq;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class MGBreastMarkTemplateInsert : DataAccessBase
    {
        public MG_BREASTMARKTEMPLATE MG_BREASTMARKTEMPLATE { get; set; }

        public MGBreastMarkTemplateInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARKTEMPLATE_Insert;
        }

        public void InsertData()
        {
            this.ParameterList = this.BuildParameters();
            DataTable dt = this.ExecuteDataTable();
            if (dt != null)
            {
                if(dt.Rows.Count > 0)
                    this.MG_BREASTMARKTEMPLATE.TPL_ID = Convert.ToInt32(dt.Rows[0]["TPL_ID"]);
            }
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                           Parameter("@TPL_NAME", MG_BREASTMARKTEMPLATE.TPL_NAME),
                                           Parameter("@EMP_ID", MG_BREASTMARKTEMPLATE.EMP_ID),
                                           Parameter("@SHAPE", MG_BREASTMARKTEMPLATE.SHAPE),
                                           Parameter("@STYLE", MG_BREASTMARKTEMPLATE.STYLE),
                                           Parameter("@FILL_COLOR", MG_BREASTMARKTEMPLATE.FILL_COLOR),
                                           Parameter("@STROKE_COLOR", MG_BREASTMARKTEMPLATE.STROKE_COLOR),
                                           Parameter("@BORDER_COLOR", MG_BREASTMARKTEMPLATE.BORDER_COLOR),
                                           Parameter("@FONT_COLOR", MG_BREASTMARKTEMPLATE.FONT_COLOR),
                                           Parameter("@FONT_FAMILY", MG_BREASTMARKTEMPLATE.FONT_FAMILY),
                                           Parameter("@FONT_SIZE", MG_BREASTMARKTEMPLATE.FONT_SIZE),
                                           Parameter("@DIMENSION", MG_BREASTMARKTEMPLATE.DIMENSION),
                                           Parameter("@THICKNESS", MG_BREASTMARKTEMPLATE.THICKNESS),
                                           Parameter("@UNIT", MG_BREASTMARKTEMPLATE.UNIT),
                                           Parameter("@SHOW_BORDER", MG_BREASTMARKTEMPLATE.SHOW_BORDER),
                                           Parameter("@CAN_RESIZE", MG_BREASTMARKTEMPLATE.CAN_RESIZE),
                                           Parameter("@IS_DEFAULT", MG_BREASTMARKTEMPLATE.IS_DEFAULT),
                                           Parameter("@ORG_ID", MG_BREASTMARKTEMPLATE.ORG_ID),
                                           Parameter("@CREATED_BY", MG_BREASTMARKTEMPLATE.CREATED_BY)
                                       };
            return parameters;
        }
    }
}
