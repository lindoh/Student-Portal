using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace Student_Portal.Views
{
    /// <summary>
    /// Interaction logic for CreateUserAccountView.xaml
    /// </summary>
    public partial class CreateUserAccountView : UserControl
    {
        public CreateUserAccountView()
        {
            InitializeComponent();
        }

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
            if (FnameTxt.Text == "" || LnameTxt.Text == "" || GenderTxt.Text == "" || IdNumberTxt.Text == "" || NationalityTxt.Text == "" || DOBTxt.Text == ""
                || AddressTxt.Text == "" || NumberTxt.Text == "" || DateOfRegTxt.Text == "" || Stud_Lec_CBox.Text == "" || CourseNameCBox.Text == "")
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
                    string register = "INSERT INTO tbl_students VALUES('" + FnameTxt.Text + "', '" + LnameTxt.Text + "', '" + GenderTxt.Text + "', '" + IdNumberTxt.Text + "', '" + NationalityTxt.Text + "', " +
                        "'" + DOBTxt.Text + "', '" + AddressTxt.Text + "', '" + NumberTxt.Text + "', '" + DateOfRegTxt.Text + "', '" + Stud_Lec_CBox.Text + "', '" + CourseNameCBox.Text + "')";
                    cmd = new OleDbCommand(register, con);
                    cmd.ExecuteNonQuery();


                    con.Close();
                }
                catch (OleDbException)
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
