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
    public partial class login : ContentPage
    {
        SqlConnection sqlConnection;
        public login()
        {
            InitializeComponent();

            string srvrdbname = "B1";
            string srvrname = "192.168.8.101,2537";
            string srvrusername = "YAHYA";
            string srvrpassword = "123456";
            string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
            sqlConnection = new SqlConnection(sqlconn);
        }





        private void Button_Clicked_2(object sender, EventArgs e)
        {
            sqlConnection.Open();
            String q = "select count(*)from [B1].[dbo].[User] where Nom='" + Nom.Text + "'and Mot='" + pwd.Text + "'";
            SqlCommand cm = new SqlCommand(q, sqlConnection);
            string cd = cm.ExecuteScalar().ToString();
            sqlConnection.Close();
            if (cd == "1")
            {
                Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                DisplayAlert("info", "Mot de passe ou nom incoreect", "ok");
            }

        }






    }
    
}