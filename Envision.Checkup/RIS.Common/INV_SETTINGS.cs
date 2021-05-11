using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_SETTINGS
    {
        private int _SETTINGS_ID;
        private string _SETTINGS_UID;
        private string _INV_METHOD;
        private string _FREE_PROD_PRICING;
        private string _DISCOUNT_EFFECT;
        private int _PO_AUTH_LEVEL;
        private string _GENERATE_AUTO_PR;
        private int _AUTO_PR_FREQ_DAYS;
        private double _GLOBAL_SELLING_MARKUP;
        private string _ALLOW_NEW_IF_PENDING;
        private string _OVERRIDE_IF_EMERGENCY;
        private string _SELL_REUSED_WO_RENTRY;
        private string _REORDER_CALC_METHOD;
        private string _CENTRAL_STOCK_UNIT;
        private string _DEPT_STOCK_UNIT;
        private int _ORG_ID;
        private int _CREATED_BY;

        public INV_SETTINGS()
        { 
        }

        public int SETTINGS_ID
        {
            get { return _SETTINGS_ID; }
            set { _SETTINGS_ID = value; }
        }
        public string SETTINGS_UID
        {
            get { return _SETTINGS_UID; }
            set { _SETTINGS_UID = value; }
        }
        public string INV_METHOD
        {
            get { return _INV_METHOD; }
            set { _INV_METHOD = value; }
        }
        public string FREE_PROD_PRICING
        {
            get { return _FREE_PROD_PRICING; }
            set { _FREE_PROD_PRICING = value; }
        }
        public string DISCOUNT_EFFECT
        {
            get { return _DISCOUNT_EFFECT; }
            set { _DISCOUNT_EFFECT = value; }
        }
        public int PO_AUTH_LEVEL
        {
            get { return _PO_AUTH_LEVEL; }
            set { _PO_AUTH_LEVEL = value; }
        }
        public string GENERATE_AUTO_PR
        {
            get { return _GENERATE_AUTO_PR; }
            set { _GENERATE_AUTO_PR = value; }
        }
        public int AUTO_PR_FREQ_DAYS
        {
            get { return _AUTO_PR_FREQ_DAYS; }
            set { _AUTO_PR_FREQ_DAYS = value; }
        }
        public double GLOBAL_SELLING_MARKUP
        {
            get { return _GLOBAL_SELLING_MARKUP; }
            set { _GLOBAL_SELLING_MARKUP = value; }
        }
        public string ALLOW_NEW_IF_PENDING
        {
            get { return _ALLOW_NEW_IF_PENDING; }
            set { _ALLOW_NEW_IF_PENDING = value; }
        }
        public string OVERRIDE_IF_EMERGENCY
        {
            get { return _OVERRIDE_IF_EMERGENCY; }
            set { _OVERRIDE_IF_EMERGENCY = value; }
        }
        public string SELL_REUSED_WO_RENTRY
        {
            get { return _SELL_REUSED_WO_RENTRY; }
            set { _SELL_REUSED_WO_RENTRY = value; }
        }
        public string REORDER_CALC_METHOD
        {
            get { return _REORDER_CALC_METHOD; }
            set { _REORDER_CALC_METHOD = value; }
        }
        public string CENTRAL_STOCK_UNIT
        {
            get { return _CENTRAL_STOCK_UNIT; }
            set { _CENTRAL_STOCK_UNIT = value; }
        }
        public string DEPT_STOCK_UNIT
        {
            get { return _DEPT_STOCK_UNIT; }
            set { _DEPT_STOCK_UNIT = value; }
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

    }
}
