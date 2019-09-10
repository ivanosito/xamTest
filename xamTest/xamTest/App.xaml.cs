using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamTest.Data;
using xamTest.Views;

namespace xamTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        static SQLiteHelper db;
        public static SQLiteHelper SQLiteDb
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinSQLite.db3"));
                }
                return db;
            }
        }

    }
}
