using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //CarouselPage mainCarousel = new CarouselPage();
            //ContentPage contentPage001 = new ContentPage();
            //ContentPage contentPage002 = new ContentPage();
            //ContentPage contentPage003 = new ContentPage();
            //mainCarousel.Children.Add(contentPage001);
            //mainCarousel.Children.Add(contentPage002);
            //mainCarousel.Children.Add(contentPage003);

            //Image imgvMyImageView001 = new Image();

            //contentPage001.Content =
            //    new Label
            //    {
            //        Text = "Page 001",
            //    };
            //contentPage002.Content =
            //    new Label
            //    {
            //        Text = "Page 002",
            //    };
            //contentPage003.Content =
            //    new Label
            //    {
            //        Text = "Page 003",
            //    };
            //MainPage = mainCarousel;
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
    }
}
