using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;

using Envision.Common;
using Envision.Common.Linq;
using Envision.BusinessLogic.ProcessRead;
namespace Envision.BusinessLogic
{
    public static class Exam
    {
        private static DataTable getExam() {
            DataTable dtExam = new DataTable();
            ProcessGetRISExam processExam = new ProcessGetRISExam();
            processExam.Invoke();
            dtExam = processExam.Result.Tables[0].Copy();
            dtExam.TableName = "RIS_EXAM";
            return dtExam.Copy();
        }

        public static DataTable EliminateConsumable(DataTable data)
        {
            DataTable dtEliminateConsumable = new DataTable();
            dtEliminateConsumable = data.Clone();
            DataTable dttExam = getExam();
            foreach (DataRow dr in data.Rows) {
                DataRow[] rows = dttExam.Select("EXAM_UID='" + dr["EXAM_UID"].ToString() + "'");
                if (rows.Length > 0) {
                    if (rows[0]["SERVICE_TYPE"].ToString() == "1") {
                        dtEliminateConsumable.NewRow();
                        dtEliminateConsumable.Rows.Add(dr.ItemArray);
                        dtEliminateConsumable.AcceptChanges();
                    }
                }
            }
            return dtEliminateConsumable;
        }

        
    }
}
