using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Data_Base
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Global Varaibles
        string PasswordHash;

        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\RABBIT HOLE\YEAR 2\1st SEMESTER\CMPG215\Encryption Project\Encryption Project - Parts\String Encryption\Database\Data_Base\Data_Base.mdf"";Integrated Security=True");
        SqlCommand Command;
        SqlDataAdapter Adapter;
        DataSet DS;

        private void LoadAll()
        {
            try
            {
                Connection.Open();

                SqlCommand Command = new SqlCommand(@"SELECT * FROM tbInfo", Connection);
                DS = new DataSet();
                Adapter = new SqlDataAdapter();

                Adapter.SelectCommand = Command;
                Adapter.Fill(DS, "tbInfo");

                dataGridView.DataSource = DS;
                dataGridView.DataMember = "tbInfo";

                Connection.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void InsertNew()
        {
            Connection.Open();

            String Query = "INSERT INTO tbInfo (Name, Email, Password) VALUES (@name,@email,@passwordhash)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@name", (txtName.Text));
            Command.Parameters.AddWithValue("@email", (txtEmail.Text));
            Command.Parameters.AddWithValue("@passwordhash",(PasswordHash));

            Command.ExecuteNonQuery();

            Connection.Close();

            MessageBox.Show("New Record Added");

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            

            if (txtPassword.Text == txtConfrimPassword.Text)
            {
                PasswordHash = Utilities.hashPassword(txtPassword.Text);
                InsertNew();
                LoadAll();
            }
            else
            {
                MessageBox.Show("Passwords don't match!");
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }


    }
}
