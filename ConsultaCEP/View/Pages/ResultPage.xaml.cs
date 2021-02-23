using ConsultaCEP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultaCEP.View.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public ResultPage(CEP cep_)
        {
            InitializeComponent();

            txtPCEP.Text = cep_.cep;
            txtPBairro.Text = cep_.bairro;
            txtPCidade.Text = cep_.localidade;
            txtPComplemento.Text = cep_.complemento;
            txtPDDD.Text = cep_.ddd;
            txtPGIA.Text = cep_.gia;
            txtPLIBGE.Text = cep_.ibge;
            txtPLogradouro.Text = cep_.logradouro;
            txtPUF.Text = cep_.uf;
            txtPSiafi.Text = cep_.siafi;
        }
    }
}