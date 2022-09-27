using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace File_Encryption
{
    public partial class Form1 : Form
    { 
        string key;
        public Form1()
        {
            InitializeComponent();
            key = generateKey();
        }

        private string generateKey() 
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            Open.ShowDialog();

            txtLocalEncryptFile.Text = Open.FileName;

            SaveFileDialog Save = new SaveFileDialog();
            Save.ShowDialog();

            txtNewEncryptFile.Text = Save.FileName;

            encrypt(txtLocalEncryptFile.Text, txtNewEncryptFile.Text, key);
        }

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

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            Open.ShowDialog();

            txtLocalDecryptFile.Text = Open.FileName;

            SaveFileDialog Save = new SaveFileDialog();
            Save.ShowDialog();

            txtNewDecryptFile.Text = Save.FileName;

            decrypt(txtLocalDecryptFile.Text, txtNewDecryptFile.Text, key);
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
    }
}
