using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class UC_Help : UserControl
    {
        public UC_Help()
        {
            InitializeComponent();
            Step(page);
        }


        int page = 1;
        public void Step(int page)
        {
            this.step1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.step1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text1.ForeColor = System.Drawing.Color.White;

            this.step2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text2.ForeColor = System.Drawing.Color.White;

            this.step3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text3.ForeColor = System.Drawing.Color.White;

            if (page == 1)
            {
                this.step1.BackColor = System.Drawing.Color.White;
                this.text1.BackColor = System.Drawing.Color.White;
                this.text1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            }
            else if(page ==2)
            {
                this.step2.BackColor = System.Drawing.Color.White;
                this.text2.BackColor = System.Drawing.Color.White;
                this.text2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            }
            else
            {
                this.step3.BackColor = System.Drawing.Color.White;
                this.text3.BackColor = System.Drawing.Color.White;
                this.text3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (page == 1)
                page = 3;
            else page--;
            Step(page);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (page == 3)
                page = 1;
            else page++;
            Step(page);
        }
    }
}
