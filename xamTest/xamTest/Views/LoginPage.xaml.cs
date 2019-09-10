using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using xamTest.Models;

namespace xamTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            initAdicional();
        }

        private void initAdicional()
        {
            // Look&Feel
            BackgroundColor = Constants.BackgroundColor;
            lblUserName.TextColor = Constants.MainTextColor;
            lblPassword.TextColor = Constants.MainTextColor;
            actiLogin.IsVisible = false;
            imgLogo.HeightRequest = Constants.LogoHeight;
            // Behaviors
            txtUserName.Completed += (s, e) => txtPassword.Focus();
            txtPassword.Completed += (s, e) => CmdIngresar_Clicked(s, e);
        }

        private void CmdIngresar_Clicked(object sender, EventArgs e)
        {
            User user = new User(txtUserName.Text, txtPassword.Text);
            if(user.ValidarDatos())
            {
                DisplayAlert("Login", "Login exitoso", "Ok");
            }
            else
            {
                DisplayAlert("Login", "Error: UserName o Password vacío", "Ok");
            }
        }
    }
}