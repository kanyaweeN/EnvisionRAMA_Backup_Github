using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ResultItems
{
    private string accession_no;
    private int order_id;
    private string exam_uid;
    private string exam_name;
    private string status;
    private string rtf_text;
    private string hl7text;

    public string ACCESSION_NO
    {
        get { return accession_no; }
        set { accession_no = value; }
    }
    public int Order_ID
    {
        get { return order_id; }
        set { order_id = value; }
    }
    public string ExamCode
    {
        get { return exam_uid; }
        set { exam_uid = value; }
    }
    public string ExamName
    {
        get { return exam_name; }
        set { exam_name = value; }
    }
    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    public string ResultText
    {
        get { return rtf_text; }
        set { rtf_text = value; }
    }
    public string HL7Text
    {
        get { return hl7text; }
        set { hl7text = value; }
    }
}
