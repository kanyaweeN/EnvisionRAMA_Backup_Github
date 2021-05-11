using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;
using Envision.DataAccess.Insert;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic
{
    public class ProcessRisPrAlgorithm
    {
        public RIS_PRALGORITHM RIS_PRALGORITHM { get; set; }

        public ProcessRisPrAlgorithm()
        {
            RIS_PRALGORITHM = new RIS_PRALGORITHM();
        }

        public DataSet getAlgorithm(int orgId)
        {
            RisPrAlgorithmSelect algorithmSelect = new RisPrAlgorithmSelect();
            algorithmSelect.RIS_PRALGORITHM.ORG_ID = orgId;
            return algorithmSelect.getAlgorithmData();
        }

        public DataTable getAlgorithmData(int id, int orgId)
        {
            DataTable dtGroup = new DataTable();
            RisPrAlgorithmSelect msgSelect = new RisPrAlgorithmSelect();
            msgSelect.RIS_PRALGORITHM.ALGORITHM_ID = id;
            msgSelect.RIS_PRALGORITHM.ORG_ID = orgId;
            dtGroup = msgSelect.getAlgorithmDataByID().Tables[0];
            return dtGroup;
        }

        public void insert(string text, string logic, int orgId, int createdBy)
        {
            RisPrAlgorithmInsert algorithmInsert = new RisPrAlgorithmInsert();
            algorithmInsert.RIS_PRALGORITHM.ALGORITHM_TEXT = text;
            algorithmInsert.RIS_PRALGORITHM.LOGIC          = logic;
            algorithmInsert.RIS_PRALGORITHM.ORG_ID         = orgId;
            algorithmInsert.RIS_PRALGORITHM.CREATED_BY     = createdBy;
            algorithmInsert.Add();
        }

        public void update()
        {
           
        }

        public void delete(int id)
        {
            RisPrAlgorithmDelete algorithmDelete = new RisPrAlgorithmDelete();
            algorithmDelete.RIS_PRALGORITHM.ALGORITHM_ID = id;
            algorithmDelete.Delete();
        }
        
    }
}
