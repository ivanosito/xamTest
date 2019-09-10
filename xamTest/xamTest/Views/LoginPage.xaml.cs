using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using xamTest.Models;
using xamTest.Data;

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

        private async void CmdIngresar_Clicked(object sender, EventArgs e)
        {
            User user = new User(txtUserName.Text, txtPassword.Text);
            if(user.ValidarDatos())
            {
                // Buscar UserName
                User UserHallado = await App.SQLiteDb.GetItemByUserNameAsync(txtUserName.Text);
                if(UserHallado != null)
                {
                    if(!string.IsNullOrEmpty(UserHallado.UserName))
                    {
                        // Verificar el password
                        if(txtPassword.Text == Crypto.Decrypt(UserHallado.Password, txtPassword.Text))
                        {
                            await DisplayAlert("Login", "Login exitoso", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Login", "Error: UserName no hallado", "Ok");
                        return;
                    }
                }
                else
                {
                    await DisplayAlert("Login", "Error: Usuario no hallado", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Login", "Error: UserName o Password vacío", "Ok");
            }
        }

        public async void UserNameAutenticado(string UserNameABuscar)
        {
            User UserNameHAllado = await App.SQLiteDb.GetItemByUserNameAsync(UserNameABuscar);
        }

    }
}