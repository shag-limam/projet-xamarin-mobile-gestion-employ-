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
    public partial class AddEmp : ContentPage
    {
        SqlConnection sqlConnection;
        public AddEmp()
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
                using (SqlCommand command = new SqlCommand("INSERT INTO [B1].[dbo].[emp] VALUES(@emp_nom,@emp_prenom, @emp_age , @dept_id, @emp_salaire)", sqlConnection))
                {

                   
                    command.Parameters.Add(new SqlParameter("emp_nom", nom.Text));
                    command.Parameters.Add(new SqlParameter("emp_prenom", pr.Text));
                    command.Parameters.Add(new SqlParameter("emp_age", age.Text));
                    command.Parameters.Add(new SqlParameter("dept_id", dep.Text));
                    command.Parameters.Add(new SqlParameter("emp_salaire", sl.Text));
                    command.ExecuteNonQuery();
                }
                sqlConnection.Close();
                await App.Current.MainPage.DisplayAlert("Alert", "employee ajouter", "Ok");
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