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
    public partial class Form6_addItem : Form
    {
        MySqlConnection conn;
        public Form6_addItem()
        {
            InitializeComponent();

        }


        private void Form6_addItem_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;database=shop_db;password=Ljrjywf2009!;";
            conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand mySql_main = new MySqlCommand();
            string my_sql_mainCateg = "SELECT id_SubCateg, title_SubCateg FROM subCateg";
            DataTable list_mainCateg = new DataTable();
            list_mainCateg.Columns.Add(new DataColumn("id_SubCateg", System.Type.GetType("System.Int32")));
            list_mainCateg.Columns.Add(new DataColumn("title_SubCateg", System.Type.GetType("System.String")));
            comboBox1.DataSource = list_mainCateg;
            comboBox1.DisplayMember = "title_SubCateg";
            comboBox1.ValueMember = "id_SubCateg";
            mySql_main.CommandText = my_sql_mainCateg;
            mySql_main.Connection = conn;
            MySqlDataReader list_stud_reader;
            try
            {
                //Инициализируем ридер
                list_stud_reader = mySql_main.ExecuteReader();
                while (list_stud_reader.Read())
                {
                    DataRow rowToAdd = list_mainCateg.NewRow();
                    rowToAdd["id_SubCateg"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["title_SubCateg"] = list_stud_reader[1].ToString();
                    list_mainCateg.Rows.Add(rowToAdd);
                }
                list_stud_reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            string name_item = textBox2.Text;
            string sum_item = textBox3.Text;
            string categ_item = comboBox1.SelectedValue.ToString();
            string count_item = textBox6.Text;
            if (String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(comboBox1.Text) || String.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Введите данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql_update_current_clients = $"INSERT INTO items (title_item,sum_item,id_SubCateg,count_items) " +
                                $"VALUES ('{name_item}', '{sum_item}', '{categ_item}','{count_item}')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql_update_current_clients, conn);
                command.ExecuteNonQuery();
                textBox2.Clear();
                textBox3.Clear(); 
                textBox6.Clear();
                MessageBox.Show($"Товар успешно добавлен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
