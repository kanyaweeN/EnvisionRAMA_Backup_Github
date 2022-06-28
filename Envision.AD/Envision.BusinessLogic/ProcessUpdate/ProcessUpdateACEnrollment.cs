using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateACEnrollment
    {
        public AC_ENROLLMENT AC_ENROLLMENT { get; set; }

        public ProcessUpdateACEnrollment()
        {
            AC_ENROLLMENT = new AC_ENROLLMENT();
        }

        public void Invoke()
        {
            ACEnrollmentUpdateData _update = new ACEnrollmentUpdateData();
            _update.AC_ENROLLMENT = this.AC_ENROLLMENT;
            _update.Update();
        }
        public void UpdateAck(int Id)
        {
            ACEnrollmentUpdateData _update = new ACEnrollmentUpdateData();
            _update.AC_ENROLLMENT = this.AC_ENROLLMENT;
            _update.UpdateAck(Id);
        }
    }
}
