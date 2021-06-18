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
    public partial class RemoveMaterial : Form
    {
        public RemoveMaterial()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=databasekp");
        MySqlDataReader reader;

        private void RemovingMaterialButton_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "Select * from consist";
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.Connection = connection;
            reader = command.ExecuteReader();
            List<string> materialIDList = new List<string>();
            while (reader.Read())
                materialIDList.Add(reader.GetInt32("Mat_ID").ToString());
            reader.Close();
            if (connection.State != ConnectionState.Closed)
                connection.Close();

            if (materialIDList.Contains(MaterialIDUpDown.Value.ToString()))
            {
                command.CommandText = "Select * from consist where Mat_ID = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = MaterialIDUpDown.Value;
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.Connection = connection;
                reader = command.ExecuteReader();
                int quantityMat = 0;
                while (reader.Read())
                    quantityMat = reader.GetInt32("Cont_Quantity");
                reader.Close();
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                if (quantityMat >= QuantityUpDown.Value)
                {
                    command.CommandText = "UPDATE consist set Cont_Quantity = @quantity where Mat_ID = @id";
                    command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantityMat - QuantityUpDown.Value;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                    MessageBox.Show("Списание успешно выполнено", "Списание позиций");
                    MainForm mainForm = new MainForm();
                    mainForm.Activate();
                    return;
                }
                else
                {
                    MessageBox.Show("На складе содержится меньшее количество номенклатуры, чем требуется списать", "Ошибка!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("ID Номенклатуры некорректен", "Ошибка!");
                return;
            }
        }
    }
}
