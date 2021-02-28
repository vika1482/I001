using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1001
{
    public partial class FormUpDate : Form
    {
        string ID;
        public FormUpDate(string id, string login  , string password, string name, string roled)
        {
            InitializeComponent();
            ID = id;
            textBoxLogin.Text = login;
            textBoxPassword.Text = password;
            textBoxName.Text = name;
            textBoxRoled.Text = roled;
        }

        private void buttonUpDate_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != "" && textBoxPassword.Text != "" && textBoxName.Text != "" && textBoxRoled.Text != "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
                {
                    try
                    {

                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "UPDATE [users] SET name='" + textBoxName.Text + "', login ='" + textBoxLogin.Text + "', password='" + textBoxPassword.Text  + "', isadmin='" + textBoxRoled.Text + "' Where [users].id=" + ID;
                        cmd.ExecuteScalar();
                        con.Close();

                        this.Hide();
                        FormUser info = new FormUser();
                        info.Visible = true;
                        info.ShowInTaskbar = true;



                    }
                    catch (Exception ex)
                    {

                        //if ("-2146232060" == Convert.ToString(ex.HResult))
                        //{
                        //    MessageBox.Show("Логин занят");
                        //}

                        //else
                        //{
                        //    MessageBox.Show(Convert.ToString(ex));
                        //}

                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormUser info = new FormUser();
            info.Visible = true;
            info.ShowInTaskbar = true;
        }
    }
}
