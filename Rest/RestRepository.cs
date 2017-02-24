using RestResource.Contract;
using RestResource.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace RestResource.Rest
{
    public class RestRepository : IRestRepository
    {
        private HttpClient Client { get; set; }
        private string BaseUri { get; set; }

        public RestRepository(string baseUri)
        {
            Client = new HttpClient();
            BaseUri = baseUri;
        }

        public virtual void SetHeader(string name, string value)
        {
            Client.DefaultRequestHeaders.Add(name, value);
        }

        public virtual async Task<Response<T>> GetAsync<T>(string uri)
        {
            try
            {
                UpdateHeader();
                var absoluteUri = new Uri(new Uri(BaseUri), uri);
                var response = await Client.GetAsync(absoluteUri);
                var result = new Response<T>()
                {
                    StatusCode = response.StatusCode,
                    IsSuccessStatusCode = response.IsSuccessStatusCode
                };
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<T>(responseContent);
                    result.Data = responseData;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorData = JsonConvert.DeserializeObject<ErrorInformation>(errorContent);
                    result.Error = errorData;
                }
                return result;
            }
            catch
            {
                return new Response<T>()
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Error = new ErrorInformation()
                    {
                        Message = "Unable to connect to service"
                    }
                };
            }
        }

        public virtual async Task<Response<T>> PostAsync<T>(string uri, Object item)
        {
            try
            {
                UpdateHeader();
                var absoluteUri = new Uri(new Uri(BaseUri), uri);
                var jsonString = JsonConvert.SerializeObject(item, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(absoluteUri, content);
                var result = new Response<T>()
                {
                    StatusCode = response.StatusCode,
                    IsSuccessStatusCode = response.IsSuccessStatusCode
                };
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<T>(responseContent);
                    result.Data = responseData;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorData = JsonConvert.DeserializeObject<ErrorInformation>(errorContent);
                    result.Error = errorData;
                }
                return result;
            }
            catch
            {
                return new Response<T>()
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Error = new ErrorInformation()
                    {
                        Message = "Unable to connect to service"
                    }
                };
            }
        }

        public virtual async Task<Response<T>> PutAsync<T>(string uri, Object item)
        {
            try
            {
                UpdateHeader();
                var absoluteUri = new Uri(new Uri(BaseUri), uri);
                var jsonString = JsonConvert.SerializeObject(item, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await Client.PutAsync(absoluteUri, content);
                var result = new Response<T>()
                {
                    StatusCode = response.StatusCode,
                    IsSuccessStatusCode = response.IsSuccessStatusCode
                };
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<T>(responseContent);
                    result.Data = responseData;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorData = JsonConvert.DeserializeObject<ErrorInformation>(errorContent);
                    result.Error = errorData;
                }
                return result;
            }
            catch
            {
                return new Response<T>()
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Error = new ErrorInformation()
                    {
                        Message = "Unable to connect to service"
                    }
                };
            }
        }

        public virtual async Task<Response<T>> DeleteAsync<T>(string uri)
        {
            try
            {
                UpdateHeader();
                var absoluteUri = new Uri(new Uri(BaseUri), uri);
                var response = await Client.DeleteAsync(absoluteUri);
                var result = new Response<T>()
                {
                    StatusCode = response.StatusCode,
                    IsSuccessStatusCode = response.IsSuccessStatusCode
                };
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<T>(responseContent);
                    result.Data = responseData;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorData = JsonConvert.DeserializeObject<ErrorInformation>(errorContent);
                    result.Error = errorData;
                }
                return result;
            }
            catch
            {
                return new Response<T>()
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Error = new ErrorInformation()
                    {
                        Message = "Unable to connect to service"
                    }
                };
            }
        }

        public virtual void UpdateHeader()
        {
            //Add information that you need to put on the header request
        }

        public virtual Response<T> Get<T>(string uri)
        {
            var task = GetAsync<T>(uri);
            Task.WaitAll(task);
            return task.Result;
        }

        public virtual Response<T> Post<T>(string uri, object item)
        {
            var task = PostAsync<T>(uri, item);
            Task.WaitAll(task);
            return task.Result;
        }

        public virtual Response<T> Put<T>(string uri, object item)
        {
            var task = PutAsync<T>(uri, item);
            Task.WaitAll(task);
            return task.Result;
        }

        public virtual Response<T> Delete<T>(string uri)
        {
            var task = DeleteAsync<T>(uri);
            Task.WaitAll(task);
            return task.Result;
        }

        public virtual Task<Response<PaginationResponse<T>>> GetPagedAsync<T>(string uri, Pagination pagination, Sorting sorting)
        {
            var newUri = $"{uri}?{pagination.GetUrl()}&{sorting.GetUrl()}";
            return GetAsync<PaginationResponse<T>>(newUri);
        }

        public virtual Response<PaginationResponse<T>> GetPaged<T>(string uri, Pagination pagination, Sorting sorting)
        {
            var task = GetPagedAsync<T>(uri, pagination, sorting);
            Task.WaitAll(task);
            return task.Result;
        }
    }
}
