using System;
using EnvisionInterfaceEngine.Common.HL7.Segment;

namespace EnvisionInterfaceEngine.Common.HL7
{
    public class HL7ADT : IHL7ADT, IDisposable
    {
        private bool disposed = false;

        public HL7ADT()
            : base()
        {
            MSH = new MSH();

            ORG = new GBL_ENV();

            PATIENT = new HIS_REGISTRATION();
            OLD_PATIENT = new HIS_REGISTRATION();
        }
        ~HL7ADT()
        {
            if (!disposed)
                Dispose();
        }

        public void Dispose()
        {
            MSH = null;

            ORG = null;

            PATIENT = null;
            OLD_PATIENT = null;

            disposed = true;
        }

        public MSH MSH { get; set; }

        public GBL_ENV ORG { get; set; }

        public HIS_REGISTRATION PATIENT { get; set; }
        public HIS_REGISTRATION OLD_PATIENT { get; set; }
    }
    public interface IHL7ADT
    {
        MSH MSH { get; set; }

        GBL_ENV ORG { get; set; }
        HIS_REGISTRATION PATIENT { get; set; }
    }
}