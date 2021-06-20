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

namespace DBKP
{
    public partial class MainForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=databasekp");
        MySqlDataReader reader;
        public MainForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            TableName.Text = null;
        }

        private void DisplayTableStorage_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM storage");
            TableGridView.Rows.Clear();
            TableGridView.Columns.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            TableGridView.Columns.Add("St_ID", "ID Склада");
            TableGridView.Columns.Add("St_Description", "Описание");
            TableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            while (reader.Read())
                TableGridView.Rows.Add(reader["St_ID"].ToString(), reader["St_Description"].ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            TableName.Text = "Склады";
        }

        private void DisplayTableFactory_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM factory");
            TableGridView.Rows.Clear();
            TableGridView.Columns.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            TableGridView.Columns.Add("Fact_ID", "ID РЦ");
            TableGridView.Columns.Add("Fact_Status", "Статус");
            TableGridView.Columns.Add("Fact_Time", "Время");
            TableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            while (reader.Read())
                TableGridView.Rows.Add(reader["Fact_ID"].ToString(), reader["Fact_Status"].ToString(),
                    reader["Fact_Time"].ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            TableName.Text = "РЦ";
        }

        private void DisplayTableMaterial_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM material");
            TableGridView.Rows.Clear();
            TableGridView.Columns.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            TableGridView.Columns.Add("Mat_ID", "ID Номенклатуры");
            TableGridView.Columns.Add("Mat_Description", "Описание");
            TableGridView.Columns.Add("Spec_ID", "ID Спецификации");
            TableGridView.Columns.Add("Map_ID", "ID Техкарты");
            TableGridView.Columns.Add("OrdSpec_ID", "ID Спецификации заказа");
            TableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            while (reader.Read())
                TableGridView.Rows.Add(reader["Mat_ID"].ToString(), reader["Mat_Description"].ToString(),
                    reader["Spec_ID"].ToString(), reader["Map_ID"].ToString(),
                    reader["OrdSpec_ID"].ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            TableName.Text = "Номенклатура";
        }

        private void DisplayTableConsist_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM consist");
            TableGridView.Rows.Clear();
            TableGridView.Columns.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            TableGridView.Columns.Add("Mat_ID", "ID Номенклатуры");
            TableGridView.Columns.Add("St_ID", "ID Склада");
            TableGridView.Columns.Add("Cont_Quantity", "Количество");
            TableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            while (reader.Read())
                TableGridView.Rows.Add(reader["Mat_ID"].ToString(), reader["St_ID"].ToString(),
                    reader["Cont_Quantity"].ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            TableName.Text = "Запасы";
        }

        private void MakeOrder_Click(object sender, EventArgs e)
        {
            DisplayTableOrder_Click(null, null);
            MakeOrder makeOrder = new MakeOrder();
            if (makeOrder == null || makeOrder.IsDisposed)
                makeOrder.Show();
            else
            {
                makeOrder.Show();
                makeOrder.Focus();
            }
        }

        private void DisplayTableOrder_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `order`");
            TableGridView.Rows.Clear();
            TableGridView.Columns.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            TableGridView.Columns.Add("Ord_ID", "ID Заказа");
            TableGridView.Columns.Add("Ord_Status", "Статус");
            TableGridView.Columns.Add("Ord_Date", "Дата");
            TableGridView.Columns.Add("Ord_Quantity", "Количество");
            TableGridView.Columns.Add("Mat_ID", "ID Номенклатуры");
            TableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            while (reader.Read())
                TableGridView.Rows.Add(reader["Ord_ID"].ToString(), reader["Ord_Status"].ToString(),
                reader["Ord_Date"].ToString(), reader["Ord_Quantity"].ToString(),
                reader["Mat_ID"].ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            TableName.Text = "Заказы";
        }

        private void OrderMaterialButton_Click(object sender, EventArgs e)
        {
            DisplayTableConsist_Click(null, null);
            OrderMaterial orderMaterial = new OrderMaterial();
            if (orderMaterial == null || orderMaterial.IsDisposed)
                orderMaterial.Show();
            else
            {
                orderMaterial.Show();
                orderMaterial.Focus();
            }
        }

        private void ManageFactoryButton_Click(object sender, EventArgs e)
        {
            DisplayTableFactory_Click(null, null);
            ManageFactory manageFactory = new ManageFactory();
            if (manageFactory == null || manageFactory.IsDisposed)
                manageFactory.Show();
            else
            {
                manageFactory.Show();
                manageFactory.Focus();
            }
        }

        private void RemoveMaterialButton_Click(object sender, EventArgs e)
        {
            DisplayTableConsist_Click(null, null);
            RemoveMaterial removeMaterial = new RemoveMaterial();
            if (removeMaterial == null || removeMaterial.IsDisposed)
                removeMaterial.Show();
            else
            {
                removeMaterial.Show();
                removeMaterial.Focus();
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (TableName.Text == "РЦ")
                DisplayTableFactory_Click(null, null);
            else if (TableName.Text == "Запасы")
                DisplayTableConsist_Click(null, null);
            else if (TableName.Text == "Заказы")
                DisplayTableOrder_Click(null, null);
        }

        private void FactoryOrderButton_Click(object sender, EventArgs e)
        {
            DisplayTableOrder_Click(null, null);
            FactoryOrder factoryOrder = new FactoryOrder();
            if (factoryOrder == null || factoryOrder.IsDisposed)
                factoryOrder.Show();
            else
            {
                factoryOrder.Show();
                factoryOrder.Focus();
            }
        }
    }
}
