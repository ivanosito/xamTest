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
            lblUserName.IsVisible = true;
            txtUserName.IsVisible = true;
            lblPassword.IsVisible = true;
            txtPassword.IsVisible = true;
            imgLogo.HeightRequest = Constants.LogoHeight;
            // Behaviors
            txtUserName.Completed += (s, e) => txtPassword.Focus();
            txtPassword.Completed += (s, e) => CmdIngresar_Clicked(s, e);
        }

        private async void CmdIngresar_Clicked(object sender, EventArgs e)
        {
            lblUserName.IsVisible = false;
            txtUserName.IsVisible = false;
            lblPassword.IsVisible = false;
            txtPassword.IsVisible = false;
            actiLogin.IsVisible = true;
            User user = new User(txtUserName.Text, txtPassword.Text);
            if(user.ValidarDatos())
            {
                // Buscar UserName
                User UserHallado = await App.SQLiteDb.GetItemByUserNameAsync(txtUserName.Text);
                if(UserHallado != null)
                {
                    // Verificar el password
                    if(txtPassword.Text == Crypto.Decrypt(UserHallado.Password, txtPassword.Text))
                    {
                        MainPage mainPage = new MainPage();
                        await Navigation.PushAsync(mainPage);
                    }
                    else
                    {
                        await DisplayAlert("Login", "Error: Usuario no reconocido", "Ok");
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
            lblUserName.IsVisible = true;
            txtUserName.IsVisible = true;
            lblPassword.IsVisible = true;
            txtPassword.IsVisible = true;
            actiLogin.IsVisible = false;
        }

        private async void CmdRegistrarse_Clicked(object sender, EventArgs e)
        {
            lblUserName.IsVisible = false;
            txtUserName.IsVisible = false;
            lblPassword.IsVisible = false;
            txtPassword.IsVisible = false;
            actiLogin.IsVisible = true;
            User UserRepetido = await App.SQLiteDb.GetItemByUserNameAsync(txtUserName.Text);
            if (UserRepetido == null)
            {
                try
                {
                    User userNuevo = new User(txtUserName.Text, Crypto.Encrypt(txtPassword.Text, txtPassword.Text));
                    await App.SQLiteDb.SaveItemAsync(userNuevo);
                    await DisplayAlert("Login", "Registro exitoso!", "Ok");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Login", ex.Message, "Ok");
                    lblUserName.IsVisible = true;
                    txtUserName.IsVisible = true;
                    lblPassword.IsVisible = true;
                    txtPassword.IsVisible = true;
                    actiLogin.IsVisible = false;
                }
            }
            else
            {
                await DisplayAlert("Login", "Error: Usuario ya existe", "Ok");
            }
            lblUserName.IsVisible = true;
            txtUserName.IsVisible = true;
            lblPassword.IsVisible = true;
            txtPassword.IsVisible = true;
            actiLogin.IsVisible = false;
        }
    }
}