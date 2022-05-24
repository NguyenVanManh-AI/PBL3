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
    public partial class FormInformationUser : Form
    {
        string username;
        public FormInformationUser(string user_name)
        {
            username = user_name;
            InitializeComponent();
            guna2HtmlLabel1.Text = username;
        }
    }
}
