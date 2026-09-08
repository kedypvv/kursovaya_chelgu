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
    public partial class Form1_addClient : Form
    {
        MySqlConnection conn;
        public Form1_addClient()
        {
            InitializeComponent();
        }

        private void Form1_addClient_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;database=shop_db;password=Ljrjywf2009!;";
            conn = new MySqlConnection(connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string new_fio_client = textBox1.Text;
            string new_phone_client = textBox2.Text;
            string ins_email = textBox3.Text;

            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Введите данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string sql_update_current_clients = $"INSERT INTO clients (fio_client, phone_client, email_client) " +
                               $"VALUES ('{new_fio_client}', '{new_phone_client}', '{ins_email}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update_current_clients, conn);
                command.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show($"Клиент успешно добавлен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            
        }

    }
}
