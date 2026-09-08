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
    public partial class Form6 : Form
    {
        MySqlConnection conn;
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataSet ds = new DataSet();
        private DataTable table = new DataTable();
        string id_selected_rows = "0";
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentCell.Selected = true;
                GetSelectedIDString();
            }
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
        public void DeleteUser()
        {
            string sql_delete_items = "DELETE FROM items WHERE id_items='" + id_selected_rows + "'";
            MySqlCommand delete_items= new MySqlCommand(sql_delete_items, conn);
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
        public void ChangeStateStudent(string new_id)
        {
            if (toolStripTextBox1.Visible!=true)
            {

                toolStripTextBox1.Visible = true;
                toolStripTextBox1.Enabled = true;
                MessageBox.Show("Введите количество рядом с кнопкой");
            }
            else
            {

                toolStripTextBox1.Visible = true;
                toolStripTextBox1.Enabled = true;
                string redact_id = toolStripTextBox1.Text;
                conn.Open();
                string query2 = $"UPDATE items SET count_items='{redact_id}' WHERE (id_items='{new_id}') ";
                MySqlCommand command = new MySqlCommand(query2, conn);
                command.ExecuteNonQuery();
                conn.Close();
                reload_list();
            }

        }
        public void GetListUsers()
        {
            string commandStr = "SELECT id_items AS 'Код', title_item AS 'Название вещи', sum_item AS 'Цена',count_items AS 'Количество товара' FROM items";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            MyDA.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            conn.Close();
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();
        }

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string connStr = "server=127.0.0.1;port=3306;user=root;database=shop_db;password=Ljrjywf2009!;";
            conn = new MySqlConnection(connStr);
            GetListUsers();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            reload_list();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удаление строки под кодом " + id_selected_rows);
            DeleteUser();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ChangeStateStudent(id_selected_rows);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            Form6_addItem formaddItem = new Form6_addItem();
            formaddItem.ShowDialog();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
               
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }   
}
