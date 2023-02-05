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
    public partial class Dep : ContentPage
    {
        SqlConnection sqlConnection;
        public IList<dep> deps { get; set; }

        public Dep()
        {

            InitializeComponent();
            string srvrdbname = "B1";
            string srvrname = "192.168.8.101,2537";
            string srvrusername = "YAHYA";
            string srvrpassword = "123456";
            string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";

            sqlConnection = new SqlConnection(sqlconn);
            sqlConnection.Open();
            string queryString = "Select * from [B1].[dbo].[dept]";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            deps = new List<dep>();
            while (reader.Read())
            {
                deps.Add(new dep
                {
                    id = Convert.ToInt32(reader["dept_id"]),
                    nom = reader["dept_nom"].ToString(),
               

                }
                );
            }
            reader.Close();
            sqlConnection.Close();
            lvdep.ItemsSource = deps;
        }
        public class dep
        {
            public int id { get; set; }
            public string nom { get; set; }
         
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Adddep());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new editdep());

        }

        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new supdep());
        }
    }
}