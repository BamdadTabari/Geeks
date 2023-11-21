﻿using Dayana.Shared.Infrastructure.Pagination;
using System.Net.Http.Json;
using System.Text.Json;

namespace Dayana.Shared.Persistence.HttpObjects;
public class HttpService : IHttpService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public HttpService(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    #region Get

    public async Task<T> GetValue<T>(string requestUrl)
    {
        var response = await _client.GetAsync(requestUrl);

        var content = await response.Content.ReadAsStreamAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception("bad request | maybe wrong address");

        return await JsonSerializer.DeserializeAsync<T>(content, _options);
    }

    public async Task<List<T>> GetValueList<T>(string requestUrl)
    {
        var response = await _client.GetAsync(requestUrl);

        var content = await response.Content.ReadAsStreamAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception("bad request | maybe wrong address");

        return await JsonSerializer.DeserializeAsync<List<T>>(content, _options);
    }

    #endregion

    #region Post Put Patch

    public async Task<HttpResponseMessage> PostValue<T>(string requestUrl, T data)
    {
        try
        {
            var serializedData = JsonSerializer.Serialize(data, _options);
            var response = await _client.PostAsJsonAsync(requestUrl, serializedData);
            Console.WriteLine(response);
            return response;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message, e);
        }
    }

    public async Task<HttpResponseMessage> PutValue<T>(string requestUrl, T data)
    {
        var serializedData = JsonSerializer.Serialize(data, _options);
        return await _client.PutAsJsonAsync(requestUrl, serializedData);
    }

    public async Task<HttpResponseMessage> PatchValue<T>(string requestUrl, T data)
    {
        var serializedData = JsonSerializer.Serialize(data, _options);
        return await _client.PatchAsJsonAsync(requestUrl, serializedData);
    }

    #endregion

    #region Delete

    public async Task<HttpResponseMessage> DeleteValue<T>(string requestUrl)
    {
        return await _client.DeleteAsync(requestUrl);
    }

    #endregion

    #region Pagination

    public async Task<PaginatedList<T>> GetPagedValue<T>(string requestUrl)
    {
        var response = await _client.GetAsync(requestUrl);
        var dataAsJson = await response.Content.ReadAsStreamAsync();
        var dataList = await JsonSerializer.DeserializeAsync<List<T>>(dataAsJson);
        if (dataList == null)
            throw new NullReferenceException("there is not any data here, add some data man!!");

        return new PaginatedList<T>() { Data = dataList, TotalCount = dataList.Count };
    }

    #endregion
}