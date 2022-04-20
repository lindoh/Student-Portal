using System.Windows;
using System.Windows.Input;
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


                //Check if the user doesn't already exist before storing new data
                con.Open();         //Open connection to the database
                string existingUser = "SELECT * FROM tbl_users WHERE username = '" + UsernameTxt.Text + "' ";
                cmd = new OleDbCommand(existingUser, con);
                OleDbDataReader dr = cmd.ExecuteReader();       //Read from database table

                //If the same data exists in the table
                if (dr.Read())
                {
                    MessageBox.Show("User already exists", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    clearTextboxes();           //Clear textboxes     
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


                //Clear all textboxes
                clearTextboxes();
            }
            else
            {
                MessageBox.Show("Passwords do not match, Please re-enter", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
            clearTextboxes();
        }

        /// <summary>
        /// Navigate to the Login Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Navigate to the Login Screen
            new MainWindow().Show();
            Hide();
        }

        #endregion

        #region Supporting Methods

        /// <summary>
        /// Clears all textboxes
        /// </summary>
        private void clearTextboxes()
        {
            UsernameTxt.Text = string.Empty;
            PasswordTxt.Password = string.Empty;
            ConPasswordTxt.Password = string.Empty;
        }


        #endregion

    
    }
}
