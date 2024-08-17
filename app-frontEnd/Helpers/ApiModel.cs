using Newtonsoft.Json;
using System.Diagnostics;

namespace app_frontEnd.Helpers
{
    public class ApiModel<T>
    {

        private readonly IConfiguration _configuration;
        public ApiModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<T> GetAllAsync()
        {
            try
            {
                var _client = new HttpClient();
                _client.BaseAddress = new Uri(_configuration.GetSection("UrlConfiguration").Value);
                HttpResponseMessage result = await _client.GetAsync(_client.BaseAddress + "api/task/get");
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    T model = JsonConvert.DeserializeObject<T>(response);
                    if (model != null)
                    {
                        return model;
                    }

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return default(T);
        }
        public async Task<T> GetByIdAsync(string Id)
        {
            try
            {
                var _client = new HttpClient();
                _client.BaseAddress = new Uri(_configuration.GetSection("UrlConfiguration").Value);
                HttpResponseMessage result = await _client.GetAsync(_client.BaseAddress + "api/task/getById/"+ Id);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    T model = JsonConvert.DeserializeObject<T>(response);
                    if (model != null)
                    {
                        return model;
                    }

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return default(T);
        }
        public async Task<T> PostAsync(object model)
        {
            var _client = new HttpClient();
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            _client.BaseAddress = new Uri(_configuration.GetSection("UrlConfiguration").Value);
            HttpResponseMessage result = await _client.PostAsync(_client.BaseAddress + "api/task/create", content);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                T mdl = JsonConvert.DeserializeObject<T>(response);
                if (mdl != null)
                {
                    return mdl;
                }
            }
            return default(T);
        }

        public async Task<T> PutAsync(object model,string id)
        {
            string _id = id;
            var _client = new HttpClient();
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            _client.BaseAddress = new Uri(_configuration.GetSection("UrlConfiguration").Value);
            HttpResponseMessage result = await _client.PutAsync(_client.BaseAddress + "api/task/update/"+ _id, content);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                T mdl = JsonConvert.DeserializeObject<T>(response);
                if (mdl != null)
                {
                    return mdl;
                }
            }
            return default(T);
        }

        public async Task<T> DeleteAsync(string Id)
        {
            var _client = new HttpClient();
            _client.BaseAddress = new Uri(_configuration.GetSection("UrlConfiguration").Value);
            HttpResponseMessage result = await _client.DeleteAsync(_client.BaseAddress + "api/task/delete/" + Id);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                T model = JsonConvert.DeserializeObject<T>(response);
                if (model != null)
                {
                    return model;
                }

            }
            return default(T);
        }

    }
}
