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

        private string Swap() // Method that completes Step 1: Swap the first letter with the last letter in the string and store it in newString.   || eg. James becomes sameJ
        {
            //Variables
            int ifirstPosition, ilastPosition, Temp;
            string str, newStr, smidparts, sfirstPosition, slastPosition;
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

        private static string EncrytedStr(string str) // Method that completes Step3: Move each character in the newString 3 spaces up on the ASCII Table.  || e.g Jemas becomes Mhpdv
        {
            char[] arr = str.ToCharArray(); //Array that converts newString from step 2 into characters

            //Variables
            string newStr = ""; //Empty string initializes variable 
            char CharInArray, newCharInArray; 
            int ASCIIvalue, newASCIIvalue;

            for (int i = 0; i  < str.Length; i++) //For loop for moving characters 3 spaces up on the ASCII Table and turning array into one string.  
            {
                CharInArray = arr[i]; 

                ASCIIvalue = (char)CharInArray;

                newASCIIvalue = ASCIIvalue + 3; // Moving Characters

                newCharInArray = (char)newASCIIvalue;

                newStr += newCharInArray; // Turning array new charaters into one string.
            }

            return newStr; // returns the new string.
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                lblEncrypt.Text = EncrytedStr(ReverseString(Swap()));

                lblEncrypt.Visible = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid input");
            }
           
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

        }

        
    }
}
