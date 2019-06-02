using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using UberHack.Core;
using UberHack.Core.Util;

namespace UberHack.Service.Controllers
{
    public class RideController : ApiController
    {

        private static string token = Security.ReturnAcceessToken();

        ///// <summary>
        /// Solicita viagem  ao motorista e retorna o status da solicitação
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<RideResponse> Post(RideRequest body)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.BaseAddress = Security.BaseAddress("SANDBOX");
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"requests", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var Exception = JsonConvert.DeserializeObject(content);
                throw new System.Exception(Exception.ToString());
            }
            try
            {
                return JsonConvert.DeserializeObject<RideResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }





        }
    }
}
