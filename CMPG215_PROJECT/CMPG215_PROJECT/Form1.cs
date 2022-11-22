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
using System.Security.Cryptography;
using System.IO;

namespace CMPG215_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            key = generateKey();
        }

        //GLOBAL VARIABLES
        string str;
        string PasswordHash;
        string key;

        //Connection for the database
        //Attach your own connection string on the SQL Connection (example new SqlConnection = (@"Connection String ");)
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\GIVEN MNISI\Downloads\CMPG215_PROJECT\CMPG215_PROJECT\InfoDB.mdf"";Integrated Security=True");
        
        SqlCommand Command;
        SqlDataAdapter Adapter;
        DataSet DS;

        //METHODS
        private string generateKey()
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }

        //Method for loading the database
        private void LoadAll()
        {
            try
            {
                Connection.Open();

                SqlCommand Command = new SqlCommand(@"SELECT * FROM InfoTB", Connection);
                DS = new DataSet();
                Adapter = new SqlDataAdapter();

                Adapter.SelectCommand = Command;
                Adapter.Fill(DS, "InfoTB");

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

            String Query = "INSERT INTO InfoTB (Name, Email, Password) VALUES (@name,@email,@passwordhash)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@name", (txtName.Text));
            Command.Parameters.AddWithValue("@email", (txtEmail.Text));
            Command.Parameters.AddWithValue("@passwordhash", (PasswordHash));

            Command.ExecuteNonQuery();

            Connection.Close();

            MessageBox.Show("New Record Added");
        }

        /*
           SELF CREATED ALGORITHM 
         * SELF GENERATED ALGORITHM STEPS

            Step1: Swap the first letter with the last letter in the string and store it in newString.   || eg. James becomes sameJ

            Step2: Reverse the newString.    || e.g sameJ becomes Jemas

            Step3: Move each character in the string 3 spaces up on the ASCII Table.
        */

        // Method that completes Step 1: Swap the first letter with the last letter in the string and store it in newString. (example. James becomes sameJ)
        private static string Swap(String str) 
        {
          
            int ifirstPosition, ilastPosition, Temp;
            string newStr, smidparts, sfirstPosition, slastPosition;

            ifirstPosition = 0;                                     //Index of first Letter
            ilastPosition = str.Length - 1;                         //Index of last Letter
            smidparts = str.Substring(1, ilastPosition - 1);

            //Swapping first and last letter
            Temp = ifirstPosition;
            ifirstPosition = ilastPosition;
            ilastPosition = Temp;

            //Getting first and last letter form the string
            sfirstPosition = str.Substring(ifirstPosition, 1);
            slastPosition = str.Substring(ilastPosition, 1);

            newStr = sfirstPosition + smidparts + slastPosition;

            return newStr;
        }

        // Method that completes Step 2: Reverse the newString.  (example. sameJ becomes Jemas)
        private static string ReverseString(String input) 
        {
            string ReversedStr = "";

            //for to reverses string
            for (int i = input.Length - 1; i >= 0; i--)     
            {
                ReversedStr += input[i];
            }
            return ReversedStr;
        }

        // Method that completes Step3: Move each character in the newString 3 spaces up on the ASCII Table. (example. Jemas becomes Mhpdv)
        private static string EncrytedStr(string str) 
        {
            //Array that converts newString from step 2 into characters
            char[] arr = str.ToCharArray(); 

            string newStr = ""; 
            char CharInArray, newCharInArray;
            int ASCIIvalue, newASCIIvalue;

            //For loop for moving characters 3 spaces up on the ASCII Table and turning array into one string.  
            for (int i = 0; i < str.Length; i++) 
            {
                CharInArray = arr[i];

                ASCIIvalue = (char)CharInArray;

                newASCIIvalue = ASCIIvalue + 3; // Moving Characters

                newCharInArray = (char)newASCIIvalue;

                // Turning array new charaters into one string.
                newStr += newCharInArray; 
            }
            return newStr; 
        }

        //Same as the encryption
        private static string DecrytedStr(string str)
        {
            char[] arr = str.ToCharArray();

            string newStr = ""; 
            char CharInArray, newCharInArray;
            int ASCIIvalue, newASCIIvalue;

            for (int i = 0; i < str.Length; i++) 
            {
                CharInArray = arr[i];

                ASCIIvalue = (char)CharInArray;

                newASCIIvalue = ASCIIvalue - 3; 

                newCharInArray = (char)newASCIIvalue;

                newStr += newCharInArray; 
            }
            return newStr; 
        }

        //RAR FILE 
        private void encrypt(string input, string output, string hash)
        {
            FileStream inStream, outStream;
            CryptoStream cryStream;

            TripleDESCryptoServiceProvider tdc = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteTexto;

            inStream = new FileStream(input, FileMode.Open, FileAccess.Read);
            outStream = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);

            byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(hash));
            byteTexto = File.ReadAllBytes(input);

            md5.Clear();

            tdc.Key = byteHash;
            tdc.Mode = CipherMode.ECB;

            cryStream = new CryptoStream(outStream, tdc.CreateEncryptor(), CryptoStreamMode.Write);

            int byteRead;
            long length, position = 0;
            length = inStream.Length;

            while (position < length)
            {
                byteRead = inStream.Read(byteTexto, 0, byteTexto.Length);
                position += byteRead;

                cryStream.Write(byteTexto, 0, byteRead);
            }

            inStream.Close();
            outStream.Close();
        }
        private void decrypt(string input, string output, string hash)
        {
            FileStream inStream, outStream;
            CryptoStream cryStream;

            TripleDESCryptoServiceProvider tdc = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteTexto;

            inStream = new FileStream(input, FileMode.Open, FileAccess.Read);
            outStream = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);

            byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(hash));
            byteTexto = File.ReadAllBytes(input);

            md5.Clear();

            tdc.Key = byteHash;
            tdc.Mode = CipherMode.ECB;

            cryStream = new CryptoStream(outStream, tdc.CreateDecryptor(), CryptoStreamMode.Write);

            int byteRead;
            long length, position = 0;
            length = inStream.Length;

            while (position < length)
            {
                byteRead = inStream.Read(byteTexto, 0, byteTexto.Length);
                position += byteRead;

                cryStream.Write(byteTexto, 0, byteRead);
            }
            inStream.Close();
            outStream.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //If the user does not enter anything (Name, Email and Password) it shows a message box
            if(txtName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Field Required!");
            }
            else
            {
                //Comparing the two password (Password & Verify password)
                if (txtPassword.Text == txtPasswordVerify.Text)
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
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            {
                //Checkbox for showing the password 
                if (cbShowPassword.Checked)
                {
                    txtPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clears the fields entered by the user
            txtName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPasswordVerify.Clear();
        }

        private void btnEncryptT_Click(object sender, EventArgs e)
        {
            string Entered_Password, Database_Password;

            Entered_Password = Utilities.hashPassword(txtPasswordT.Text);

            string sql = "SELECT * FROM InfoTB WHERE Name Like'%" + txtNameT.Text + "%'";
            Command = new SqlCommand(sql, Connection);
            Connection.Open();

            using (SqlDataReader Reader = Command.ExecuteReader())
            {
                if(Reader.Read())
                {
                    // Retrieving database password and storing it in a variable.
                    Database_Password = Reader["Password"].ToString(); 

                    //Check if passwords match (Password hash & Password entered)
                    if(Database_Password == Entered_Password)
                    {
                        str = txtEncryptT.Text;
                        txtEncryptedT.Text = EncrytedStr(ReverseString(Swap(str)));
                    }
                    else 
                    {
                        MessageBox.Show("Invalid credentials!");
                    }
                }
            }
            Connection.Close();
        }

        private void btnDecryptT_Click(object sender, EventArgs e)
        {
            //Same as the encryption method
            string Entered_Password, Database_Password;
            Entered_Password = Utilities.hashPassword(txtPasswordT.Text);

            string sql = "SELECT * FROM InfoTB WHERE Name Like'%" + txtNameT.Text + "%'";
            Command = new SqlCommand(sql, Connection);
            Connection.Open();

            using (SqlDataReader Reader = Command.ExecuteReader())
            {
                if (Reader.Read())
                {
                    Database_Password = Reader["Password"].ToString(); 
                    
                    if (Database_Password == Entered_Password)
                    {
                        Connection.Close();
                        try
                        {
                            str = txtDecryptT.Text;

                            string x, y, DecryptedString = "";
                            x = DecrytedStr(str);
                            y = ReverseString(x);
                            DecryptedString = Swap(y);

                            txtDecryptedT.Text = DecryptedString;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Invalid input");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials!");
                    }
                }
            }
        }

        private void btnEncryptR_Click(object sender, EventArgs e)
        {

            string Entered_Password, Database_Password;

            Entered_Password = Utilities.hashPassword(txtPasswordR.Text);

            string sql = "SELECT * FROM InfoTB WHERE Name Like'%" + txtNameR.Text + "%'";
            Command = new SqlCommand(sql, Connection);
            Connection.Open();

            using (SqlDataReader Reader = Command.ExecuteReader())
            {
                if (Reader.Read())
                {
                    Database_Password = Reader["Password"].ToString(); 
                    if (Database_Password == Entered_Password)
                    {
                        OpenFileDialog Open = new OpenFileDialog();
                        Open.ShowDialog();

                        txtRarE.Text = Open.FileName;

                        SaveFileDialog Save = new SaveFileDialog();
                        Save.ShowDialog();

                        txtEncryptedR.Text = Save.FileName;

                        encrypt(txtRarE.Text, txtEncryptedR.Text, key);
                        MessageBox.Show("RAR File Successfully Encrypted!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials!");
                    }
                }
            }
            Connection.Close();
        }
        private void btnDecryptR_Click(object sender, EventArgs e)
        {
            string Entered_Password, Database_Password;

            Entered_Password = Utilities.hashPassword(txtPasswordR.Text);

            string sql = "SELECT * FROM InfoTB WHERE Name Like'%" + txtNameR.Text + "%'";
            Command = new SqlCommand(sql, Connection);
            Connection.Open();

            using (SqlDataReader Reader = Command.ExecuteReader())
            {
                if (Reader.Read())
                {

                    Database_Password = Reader["Password"].ToString(); 

                    if (Database_Password == Entered_Password)
                    {
                        OpenFileDialog Open = new OpenFileDialog();
                        Open.ShowDialog();

                        txtRarD.Text = Open.FileName;

                        SaveFileDialog Save = new SaveFileDialog();
                        Save.ShowDialog();

                        txtDecryptedR.Text = Save.FileName;

                        decrypt(txtRarD.Text, txtDecryptedR.Text, key);
                        MessageBox.Show("RAR File Successfully Decrypted!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials!");
                    }
                }
            }
            Connection.Close();  
        }


        private void btnEncryptI_Click(object sender, EventArgs e)
        {
            string Entered_Password, Database_Password;

            Entered_Password = Utilities.hashPassword(txtPassWordI.Text);

            string sql = "SELECT * FROM InfoTB WHERE Name Like'%" + txtNameI.Text + "%'";
            Command = new SqlCommand(sql, Connection);
            Connection.Open();

            using (SqlDataReader Reader = Command.ExecuteReader())
            {
                if (Reader.Read())
                {
                    Database_Password = Reader["Password"].ToString(); 

                    if (Database_Password == Entered_Password)
                    {
                        OpenFileDialog Open = new OpenFileDialog();
                        Open.ShowDialog();

                        txtImageE.Text = Open.FileName;

                        SaveFileDialog Save = new SaveFileDialog();
                        Save.ShowDialog();

                        txtEncryptedI.Text = Save.FileName;

                        encrypt(txtImageE.Text, txtEncryptedI.Text, key);
                        MessageBox.Show("Image Successfully Encrypted");
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials!");
                    }
                }
            }
            Connection.Close();
        }

        private void btnDecryptI_Click(object sender, EventArgs e)
        {
             string Entered_Password, Database_Password;

            Entered_Password = Utilities.hashPassword(txtPassWordI.Text);

            string sql = "SELECT * FROM InfoTB WHERE Name Like'%" + txtNameI.Text + "%'";
            Command = new SqlCommand(sql, Connection);
            Connection.Open();

            using (SqlDataReader Reader = Command.ExecuteReader())
            {
                if (Reader.Read())
                {
                    Database_Password = Reader["Password"].ToString(); 

                    if (Database_Password == Entered_Password)
                    {
                        OpenFileDialog Open = new OpenFileDialog();
                        Open.ShowDialog();

                        txtImageD.Text = Open.FileName;

                        SaveFileDialog Save = new SaveFileDialog();
                        Save.ShowDialog();

                        txtDecryptedI.Text = Save.FileName;

                        decrypt(txtImageD.Text, txtDecryptedI.Text, key);
                        MessageBox.Show("Image Successfully Decrypted");
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials!");
                    }
                }
            }
            Connection.Close();
        }
    }
}
