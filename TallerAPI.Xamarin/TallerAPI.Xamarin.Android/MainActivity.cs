using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Threading.Tasks;

namespace TallerAPI.Xamarin.Droid
{


    [Activity(Label = "TallerAPI.Xamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        private string url = "http://192.168.1.53:81/api/Publicacion";

        protected override void OnCreate(Bundle savedInstanceState)
        {
           TabLayoutResource = Resource.Layout.Tabbar;
           ToolbarResource = Resource.Layout.Toolbar;
             GetGroupsAsync(url);
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }


        public async Task<string> GetGroupsAsync(string url)
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
                        return rtaMessage;
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