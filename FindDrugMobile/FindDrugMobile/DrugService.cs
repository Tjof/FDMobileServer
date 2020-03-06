using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindDrugMobile
{
    class DrugService
    {
        const string Url = "http://20.188.34.167:5000/Drug";
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<Drug[]> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<Drug[]>(result);
        }
    }
}
