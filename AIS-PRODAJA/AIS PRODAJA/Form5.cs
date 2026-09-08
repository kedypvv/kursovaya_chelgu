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
    public partial class Form5 : Form
    {
        MySqlConnection conn;
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataSet ds = new DataSet();
        private DataTable table = new DataTable();
        private DataTable tablee = new DataTable();
        string id_selected_rows = "0";
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        public void GetSelectedIDString()
        {
            string index_selected_rows;
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
            toolStripLabel4.Text = id_selected_rows;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            GetSelectedIDString();
        }

        public void reload_list()
        {
            table.Clear();
            GetListUsers();
        }

        public void ChangeStateStudent(string new_id)
        {
            
        }
        public void GetListUsers()
        {
         string commandStr = "SELECT id_order AS 'Код', date_order AS 'Время и дата заказа', id_client AS 'ID клиента',sum_order AS 'Сумма заказа' FROM orders ";
         conn.Open();
         MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
         MyDA.Fill(table);
         bSource.DataSource = table;
         dataGridView1.DataSource = bSource;
         conn.Close();
         int count_rows = dataGridView1.RowCount - 1;
         toolStripLabel2.Text = (count_rows).ToString();
         
        }

        public void DeleteUser()
        {
            string sql_delete_items = "DELETE FROM orders WHERE id_order='" + id_selected_rows + "'";
            MySqlCommand delete_items = new MySqlCommand(sql_delete_items, conn);
            try
            {
                conn.Open();
                delete_items.ExecuteNonQuery();
                MessageBox.Show("Удаление прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления строки \n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
                reload_list();
            }
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;database=shop_db;password=Ljrjywf2009!;";
            conn = new MySqlConnection(connStr);
            GetListUsers();
            toolStripButton4.Visible = false;
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
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ChangeStateStudent(id_selected_rows);
        }

        private void отчислитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeStateStudent("1");
        }

        private void зачислитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeStateStudent("2");
        }

        private void выделенныйИДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(id_selected_rows);
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Удаления поля под кодом " + id_selected_rows);
            DeleteUser();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            reload_list();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            table.Clear();
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = false;
            string command = "SELECT id_MainCateg AS 'Код проданого товара', id_items AS 'ID проданого товара', count_items AS 'Количество проданого товара' FROM korzinaOrders ";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(command, conn);
            MyDA.Fill(tablee);
            bSource.DataSource = tablee;
            dataGridView1.DataSource = bSource;
            conn.Close();
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();
            toolStripButton3.Visible = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Visible = true;
            toolStripButton4.Enabled = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            toolStripButton3.Visible = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Visible = false;
            toolStripButton4.Enabled = false;
            string commandStr = "SELECT id_order AS 'Код', date_order AS 'Время и дата заказа', id_client AS 'ID клиента',sum_order AS 'Сумма заказа' FROM orders ";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            MyDA.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            conn.Close();
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
