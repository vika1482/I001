using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1001
{
    public partial class FormRead : Form
    {
        string ID;
        public FormRead(string id, string login, string password, string name, string roled)
        {
            InitializeComponent();
            ID = id;
            textBoxLogin.Text = login;
            textBoxPassword.Text = password;
            textBoxName.Text = name;
            textBoxRoled.Text = roled;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUser info = new FormUser();
            info.Visible = true;
            info.ShowInTaskbar = true;
        }
    }
}
