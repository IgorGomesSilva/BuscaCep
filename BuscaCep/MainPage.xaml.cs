using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BuscaCep.Models;
using BuscaCep.Service;

namespace BuscaCep
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			xButton.Clicked += BuscarCEP;
		}

		private void BuscarCEP(object sender, EventArgs args)
		{
			string cep = xCep.Text.Trim();
			if (isValidCEP(cep))
			{
				try
				{
					Endereco end = ViaCepService.BuscarEnderecoViaCEP(cep);
					if(end != null)
					{
						xResult.Text = string.Format("Endereço: {0}, {1}, {2}, {3}", end.Logradouro, end.Bairro, end.Localidade, end.UF);
					}
					else
					{
						DisplayAlert("ERRO", "O endereço não foi encontrado para o cep informado: " + cep, "OK");
					}
				}
				catch(Exception e)
				{
					DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
				}
				
			}
			
		}

		private bool isValidCEP(string cep)
		{
			bool valido = true;
			if(cep.Length != 8)
			{
				DisplayAlert("Erro !", "CEP inválido ! O cep deve conter 8 caracteres. ", "OK");
				return false;
			}
			int novoCEP = 0;
			if(!int.TryParse(cep, out novoCEP))
			{
				DisplayAlert("ERRO", "CEP inválido ! O cep deve ser composto apenas por Números !", "OK");
				return false;
			}
			return valido;
		}
	}
}
