using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBKP
{
    public partial class ManageFactory : Form
    {
        public ManageFactory()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=databasekp");
        MySqlDataReader reader;

        private void ConfirmChangesButton_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "Select * from factory";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            List<string> factoryIDList = new List<string>();
            while (reader.Read())
                factoryIDList.Add(reader.GetInt32("Fact_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();

            if (factoryIDList.Contains(FactoryIDUpDown.Value.ToString()))
            {
                command.CommandText = "UPDATE factory set Fact_Status = @status, Fact_Time = @time where Fact_ID = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = FactoryIDUpDown.Value;
                command.Parameters.Add("@status", MySqlDbType.VarChar).Value = FactoryStatusTextBox.Text;
                command.Parameters.Add("@time", MySqlDbType.Int32).Value = FactoryTimeUpDown.Value;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                MessageBox.Show("Изменения успешно внесены", "Управление РЦ");
                MainForm mainForm = new MainForm();
                mainForm.Activate();
                return;
            }
            else
            {
                MessageBox.Show("Введенный ID некорректен", "Ошибка!");
                return;
            }
        }
    }
}
