using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Created_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*SELF GENERATED ALGORITHM
         
        Step1: Swap the first letter with the last letter in the string and store it in newString.   || eg. James becomes sameJ
        
        Step2: Reverse the newString.    || e.g sameJ becomes Jemas

        Step3: Move each character in the string 3 spaces up on the ASCII Table.
         */
        

        //Global variables
        int ifirstPosition, ilastPosition, Temp; 
        string str, newStr, smidparts, sfirstPosition, slastPosition;

        private string Swap() // Method that completes Step 1: Swap the first letter with the last letter in the string and store it in newString.   || eg. James becomes sameJ
        {
            str = txtString.Text;
            ifirstPosition = 0; //Index of first Letter
            ilastPosition = str.Length - 1;  //Index of last Letter

            smidparts = str.Substring(1, ilastPosition - 1);

            //Swapping first and last letter
            Temp = ifirstPosition;
            ifirstPosition = ilastPosition;
            ilastPosition = Temp;

            //Getting first and last letter form the string
            sfirstPosition = str.Substring(ifirstPosition, 1);
            slastPosition = str.Substring(ilastPosition, 1);

            //The New String
            newStr = sfirstPosition + smidparts + slastPosition;

            return newStr;
        }

        private static string ReverseString(String input) // Method that completes Step2: Reverse the newString.    || e.g sameJ becomes Jemas
        {
            string ReversedStr = "";

            for (int i = input.Length - 1; i >= 0; i--) //for to reverses string
            {
                ReversedStr += input[i];
            }

            return ReversedStr;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            lblEncrypt.Visible = true;
            lblEncrypt.Text = ReverseString(Swap());
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

        }

        
    }
}
