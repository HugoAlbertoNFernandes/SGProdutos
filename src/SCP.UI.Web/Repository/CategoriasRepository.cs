using Newtonsoft.Json;
using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SCP.UI.Web.Repository
{
    public class CategoriasRepository
    {
        HttpClient cliente = new HttpClient();
        private string _url { get; set; }

        public CategoriasRepository(string url)
        {
            this._url = url;

            cliente.BaseAddress = new Uri(this._url);
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Categoria>> GetAllCategoriaAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync(this._url);

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Categoria>>(dados);
            }
            return new List<Categoria>();
        }
    }
}
