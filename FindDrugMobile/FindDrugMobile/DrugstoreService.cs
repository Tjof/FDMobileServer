using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindDrugMobile
{
    class DrugstoreService
    {
        const string Url = "https://localhost:44379/аптеки";
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Drugstore>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Drugstore>>(result);
        }
    }
}
