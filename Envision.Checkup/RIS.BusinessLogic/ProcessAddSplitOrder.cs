/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddSplitOrder : IBusinessLogic
    {
        private SplitOrder _splitorder;

        public ProcessAddSplitOrder()
        {

        }

        public void Invoke()
        {
            SplitOrderInsertData splitdata = new SplitOrderInsertData();
            splitdata.SplitOrder = this.SplitOrder;
            splitdata.Add();

        }

        public SplitOrder SplitOrder
        {
            get { return _splitorder; }
            set { _splitorder = value; }
        }
    }
}
