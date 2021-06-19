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
            this.ClientSize = new System.Drawing.Size(429, 228);
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=databasekp");
        MySqlDataReader reader;

        void ShowMaterial()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM material where material.Mat_ID in (select consist.Mat_ID from consist where St_ID = 2 or St_ID = 3) and material.ordspec_id in (1, 2, 3, 4, 5)");
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
            this.ClientSize = new System.Drawing.Size(429, 228);
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

                if (MessageBox.Show("Вы желаете оформить заказ на стандартной спецификации? Нажмите «Нет», если желаете изменить спецификацию.", "Выбор спецификации", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    command.CommandText = "INSERT INTO `order` VALUES (@id, @status, @dateTime, @quantity, @material)";
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = orderCount.Count + 1;
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
                    this.ClientSize = new System.Drawing.Size(429, 500);
                    if (MaterialUpDown.Value == 7)
                    {
                        ModifiedUpDown1.Enabled = true; ModifiedUpDown4.Enabled = false;
                        ModifiedUpDown2.Enabled = true; ModifiedUpDown5.Enabled = false;
                        ModifiedUpDown3.Enabled = true; ModifiedUpDown6.Enabled = false;
                        ModifiedLabel1.Text = "Камера"; ModifiedLabel4.Text = "";
                        ModifiedLabel2.Text = "Дверка"; ModifiedLabel5.Text = "";
                        ModifiedLabel3.Text = "Вращающийся столик"; ModifiedLabel6.Text = "";
                        return;
                    }
                    else if (MaterialUpDown.Value == 8)
                    {
                        ModifiedUpDown1.Enabled = true; ModifiedUpDown4.Enabled = false;
                        ModifiedUpDown2.Enabled = true; ModifiedUpDown5.Enabled = false;
                        ModifiedUpDown3.Enabled = false; ModifiedUpDown6.Enabled = false;
                        ModifiedLabel1.Text = "Щит из пластика"; ModifiedLabel4.Text = "";
                        ModifiedLabel2.Text = "Труба"; ModifiedLabel5.Text = "";
                        ModifiedLabel3.Text = ""; ModifiedLabel6.Text = "";
                        return;
                    }
                    else if (MaterialUpDown.Value == 12)
                    {
                        ModifiedUpDown1.Enabled = true; ModifiedUpDown4.Enabled = true;
                        ModifiedUpDown2.Enabled = true; ModifiedUpDown5.Enabled = true;
                        ModifiedUpDown3.Enabled = true; ModifiedUpDown6.Enabled = true;
                        ModifiedLabel1.Text = "Трансформатор"; ModifiedLabel4.Text = "Провода";
                        ModifiedLabel2.Text = "Магнетрон"; ModifiedLabel5.Text = "Конденсатор";
                        ModifiedLabel3.Text = "Лампа"; ModifiedLabel6.Text = "Резистор";
                        return;
                    }
                    else if (MaterialUpDown.Value == 18)
                    {
                        ModifiedUpDown1.Enabled = true; ModifiedUpDown4.Enabled = false;
                        ModifiedUpDown2.Enabled = true; ModifiedUpDown5.Enabled = false;
                        ModifiedUpDown3.Enabled = false; ModifiedUpDown6.Enabled = false;
                        ModifiedLabel1.Text = "Двигатель вентилятора"; ModifiedLabel4.Text = "";
                        ModifiedLabel2.Text = "Вентилятор"; ModifiedLabel5.Text = "";
                        ModifiedLabel3.Text = ""; ModifiedLabel6.Text = "";
                        return;
                    }
                    else if (MaterialUpDown.Value == 9)
                    {
                        ModifiedUpDown1.Enabled = true; ModifiedUpDown4.Enabled = true;
                        ModifiedUpDown2.Enabled = true; ModifiedUpDown5.Enabled = false;
                        ModifiedUpDown3.Enabled = true; ModifiedUpDown6.Enabled = false;
                        ModifiedLabel1.Text = "Корпус"; ModifiedLabel4.Text = "Система охлаждения";
                        ModifiedLabel2.Text = "Волновод"; ModifiedLabel5.Text = "";
                        ModifiedLabel3.Text = "Электрическое оборудование"; ModifiedLabel6.Text = "";
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Введенное количество некорректно", "Ошибка!");
                return;
            }
        }

        private void MakeOrderModifiedButton_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("select * from ordspec_structure GROUP by OrdSpec_ID");
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            List<string> specCount = new List<string>();
            reader = command.ExecuteReader();
            while (reader.Read())
                specCount.Add(reader.GetInt32("OrdSpec_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();

            command.CommandText = "select * from ordspec_structure";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            List<string> specStrucCount = new List<string>();
            reader = command.ExecuteReader();
            while (reader.Read())
                specStrucCount.Add(reader.GetInt32("OrdSpecStruc_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();

            command.CommandText = "select * from material";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            List<string> materialCount = new List<string>();
            reader = command.ExecuteReader();
            while (reader.Read())
                materialCount.Add(reader.GetInt32("Mat_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();

            command.CommandText = "select * from order_specification";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            List<string> ordspecCount = new List<string>();
            reader = command.ExecuteReader();
            while (reader.Read())
                ordspecCount.Add(reader.GetInt32("OrdSpec_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();

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

            if (MaterialUpDown.Value == 7)
            {
                command.CommandText = "insert into ordspec_structure values (@id1, 1, @quantity1, @specID, @matID1);";
                command.Parameters.Add("@id1", MySqlDbType.Int32).Value = specStrucCount.Count + 1;
                command.Parameters.Add("@id2", MySqlDbType.Int32).Value = specStrucCount.Count + 2;
                command.Parameters.Add("@id3", MySqlDbType.Int32).Value = specStrucCount.Count + 3;
                command.Parameters.Add("@quantity1", MySqlDbType.Int32).Value = ModifiedUpDown1.Value;
                command.Parameters.Add("@quantity2", MySqlDbType.Int32).Value = ModifiedUpDown2.Value;
                command.Parameters.Add("@quantity3", MySqlDbType.Int32).Value = ModifiedUpDown3.Value;
                command.Parameters.Add("@specID", MySqlDbType.Int32).Value = specCount.Count;
                command.Parameters.Add("@matID1", MySqlDbType.Int32).Value = 4;
                command.Parameters.Add("@matID2", MySqlDbType.Int32).Value = 5;
                command.Parameters.Add("@matID3", MySqlDbType.Int32).Value = 6;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id2, 2, @quantity2, @specID, @matID2)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id3, 3, @quantity3, @specID, @matID3)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into order_specification values (@id, @description, @Spec_ID)";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = ordspecCount.Count+1;
                command.Parameters.Add("@description", MySqlDbType.VarChar).Value = "Корпус";
                command.Parameters.Add("@Spec_ID", MySqlDbType.Int32).Value = 2;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into material values (@idmat, @description, @Spec_ID, @Map_ID, @OrdSpec_ID)";
                command.Parameters.Add("@idmat", MySqlDbType.Int32).Value = materialCount.Count+1;
                command.Parameters.Add("@Map_ID", MySqlDbType.Int32).Value = 2;
                command.Parameters.Add("@OrdSpec_ID", MySqlDbType.Int32).Value = ordspecCount.Count+1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "INSERT INTO `order` VALUES (@idorder, @status, @dateTime, @quantity, @material)";
                command.Parameters.Add("@idorder", MySqlDbType.Int32).Value = orderCount.Count + 1;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Создан";
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = QuantityUpDown.Value;
                command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@material", MySqlDbType.Int32).Value = materialCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            else if (MaterialUpDown.Value == 8)
            {
                command.CommandText = "insert into ordspec_structure values (@id1, 1, @quantity1, @specID, @matID1);";
                command.Parameters.Add("@id1", MySqlDbType.Int32).Value = specStrucCount.Count + 1;
                command.Parameters.Add("@id2", MySqlDbType.Int32).Value = specStrucCount.Count + 2;
                command.Parameters.Add("@quantity1", MySqlDbType.Int32).Value = ModifiedUpDown1.Value;
                command.Parameters.Add("@quantity2", MySqlDbType.Int32).Value = ModifiedUpDown2.Value;
                command.Parameters.Add("@specID", MySqlDbType.Int32).Value = specCount.Count;
                command.Parameters.Add("@matID1", MySqlDbType.Int32).Value = 10;
                command.Parameters.Add("@matID2", MySqlDbType.Int32).Value = 11;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id2, 2, @quantity2, @specID, @matID2)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into order_specification values (@id, @description, @Spec_ID)";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = ordspecCount.Count + 1;
                command.Parameters.Add("@description", MySqlDbType.VarChar).Value = "Волновод";
                command.Parameters.Add("@Spec_ID", MySqlDbType.Int32).Value = 3;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into material values (@idmat, @description, @Spec_ID, @Map_ID, @OrdSpec_ID)";
                command.Parameters.Add("@idmat", MySqlDbType.Int32).Value = materialCount.Count + 1;
                command.Parameters.Add("@Map_ID", MySqlDbType.Int32).Value = 5;
                command.Parameters.Add("@OrdSpec_ID", MySqlDbType.Int32).Value = ordspecCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "INSERT INTO `order` VALUES (@idorder, @status, @dateTime, @quantity, @material)";
                command.Parameters.Add("@idorder", MySqlDbType.Int32).Value = orderCount.Count + 1;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Создан";
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = QuantityUpDown.Value;
                command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@material", MySqlDbType.Int32).Value = materialCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            else if (MaterialUpDown.Value == 12)
            {
                command.CommandText = "insert into ordspec_structure values (@id1, 1, @quantity1, @specID, @matID1);";
                command.Parameters.Add("@id1", MySqlDbType.Int32).Value = specStrucCount.Count + 1;
                command.Parameters.Add("@id2", MySqlDbType.Int32).Value = specStrucCount.Count + 2;
                command.Parameters.Add("@id3", MySqlDbType.Int32).Value = specStrucCount.Count + 3;
                command.Parameters.Add("@id4", MySqlDbType.Int32).Value = specStrucCount.Count + 4;
                command.Parameters.Add("@id5", MySqlDbType.Int32).Value = specStrucCount.Count + 5;
                command.Parameters.Add("@id6", MySqlDbType.Int32).Value = specStrucCount.Count + 6;
                command.Parameters.Add("@quantity1", MySqlDbType.Int32).Value = ModifiedUpDown1.Value;
                command.Parameters.Add("@quantity2", MySqlDbType.Int32).Value = ModifiedUpDown2.Value;
                command.Parameters.Add("@quantity3", MySqlDbType.Int32).Value = ModifiedUpDown3.Value;
                command.Parameters.Add("@quantity4", MySqlDbType.Int32).Value = ModifiedUpDown4.Value;
                command.Parameters.Add("@quantity5", MySqlDbType.Int32).Value = ModifiedUpDown5.Value;
                command.Parameters.Add("@quantity6", MySqlDbType.Int32).Value = ModifiedUpDown6.Value;
                command.Parameters.Add("@specID", MySqlDbType.Int32).Value = specCount.Count;
                command.Parameters.Add("@matID1", MySqlDbType.Int32).Value = 1;
                command.Parameters.Add("@matID2", MySqlDbType.Int32).Value = 2;
                command.Parameters.Add("@matID3", MySqlDbType.Int32).Value = 3;
                command.Parameters.Add("@matID4", MySqlDbType.Int32).Value = 13;
                command.Parameters.Add("@matID5", MySqlDbType.Int32).Value = 14;
                command.Parameters.Add("@matID6", MySqlDbType.Int32).Value = 15;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id2, 2, @quantity2, @specID, @matID2)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id3, 3, @quantity3, @specID, @matID3)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id4, 4, @quantity4, @specID, @matID4)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id5, 5, @quantity5, @specID, @matID5)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id6, 6, @quantity6, @specID, @matID6)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into order_specification values (@id, @description, @Spec_ID)";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = ordspecCount.Count + 1;
                command.Parameters.Add("@description", MySqlDbType.VarChar).Value = "Электрическое оборудование";
                command.Parameters.Add("@Spec_ID", MySqlDbType.Int32).Value = 4;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into material values (@idmat, @description, @Spec_ID, @Map_ID, @OrdSpec_ID)";
                command.Parameters.Add("@idmat", MySqlDbType.Int32).Value = materialCount.Count + 1;
                command.Parameters.Add("@Map_ID", MySqlDbType.Int32).Value = 4;
                command.Parameters.Add("@OrdSpec_ID", MySqlDbType.Int32).Value = ordspecCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "INSERT INTO `order` VALUES (@idorder, @status, @dateTime, @quantity, @material)";
                command.Parameters.Add("@idorder", MySqlDbType.Int32).Value = orderCount.Count + 1;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Создан";
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = QuantityUpDown.Value;
                command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@material", MySqlDbType.Int32).Value = materialCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            else if (MaterialUpDown.Value == 18)
            {
                command.CommandText = "insert into ordspec_structure values (@id1, 1, @quantity1, @specID, @matID1);";
                command.Parameters.Add("@id1", MySqlDbType.Int32).Value = specStrucCount.Count + 1;
                command.Parameters.Add("@id2", MySqlDbType.Int32).Value = specStrucCount.Count + 2;
                command.Parameters.Add("@quantity1", MySqlDbType.Int32).Value = ModifiedUpDown1.Value;
                command.Parameters.Add("@quantity2", MySqlDbType.Int32).Value = ModifiedUpDown2.Value;
                command.Parameters.Add("@specID", MySqlDbType.Int32).Value = specCount.Count;
                command.Parameters.Add("@matID1", MySqlDbType.Int32).Value = 16;
                command.Parameters.Add("@matID2", MySqlDbType.Int32).Value = 17;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id2, 2, @quantity2, @specID, @matID2)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into order_specification values (@id, @description, @Spec_ID)";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = ordspecCount.Count + 1;
                command.Parameters.Add("@description", MySqlDbType.VarChar).Value = "Система охлаждения";
                command.Parameters.Add("@Spec_ID", MySqlDbType.Int32).Value = 5;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into material values (@idmat, @description, @Spec_ID, @Map_ID, @OrdSpec_ID)";
                command.Parameters.Add("@idmat", MySqlDbType.Int32).Value = materialCount.Count + 1;
                command.Parameters.Add("@Map_ID", MySqlDbType.Int32).Value = 3;
                command.Parameters.Add("@OrdSpec_ID", MySqlDbType.Int32).Value = ordspecCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "INSERT INTO `order` VALUES (@idorder, @status, @dateTime, @quantity, @material)";
                command.Parameters.Add("@idorder", MySqlDbType.Int32).Value = orderCount.Count + 1;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Создан";
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = QuantityUpDown.Value;
                command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@material", MySqlDbType.Int32).Value = materialCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            else if (MaterialUpDown.Value == 9)
            {
                command.CommandText = "insert into ordspec_structure values (@id1, 1, @quantity1, @specID, @matID1);";
                command.Parameters.Add("@id1", MySqlDbType.Int32).Value = specStrucCount.Count + 1;
                command.Parameters.Add("@id2", MySqlDbType.Int32).Value = specStrucCount.Count + 2;
                command.Parameters.Add("@id3", MySqlDbType.Int32).Value = specStrucCount.Count + 3;
                command.Parameters.Add("@id4", MySqlDbType.Int32).Value = specStrucCount.Count + 4;
                command.Parameters.Add("@quantity1", MySqlDbType.Int32).Value = ModifiedUpDown1.Value;
                command.Parameters.Add("@quantity2", MySqlDbType.Int32).Value = ModifiedUpDown2.Value;
                command.Parameters.Add("@quantity3", MySqlDbType.Int32).Value = ModifiedUpDown3.Value;
                command.Parameters.Add("@quantity4", MySqlDbType.Int32).Value = ModifiedUpDown4.Value;
                command.Parameters.Add("@specID", MySqlDbType.Int32).Value = specCount.Count;
                command.Parameters.Add("@matID1", MySqlDbType.Int32).Value = 7;
                command.Parameters.Add("@matID2", MySqlDbType.Int32).Value = 8;
                command.Parameters.Add("@matID3", MySqlDbType.Int32).Value = 12;
                command.Parameters.Add("@matID4", MySqlDbType.Int32).Value = 18;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id2, 2, @quantity2, @specID, @matID2)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id3, 3, @quantity3, @specID, @matID3)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into ordspec_structure values (@id4, 4, @quantity4, @specID, @matID4)";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into order_specification values (@id, @description, @Spec_ID)";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = ordspecCount.Count + 1;
                command.Parameters.Add("@description", MySqlDbType.VarChar).Value = "Микроволновая печь";
                command.Parameters.Add("@Spec_ID", MySqlDbType.Int32).Value = 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "insert into material values (@idmat, @description, @Spec_ID, @Map_ID, @OrdSpec_ID)";
                command.Parameters.Add("@idmat", MySqlDbType.Int32).Value = materialCount.Count + 1;
                command.Parameters.Add("@Map_ID", MySqlDbType.Int32).Value = 1;
                command.Parameters.Add("@OrdSpec_ID", MySqlDbType.Int32).Value = ordspecCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "INSERT INTO `order` VALUES (@idorder, @status, @dateTime, @quantity, @material)";
                command.Parameters.Add("@idorder", MySqlDbType.Int32).Value = orderCount.Count + 1;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = "Создан";
                command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = QuantityUpDown.Value;
                command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@material", MySqlDbType.Int32).Value = materialCount.Count + 1;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            MessageBox.Show("Заказ успешно оформлен", "Оформление заказа");
            MainForm mainForm = new MainForm();
            mainForm.Activate();
            return;
        }
    }
}
