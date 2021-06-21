using System;
using System.Collections.Generic;
using System.Data;
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
            FinishOrderIDLabel.Visible = false;
            FinishOrderUpDown.Visible = false;
            FinishOrderButton.Visible = false;
        }

        private void DisplayTableStorage_Click(object sender, EventArgs e)
        {
            FinishOrderIDLabel.Visible = false;
            FinishOrderUpDown.Visible = false;
            FinishOrderButton.Visible = false;
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
            FinishOrderIDLabel.Visible = false;
            FinishOrderUpDown.Visible = false;
            FinishOrderButton.Visible = false;
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
            FinishOrderIDLabel.Visible = false;
            FinishOrderUpDown.Visible = false;
            FinishOrderButton.Visible = false;
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
            FinishOrderIDLabel.Visible = false;
            FinishOrderUpDown.Visible = false;
            FinishOrderButton.Visible = false;
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
            FinishOrderIDLabel.Visible = false;
            FinishOrderUpDown.Visible = false;
            FinishOrderButton.Visible = false;
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
            else if (TableName.Text == "Журнал работы")
                DisplayWorkLog();
            else if (TableName.Text == "Журнал использования")
                DisplayUsedLog();
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

        private void DisplayWorkLog()
        {
            FinishOrderIDLabel.Visible = true;
            FinishOrderUpDown.Visible = true;
            FinishOrderButton.Visible = true;
            MySqlCommand command = new MySqlCommand("SELECT * FROM work_log");
            TableGridView.Rows.Clear();
            TableGridView.Columns.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            TableGridView.Columns.Add("Note_Num", "Номер записи");
            TableGridView.Columns.Add("Ord_ID", "ID Заказа");
            TableGridView.Columns.Add("Oper_ID", "ID Операции");
            TableGridView.Columns.Add("Map_ID", "ID Техкарты");
            TableGridView.Columns.Add("Fact_ID", "ID РЦ");
            TableGridView.Columns.Add("Mat_ID", "ID Номенклатуры");
            TableGridView.Columns.Add("Work_Time", "Потраченное время");
            TableGridView.Columns.Add("Exit_Quantity", "Количество выпуска");
            TableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            while (reader.Read())
                TableGridView.Rows.Add(reader["Note_Num"].ToString(), reader["Ord_ID"].ToString(),
                    reader["Oper_ID"].ToString(), reader["Map_ID"].ToString(),
                    reader["Fact_ID"].ToString(), reader["Mat_ID"].ToString(),
                    reader["Work_Time"].ToString(), reader["Exit_Quantity"].ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            TableName.Text = "Журнал работы";
        }

        private void DisplayUsedLog()
        {
            FinishOrderIDLabel.Visible = true;
            FinishOrderUpDown.Visible = true;
            FinishOrderButton.Visible = true;
            MySqlCommand command = new MySqlCommand("SELECT * FROM used_log");
            TableGridView.Rows.Clear();
            TableGridView.Columns.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            TableGridView.Columns.Add("Note_Num", "Номер записи");
            TableGridView.Columns.Add("Ord_ID", "ID Заказа");
            TableGridView.Columns.Add("Mat_ID", "ID Номенклатуры");
            TableGridView.Columns.Add("Used_Quantity", "Количество использованных");
            TableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            while (reader.Read())
                TableGridView.Rows.Add(reader["Note_Num"].ToString(), reader["Ord_ID"].ToString(),
                    reader["Mat_ID"].ToString(), reader["Used_Quantity"].ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            TableName.Text = "Журнал использования";
        }

        private void WorkLogButton_Click(object sender, EventArgs e)
        {
            DisplayWorkLog();
        }

        private void UsedLogButton_Click(object sender, EventArgs e)
        {
            DisplayUsedLog();
        }

        private void FinishOrderButton_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("select Ord_ID from `order` where Ord_Status = @statusInFactoring");
            command.Parameters.Add("@statusInFactoring", MySqlDbType.VarChar).Value = "В производстве";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            List<string> orderFactoring = new List<string>();
            while (reader.Read())
                orderFactoring.Add(reader.GetInt32("Ord_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();

            if (orderFactoring.Contains(FinishOrderUpDown.Value.ToString()))
            {
                command.CommandText = "select * from work_log where Ord_ID = @idFinishing";
                command.Parameters.Add("@idFinishing", MySqlDbType.Int32).Value = FinishOrderUpDown.Value;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int factIDFinishing = -1;
                while (reader.Read())
                    factIDFinishing = reader.GetInt32("Fact_ID");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select * from work_log where Ord_ID = @idFinishing";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int workTimeFinishing = -1;
                while (reader.Read())
                    workTimeFinishing = reader.GetInt32("Work_Time");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select * from work_log where Ord_ID = @idFinishing";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int exitQuantity = -1;
                while (reader.Read())
                    exitQuantity = reader.GetInt32("Exit_Quantity");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select * from work_log where Ord_ID = @idFinishing";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int matIDFinishing = -1;
                while (reader.Read())
                    matIDFinishing = reader.GetInt32("Mat_ID");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select * from used_log where Ord_ID = @idFinishing";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> matIDUsed = new List<int>();
                while (reader.Read())
                    matIDUsed.Add(reader.GetInt32("Mat_ID"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select * from used_log where Ord_ID = @idFinishing";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> matQuantityUsed = new List<int>();
                while (reader.Read())
                    matQuantityUsed.Add(reader.GetInt32("Used_Quantity"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();


                List<int> matQuantitySelected = new List<int>();
                for (int i = 0; i < matIDUsed.Count; i++)
                {
                    command.CommandText = "select * from consist where Mat_ID = @selectUsedID" + i + "";
                    command.Parameters.Add("@selectUsedID" + i + "", MySqlDbType.Int32).Value = matIDUsed[i];
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    command.Connection = connection;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                        matQuantitySelected.Add(reader.GetInt32("Cont_Quantity"));
                    reader.Close();
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }

                command.CommandText = "select * from factory where Fact_ID = @factIDfromFactory";
                command.Parameters.Add("@factIDfromFactory", MySqlDbType.Int32).Value = factIDFinishing;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int factTimeFromFactory = -1;
                while (reader.Read())
                    factTimeFromFactory = reader.GetInt32("Fact_Time");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                bool notEnoughTime = false;
                if (factTimeFromFactory < workTimeFinishing)
                    notEnoughTime = true;

                if (notEnoughTime)
                {
                    MessageBox.Show("Оставшегося времени работы на РЦ недостаточно. Невозможно завершить производство заказа", "Ошибка!");
                    return;
                }

                bool notEnoughMat = false;
                for (int i = 0; i < matIDUsed.Count; i++)
                    if (matQuantitySelected[i] < matQuantityUsed[i])
                        notEnoughMat = true;

                if (notEnoughMat)
                {
                    MessageBox.Show("Недостаточно номенклатуры на складе. Невозможно завершить производство заказа", "Ошибка!");
                    return;
                }

                for (int i = 0; i < matIDUsed.Count; i++)
                {
                    command.CommandText = "Update consist set Cont_Quantity = @minusUsedQuantity" + i + " where Mat_ID = @minusUsedID" + i + "";
                    command.Parameters.Add("@minusUsedQuantity" + i + "", MySqlDbType.Int32).Value = (matQuantitySelected[i] - matQuantityUsed[i]);
                    command.Parameters.Add("@minusUsedID" + i + "", MySqlDbType.Int32).Value = matIDUsed[i];
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }

                command.CommandText = "select * from consist where Mat_ID = @materialIDFinishing";
                command.Parameters.Add("@materialIDFinishing", MySqlDbType.Int32).Value = matIDFinishing;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int matQuantityFinishing = -1;
                while (reader.Read())
                    matQuantityFinishing = reader.GetInt32("Cont_Quantity");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "Update consist set Cont_Quantity = @plusExitQuantity where Mat_ID = @plusExitID";
                command.Parameters.Add("@plusExitQuantity", MySqlDbType.Int32).Value = matQuantityFinishing+exitQuantity;
                command.Parameters.Add("@plusExitID", MySqlDbType.Int32).Value = matIDFinishing;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "Update factory set Fact_Time = @newFactTime where Fact_ID = @factIDfromFactory";
                command.Parameters.Add("@newFactTime", MySqlDbType.Int32).Value = factTimeFromFactory - workTimeFinishing;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "Update `order` set Ord_Status = @statusFinishing where Ord_ID = @idFinishing";
                command.Parameters.Add("@statusFinishing", MySqlDbType.VarChar).Value = "Готов";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            else
            {
                MessageBox.Show("Введенный ID некорректен. Заказ должен иметь статус «В производстве»", "Ошибка!");
                return;
            }
            MessageBox.Show("Заказ успешно произведен", "Производственный заказ");
            MainForm mainForm = new MainForm();
            mainForm.Activate();
            return;
        }
    }
}
