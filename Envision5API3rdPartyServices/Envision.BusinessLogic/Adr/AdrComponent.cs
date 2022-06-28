using Envision.Database.DataAccess.Select;
using Envision.Entity.Adr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Envision.BusinessLogic.Adr
{
    public class AdrComponent
    {
        public List<AdrData> SearchAdrByMode(string mode, string mrn, string drugCode)
        {
            AdrSelectData data = new AdrSelectData();
            DataSet ds = data.SearchAdrByMode(mode, mrn, drugCode);
            List<AdrData> _adrs = new List<AdrData>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AdrLevel _adrLv = new AdrLevel
                {
                    vocab = row["vocab"].ToString(),
                    vocabDescription = row["vocabDescription"].ToString()
                };
                List<AdrComment> _adrComments = new List<AdrComment>();
                AdrComment _adrComment = new AdrComment
                {
                    commentType = row["commentType"].ToString(),
                    description = row["commentDescription"].ToString(),
                };
                _adrComments.Add(_adrComment);
                AdrData _adr = new AdrData
                {
                    adrId = row["adrId"].ToString(),
                    drugCode = row["drugCode"].ToString(),
                    drugName = row["drugName"].ToString(),
                    ingredientCode = row["ingredientCode"].ToString(),
                    ingredientName = row["ingredientName"].ToString(),
                    adrLevel = _adrLv,
                    severity = row["severity"].ToString(),
                    naranjo = row["naranjo"].ToString(),
                    sideEffect = row["sideEffect"].ToString(),
                    editDate = Convert.ToDateTime(row["editDate"]).ToString("yyyy-MM-dd HH:mm:ss"),
                    comments = _adrComments,
                };
                _adrs.Add(_adr);
            }
            return _adrs;
        }
    }
}
