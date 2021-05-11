using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace Envision.NET.Forms.Orders
{
    public partial class frmOnlineArrivalWorklist_Beep : Form
    {
        public frmOnlineArrivalWorklist_Beep()
        {
            InitializeComponent();
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Size = new Size(400,300);
            this.timer1.Interval = 3200;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RingCall()
        {
            SoundPlayer My_JukeBox = new SoundPlayer(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "Sounds\\salamisound-2655584-ding-dong-bell-will-ring-3.wav"));
            //for (int i = 0; i < 10; i++)
            //{
                My_JukeBox.Play();
                Thread.Sleep(500);
                My_JukeBox.Play();
                Thread.Sleep(500);
                My_JukeBox.Play();
                //Console.Beep(4000, 50);
                //Console.Beep(1000, 25);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            RingCall();
            timer1.Start();
        }

        private void frmOnlineArrivalWorklist_Beep_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
