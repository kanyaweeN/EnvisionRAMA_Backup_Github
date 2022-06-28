using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISContrastLot : IBusinessLogic
    {
        public RIS_CONTRASTLOT RIS_CONTRASTLOT { get; set; }
        public ProcessAddRISContrastLot()
        {
            RIS_CONTRASTLOT = new RIS_CONTRASTLOT();
        }
        public void Invoke()
        {
            RISContrastLotInsertData _proc = new RISContrastLotInsertData();
            _proc.RIS_CONTRASTLOT = this.RIS_CONTRASTLOT;
            _proc.Add();
        }
        public void AddLotMapping(int contrastId, int lotId, int createBy)
        {
            RISContrastLotInsertData _proc = new RISContrastLotInsertData();
            _proc.AddLotMapping(contrastId, lotId, createBy);
        }
        public void deleteLotMapping(int lotmappintId)
        {
            RISContrastLotInsertData _proc = new RISContrastLotInsertData();
            _proc.deleteLotMapping(lotmappintId);
        }
    }
}
