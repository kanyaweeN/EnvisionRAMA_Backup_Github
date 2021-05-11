using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using RIS.BusinessLogic;
using RIS.Forms.GBLMessage;
using RIS.Common.Common;

namespace RIS.Forms.Lookup
{
    public partial class Lookup : Form
    {
        //--Variable declaration--\\
        //string tabName;                 //Keep the table name from which data will come
        string fldname;                 //Keep the table field name 
        string[] fieldName;             //To keep the field name in a arry type string
        //string whereClause;             //Which field will be check

        //--Variable for keep track that the column header is already inserted or not--\\
        //int i = 0;
        //--Variable for check the "Enter" Event--\\
        int enterCheck = 0;
        //--Variable for keep the SQL--\\
        string sentSql;
        //string sentSql1;
        string title;

        int addCol = 0;

        MyMessageBox msg = new MyMessageBox();
        //--Create object for dbConnection class--\\
        

        public event ValueUpdatedEventHandler ValueUpdated;

        public Lookup()
        {
            InitializeComponent();
        }

        private void MyLookup_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);
        }


        public void getData(string sql, string fn, string wc, string ttl)
        {
            title = ttl;
            this.Text = title;
            sentSql = sql;
            fldname = fn;
            try
            {
                fieldName = fn.Split(new Char[] { ',' });
                string newSql = sql.Replace("'%%'", "'%" + wc + "%'");
                if (addCol == 0)
                {
                    int k = 0;
                    while (k < fieldName.Length)
                    {
                        listView1.Columns.Add(fieldName[k].ToString(), -2, HorizontalAlignment.Left);
                        k++;
                    }
                    addCol = 1;
                }
                DataTable dt = new DataTable();
                try
                {
                    ProcessGetGBLLookup lkp = new ProcessGetGBLLookup(newSql);
                    lkp.Invoke();
                    dt = lkp.ResultSet.Tables[0];

                    int x = 0;
                    while (x < dt.Rows.Count)
                    {

                        listView1.Items.Add(dt.Rows[x][0].ToString(), x);

                        int fldCount = 1;
                        while (fldCount < fieldName.Length)
                        {
                            listView1.Items[x].SubItems.Add(dt.Rows[x][fldCount].ToString());
                            fldCount++;
                        }
                        x++;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //--Button clik event--\\
        private void btnOk_Click(object sender, EventArgs e)
        {
            //--When the user will select no row in the listView--\\
            if (listView1.SelectedItems.Count == 0)
            {
                string msgid=msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
            }
            else
            {
                string newValue = "";
                int i = 0;
                while (i < fieldName.Length)
                {
                    if (newValue == "")
                    {
                        newValue = listView1.SelectedItems[0].SubItems[i].Text.ToString();
                    }
                    else
                    {
                        newValue = newValue + "^" + listView1.SelectedItems[0].SubItems[i].Text.ToString() + "";
                    }
                    i++;
                }
                ValueUpdatedEventArgs valueArgs = new ValueUpdatedEventArgs(newValue);
                ValueUpdated(this, valueArgs);
            }
            this.Close();
        }

        //--Function for clear the last character inputed in the search textBox--\\
        public void clearChar()
        {
            string nwString1 = "";
            string temp = txtSearch.Text;
            int j = 0;
            while (j < temp.Length - 1)
            {
                nwString1 = nwString1 + temp[j];
                j++;
            }
            txtSearch.Text = nwString1;
        }


        //--This for the text change event in search text box 
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            //--calling function get data for search by the changed text in the text box--\\
            getData(sentSql, fldname, txtSearch.Text,title);
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                //--Set the enter chesk value 1 for performing Ok_button_click event when user--\\ 
                //--press the enter button--\\
                enterCheck = 1;
            }
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nwString = "";

            //--Perform when "Enter" button press--\\
            if (enterCheck == 1)
            {
                btnOk_Click(sender, e);
            }
            //--Perform when "Back Space" button press--\\
            else if (e.KeyChar.ToString() == "")
            {
                //--Call clearChar for delete last character--\\
                clearChar();
            }
            //--Perform when other button press--\\
            else
            {
                nwString = txtSearch.Text + e.KeyChar.ToString();
                txtSearch.Text = nwString;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            btnOk_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
       