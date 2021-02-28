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
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        void UpdateTable()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    dataGridView.Rows.Clear();
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "select * from [users]";

                    SqlDataReader reader = cmd.ExecuteReader();
                    int j = 0;
                    while (reader.Read())
                    {
                        dataGridView.Rows.Add();
                        dataGridView.Rows[j].Cells[0].Value = Convert.ToString(String.Format("{0}", reader[0]));
                        dataGridView.Rows[j].Cells[1].Value = Convert.ToString(String.Format("{0}", reader[1]));
                        dataGridView.Rows[j].Cells[2].Value = Convert.ToString(String.Format("{0}", reader[2]));
                        dataGridView.Rows[j].Cells[3].Value = Convert.ToString(String.Format("{0}", reader[3]));
                        dataGridView.Rows[j].Cells[4].Value = Convert.ToString(String.Format("{0}", reader[4]));
                        if (dataGridView.Rows[j].Cells[4].Value.ToString() == "True")
                        {
                            dataGridView.Rows[j].Cells[4].Value = "1";
                        }
                        else
                        {
                            dataGridView.Rows[j].Cells[4].Value = "0";
                        }
                        j++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
                finally
                {
                    con.Close();
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdd au = new FormAdd();
            au.Visible = true;
            au.ShowInTaskbar = true;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //информация о пользователе
            try
            {
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
                {
                    String id = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[0].Value);
                    String Login = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[1].Value);
                    String Password = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[2].Value);
                    String Name = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[3].Value);
                    String Roled = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[4].Value);
                    this.Hide();
                    FormRead uu = new FormRead(id, Login, Password, Name, Roled);
                    uu.Visible = true;
                    uu.ShowInTaskbar = true;
                }
            }
            catch { }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //изменить
                if (e.ColumnIndex == 5)
                {
                    String id = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[0].Value);
                    String Login = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[2].Value);
                    String Password = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[3].Value);
                    String Name = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[1].Value);
                    String Roled = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[4].Value);
                    this.Hide();
                    FormUpDate uc = new FormUpDate(id, Login, Password, Name, Roled);
                    uc.Visible = true;

                }
                //удалить
                if (e.ColumnIndex == 6)
                {
                    String id = Convert.ToString(dataGridView.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[0].Value);

                    using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
                    {
                        try
                        {

                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "DELETE FROM users where id=@Id";
                            cmd.Parameters.AddWithValue(@"Id", id);
                            cmd.ExecuteScalar();
                            con.Close();
                            UpdateTable();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Convert.ToString(ex));
                        }
                    }

                }
            }
            catch { }
        }
    }
}
