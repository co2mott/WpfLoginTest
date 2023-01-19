using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfLoginTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-IS69AVIT\\SQLEXPRESS;Initial Catalog=RapidTestDB;Integrated Security=True");
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {

            String username, user_password;

            username = txt_Username.Text;
            user_password = txt_Password.Password;

            if (txt_Username.Text != "" && txt_Password.Password != "")
            {
                // Login Code
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from users inner join role on users.userrole=role.roleid where username= @username and password= @password", con);
                cmd.Parameters.AddWithValue("@username", txt_Username.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Password);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string usertype = dt.Rows[0][5].ToString();

                    //Role Code

                    if (usertype == "admin")
                    {
                        AdminView AdminView = new AdminView();
                        AdminView.Show();
                        this.Hide();

                        MessageBox.Show("Welcome Admin");
                    }
                    else if (usertype == "user")
                    {
                        CostumerView CostumerView = new CostumerView();
                        CostumerView.Show();
                        this.Hide();

                        MessageBox.Show("Welcome User");
                    }

                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error");
                }
                con.Close();

            }try
            {
                con.Close();
            }
        

            //          {
            //      String querry = "SELECT * FROM loginrapid WHERE username = '" + txt_Username.Text + "' AND password = '" + txt_Password.Password + "'";
            //SqlDataAdapter sda = new SqlDataAdapter(querry, con);

            //DataTable dtable = new DataTable();
            //sda.Fill(dtable);
            //if (dtable.Rows.Count > 0)
            //{
            //username = txt_Username.Text;
            //user_password = txt_Password.Password;

            //MainForm form2 = new MainForm();
                   // form2.Show();
                    //this.Hide();

             //   }
             //   else
           //     {
                //    MessageBox.Show("Invalid login details", "Error");
                //    txt_Username.Clear();
                 //   txt_Password.Clear();
            
                //    txt_Username.Focus();
           //     }
         //   }

          catch
         {
        MessageBox.Show("Error");
       }

       finally
  {
      con.Close();
   }
      } 

        private void button_clear_Click(object sender, RoutedEventArgs e)

        {
            txt_Username.Clear();
            txt_Password.Clear();

            txt_Username.Focus();
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {

            {

                if (MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Windows.Application.Current.Shutdown();
                }
                else
                {
                    MainWindow form2 = new MainWindow();
                    form2.Show();
                    this.Hide();
                }

            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordForm form3 = new ChangePasswordForm();
            form3.Show();
            this.Hide();
        }

        private void txt_Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

