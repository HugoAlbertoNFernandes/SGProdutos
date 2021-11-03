using Newtonsoft.Json;
using SGP.AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SCP.UI.Web.Repository
{
    public class ProdutosRepository
    {
        HttpClient cliente = new HttpClient();
        private string _url { get; set; }
        public ProdutosRepository(string url)
        {
            this._url = url;

            cliente.BaseAddress = new Uri(this._url);
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Produto>> GetAllProdutoAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync(this._url);

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Produto>>(dados);
            }
            return new List<Produto>();
        }

        public async Task<List<Produto>> PostProdutoAsync(Produto produto)
        {
            try
            {

                var json = JsonConvert.SerializeObject(produto);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = await cliente.PostAsync(this._url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var dados = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Produto>>(dados);
                }
                return new List<Produto>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task DeleteProdutoAsync()
        {
           
            

            //await cliente.DeleteAsync(this._url);
            



            //if (response.IsSuccessStatusCode)
            //{
            //    var dados = await response.Content.ReadAsStringAsync();
            //    return JsonConvert.DeserializeObject<List<Produto>>(dados);
            //}
            //return new List<Produto>();
        }
    }
}
