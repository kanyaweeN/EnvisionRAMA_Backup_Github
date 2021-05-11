using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_ITEM
    {
        public INV_ITEM()
        { 
        }

        #region Field

        private int _ITEM_ID;
    	private string _ITEM_UID;
        private string _ITEM_NAME;
        private string _ITEM_DESC;
        private byte[] _ITEM_IMG;
        private int _CATEGORY_ID;
        private int _TYPE_ID;
        private int _TXN_UNIT;
        private byte _RE_ORDER_DAYS;
        private double _RE_ORDER_QTY;
        private string _IS_FOREIGN;
        private string _INCLUDE_IN_AUTO_PR;
        private int _GL_CODE;
        private string _IS_FA;
        private string _IS_REUSABLE;
        private double _REUSE_PRICE_PERC;
        private int _VENDOR_ID;
        private double _PURCHASE_PRICE;
        private double _SELLING_PRICE;
        private string _ALLOW_PARTIAL_DELIVERY;
        private string _ALLOW_PARTIAL_RECIEVE;
        private int _ORG_ID;

        #endregion Field

        #region Property

        public int ITEM_ID
        {
            get { return _ITEM_ID; }
            set { _ITEM_ID = value; }
        }

        public string ITEM_UID
        {
            get { return _ITEM_UID; }
            set { _ITEM_UID = value; }
        }
        public string ITEM_NAME
        {
            get { return _ITEM_NAME; }
            set { _ITEM_NAME = value; }
        }
        public string ITEM_DESC
        {
            get { return _ITEM_DESC; }
            set { _ITEM_DESC = value; }
        }
        public byte[] ITEM_IMG
        {
            get { return _ITEM_IMG; }
            set { _ITEM_IMG = value; }
        }
        public int CATEGORY_ID
        {
            get { return _CATEGORY_ID; }
            set { _CATEGORY_ID = value; }
        }
        public int TYPE_ID
        {
            get { return _TYPE_ID; }
            set { _TYPE_ID = value; }
        }
        public int TXN_UNIT
        {
            get { return _TXN_UNIT; }
            set { _TXN_UNIT = value; }
        }
        public byte RE_ORDER_DAYS
        {
            get { return _RE_ORDER_DAYS; }
            set { _RE_ORDER_DAYS = value; }
        }
        public double RE_ORDER_QTY
        {
            get { return _RE_ORDER_QTY; }
            set { _RE_ORDER_QTY = value; }
        }
        public string IS_FOREIGN
        {
            get { return _IS_FOREIGN; }
            set { _IS_FOREIGN = value; }
        }
        public string INCLUDE_IN_AUTO_PR
        {
            get { return _INCLUDE_IN_AUTO_PR; }
            set { _INCLUDE_IN_AUTO_PR = value; }
        }
        public int GL_CODE
        {
            get { return _GL_CODE; }
            set { _GL_CODE = value; }
        }
        public string IS_FA
        {
            get { return _IS_FA; }
            set { _IS_FA = value; }
        }
        public string IS_REUSABLE
        {
            get { return _IS_REUSABLE; }
            set { _IS_REUSABLE = value; }
        }
        public double REUSE_PRICE_PERC
        {
            get { return _REUSE_PRICE_PERC; }
            set { _REUSE_PRICE_PERC = value; }
        }
        public int VENDOR_ID
        {
            get { return _VENDOR_ID; }
            set { _VENDOR_ID = value; }
        }
        public double PURCHASE_PRICE
        {
            get { return _PURCHASE_PRICE; }
            set { _PURCHASE_PRICE = value; }
        }
        public double SELLING_PRICE
        {
            get { return _SELLING_PRICE; }
            set { _SELLING_PRICE = value; }
        }
        public string ALLOW_PARTIAL_DELIVERY
        {
            get { return _ALLOW_PARTIAL_DELIVERY; }
            set { _ALLOW_PARTIAL_DELIVERY = value; } 
        }
        public string ALLOW_PARTIAL_RECIEVE
        {
            get { return _ALLOW_PARTIAL_RECIEVE; }
            set { _ALLOW_PARTIAL_RECIEVE = value; }
        }
        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }

        #endregion Property

    }
}
