using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AIS_PRODAJA
{
    public partial class Form4 : Form
    {
        public void GetListClients(ListBox listbox)
        {
            listbox.Items.Clear();
            conn.Open();
            string sql = $"SELECT * FROM employees";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id_emloyee = reader[0].ToString();
                string fio_emloyee = reader[1].ToString();
                string post_emloyee = reader[2].ToString();
                string email_emloyee = reader[3].ToString();

                listbox.Items.Add($"{id_emloyee}) ФИО: {fio_emloyee} | Должность: {post_emloyee} | Номер телефона: {email_emloyee}");
            }
            reader.Close();
            conn.Close();
        }
        public bool DeleteClients(string id_employee)
        {
            int InsertCount = 0;
            bool result = false;
            conn.Open();
            string query = $"DELETE FROM employees WHERE (id_employee='{id_employee}')";
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                InsertCount = command.ExecuteNonQuery();
            }
            catch
            {
                InsertCount = 0;
            }
            finally
            {
                conn.Close();
                if (InsertCount != 0)
                {
                    result = true;
                }
            }
            return result;
        }
        MySqlConnection conn;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id_delete = textBox1.Text;
            if (DeleteClients(id_delete))
            {
                GetListClients(listBox1);
                MessageBox.Show("Сотрудник успешно удалён!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите ID!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Некорректное значение!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Clear();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;database=shop_db;password=Ljrjywf2009!;";
            conn = new MySqlConnection(connStr);
            GetListClients(listBox1);
        }
    }
}
