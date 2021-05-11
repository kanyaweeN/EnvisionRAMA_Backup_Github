using System;
using EnvisionInterfaceEngine.Common.HL7.Segment;

namespace EnvisionInterfaceEngine.Common.HL7
{
    public class HL7ORM : IHL7ORM, IHL7ADT, IDisposable
    {
        private bool disposed = false;

        public HL7ORM()
            : base()
        {
            MSH = new MSH();

            ORG = new GBL_ENV();

            PATIENT = new HIS_REGISTRATION();
            INSURANCETYPE = new RIS_INSURANCETYPE();

            ORDER = new RIS_ORDER();
            PATIENT_STATUS = new RIS_PATSTATUS();
            REFERENCE_UNIT = new HR_UNIT();
            REFERRING_DOCTOR = new HR_EMP();

            ORDER_DETAIL = new RIS_ORDERDTL();
            EXAM = new RIS_EXAM();
            MODALITY = new RIS_MODALITY();
            MODALITYAETITLE = new RIS_MODALITYAETITLE();
            MODALITYTYPE = new RIS_MODALITYTYPE();
            IMAGE_CAPTURED_BY = new HR_EMP();
            ASSIGNED_TO = new HR_EMP();
            OPERATOR = new HR_EMP();
        }
        ~HL7ORM()
        {
            if (!disposed)
                Dispose();
        }

        public void Dispose()
        {
            ORDER_CONTROL = string.Empty;
            ORDER_STATUS = string.Empty;
            RESULT_STATUS = string.Empty;

            MSH = null;

            ORG = null;

            PATIENT = null;
            INSURANCETYPE = null;

            ORDER = null;
            PATIENT_STATUS = null;
            REFERENCE_UNIT = null;
            REFERRING_DOCTOR = null;

            ORDER_DETAIL = null;
            EXAM = null;
            MODALITY = null;
            MODALITYTYPE = null;
            IMAGE_CAPTURED_BY = null;
            ASSIGNED_TO = null;
            OPERATOR = null;

            disposed = true;
        }

        public string ORDER_CONTROL { get; set; }
        public string ORDER_STATUS { get; set; }
        public string RESULT_STATUS { get; set; }

        public MSH MSH { get; set; }

        public GBL_ENV ORG { get; set; }

        public HIS_REGISTRATION PATIENT { get; set; }
        public RIS_INSURANCETYPE INSURANCETYPE { get; set; }

        public RIS_ORDER ORDER { get; set; }
        public RIS_PATSTATUS PATIENT_STATUS { get; set; }
        public HR_UNIT REFERENCE_UNIT { get; set; }
        public HR_EMP REFERRING_DOCTOR { get; set; }

        public RIS_ORDERDTL ORDER_DETAIL { get; set; }
        public RIS_EXAM EXAM { get; set; }
        public RIS_MODALITY MODALITY { get; set; }
        public RIS_MODALITYAETITLE MODALITYAETITLE { get; set; }
        public RIS_MODALITYTYPE MODALITYTYPE { get; set; }
        public HR_EMP IMAGE_CAPTURED_BY { get; set; }
        public HR_EMP ASSIGNED_TO { get; set; }
        public HR_EMP OPERATOR { get; set; }
    }
    public interface IHL7ORM
    {
        string ORDER_CONTROL { get; set; }
        string ORDER_STATUS { get; set; }
        string RESULT_STATUS { get; set; }

        MSH MSH { get; set; }

        GBL_ENV ORG { get; set; }

        HIS_REGISTRATION PATIENT { get; set; }
        RIS_INSURANCETYPE INSURANCETYPE { get; set; }

        RIS_ORDER ORDER { get; set; }
        RIS_PATSTATUS PATIENT_STATUS { get; set; }
        HR_UNIT REFERENCE_UNIT { get; set; }
        HR_EMP REFERRING_DOCTOR { get; set; }

        RIS_ORDERDTL ORDER_DETAIL { get; set; }
        RIS_EXAM EXAM { get; set; }
        RIS_MODALITY MODALITY { get; set; }
        RIS_MODALITYAETITLE MODALITYAETITLE { get; set; }
        RIS_MODALITYTYPE MODALITYTYPE { get; set; }
        HR_EMP IMAGE_CAPTURED_BY { get; set; }
        HR_EMP ASSIGNED_TO { get; set; }
        HR_EMP OPERATOR { get; set; }
    }
}