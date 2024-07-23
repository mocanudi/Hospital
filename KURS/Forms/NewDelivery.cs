using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using KURS.Classes;
namespace KURS.Forms
{
    public partial class NewDelivery : Form
    {
        DataBase database = new DataBase();
        public NewDelivery()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void NewDelivery_Load(object sender, EventArgs e)
        {
           
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            Delivery item = new Delivery();
            item.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DIN;Initial Catalog=db_AK;Integrated Security=True");
            database.OpenConnection();
            con.Open();

            SqlCommand taskInsertCar = new SqlCommand("insert into Librarian (librarian_FIO, librarian_Phone, librarian_position, librarian_specialization, librarian_qualification)" +
                " values (@b, @c, @d, @e, @f)", con);
            
            taskInsertCar.Parameters.Add("@b", SqlDbType.VarChar);
            taskInsertCar.Parameters.Add("@c", SqlDbType.VarChar);
            taskInsertCar.Parameters.Add("@d", SqlDbType.VarChar);
            taskInsertCar.Parameters.Add("@e", SqlDbType.VarChar);
            taskInsertCar.Parameters.Add("@f", SqlDbType.VarChar);

            taskInsertCar.Parameters["@b"].Value = textBox3.Text;
            taskInsertCar.Parameters["@c"].Value = textBox4.Text;
            taskInsertCar.Parameters["@d"].Value = textBox2.Text;
            taskInsertCar.Parameters["@e"].Value = textBox1.Text;
            taskInsertCar.Parameters["@f"].Value = textBox5.Text;

            taskInsertCar.ExecuteNonQuery();
            MessageBox.Show("Врач добавлен!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            database.ClosedConnection();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
