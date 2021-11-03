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
    public class ClienteRepository
    {
        HttpClient cliente = new HttpClient();
        private string _url { get; set; }
        public ClienteRepository(string url, string email, string senha)
        {
            this._url = url + "/" + email + "/" + senha;

            cliente.BaseAddress = new Uri(this._url);
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Cliente>> GetLoginAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync(this._url);

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cliente>>(dados);
            }
            return new List<Cliente>();
        }
    }
}
