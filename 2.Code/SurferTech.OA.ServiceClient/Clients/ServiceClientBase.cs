using SurferTech.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.ServiceClient.Clients
{
    public abstract class ServiceClientBase
    {
        public static readonly HttpClient client = new HttpClient();
        static ServiceClientBase()
        {
            client.BaseAddress = new Uri(ConfigHelper.ServiceUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task<T> Get<T>(string path)
        {
            var response = await client.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return await Task.FromResult<T>(default(T));
        }

        protected async Task<T> Post<T>(string path, object requestModel)
        {
            var response = await client.PostAsJsonAsync(path,requestModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return await Task.FromResult<T>(default(T));
        }
    }
}
