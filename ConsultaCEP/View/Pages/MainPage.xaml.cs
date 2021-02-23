using ConsultaCEP.View.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using ConsultaCEP.Model;
using Xamarin.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConsultaCEP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Clicked(object sender, EventArgs e)
        {
            if (txtCEP.Text == "")
            {
                DisplayAlert("Atenção", "Digite o CEP desejado!", "OK");
            }
            else if (txtCEP.Text == null)
            {
                DisplayAlert("Atenção", "Digite o CEP desejado!", "OK");
            }
            else if (txtCEP.Text.Length < 8)
            {
                DisplayAlert("Atenção", "Tamanho de CEP invalido!", "OK");
            }
            else
            {
                
                string URLAuth = "https://viacep.com.br/ws/" + txtCEP.Text + "/json/";
                WebRequest request = WebRequest.Create(URLAuth);
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseData = reader.ReadToEnd();

                var data = JsonConvert.DeserializeObject<CEP>(responseData);

                Console.WriteLine(responseData);
                reader.Close();
                response.Close();

                //Chama pagina de resultados
                Navigation.PushModalAsync(new ResultPage(data));
            }
        }
    }
}
