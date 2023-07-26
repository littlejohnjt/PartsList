using Newtonsoft.Json;
using PartsList.Shared.Data;
using PartsList.Shared.Models;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace PartsList.Client.Services;

public class APIRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected string _controllerName;
    protected string _primaryKeyName;
    protected HttpClient _httpClient;

    public APIRepository(HttpClient httpClient, string controllerName, string primaryKeyName)
    {
        _httpClient = httpClient;
        _controllerName = controllerName;
        _primaryKeyName = primaryKeyName;
    }

    public async Task<bool> Delete(TEntity entity)
    {
        try
        {
            if (entity == null) return false;

            var id = 
                entity.GetType().GetProperty(_primaryKeyName)
                .GetValue(entity, null).ToString();

            if (string.IsNullOrEmpty(id)) return false;

            var uri = $"{_controllerName}/{WebUtility.UrlEncode(id)}";
            var result = await _httpClient.DeleteAsync(uri);
            result.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Delete(object id)
    {
        try
        {
            if (id == null) return false;

            var uri = $"{_controllerName}/{WebUtility.HtmlEncode(id.ToString())}";
            var result = await _httpClient.DeleteAsync(uri);
            result.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        try
        {
            var result = await _httpClient.GetAsync(_controllerName);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<APIListOfEntityResponse<TEntity>>(responseBody);

            if (response == null) return null;

            if (response.Success)
                return response.Data;
            else
                return new List<TEntity>();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<TEntity> GetById(int id)
    {
        try
        {
            var url = $"{_controllerName}/{WebUtility.HtmlEncode(id.ToString())}";
            var result = await _httpClient.GetAsync(url);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);

            if (response == null) return null;

            if (response.Success)
                return response.Data;
            else
                return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        try
        {
            var result = await _httpClient.PostAsJsonAsync(_controllerName, entity);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);

            if (response == null) return null;

            if (response.Success)
                return response.Data;
            else
                return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        try
        {
            var result = await _httpClient.PutAsJsonAsync(_controllerName, entity);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);

            if (response == null) return null;

            if (response.Success)
                return response.Data;
            else
                return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
