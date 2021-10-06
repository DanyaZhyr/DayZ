using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }

        //Колонки таблицы
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        private DataGridViewColumn dataGridViewColumn5 = null;

        //Инициализация таблицы
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.Columns.Add(getDataGridViewColumn5());
            dataGridView1.AutoResizeColumns();
        }

        //Динамическое создание первой колонки в таблице
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "name";
                dataGridViewColumn1.HeaderText = "Марка";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn1;
        }

        //Динамическое создание второй колонки в таблице
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "country";
                dataGridViewColumn2.HeaderText = "Страна производитель";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn2;
        }

        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Диагональ";
                dataGridViewColumn3.ValueType = typeof(double);
                dataGridViewColumn3.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn3;
        }

        //Динамическое создание четвертой колонки в таблице
        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Цена";
                dataGridViewColumn4.ValueType = typeof(int);
                dataGridViewColumn4.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn4;
        }

        //Динамическое создание пятой колонки в таблице
        private DataGridViewColumn getDataGridViewColumn5()
        {
            if (dataGridViewColumn5 == null)
            {
                dataGridViewColumn5 = new DataGridViewTextBoxColumn();
                dataGridViewColumn5.Name = "";
                dataGridViewColumn5.HeaderText = "Б/у";
                dataGridViewColumn5.ValueType = typeof(bool);
                dataGridViewColumn5.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn5;
        }

        //Колекция HashSet
        private HashSet<Phone> phoneHashSet = new HashSet<Phone>();

        //Добавление телефона в колекцию
        private void addPhone(string name, string country, double diagonal, int price, bool used)
        {
            Phone p = new Phone(name, country, diagonal, price, used);
            phoneHashSet.Add(p);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            checkBox1.Checked = false;
            showListInGrid();
        }

        //Удаление телефона с колекции
        private void deletePhone(int index)
        {
            phoneHashSet.Remove(phoneHashSet.ElementAt(index));
            showListInGrid();
        }

        //Отображение колекции в таблице
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Phone s in phoneHashSet)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell5 = new
                DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.getName();
                cell2.ValueType = typeof(string);
                cell2.Value = s.getCountry();
                cell3.ValueType = typeof(double);
                cell3.Value = s.getDiagonal();
                cell4.ValueType = typeof(int);
                cell4.Value = s.getPrice();
                cell5.ValueType = typeof(string);
                if (s.getUsed() == true) 
                {
                    cell5.Value = "Да";
                }
                else
                {
                    cell5.Value = "Нет";
                }
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                dataGridView1.Rows.Add(row);
            }
        }

        //Обработчик нажатия на кнопку добавления
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                textBox2.Text = "China";
                MessageBox.Show("Не введена страна производитель", "", MessageBoxButtons.OK);
            }
            addPhone(textBox1.Text, textBox2.Text, double.Parse(textBox3.Text), int.Parse(textBox4.Text), checkBox1.Checked);
        }

        //Обработчик нажатия на удалить
        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить телефон?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deletePhone(selectedRow);
                }
                catch (Exception)
                {
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
