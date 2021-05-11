using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class RISNursesData
    {
        #region Member

        private int _selectcase;
        private string _accessionnoparameter;
        private int _NURSE_DATA_UK_ID;
        private int _NURSE_ID;
        private string _ACCESSION_NO;
        private DateTime _INPUT_DT;
        private int _ANESTHESIA_TECHNIQUE;
        private string _PAST_ILL_DM;
        private string _PAST_ILL_HT;
        private string _PAST_ILL_HD;
        private string _PAST_ILL_ASTHMA;
        private string _PAST_ILL_OTHERS;
        private string _PROCEDURE;
        private string _DIAGNOSIS;
        private string _OTHER_DESCRIPTION;
        private int _ASSISTANT_ID;
        private int _OPERATOR_ID;
        private int _ORG_ID;
        private int _CREATED_BY;
        private DateTime _CREATED_ON;
        private int _LAST_MODIFIED_BY;
        private DateTime _LAST_MODIFIED_ON;

        #endregion


        #region Property
        public int SELECTCASE
        {
            get { return _selectcase; }
            set { _selectcase = value; }
        }
        public string ACCESSIONPARAMETER
        {
            get { return _accessionnoparameter; }
            set { _accessionnoparameter = value; }
        }
        public int NURSE_DATA_UK_ID
        {
            get { return _NURSE_DATA_UK_ID; }
            set { _NURSE_DATA_UK_ID = value; }
        }
        public int NURSE_ID
        {
            get { return _NURSE_ID; }
            set { _NURSE_ID = value; }
        }
        public string ACCESSION_NO
        {
            get { return _ACCESSION_NO; }
            set { _ACCESSION_NO = value; }
        }
        public DateTime INPUT_DT
        {
            get { return _INPUT_DT; }
            set { _INPUT_DT = value; }
        }
        public int ANESTHESIA_TECHNIQUE
        {
            get { return _ANESTHESIA_TECHNIQUE; }
            set { _ANESTHESIA_TECHNIQUE = value; }
        }
        public string PAST_ILL_DM
        {
            get { return _PAST_ILL_DM; }
            set { _PAST_ILL_DM = value; }
        }
        public string PAST_ILL_HT
        {
            get { return _PAST_ILL_HT; }
            set { _PAST_ILL_HT = value; }
        }
        public string PAST_ILL_HD
        {
            get { return _PAST_ILL_HD; }
            set { _PAST_ILL_HD = value; }
        }
        public string PAST_ILL_ASTHMA
        {
            get { return _PAST_ILL_ASTHMA; }
            set { _PAST_ILL_ASTHMA = value; }
        }
        public string PAST_ILL_OTHERS
        {
            get { return _PAST_ILL_OTHERS; }
            set { _PAST_ILL_OTHERS = value; }
        }

        public string PROCEDURE
        {
            get { return _PROCEDURE; }
            set { _PROCEDURE = value; }
        }
        public string DIAGNOSIS
        {
            get { return _DIAGNOSIS; }
            set { _DIAGNOSIS = value; }
        }
        public string OTHER_DESCRIPTION
        {
            get { return _OTHER_DESCRIPTION; }
            set { _OTHER_DESCRIPTION = value; }
        }
        public int ASSISTANT_ID
        {
            get { return _ASSISTANT_ID; }
            set { _ASSISTANT_ID = value; }
        }

        public int OPERATOR_ID
        {
            get { return _OPERATOR_ID; }
            set { _OPERATOR_ID = value; }
        }
        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }



        public int CREATED_BY
        {
            get { return _CREATED_BY; }
            set { _CREATED_BY = value; }
        }
        public DateTime CREATED_ON
        {
            get { return _CREATED_ON; }
            set { _CREATED_ON = value; }
        }
        public int LAST_MODIFIED_BY
        {
            get { return _LAST_MODIFIED_BY; }
            set { _LAST_MODIFIED_BY = value; }
        }
        public DateTime LAST_MODIFIED_ON
        {
            get { return _LAST_MODIFIED_ON; }
            set { _LAST_MODIFIED_ON = value; }
        }
        #endregion


        #region Constructor
        public RISNursesData()
        {

        }
        #endregion


        #region Method
        public RISNursesData Copy()
        {
            return MemberwiseClone() as RISNursesData;
        }
        #endregion
    }
}
