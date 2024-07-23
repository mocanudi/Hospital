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

namespace KURS.Forms.Zaprosi
{
    public partial class Z2 : Form
    {
        DataBase database = new DataBase();

        int selectedRow;
        enum RowState
        {
            Existed,
            New,
            Modified,
            ModifiedNew,
            Deleted
        }
        public Z2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns2()
        {
            dataGridView1.Columns.Add("ID_borrowing", "ID обращения");
            dataGridView1.Columns.Add("borrowing_price", "Стоимость приема");
            dataGridView1.Columns.Add("borrowing_Status", "Статус обращения");

            dataGridView1.Columns.Add("reader_Surname", "Фамилия пациента");
            dataGridView1.Columns.Add("reader_Name", "Имя пациента");

            dataGridView1.Columns.Add("isNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2),
                record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid2(DataGridView dwg, int price, int price1)
        {
            dwg.Rows.Clear();

            string querystring = $"SELECT ID_borrowing, borrowing_price, borrowing_Status, b.reader_Surname, b.reader_Name FROM Borrowing a INNER JOIN Reader b ON b.ID_reader = a.ID_reader " +
                $"where borrowing_price BETWEEN '{price}' and '{price1}'";


            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            database.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }
        private void Z2_Load(object sender, EventArgs e)
        {
            CreateColumns2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox1.Text);
            int price1 = Convert.ToInt32(textBox2.Text);

            RefreshDataGrid2(dataGridView1, price, price1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forma item = new Forma();
            item.Show();
            this.Hide();
        }
    }
}
