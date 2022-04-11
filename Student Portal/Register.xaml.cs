using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace Student_Portal
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        #region Default Constructor
        public Register()
        {
            InitializeComponent();
        }

        #endregion
      
        #region Database Objects
        //
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = db_studentportal.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        #endregion

        #region Private Methods

        /// <summary>
        /// Registration button:
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if none of the text fields is empty
            if (Fname.Text == "" || Lname.Text == "" || Gender.Text == "" || IdNumber.Text == "" || Nationality.Text == "" || DOB.Text == ""
                || Address.Text == "" || Number.Text == "" || DateOfReg.Text == "" || Discipline.Text == "" || CourseName.Text == "")
            {
                MessageBox.Show("One or more text fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (GenUsernameTxt.Text == "" || GenPasswordTxt.Text == "")
            {
                MessageBox.Show("Username and/or Password fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    con.Open();      //Open connection to database
                    string register = "INSERT INTO tbl_students VALUES('" + Fname.Text + "', '" + Lname.Text + "', '" + Gender.Text + "', '" + IdNumber.Text + "', '" + Nationality.Text + "', " +
                        "'" + DOB.Text + "', '" + Address.Text + "', '" + Number.Text + "', '" + DateOfReg.Text + "', '" + Discipline.Text + "', '" + CourseName.Text + "')";
                    cmd = new OleDbCommand(register, con);
                    cmd.ExecuteNonQuery();

                    
                    con.Close();
                }
                catch(OleDbException)
                {
                    MessageBox.Show("Couldn't open connection to the database", "Database Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
                /// Clears all textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            //Clear textboxes
            clearTextboxes('u');
        }

    

        #endregion

        #region Supporting Methods

        /// <summary>
        /// Clears all textboxes
        /// If argument character is 'u' clear all textboxes including Username
        /// Else clear Password textboxes only --> c = 'p'
        /// </summary>
        private void clearTextboxes(char c)
        {
        if (c == 'u')
        {
           
        }
        else if (c == 'p')
        {
            
        }

        }


#endregion
    }
}