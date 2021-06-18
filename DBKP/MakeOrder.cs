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
    public partial class MakeOrder : Form
    {
        public MakeOrder()
        {
            InitializeComponent();
            ShowMaterial();
            MaximizeBox = false;
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=databasekp");
        MySqlDataReader reader;

        void ShowMaterial()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM material where material.Mat_ID in (select consist.Mat_ID from consist where St_ID = 2 or St_ID = 3)");
            MaterialGridView.Rows.Clear();
            MaterialGridView.Columns.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            MaterialGridView.Columns.Add("Mat_ID", "ID Номенклатуры");
            MaterialGridView.Columns.Add("Mat_Description", "Описание");
            MaterialGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            while (reader.Read())
                MaterialGridView.Rows.Add(reader["Mat_ID"].ToString(), reader["Mat_Description"].ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        private void MakeOrderButton_Click(object sender, EventArgs e)
        {
            bool idHave = false;
            for (int i = 0; i < MaterialGridView.Rows.Count; i++)
            {
                if (MaterialGridView.Rows[i].Cells[0].Value.ToString() == MaterialUpDown.Value.ToString())
                    idHave = true;
            }
            if (!idHave)
            {
                MessageBox.Show("Данный ID не содержится в таблице", "Ошибка!");
                return;
            }
            MySqlCommand command = new MySqlCommand("SELECT * FROM material where material.Mat_ID in (SELECT consist.Mat_ID from consist where Cont_Quantity > " + (QuantityUpDown.Value - 1) +")");
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            List<string> selectedMatID = new List<string>();
            reader = command.ExecuteReader();
            while (reader.Read())
                selectedMatID.Add(reader.GetInt32("Mat_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            if (selectedMatID.Contains(MaterialUpDown.Value.ToString()))
            {
                command.CommandText = "Select * from `order`";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<string> orderCount = new List<string>();
                while (reader.Read())
                    orderCount.Add(reader.GetInt32("Ord_ID").ToString());
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "INSERT INTO `order` VALUES (@id, @status, @dateTime, @quantity, @material)";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = orderCount.Count+1;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Создан";
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = QuantityUpDown.Value;
                command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@material", MySqlDbType.Int32).Value = MaterialUpDown.Value;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                MessageBox.Show("Заказ успешно оформлен", "Оформление заказа");
                MainForm mainForm = new MainForm();
                mainForm.Activate();
                return;
            }
            else
            {
                MessageBox.Show("Введенное количество некорректно", "Ошибка!");
                return;
            }
        }
    }
}
