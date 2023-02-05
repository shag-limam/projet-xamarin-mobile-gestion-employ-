using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gestion_employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class supEmp : ContentPage
    {
        SqlConnection sqlConnection;
        public supEmp()
        {
            InitializeComponent();

            string srvrdbname = "B1";
            string srvrname = "192.168.8.101,2537";
            string srvrusername = "YAHYA";
            string srvrpassword = "123456";
            string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
            sqlConnection = new SqlConnection(sqlconn);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                sqlConnection.Open();
                int idtodelete = Convert.ToInt32(id.Text);
                using (SqlCommand command = new SqlCommand($"Delete FROM [B1].[dbo].[emp] WHERE emp_id = {idtodelete} ", sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
                sqlConnection.Close();
             
                await App.Current.MainPage.DisplayAlert("Alert", "Congrats you have successfully deleted the row item", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new Employe());
            }


            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                throw;
            }
            
        }
    }
}