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
    public partial class Form1 : Form
    {
        public void GetListClients(ListBox listbox)
        {
            listbox.Items.Clear();
            conn.Open();
            string sql = $"SELECT * FROM clients";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listbox.Items.Add($"{reader[0].ToString()}) ФИО: {reader[1].ToString()} | Номер: {reader[2].ToString()} | EMAIL: {reader[3].ToString()}");
            }
            reader.Close();
            conn.Close();
        }
        public bool InsertClients(string fio_client, string phone_client, string email_client)
        {
            int InsertCount = 0;
            bool result = false;
            conn.Open();
            string query = $"INSERT INTO clients (fio_client, phone_client, email_client) VALUES ('{fio_client}', '{phone_client}', '{email_client}')";
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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ins_fio = textBox1.Text;
            string ins_phone = textBox2.Text;
            string ins_email = textBox3.Text;
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Введите данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (InsertClients(ins_fio, ins_phone, ins_email))
                {
                    GetListClients(listBox1);
                    MessageBox.Show("Клиент успешно добавлен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Произошла ошибка.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;database=shop_db;password=Ljrjywf2009!;";
            conn = new MySqlConnection(connStr);
            GetListClients(listBox1);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
