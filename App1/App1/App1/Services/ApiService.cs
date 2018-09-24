using App1.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public class ApiService
    {

        public async Task<Response> CheckConnection()
        {

            if(!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please turn on your internet settings."
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");

            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Check your internet connection."
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok"
            };
        }

        public async Task<Response> GetList<T>(string urlBase, string servicePrefix, string controller)
        {

            try
            {

                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var reponse = await client.GetAsync(url);
                var result = await reponse.Content.ReadAsStringAsync();

                if (!reponse.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list
                };

            }catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }

    }
}
