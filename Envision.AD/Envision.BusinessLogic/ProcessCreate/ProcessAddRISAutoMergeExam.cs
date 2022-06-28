using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISAutoMergeExam : IBusinessLogic
    {
        public RIS_AUTOMERGECONFIG RIS_AUTOMERGECONFIG { get; set; }
        public ProcessAddRISAutoMergeExam()
        {
            RIS_AUTOMERGECONFIG = new RIS_AUTOMERGECONFIG();
        }
        public void Invoke()
        {
            RIS_AutoMergeExam_Insert _proc = new RIS_AutoMergeExam_Insert();
            _proc.RIS_AUTOMERGECONFIG = RIS_AUTOMERGECONFIG;
            _proc.Insert();
        }
    }
}
