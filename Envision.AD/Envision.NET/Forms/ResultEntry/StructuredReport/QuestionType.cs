using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.NET.Forms.ResultEntry.StructuredReport
{
    
    public enum QuestionType {
        QNone,
        QLable,
        QText,
        QCheck,
        QRadio,
        QDate,
        QMemo,
        QNumber,
        QGroup,
        QNColumn,
        QNewLine,
    }

    public static class QuestionTypeHelper {
        private static GBLEnvVariable env = new GBLEnvVariable();

        public static QuestionType GetQuestionType(int ID)
        {
            DataTable dtt = new DataTable();
        
            ProcessGetSRQuestionType proc = new ProcessGetSRQuestionType();
            proc.SR_QUESTIONTYPE.ORG_ID = env.OrgID;
            dtt = proc.GetData();
            QuestionType q = QuestionType.QNone;
            DataRow[] rows = dtt.Select("Q_TYPE_ID=" + ID.ToString());
            switch (rows[0]["Q_TYPE_NAME"].ToString())
            {
                case "QLable":
                    q = QuestionType.QLable;
                    break;
                case "QText":
                    q = QuestionType.QText;
                    break;
                case "QCheck":
                    q = QuestionType.QCheck;
                    break;
                case "QRadio":
                    q = QuestionType.QRadio;
                    break;
                case "QDate":
                    q = QuestionType.QDate;
                    break;
                case "QMemo":
                    q = QuestionType.QMemo;
                    break;
                case "QNumber":
                    q = QuestionType.QNumber;
                    break;
                case "QGroup":
                    q = QuestionType.QGroup;
                    break;
                case "QNColumn":
                    q = QuestionType.QNColumn;
                    break;
                case "QNewLine":
                    q = QuestionType.QNewLine;
                    break;
            }
            return q;
        }
    }
}
