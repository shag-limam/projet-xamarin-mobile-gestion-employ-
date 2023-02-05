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
    public partial class editemp : ContentPage
    {
        SqlConnection sqlConnection;
        public editemp()
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

                int IdtoBeUpdated = Convert.ToInt32(id.Text);

                string NomTobeUpdated = nom.Text;
                string prTobeUpdated = pr.Text;
                string salaireTobeUpdated = salaire.Text;
                string telTobeUpdated = tel.Text;
 




                string qerystr = $"UPDATE [GA].[dbo].[empl] SET emp_nom='{NomTobeUpdated}',emp_nom='{prTobeUpdated}' , emp_age ='{salaireTobeUpdated}' , emp_salaire ='{telTobeUpdated}',  WHERE emp_id='{IdtoBeUpdated}'";

                using (SqlCommand command = new SqlCommand(qerystr, sqlConnection))
                {
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                await App.Current.MainPage.DisplayAlert("Alert", "Employee a modifier", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new Dep());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                throw;
            }
           
        }
    }
}