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
    public partial class Employe : ContentPage
    {
        SqlConnection sqlConnection;
        public IList<emp> emps { get; set; }

        public Employe()
        {

            InitializeComponent();
            string srvrdbname = "B1";
            string srvrname = "192.168.8.101,2537";
            string srvrusername = "YAHYA";
            string srvrpassword = "123456";
            string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";

            sqlConnection = new SqlConnection(sqlconn);
            sqlConnection.Open();
            string queryString = "Select * from [B1].[dbo].[emp]";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            emps= new List<emp>();
            while (reader.Read())
            {
                emps.Add(new emp
                {
                    emp_id = Convert.ToInt32(reader["emp_id"]),
                    emp_nom = reader["emp_nom"].ToString(),
                    emp_age = reader["emp_age"].ToString(),
                    dept_id = Convert.ToInt32(reader["dept_id"]),
                    emp_salaire = Convert.ToInt32(reader["emp_salaire"]),

                }
                );
            }
            reader.Close();
            sqlConnection.Close();
            lvemp.ItemsSource = emps;
        }
            public class emp
        {
            public int emp_id { get; set; }
            public string emp_nom { get; set; }
            public string  emp_age { get; set; }
            public int dept_id { get; set; }
            public int emp_salaire { get; set; }

        }
      




        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddEmp());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new editemp());
        }

        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new supEmp());

        }

      
    }
}