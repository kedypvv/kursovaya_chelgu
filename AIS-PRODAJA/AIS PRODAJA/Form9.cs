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
    public partial class Form9 : Form
    {
        MySqlConnection conn;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;database=shop_db;password=Ljrjywf2009!;";
            conn = new MySqlConnection(connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string selected_id_client = textBox1.Text;
            conn.Open();
            string sql = $"SELECT id_client,fio_client,phone_client FROM clients WHERE id_client={selected_id_client}";
            MySqlCommand command = new MySqlCommand(sql, conn);
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    listBox1.Items.Add("ID клиента: " + reader[0].ToString());
                    listBox1.Items.Add("ФИО клиента:" + reader[1].ToString());
                    listBox1.Items.Add("Номер клиента: " + reader[2].ToString());
                    listBox1.Items.Add("----------------------------------------------------------------------------------------------------");
                    reader.Close();
                }
                else
                {
                    textBox1.Clear();
                    MessageBox.Show($"Данные о клиенте с ID {selected_id_client} отсутствуют.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                textBox1.Clear();
                MessageBox.Show($"Заполните поле ID!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            conn.Open();
            string sql = $"SELECT id_client,fio_client,phone_client FROM clients";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add("ID клиента: " + reader[0].ToString());
                listBox1.Items.Add("ФИО клиента: " + reader[1].ToString());
                listBox1.Items.Add("Номер клиента: " + reader[2].ToString());
                listBox1.Items.Add("----------------------------------------------------------------------------------------------------");
            }
            reader.Close();
            conn.Close();
        }
    }
}
        