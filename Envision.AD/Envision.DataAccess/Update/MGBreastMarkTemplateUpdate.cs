using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.Common.Linq;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Update
{
    public class MGBreastMarkTemplateUpdate : DataAccessBase
    {
        public MG_BREASTMARKTEMPLATE MG_BREASTMARKTEMPLATE { get; set; }

        public MGBreastMarkTemplateUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARKTEMPLATE_Update;
        }

        public void UpdateData(int mode)
        {
            this.ParameterList = this.BuildParameters(mode);
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters(int mode)
        {
            DbParameter[] parameters = {
                                           Parameter("@TPL_ID", MG_BREASTMARKTEMPLATE.TPL_ID),
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
                                           Parameter("@LAST_MODIFIED_BY", MG_BREASTMARKTEMPLATE.LAST_MODIFIED_BY),
                                           Parameter("@MODE", mode)
                                       };
            return parameters;
        }
    }
}
