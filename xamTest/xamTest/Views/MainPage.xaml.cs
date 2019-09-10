using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using xamTest.Models;

namespace xamTest
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        #region "Properties, objetos previos a la construcción de un objeto de esta class"

        // pictures :: una colección de CarouselItems, que será el ItemSource del carousel en XAML
        ObservableCollection<CarouselItem> pictures = new ObservableCollection<CarouselItem>();

        #endregion "Properties, objetos previos a la construcción de un objeto de esta class"

        #region "Constructor"

        public MainPage()
        {
            InitializeComponent();
            actiRandom.IsVisible = false;
        }

        #endregion "Constructor"

        #region "Methods handlers de eventos en el XAML"

        // PickPais handler
        private void PickPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            actiRandom.IsVisible = true;
            // -- Borra las fotos actuales, si las hay
            for (int i = pictures.Count-1; i >= 0; i--)
            {
                pictures.RemoveAt(i);
            }
            // -- Pone fotos de Spain, si escogió "Spain" o "Alls"
            if ((string)pickPais.SelectedItem == "Spain" || (string)pickPais.SelectedItem == "Alls")
            {
                pictures.Add(new CarouselItem { Picture = ImageSource.FromFile("spain001.jpg") });
                pictures.Add(new CarouselItem { Picture = ImageSource.FromFile("spain002.jpg") });
            }
            // -- Pone fotos de France, si escogió "France" o "Alls"
            if ((string)pickPais.SelectedItem == "France" || (string)pickPais.SelectedItem == "Alls")
            {
                pictures.Add(new CarouselItem { Picture = ImageSource.FromFile("france001.jpg") });
                pictures.Add(new CarouselItem { Picture = ImageSource.FromFile("france002.jpg") });
            }
            // -- Pone fotos de UK, si escogió "UK" o "Alls"
            if ((string)pickPais.SelectedItem == "UK" || (string)pickPais.SelectedItem == "Alls")
            {
                pictures.Add(new CarouselItem { Picture = ImageSource.FromFile("uk001.jpg") });
                pictures.Add(new CarouselItem { Picture = ImageSource.FromFile("uk002.jpg") });
            }
            // Si escogió "Random"
            if((string)pickPais.SelectedItem == "Random")
            {
                RestGET();
            }
            // Carga las fotos en el Carousel
            CV.ItemsSource = pictures;
            actiRandom.IsVisible = false;
        }

        #endregion "Methods handlers de eventos en el XAML"

        #region "Methods helpers"
        // Helper :: REST service consumer
        public async void RestGET()
        {
            var uri = new Uri(string.Format("https://source.unsplash.com/random", string.Empty));
            HttpClient _client = new HttpClient();
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                byte[] byteImagenCapturada = GetImageStreamAsBytes(stream);
                pictures.Add(new CarouselItem { Picture = ImageSource.FromStream(() => new MemoryStream(byteImagenCapturada)) });
            }
        }

        // Helper :: Convierte a bytes un ImageStream (Lo usa RestGET())
        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        #endregion "Methods helpers"
    }
}
