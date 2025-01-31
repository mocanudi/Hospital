﻿using System;
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
    public partial class NewItem : Form
    {
        DataBase database = new DataBase();

        public NewItem()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items item = new Items();
            item.Show();
            this.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
           
            database.OpenConnection();
            SqlConnection con = new SqlConnection("Data Source=DIN;Initial Catalog=db_AK;Integrated Security=True");


            
                con.Open();
                SqlCommand taskInsertOrder = new SqlCommand("Insert into Book(book_Name, book_sympthoms, " +
                    "book_level, ID_author) Values(@a, @b," +
                    " @d, @e)", con);
                taskInsertOrder.Parameters.Add("@a", SqlDbType.VarChar);
                taskInsertOrder.Parameters.Add("@b", SqlDbType.VarChar);
                taskInsertOrder.Parameters.Add("@d", SqlDbType.VarChar);
                taskInsertOrder.Parameters.Add("@e", SqlDbType.Int);

                taskInsertOrder.Parameters["@a"].Value = textBox2.Text;
                taskInsertOrder.Parameters["@b"].Value = textBox4.Text;
                taskInsertOrder.Parameters["@d"].Value = textBox3.Text;
                taskInsertOrder.Parameters["@e"].Value = comboBox1_supplier.SelectedValue;
                taskInsertOrder.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Диагноз добавлен!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);



            database.ClosedConnection();
        }

        private void NewItem_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DIN;Initial Catalog=db_AK;Integrated Security=True");

            con.Open();
            SqlDataReader dr1;
            DataTable dt1 = new DataTable();
            SqlCommand task1;
            task1 = new SqlCommand("Select * FROM Author", con);
            dr1 = task1.ExecuteReader();
            dt1.Load(dr1);
            comboBox1_supplier.DisplayMember = "author_pills";
            comboBox1_supplier.ValueMember = "ID_author";
            comboBox1_supplier.DataSource = dt1;

            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Enter_label_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
