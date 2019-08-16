using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using BuscaCep.Models;
using Newtonsoft.Json;

namespace BuscaCep.Service
{
	public class ViaCepService
	{
		private static string URL = "http://viacep.com.br/ws/{0}/json/";
		public static Endereco BuscarEnderecoViaCEP(string cep)
		{
			string NovaURL = string.Format(URL, cep);

			WebClient wc = new WebClient();
			string result = wc.DownloadString(NovaURL);

			Endereco end = JsonConvert.DeserializeObject<Endereco>(result);

			if (end == null)
				return null;

			return end;

		}
	}
}
