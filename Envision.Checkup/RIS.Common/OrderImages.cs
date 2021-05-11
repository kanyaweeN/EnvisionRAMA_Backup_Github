using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class OrderImages
    {
        private string _hn;
        private int _orderid;
        private string _imgname;
        private int _slno;
        private int _orgid;
        private int _createdby;
        private int _lastmodifiedby;
        private int _scheduleid;



        public OrderImages()
        {
        }

        public string PatientID
        {
            get { return _hn; }
            set { _hn = value; }
        }

        public int OrderId
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        public string ImageName
        {
            get { return _imgname; }
            set { _imgname = value; }
        }


        public int SlNo
        {
            get { return _slno; }
            set { _slno = value; }
        }
        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public int CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }


        public int ModifiedBy
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
        }
        public int ScheduleID
        {
            get { return _scheduleid; }
            set { _scheduleid = value; }
        }
    }


 }

   