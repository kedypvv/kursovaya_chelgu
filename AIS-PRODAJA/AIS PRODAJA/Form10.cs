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
    public partial class Form10 : Form
    {
        MySqlConnection conn;

        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataSet ds = new DataSet();
        private DataTable table = new DataTable();

        string id_selected_rows = "0";
        string id_selected_clients = "0";
        string titleItems_selected_rows = "";
        string priceItems_selected_rows = "";
        bool issetOrder = false;
        double sum_order = 0;
        public void GetComboBox1()
        {
            DataTable list_client_table = new DataTable();
            MySqlCommand list_client_command = new MySqlCommand();
            conn.Open();
            list_client_table.Columns.Add(new DataColumn("id_MainCateg", System.Type.GetType("System.Int32")));
            list_client_table.Columns.Add(new DataColumn("title_MainCateg", System.Type.GetType("System.String")));
            comboBox1.DataSource = list_client_table;
            comboBox1.DisplayMember = "title_MainCateg";
            comboBox1.ValueMember = "id_MainCateg";
            string sql_list_clients = "SELECT id_MainCateg, title_MainCateg FROM mainCateg";
            list_client_command.CommandText = sql_list_clients;
            list_client_command.Connection = conn;
            MySqlDataReader list_client_reader;
            try
            {
                list_client_reader = list_client_command.ExecuteReader();
                while (list_client_reader.Read())
                {
                    DataRow rowToAdd = list_client_table.NewRow();
                    rowToAdd["id_MainCateg"] = Convert.ToInt32(list_client_reader[0]);
                    rowToAdd["title_MainCateg"] = list_client_reader[1].ToString();
                    list_client_table.Rows.Add(rowToAdd);
                }
                list_client_reader.Close();
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
        public void GetComboBox2(string id_MainCateg)
        {
            DataTable list_client_table = new DataTable();
            MySqlCommand list_client_command = new MySqlCommand();
            conn.Open();
            list_client_table.Columns.Add(new DataColumn("id_SubCateg", System.Type.GetType("System.Int32")));
            list_client_table.Columns.Add(new DataColumn("title_SubCateg", System.Type.GetType("System.String")));
            comboBox2.DataSource = list_client_table;
            comboBox2.DisplayMember = "title_SubCateg";
            comboBox2.ValueMember = "id_SubCateg";
            string sql_list_clients = $"SELECT id_SubCateg, title_SubCateg FROM subCateg WHERE id_SubCateg = {id_MainCateg}";
            list_client_command.CommandText = sql_list_clients;
            list_client_command.Connection = conn;
            MySqlDataReader list_client_reader;
            try
            {
                list_client_reader = list_client_command.ExecuteReader();
                while (list_client_reader.Read())
                {
                    DataRow rowToAdd = list_client_table.NewRow();
                    rowToAdd["id_SubCateg"] = Convert.ToInt32(list_client_reader[0]);
                    rowToAdd["title_SubCateg"] = list_client_reader[1].ToString();
                    list_client_table.Rows.Add(rowToAdd);
                }
                list_client_reader.Close();
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
        public void GetComboBox3()
        {
            DataTable list_client_table = new DataTable();
            MySqlCommand list_client_command = new MySqlCommand();
            conn.Open();
            list_client_table.Columns.Add(new DataColumn("id_client", System.Type.GetType("System.Int32")));
            list_client_table.Columns.Add(new DataColumn("fio_client", System.Type.GetType("System.String")));
            comboBox3.DataSource = list_client_table;
            comboBox3.DisplayMember = "fio_client";
            comboBox3.ValueMember = "id_client";
            string sql_list_clients = "SELECT id_client, fio_client FROM clients";
            list_client_command.CommandText = sql_list_clients;
            list_client_command.Connection = conn;
            MySqlDataReader list_client_reader;
            try
            {
                list_client_reader = list_client_command.ExecuteReader();
                while (list_client_reader.Read())
                {
                    DataRow rowToAdd = list_client_table.NewRow();
                    rowToAdd["id_client"] = Convert.ToInt32(list_client_reader[0]);
                    rowToAdd["fio_client"] = list_client_reader[1].ToString();
                    list_client_table.Rows.Add(rowToAdd);
                }
                list_client_reader.Close();
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

        public Form10()
        {
            InitializeComponent();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            GetComboBox2(comboBox1.SelectedValue.ToString());
            comboBox2.Text = "";
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            table.Clear();
            GetListUsers(comboBox2.SelectedValue.ToString());
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[0].FillWeight = 10;
            dataGridView1.Columns[1].FillWeight = 70;
            dataGridView1.Columns[2].FillWeight = 20;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      
            dataGridView1.ColumnHeadersVisible = true;
        }
        
        public void GetFirstListUsers()
        {
            string commandStr = $"SELECT id_items AS Код, title_item AS 'Название товара', sum_item AS 'Цена товара' FROM items";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            MyDA.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            conn.Close();

        }
        
        public void GetListUsers(string idSubCateg)
        {
            
            string commandStr = $"SELECT id_items AS Код, title_item AS 'Название товара', sum_item AS 'Цена товара' FROM items WHERE id_SubCateg = {idSubCateg}";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            MyDA.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            conn.Close();

        }
        
        public void reload_list()
        {
            table.Clear();
            GetListUsers(comboBox2.SelectedValue.ToString());
        }
        
        public void GetSelectedIDString()
        {
            
            string index_selected_rows;
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
            titleItems_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[1].Value.ToString();
            priceItems_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[2].Value.ToString();

        }
        
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentCell.Selected = true;
                GetSelectedIDString();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            GetSelectedIDString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form1_addClient formNewClient = new Form1_addClient();
            formNewClient.ShowDialog();
            GetComboBox3();
            comboBox3.SelectedValue = Convert.ToInt32(SomeClass.new_inserted_id);
        }

        public void InsertOrderMain()
        {
            string dataOrder = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string idClient = id_selected_clients;
            string summOrder = "0";
            string sql_update_current_stud = $"INSERT INTO orders (date_order, id_client, sum_order) " +
                                              $"VALUES ('{dataOrder}', '{idClient}', '{summOrder}'); " +
                                              $"SELECT id_order FROM orders WHERE (id_order = LAST_INSERT_ID());";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql_update_current_stud, conn);
            string new_inserted_mainOrder_id = command.ExecuteScalar().ToString();
            SomeClass.new_inserted_mainOrder_id = new_inserted_mainOrder_id;
            label7.Text = $"Добавлен заказ в БД с ID {SomeClass.new_inserted_mainOrder_id}";
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            id_selected_clients = comboBox3.SelectedValue.ToString();
            InsertOrderMain();
            issetOrder = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowNumber = dataGridView2.Rows.Add();
            dataGridView2.Rows[rowNumber].Cells[0].Value = id_selected_rows;
            dataGridView2.Rows[rowNumber].Cells[1].Value = titleItems_selected_rows;
            dataGridView2.Rows[rowNumber].Cells[2].Value = "1";
            dataGridView2.Rows[rowNumber].Cells[3].Value = priceItems_selected_rows;
            dataGridView2.Rows[rowNumber].Cells[4].Value = priceItems_selected_rows;
            sum_order += Convert.ToDouble(dataGridView2.Rows[rowNumber].Cells[4].Value) * Convert.ToDouble(dataGridView2.Rows[rowNumber].Cells[2].Value);
            label7.Text = "Сумма заказа" + sum_order.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (issetOrder)
            {
                double sum_order = 0;
                int countPosition = dataGridView2.Rows.Count;
                conn.Open();
                for (int i = 0; i < countPosition; i++)
                {
                    string id_items = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    string count_items = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    double sum_item = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    string id_MainCateg = SomeClass.new_inserted_mainOrder_id;
                    sum_order += Convert.ToInt32(count_items) * sum_item;
                    string query = $"INSERT INTO  korzinaOrders (id_items, count_items, id_MainCateg) " +
                        $"VALUES ('{id_items}', '{count_items}', {id_MainCateg})";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.ExecuteNonQuery();
                }
                conn.Close();

                label6.Text = $"Итоговая сумма заказа №{SomeClass.new_inserted_mainOrder_id} составляет {sum_order}";
                conn.Open();
                string query2 = $"UPDATE orders SET sum_order='{sum_order}' WHERE (id_order='{SomeClass.new_inserted_mainOrder_id}')";
                MySqlCommand comman1 = new MySqlCommand(query2, conn);
                comman1.ExecuteNonQuery();
                conn.Close();
                dataGridView2.Rows.Clear();
                SomeClass.new_inserted_mainOrder_id = "0";
            }
            else
            {
                MessageBox.Show("Упс. Заказ не создан. Что-то пошло не так...");
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sum_order = 0;
            int selRowNum = dataGridView2.CurrentCell.RowIndex;
            double itogPosition = Convert.ToDouble(dataGridView2.Rows[selRowNum].Cells[3].Value) * Convert.ToDouble(dataGridView2.Rows[selRowNum].Cells[2].Value);
            dataGridView2.Rows[selRowNum].Cells[4].Value = itogPosition.ToString();
            int countPosition = dataGridView2.Rows.Count;

            for (int i = 0; i < countPosition; i++)
            {
                string countItems = dataGridView2.Rows[i].Cells[2].Value.ToString();
                double priceItems = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                sum_order += Convert.ToInt32(countItems) * priceItems;
            }
            label7.Text = "Сумма заказа  " + sum_order.ToString();
            
        }
        

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;database=shop_db;password=Ljrjywf2009!;";
            conn = new MySqlConnection(connStr);
            GetComboBox1();
            GetComboBox3();
            comboBox3.Text = "";
            comboBox1.Text = "";
            GetFirstListUsers();
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[0].FillWeight = 10;
            dataGridView1.Columns[1].FillWeight = 70;
            dataGridView1.Columns[2].FillWeight = 20;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = true;
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
