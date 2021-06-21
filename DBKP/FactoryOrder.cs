using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBKP
{
    public partial class FactoryOrder : Form
    {
        public FactoryOrder()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=databasekp");
        MySqlDataReader reader;
        List<string> ordIDList = new List<string>();

        private void OrderIDListFilling()
        {
            MySqlCommand command = new MySqlCommand();
            ordIDList.Clear();
            command.CommandText = "select * from `order` where Ord_Status = @statuscreated";
            command.Parameters.Add("@statuscreated", MySqlDbType.VarChar).Value = "Создан";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            while (reader.Read())
                ordIDList.Add(reader.GetInt32("Ord_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        private void StartFactoringButton_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand();
            OrderIDListFilling();
            if (ordIDList.Contains(OrderIDUpDown.Value.ToString()))
            {
                command.CommandText = "Update `order` set Ord_Status = @statusfactoring where Ord_ID = @idfactoring";
                command.Parameters.Add("@idfactoring", MySqlDbType.Int32).Value = OrderIDUpDown.Value;
                command.Parameters.Add("@statusfactoring", MySqlDbType.VarChar).Value = "В производстве";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select Mat_ID from `order` where Ord_ID = @idfactoring";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int orderMatID = -1;
                while (reader.Read())
                    orderMatID = reader.GetInt32("Mat_ID");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select Ord_Quantity from `order` where Ord_ID = @idfactoring";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int orderQuantity = -1;
                while (reader.Read())
                    orderQuantity = reader.GetInt32("Ord_Quantity");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select Map_ID from material where Mat_ID = @ordMatID";
                command.Parameters.Add("@ordMatID", MySqlDbType.Int32).Value = orderMatID;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int matMapID = -1;
                while (reader.Read())
                    matMapID = reader.GetInt32("Map_ID");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select ordspec_ID from material where Mat_ID = @ordMatID";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int matOrdSpecID = -1;
                while (reader.Read())
                    matOrdSpecID = reader.GetInt32("ordspec_ID");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select * from map_structure where map_ID = @ordMapID";
                command.Parameters.Add("@ordMapID", MySqlDbType.Int32).Value = matMapID;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> mapOperTimeList = new List<int>();
                while (reader.Read())
                    mapOperTimeList.Add(reader.GetInt32("Oper_Time"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select * from map_structure where map_ID = @ordMapID";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> mapFactIDList = new List<int>();
                while (reader.Read())
                    mapFactIDList.Add(reader.GetInt32("Fact_ID"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select * from map_structure where map_ID = @ordMapID";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> mapOperIDList = new List<int>();
                while (reader.Read())
                    mapOperIDList.Add(reader.GetInt32("Oper_ID"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select OrdSpecStruc_Quantity from ordspec_structure where ordspec_ID = @ordspecquantitymatID";
                command.Parameters.Add("@ordspecquantitymatID", MySqlDbType.Int32).Value = matOrdSpecID;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> ordSpecQuantityList = new List<int>();
                while (reader.Read())
                    ordSpecQuantityList.Add(reader.GetInt32("OrdSpecStruc_Quantity"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select Mat_ID from ordspec_structure where ordspec_ID = @ordspecquantitymatID";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> ordSpecMatIDList = new List<int>();
                while (reader.Read())
                    ordSpecMatIDList.Add(reader.GetInt32("Mat_ID"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select Note_Num from work_log";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> worklogNoteNumCount = new List<int>();
                while (reader.Read())
                    worklogNoteNumCount.Add(reader.GetInt32("Note_Num"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                //int factTimeSUM = 0;
                //for (int i = 0; i < mapOperTimeList.Count; i++)
                //    factTimeSUM += mapOperTimeList[i] * orderQuantity;

                command.CommandText = "insert into work_log values (@workLogNoteNum, @workLogOrdID, @workLogOperID, @worklogMapID, @workLogFactID, @workLogMatID, @workLogWorkTime, @workLogExitQuantity)";
                command.Parameters.Add("@workLogNoteNum", MySqlDbType.Int32).Value = worklogNoteNumCount.Count + 1;
                command.Parameters.Add("@workLogOrdID", MySqlDbType.Int32).Value = OrderIDUpDown.Value;
                command.Parameters.Add("@workLogOperID", MySqlDbType.Int32).Value = mapOperIDList[mapOperIDList.Count-1];
                command.Parameters.Add("@worklogMapID", MySqlDbType.Int32).Value = matMapID;
                command.Parameters.Add("@workLogFactID", MySqlDbType.Int32).Value = mapFactIDList[mapFactIDList.Count-1];
                command.Parameters.Add("@workLogMatID", MySqlDbType.Int32).Value = orderMatID;
                command.Parameters.Add("@workLogWorkTime", MySqlDbType.Int32).Value = mapOperIDList[mapOperIDList.Count-1]*orderQuantity;
                command.Parameters.Add("@workLogExitQuantity", MySqlDbType.Int32).Value = orderQuantity;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                command.CommandText = "select Note_Num from used_log";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                List<int> usedlogNoteNumCount = new List<int>();
                while (reader.Read())
                    usedlogNoteNumCount.Add(reader.GetInt32("Note_Num"));
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                for (int i = 0; i < ordSpecMatIDList.Count; i++)
                {
                    command.CommandText = "insert into used_log values (@usedLogNoteNum" + i + ", @usedLogOrdID" + i + ", @usedLogMatID" + i + ", @usedLogMatQuantity" + i + ")";
                    command.Parameters.Add("@usedLogNoteNum" + i + "", MySqlDbType.Int32).Value = usedlogNoteNumCount.Count + (i + 1);
                    command.Parameters.Add("@usedLogOrdID" + i + "", MySqlDbType.Int32).Value = OrderIDUpDown.Value;
                    command.Parameters.Add("@usedLogMatID" + i + "", MySqlDbType.Int32).Value = ordSpecMatIDList[i];
                    command.Parameters.Add("@usedLogMatQuantity" + i + "", MySqlDbType.Int32).Value = ordSpecQuantityList[i]*orderQuantity;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Введенный ID некорректен. Заказ должен иметь статус «Создан»", "Ошибка!");
                return;
            }
            MessageBox.Show("Заказ успешно запущен в производство", "Производственный заказ");
            MainForm mainForm = new MainForm();
            mainForm.Activate();
            return;
        }

        private void CloseOrderButton_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand();
            OrderIDListFilling();
            if (ordIDList.Contains(OrderIDUpDown.Value.ToString()))
            {
                command.CommandText = "Update `order` set Ord_Status = @statusclosed where Ord_ID = @idclosed";
                command.Parameters.Add("@idclosed", MySqlDbType.Int32).Value = OrderIDUpDown.Value;
                command.Parameters.Add("@statusclosed", MySqlDbType.VarChar).Value = "Закрыт";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                MessageBox.Show("Заказ успешно закрыт", "Закрытие заказа");
                MainForm mainForm = new MainForm();
                mainForm.Activate();
                return;
            }
            else
            {
                MessageBox.Show("Введенный ID некорректен. Заказ должен иметь статус «Создан»", "Ошибка!");
                return;
            }
        }
    }
}
