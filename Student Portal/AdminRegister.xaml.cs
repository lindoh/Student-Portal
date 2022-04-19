using System.Windows;
using System.Data.OleDb;

namespace Student_Portal
{
    /// <summary>
    /// Interaction logic for AdminRegister.xaml
    /// </summary>
    public partial class AdminRegister : Window
    {
        #region Default Constractor
        public AdminRegister()
        {
            InitializeComponent();
        }

        #endregion

        #region Database Objects Initialization

        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0, Data Source = db_studentportal");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        #endregion

        #region Private Methods
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if all text fields have data
            if (UsernameTxt.Text == "" && PasswordTxt.Password == "" && ConPasswordTxt.Password == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (PasswordTxt.Password == ConPasswordTxt.Password)       //If the passwords match
            {
                try
                {
                    con.Open();         //Open connection to the database

                    //Insert the username and password data into the database tbl_users table
                    string register = "INSERT INTO tbl_users VALUES('" + UsernameTxt.Text + "', '" + PasswordTxt.Password + "')";
                    cmd = new OleDbCommand(register, con);      //Create the command
                    cmd.ExecuteNonQuery();                      //Execute the command
                    con.Close();                                //Close connection
                }
                catch(OleDbException)
                {
                    MessageBox.Show("Couldn't open connection to the database", "Database Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                MessageBox.Show("Account Successfully Created", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
                clearTextboxes();

                //Navigate to the admin Home screen
                new HomeScreen().Show();
                Hide();
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearTextboxes();
        }

        private void BackToLoginLbl_MouseLeftButtonDown(object sender, RoutedEventArgs e)
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
