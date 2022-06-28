using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;

using Envision.Common;
using Envision.Common.Linq;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
namespace Envision.BusinessLogic
{
    public class FINANCIAL
    {
        private FIN_RECEIVE fin_receivel;
        private FIN_CANCEL fin_cancel;

        public FINANCIAL()
        {
            fin_receivel = new FIN_RECEIVE();
            fin_cancel = new FIN_CANCEL();
        }

        public FIN_RECEIVE FIN_RECEIVE
        {
            get { return fin_receivel; }
            set { fin_receivel = value; }
        }
        public FIN_CANCEL FIN_CANCEL
        {
            get { return fin_cancel; }
            set { fin_cancel = value; }
        }
    }

    public class FIN_RECEIVE
    {
        private SelectData select;
        private UpdateData update;

        public FIN_RECEIVE()
        {
            select = new SelectData();
            update = new UpdateData();
        }
        public class SelectData
        {
            public SelectData()
            {

            }

            public DataTable Master(DateTime from_date, DateTime to_date)
            {
                ProcessGetFINPayment select = new ProcessGetFINPayment();
                select.FIN_PAYMENT.PAY_ID = 0;
                select.FIN_PAYMENT.FROM_DATE = new DateTime(from_date.Year, from_date.Month, from_date.Day, 0, 0, 0);
                select.FIN_PAYMENT.TO_DATE = new DateTime(to_date.Year, to_date.Month, to_date.Day, 23, 59, 59);

                try
                {
                    select.Invoke();
                    return select.Result.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return new DataTable();
            }

            public DataTable Master(int pay_id)
            {
                ProcessGetFINPayment select = new ProcessGetFINPayment();
                select.FIN_PAYMENT.PAY_ID = pay_id;
                select.FIN_PAYMENT.ORDER_ID = 0;

                try
                {
                    select.Invoke();
                    return select.Result.Tables[0];
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    return null;
                }

                return new DataTable();
            }

            public DataTable Master(int pay_id, int order_id)
            {
                ProcessGetFINPayment select = new ProcessGetFINPayment();
                select.FIN_PAYMENT.PAY_ID = pay_id;
                select.FIN_PAYMENT.ORDER_ID = order_id;

                try
                {
                    select.Invoke();
                    return select.Result.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return new DataTable();
            }

            public DataTable Detail(long pay_id, int exam_id, DateTime from_date, DateTime to_date)
            {
                ProcessGetFINPaymentdtl select = new ProcessGetFINPaymentdtl();
                select.FIN_PAYMENTDTL.PAY_ID = pay_id;
                select.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                select.FIN_PAYMENTDTL.FROM_DATE = new DateTime(from_date.Year, from_date.Month, from_date.Day, 0, 0, 0);
                select.FIN_PAYMENTDTL.TO_DATE = new DateTime(to_date.Year, to_date.Month, to_date.Day, 23, 59, 59);

                try
                {
                    select.Invoke();
                    return select.Result.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return new DataTable();
            }

            public DataTable Detail(string hn, int exam_id, DateTime from_date, DateTime to_date)
            {
                ProcessGetFINPaymentdtl select = new ProcessGetFINPaymentdtl();
                select.FIN_PAYMENTDTL.HN = hn;
                select.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                select.FIN_PAYMENTDTL.FROM_DATE = new DateTime(from_date.Year, from_date.Month, from_date.Day, 0, 0, 0);
                select.FIN_PAYMENTDTL.TO_DATE = new DateTime(to_date.Year, to_date.Month, to_date.Day, 23, 59, 59);

                try
                {
                    select.Invoke();
                    return select.Result.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return new DataTable();
            }
        }
        public class UpdateData
        {
            public UpdateData()
            {

            }

            public void Master()
            {

            }

            public void Detail(long pay_id, int exam_id, string status)
            {
                ProcessUpdateFINPaymentdtl update = new ProcessUpdateFINPaymentdtl();
                update.FIN_PAYMENTDTL.PAY_ID = pay_id;
                update.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                update.FIN_PAYMENTDTL.STATUS = Convert.ToChar(status);

                try
                {
                    update.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public void Detail(long pay_id, int exam_id, string status, int order_id)
            {
                ProcessUpdateFINPaymentdtl update = new ProcessUpdateFINPaymentdtl();
                update.FIN_PAYMENTDTL.PAY_ID = pay_id;
                update.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                update.FIN_PAYMENTDTL.STATUS = Convert.ToChar(status);
                update.FIN_PAYMENTDTL.ORDER_ID = order_id;

                try
                {
                    update.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public void Detail(long pay_id, int exam_id, int item_id
                                , byte qty, decimal rate, decimal discount
                                , decimal payable, decimal paid, string status
                                , int org_id, int created_by, int order_id)
            {
                ProcessUpdateFINPaymentdtl update = new ProcessUpdateFINPaymentdtl();
                update.FIN_PAYMENTDTL.PAY_ID = pay_id;
                update.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                update.FIN_PAYMENTDTL.ITEM_ID = item_id;
                update.FIN_PAYMENTDTL.QTY = qty;
                update.FIN_PAYMENTDTL.RATE = rate;
                update.FIN_PAYMENTDTL.DISCOUNT = discount;
                update.FIN_PAYMENTDTL.PAYABLE = payable;
                update.FIN_PAYMENTDTL.PAID = paid;
                update.FIN_PAYMENTDTL.STATUS = Convert.ToChar(status);
                update.FIN_PAYMENTDTL.ORG_ID = org_id;
                update.FIN_PAYMENTDTL.CREATED_BY = created_by;
                update.FIN_PAYMENTDTL.ORDER_ID = order_id;

                try
                {
                    update.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public SelectData Select
        {
            get { return select; }
            set { select = value; }
        }
        public UpdateData Update
        {
            get { return update; }
            set { update = value; }
        }
    }

    public class FIN_CANCEL
    {
        private SelectData select;
        private UpdateData update;

        public FIN_CANCEL()
        {
            select = new SelectData();
            update = new UpdateData();
        }
        public class SelectData
        {
            public SelectData()
            {

            }

            public DataTable Master(DateTime from_date, DateTime to_date)
            {
                ProcessGetFINPayment select = new ProcessGetFINPayment();
                select.FIN_PAYMENT.PAY_ID = -1;
                select.FIN_PAYMENT.FROM_DATE = new DateTime(from_date.Year, from_date.Month, from_date.Day, 0, 0, 0);
                select.FIN_PAYMENT.TO_DATE = new DateTime(to_date.Year, to_date.Month, to_date.Day, 23, 59, 59);

                try
                {
                    select.Invoke();
                    return select.Result.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return new DataTable();
            }

            public DataTable Detail(string hn, int exam_id, DateTime from_date, DateTime to_date)
            {



                ProcessGetFINPaymentdtl select = new ProcessGetFINPaymentdtl();
                select.FIN_PAYMENTDTL.HN = hn;
                select.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                select.FIN_PAYMENTDTL.FROM_DATE = new DateTime(from_date.Year, from_date.Month, from_date.Day, 0, 0, 0);
                select.FIN_PAYMENTDTL.TO_DATE = new DateTime(to_date.Year, to_date.Month, to_date.Day, 23, 59, 59);

                try
                {
                    select.Invoke();
                    return select.Result.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return new DataTable();
            }
            public DataTable Detail(long pay_id, string hn, int exam_id, DateTime from_date, DateTime to_date)
            {
                ProcessGetFINPaymentdtl select = new ProcessGetFINPaymentdtl();
                select.FIN_PAYMENTDTL.PAY_ID = pay_id;
                select.FIN_PAYMENTDTL.HN = hn;
                select.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                select.FIN_PAYMENTDTL.FROM_DATE = new DateTime(from_date.Year, from_date.Month, from_date.Day, 0, 0, 0);
                select.FIN_PAYMENTDTL.TO_DATE = new DateTime(to_date.Year, to_date.Month, to_date.Day, 23, 59, 59);

                try
                {
                    select.Invoke();
                    return select.Result.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return new DataTable();
            }
        }
        public class UpdateData
        {
            public UpdateData()
            {

            }

            public void Master()
            {

            }

            public void Detail(long pay_id, int exam_id, string status)
            {
                ProcessUpdateFINPaymentdtl update = new ProcessUpdateFINPaymentdtl();
                update.FIN_PAYMENTDTL.PAY_ID = pay_id;
                update.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                update.FIN_PAYMENTDTL.STATUS = Convert.ToChar(status);

                try
                {
                    update.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public void Detail(long pay_id, int exam_id, string status, int order_id)
            {
                ProcessUpdateFINPaymentdtl update = new ProcessUpdateFINPaymentdtl();
                update.FIN_PAYMENTDTL.PAY_ID = pay_id;
                update.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                update.FIN_PAYMENTDTL.STATUS = Convert.ToChar(status);
                update.FIN_PAYMENTDTL.ORDER_ID = order_id;

                try
                {
                    update.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public void Detail(long pay_id, int exam_id, int item_id
                                , byte qty, decimal rate, decimal discount
                                , decimal payable, decimal paid, string status
                                , int org_id, int created_by, int order_id)
            {
                ProcessUpdateFINPaymentdtl update = new ProcessUpdateFINPaymentdtl();
                update.FIN_PAYMENTDTL.PAY_ID = pay_id;
                update.FIN_PAYMENTDTL.EXAM_ID = exam_id;
                update.FIN_PAYMENTDTL.ITEM_ID = item_id;
                update.FIN_PAYMENTDTL.QTY = qty;
                update.FIN_PAYMENTDTL.RATE = rate;
                update.FIN_PAYMENTDTL.DISCOUNT = discount;
                update.FIN_PAYMENTDTL.PAYABLE = payable;
                update.FIN_PAYMENTDTL.PAID = paid;
                update.FIN_PAYMENTDTL.STATUS = Convert.ToChar(status);
                update.FIN_PAYMENTDTL.ORG_ID = org_id;
                update.FIN_PAYMENTDTL.CREATED_BY = created_by;
                update.FIN_PAYMENTDTL.ORDER_ID = order_id;

                try
                {
                    update.Invoke();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public SelectData Select
        {
            get { return select; }
            set { select = value; }
        }
        public UpdateData Update
        {
            get { return update; }
            set { update = value; }
        }
    }


}
