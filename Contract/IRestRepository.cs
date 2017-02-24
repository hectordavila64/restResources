using RestResource.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestResource.Contract
{
    public interface IRestRepository
    {
        void SetHeader(string name, string value);

        Task<Response<PaginationResponse<T>>> GetPagedAsync<T>(string uri, Pagination pagination, Sorting sorting);
        Task<Response<T>> GetAsync<T>(string uri);
        Task<Response<T>> PostAsync<T>(string uri, Object item);
        Task<Response<T>> PutAsync<T>(string uri, Object item);
        Task<Response<T>> DeleteAsync<T>(string uri);

        Response<PaginationResponse<T>> GetPaged<T>(string uri, Pagination pagination, Sorting sorting);
        Response<T> Get<T>(string uri);
        Response<T> Post<T>(string uri, Object item);
        Response<T> Put<T>(string uri, Object item);
        Response<T> Delete<T>(string uri);
    }
}
