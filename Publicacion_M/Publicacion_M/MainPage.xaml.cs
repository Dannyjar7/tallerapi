using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Publicacion_M
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            GetGroupsAsync("http://192.168.1.53:81/api/Publicacion");
            InitializeComponent();
        }


        public static async void GetGroupsAsync(string url)
        {
            try
            {
                //Serializar el Grupo en Json
                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage rta = await cliente.GetAsync(url);
                        string rtaMessage = await rta.Content.ReadAsStringAsync();
                        //var obj = JsonConvert.DeserializeObject<Grupo[]>(rtaMessage);
                        //return rtaMessage;
                    }
                    catch (System.Exception exe)
                    {
                        throw;
                    }
                }
            }
            catch (System.Exception exe)
            {
                throw;
            }
        }
    }
}
