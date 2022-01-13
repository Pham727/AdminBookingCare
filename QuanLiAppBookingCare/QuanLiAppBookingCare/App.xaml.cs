using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuanLiAppBookingCare.Views;

namespace QuanLiAppBookingCare
{
    public partial class App : Application
    {

        public static string url { get; set; }
        public App()
        {
            InitializeComponent();
            url = "http://www.webapibookingcare.somee.com/";
            MainPage = new  LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
