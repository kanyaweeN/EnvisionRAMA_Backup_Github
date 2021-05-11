using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public class OrderItems
{
    private string accession_no;
    private string flag;
    private int order_id;
    private string exam_uid;
    private string exam_name;
    private string priority;

	public OrderItems()
	{
	}

    public string ACCESSION_NO {
        get { return accession_no; }
        set { accession_no = value; }
    }
    public string Flag {
        get { return flag; }
        set { flag = value; }
    }
    public int Order_ID {
        get { return order_id; }
        set { order_id = value; }
    }
    public string ExamCode {
        get { return exam_uid; }
        set { exam_uid = value; }
    }
    public string ExamName {
        get { return exam_name; }
        set { exam_name = value; }
    }
    public string Priority {
        get { return priority; }
        set { priority = value; }
    }
}
