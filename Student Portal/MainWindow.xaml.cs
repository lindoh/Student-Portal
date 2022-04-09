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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

//TO DO:
//* Add Exceptions to database connection, commands, and everywhere necessary
//
namespace Student_Portal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Create OleDb objects for database connection, commands, and data adapter.
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = db_studentportal");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if text fields are empty
            if(UsernameTxt.Text == "" && PasswordTxt.Password == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Check if the username and password match an existing user's details

            try 
            {
                con.Open();     //Open connection to a data source
                string login = "SELECT * FROM tbl_users WHERE username = '" + UsernameTxt.Text + "' and password = '" + PasswordTxt.Password + "'";
                cmd = new OleDbCommand(login, con);
                OleDbDataReader dr = cmd.ExecuteReader();

                //If reading from data source is successful, open the next window (home HomeScreen)
                if (dr.Read())
                {
                    new HomeScreen().Show();    //Navigate to the Home Screen
                    Hide();                     //Hide this screen
                }
            }
            catch(OleDbException)
            {
                MessageBox.Show("Couldn't open connection to the data source", "Data Source Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            

        }
    }
}
