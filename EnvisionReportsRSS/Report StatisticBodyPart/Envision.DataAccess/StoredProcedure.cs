using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.DataAccess
{
    public enum StoredProcedure
    {
        Prc_RIS_EXAM_Insert,
        Prc_RIS_EXAM_Update,
        Prc_RIS_EXAM_UpdateByCode,
        Prc_RIS_EXAM_Delete,
        Prc_RIS_EXAM_Select,

        Prc_Modality_Count,
        Prc_RIS_MODALITY_Select,

        Prc_HR_UNIT_Select,
        Prc_ONL_CLINICSESSION_Select,
    }
}
