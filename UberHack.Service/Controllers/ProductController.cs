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
    public class ProductController : ApiController
    {

        private static string token = Security.ReturnAcceessToken();

        // GET: api/Product
        [HttpGet]
        public async void Get()
        {

            var accesstoken = "JA.VUNmGAAAAAAAEgASAAAABwAIAAwAAAAAAAAAEgAAAAAAAAG8AAAAFAAAAAAADgAQAAQAAAAIAAwAAAAOAAAAkAAAABwAAAAEAAAAEAAAAMj6oIhRSsz4AqdYFPhFp6JsAAAA9P0gL51DTooBl-mm-V5dDbgyg2KV4i2NOoTdWExDjgUHGvnk2rrFZcqxfSz1ig0SS6L2R5w9drexdi6iD3ThGzPjNMKLvCy-Ju9ZxkiT6uIdNL4PPHZAhk5uwdrYPwMCs4r42g0sBkPDxqJJDAAAAHATpALqagq3AbwZnSQAAABiMGQ4NTgwMy0zOGEwLTQyYjMtODA2ZS03YTRjZjhlMTk2ZWU";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accesstoken);
            httpClient.BaseAddress = Security.BaseAddress("API");
            HttpResponseMessage response = await httpClient.GetAsync("products?latitude=37.7759792&longitude=-122.41823");

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var Exception = JsonConvert.DeserializeObject(content);
                throw new System.Exception(Exception.ToString());
            }
            try
            {
                var x = await response.Content.ReadAsStringAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Product
        /// <summary>
        /// Retorna os produtos disponíveis para o endereço pesquisado
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ProductResponse> Get(string latitude, string longitude)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.BaseAddress = Security.BaseAddress("API");
            HttpResponseMessage response = await httpClient.GetAsync("products?latitude=" + latitude + " &longitude=" + longitude);

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var Exception = JsonConvert.DeserializeObject(content);
                throw new System.Exception(Exception.ToString());
            }
            try
            {
                return JsonConvert.DeserializeObject<ProductResponse>(await response.Content.ReadAsStringAsync());

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gera a estimativa de valor da corrida solicitada, conforme os dados o objeto
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// 
        // Post: api/Product
        [HttpPost]
        public async Task<EstimativeResponse> Post(EstimativeRequest body)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "en_US");
            httpClient.BaseAddress = Security.BaseAddress("API");
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"requests/estimate", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var Exception = JsonConvert.DeserializeObject(content);
                throw new System.Exception(Exception.ToString());
            }
            try
            {
                return JsonConvert.DeserializeObject<EstimativeResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }





        }


    }
}
