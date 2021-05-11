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
       public class ProcessAddOrderImages : IBusinessLogic
    {
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }

        public ProcessAddOrderImages()
        {
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
        }

        public void Invoke()
        {
            OrderImagesInsertData imagedata = new OrderImagesInsertData();
            imagedata.RIS_ORDERIMAGE = this.RIS_ORDERIMAGE;
            imagedata.Add();

        }
    }
}
