using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Client
    {
        private string url = "https://localhost:44392/";
        private static volatile Client instance;
        static object key = new object();
        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        instance = new Client();
                    }
                }
                return instance;
            }
        }
        private Client()
        {
        }
        public string Get(string path)
        {
            try
            {
                string jsonString = "";
                // server local
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync(path);
                response.Wait();
                var readData = response.Result;
                if (readData.IsSuccessStatusCode)
                {
                    var jsonData = readData.Content.ReadAsStringAsync();
                    jsonString = jsonData.Result;
                }
                return jsonString;
            }
            catch
            {
                return "";
            }
        }
        //private ClubsDTO GetByKey(string Key)
        //{
        //    HttpClient client = new HttpClient();
        //    // server local
        //    client.BaseAddress = new Uri("https://localhost:44392/");
        //    var response = client.GetAsync("api/clubs/getbykey/" + Key);
        //    response.Wait();
        //    var readData = response.Result;
        //    List<ClubsDTO> listClub = new List<ClubsDTO>();
        //    if (readData.IsSuccessStatusCode)
        //    {
        //        var jsonData = readData.Content.ReadAsStringAsync();
        //        string jsonString = jsonData.Result;
        //        var Data = DTO.ClubsDTO.FromJson(jsonString);
        //        listClub = Data.Select(kvp => kvp.Value).ToList();
        //    }
        //    return listClub.First();
        //}
        public async void Post(string path, object obj)
        {
            // server local
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.PostAsJsonAsync(path, obj);
            }
            catch
            {
                Console.Write("error");
            }
            try
            {
                UpdateKey(path);
            }
            catch
            {
                Console.Write("error");
            }
        }
        public async void Delete(string path, string key)
        {
            // server local
            try
            {
                if (key.Length != 0)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(url);
                    var response = await client.DeleteAsync(path + key);
                }
            }
            catch
            {
                Console.Write("error");
            }
        }
        public async void Put(string path, object obj)
        {
            try
            {
                if (obj != null)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(url);
                    var response = await client.PutAsJsonAsync(path, obj);
                }
            }
            catch
            {
                Console.Write("error");
            }
        }
        private void UpdateKey(string path)
        {
            try
            {
                List<dynamic> list = new List<dynamic>();
                string jsonString = Client.Instance.Get(path);
                var Data = DTO.obj.FromJson(jsonString);
                foreach (KeyValuePair<string, dynamic> value in Data)
                {

                    value.Value._Key = value.Key;
                }
                list = Data.Select(kvp => kvp.Value).ToList();
                foreach (dynamic value in list)
                {
                    Put(path, value);
                }
            }
            catch
            {
                Console.Write("error");
            }
        }
    }
}
