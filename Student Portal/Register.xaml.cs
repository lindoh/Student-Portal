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
        /*
                #region Database Objects
                //
                OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = db_studentportal.mdb");
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter da = new OleDbDataAdapter();

                #endregion

                #region Private Methods

                /// <summary>
                /// Registration button:
                /// Checks if textboxes are empty, create connection with the database,
                /// Store the data in the database and execute the command,
                /// And alert the user after successful account creation
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void RegisterBtn_Click(object sender, RoutedEventArgs e)
                {
                    //Check if all textboxes are empty and send appropriate message to the user
                    if (UsernameTxt.Text == "" && PasswordTxt.Password == "" && ConPasswordTxt.Password == "")
                    {
                        MessageBox.Show("Username and password fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (PasswordTxt.Password == ConPasswordTxt.Password)       //Check if passwords match in the textboxes
                    {

                        try
                        {
                            //Check if the user doesn't already exist before storing new data
                            con.Open();         //Open connection to the database
                            string existingUser = "SELECT * FROM tbl_users WHERE username = '" + UsernameTxt.Text + "' ";
                            cmd = new OleDbCommand(existingUser, con);
                            OleDbDataReader dr = cmd.ExecuteReader();       //Read from database table

                            //If the same data exists in the table
                            if (dr.Read())
                            {
                                MessageBox.Show("User already exists", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                                clearTextboxes('u');           //Clear textboxes     
                            }
                            else
                            {
                                //Store the data in the database table
                                string register = "INSERT INTO tbl_users VALUES('" + UsernameTxt.Text + "', '" + PasswordTxt.Password + "')";
                                cmd = new OleDbCommand(register, con);
                                cmd.ExecuteNonQuery();          //Execute query command

                                //Alert the user after successful account creation
                                MessageBox.Show("Your account has been successfully created", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            con.Close();                    //Close connection
                        }
                        catch (OleDbException)
                        {
                            MessageBox.Show("Couldn't open connection to the data source", "Data Source Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }


                        //Clear all textboxes
                        clearTextboxes('u');
                    }
                    else
                    {
                        MessageBox.Show("Passwords do not match, Please re-enter", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        //Clear password textboxes
                        clearTextboxes('p');
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

                /// <summary>
                /// Navigate to the Login Screen
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void BackToLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
                {
                    new MainWindow().Show();
                    Hide();
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
                        UsernameTxt.Text = string.Empty;
                        PasswordTxt.Password = string.Empty;
                        ConPasswordTxt.Password = string.Empty;
                    }
                    else if (c == 'p')
                    {
                        PasswordTxt.Password = string.Empty;
                        ConPasswordTxt.Password = string.Empty;
                    }

                }


                #endregion
        */
    }
}