using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gestion_employee
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            flyout.ss.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as fly;
            if (item != null)
            {
               Detail = new NavigationPage((Page)Activator.CreateInstance(item.targetPage));
                flyout.ss.SelectedItem = null;
                 IsPresented =false;
            }
        }
    }
}
