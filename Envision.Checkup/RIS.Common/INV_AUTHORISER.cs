using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_AUTHORISER
    {
        public INV_AUTHORISER()
        { 
        }

        private int _AUTHORISER_ID;
        private int _EMP_ID;
        private int _SERIAL;
        private string _AUTH_TYPE;
        private int _ORG_ID;
        private int _CREATED_BY;
        private int _LAST_MODIFIED_BY;

        public  int AUTHORISER_ID
        {
            get { return _AUTHORISER_ID; }
            set { _AUTHORISER_ID = value; }
        }
        public int EMP_ID
        {
            get { return _EMP_ID; }
            set { _EMP_ID = value; }
        }
        public int SERIAL
        {
            get { return _SERIAL; }
            set { _SERIAL = value; }
        }
        public string AUTH_TYPE
        {
            get { return _AUTH_TYPE; }
            set { _AUTH_TYPE = value; }
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
        public int LAST_MODIFIED_BY
        {
            get { return _LAST_MODIFIED_BY; }
            set { _LAST_MODIFIED_BY = value; }
        }
    }
}
