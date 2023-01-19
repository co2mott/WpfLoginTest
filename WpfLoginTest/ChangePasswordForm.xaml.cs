using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfLoginTest
{
    /// <summary>
    /// Interaction logic for ChangePasswordForm.xaml
    /// </summary>

        public partial class ChangePasswordForm : Window
        {
            public ChangePasswordForm()
            {
                InitializeComponent();
            }

            private void TxtUsername_TextChanged(object sender, TextChangedEventArgs e)
            {

            }



            private void TxtCurrentPassword_Leave(object sender, TextChangedEventArgs e)
            {
            }

            private void TxtCurrentPassword_TextChanged(object sender, TextChangedEventArgs e)
            {

            }

            private void TxtChangePassword_TextChanged(object sender, TextChangedEventArgs e)
            {

            }

            private void button_exit_Click(object sender, RoutedEventArgs e)
            {
                MainWindow form2 = new MainWindow();
                form2.Show();
                this.Hide();
            }

            private void button_clear_Click(object sender, RoutedEventArgs e)
            {
                TxtID.Clear();
                TxtChangePassword.Clear();

                TxtID.Focus();
            }

            private void UpdateButton_Click_1(object sender, RoutedEventArgs e)
            {
                {
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source=LAPTOP-IS69AVIT\\SQLEXPRESS;Initial Catalog=RapidTestDB;Integrated Security=True;");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Update RapidTestDB set password=@password where id = @id", con);

                        cmd.Parameters.AddWithValue("@id", int.Parse(TxtID.Text));
                        cmd.Parameters.AddWithValue("@password", TxtChangePassword.Text);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        MessageBox.Show("Succsesfully Updated");

                        MainWindow form2 = new MainWindow();
                        form2.Show();
                        this.Hide();
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                        ChangePasswordForm form2 = new ChangePasswordForm();
                        form2.Show();
                    }
                    finally
                    {
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

            private void TxtChangePassword_TextChanged_1(object sender, TextChangedEventArgs e)
            {

            }
        }
    }
