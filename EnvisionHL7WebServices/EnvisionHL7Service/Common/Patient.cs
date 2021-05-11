using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public class Patient
{
    private string hn;
    private string fname;
    private string mname;
    private string lname;
    private string fname_eng;
    private string mname_eng;
    private string lname_eng;
    private DateTime dob;
    private string gender;
    private string phone;
    private string address;
    private string doctor_name;
    private string department_name;

    public Patient() { 
    
    }

    public string HN {
        get { return hn; }
        set {  hn=value; }
    }
    
    public string FirstName
    {
        get { return fname; }
        set { fname=value ; }
    }
    public string MiddleName
    {
        get { return mname; }
        set {  mname=value; }
    }
    public string LastName
    {
        get { return lname; }
        set {  lname=value; }
    }

    public string FirstNameEng
    {
        get { return fname_eng; }
        set { fname_eng = value; }
    }
    public string MiddleNameEng
    {
        get { return mname_eng; }
        set { mname_eng = value; }
    }
    public string LastNameEng
    {
        get { return lname_eng; }
        set { lname_eng = value; }
    }
    
    public DateTime DOB {
        get {
            return dob;
        }
        set
        {
            dob = value;
        }
    }
    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    public string DoctorName {
        get { return doctor_name; }
        set { doctor_name = value; }
    }
    public string DepartmentName {
        get { return department_name; }
        set { department_name = value; }
    }
}
