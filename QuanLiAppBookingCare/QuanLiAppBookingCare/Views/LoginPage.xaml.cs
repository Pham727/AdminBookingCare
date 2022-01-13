using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuanLiAppBookingCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void cmdLogin_Clicked(object sender, EventArgs e)
        {
            if( email.Text =="bookingcare@gmail.com" && password.Text == "admin12345")
            {
                App.Current.MainPage = new MainPage();
            }
            else
            {
                DisplayAlert("Thông báo", "Email hoặc password không đúng. Vui lòng kiểm tra lại thông tin", "OK");
            }

        }
    }
}