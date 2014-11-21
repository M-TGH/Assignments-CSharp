using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exceptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Code to use on load
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            // Get all inputs
            string email = emailTextbox.Text;
            string postcode = postcodeTextbox.Text;
            string telephone = telephoneTextbox.Text;

            try
            {
                // Check all
                checkEmail(email);
                checkPhonenumber(telephone);
                checkPostcode(postcode);
                // Reward user with a motivating message if everything was entered correctly
                exceptionTextbox.Text = "";
                MessageBox.Show("All information was entered correctly." + Environment.NewLine + "-------------------------" + Environment.NewLine + "Postcode is: " + postcode + Environment.NewLine + "E-mail is: " + email + Environment.NewLine + "Telefoon is: " + telephone + Environment.NewLine + "--------------------------");
            }
            catch(Exception ex)
            {
                // Show exceptiontext
                exceptionTextbox.Text = ex.ToString();
            }
        }

        // E-mailcheck method:
        void checkEmail(string email)
        {
            // Check if it's empty
            if(String.IsNullOrEmpty(email))
            {
                throw new NullReferenceException(email);
            } // Check for the minimal length
            else if(email.Length < 6)
            {
                throw new EmailException("E-mail is too short!");
            } // Check for unallowed characters
            else if(email.IndexOfAny("!#$&'`*+-/\\=?^'{|}~[]".ToCharArray()) != -1)
            {
                throw new EmailException("E-mail contains invalid chars!");
            } // Check for needed characters( @ and . )
            else if(!email.Contains("@") || !email.Contains("."))
            {
                throw new EmailException("E-mail doesn't contain needed chars (@ or .)!");
            } // Check whether there is whitespace before or after email
            else if(email != email.Trim())
            {
                throw new EmailException("E-mail contains whitespace at end or beginning!");
            } // Check for more than 1 @'s
            else if (email.Split('@').Length - 1 > 1)
            {
                throw new EmailException("E-mail contains more than 1 @!");
            }
        }

        // Postcodecheck method:
        void checkPostcode(string postcode)
        {
            // Check if it's empty
            if (String.IsNullOrEmpty(postcode))
            {
                throw new NullReferenceException(postcode);
            }
            else
            {
                // Check if the first 4 chars are digits
                char[] chars = postcode.Substring(0, 4).ToCharArray();
                foreach(char eachchar in chars){
                    if(!Char.IsDigit(eachchar))
                    {
                        throw new PostcodeException("Postcode doesn't start with 4 digits!");
                    }
                }
                // Check if the last 2 chars are letters
                char[] chars2 = postcode.Substring(postcode.Length -2).ToCharArray();
                foreach (char eachchar in chars2)
                {
                    if (!Char.IsLetter(eachchar))
                    {
                        throw new PostcodeException("Postcode doesn't end with 2 letters!");
                    }
                }
                // Check if there are more than wanted characters
                chars = postcode.ToCharArray();
                int letOrDig = 0;
                foreach(char c in chars){
                    if(Char.IsLetterOrDigit(c)){
                        letOrDig++;
                        if(letOrDig >= 7){
                            throw new PostcodeException("Postcode contains unwanted characters (has more than 6 letters and digits)!");
                        }
                    }

                }
            }
        }

        // Phonenumbercheck method:
        void checkPhonenumber(string phonenumber)
        {
            // Check if it's empty
            if (String.IsNullOrEmpty(phonenumber))
            {
                throw new NullReferenceException(phonenumber);
            } // Check whether there's whitespace at the beginning or end
            else if(phonenumber != phonenumber.Trim())
            {
                throw new PhoneException("Phonenumber begins or ends with whitespace!");
            } // Check if it excists out of 10 numbers
            else if (new String(phonenumber.ToCharArray().Where(c => Char.IsDigit(c)).ToArray()).Length != 10)
            {
                throw new PhoneException("Phonenumber contains less or more than 10 digits!");
            } 
            else
            {
                // Check for any unallowed chars
                char[] chars = phonenumber.ToCharArray();
                foreach(char eachchar in chars){
                    if(eachchar.ToString().IndexOfAny("0123456789\t -".ToCharArray()) == -1){
                        throw new PhoneException("Phonenumber contains unwanted characters!");
                    }
                }
            }
        }
    }
}
