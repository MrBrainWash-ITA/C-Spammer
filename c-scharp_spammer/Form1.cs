using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace c_scharp_spammer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count = 1;
        void disattiva_spam()
        {
            //DISATTIVO LO SPAM
            timer1.Stop();
            textBox1.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            button1.Enabled = true;
            button2.Visible = false;
            label9.Text = "DISATTIVATO";
            label9.ForeColor = Color.Red;
            count = 0;
        }
        void attiva_spam()
        {
            //AVVIO LO SPAM!
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value);
            Thread.Sleep(2000); // METTE IN PAUSA IL PROGRAMMA PER PERMETTERE ALL'UTENTE DI TROVARE LA FINESTRA
            timer1.Start();
            textBox1.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            button1.Enabled = false;
            button2.Visible = true;
            label9.Text = "ATTIVO";
            label9.ForeColor = Color.Lime;            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send(textBox1.Text);
            if (checkBox1.Checked)
            SendKeys.Send("{ENTER}");
            count--;
            if (count == 0)
            {
                disattiva_spam();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = Convert.ToInt32(numericUpDown2.Value);
            if (count == 0)
                if (MessageBox.Show("Vuoi davvero spammare questo messaggio all'infinito ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    count = -1;
                }
            attiva_spam();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            disattiva_spam();
        }
    }
}
