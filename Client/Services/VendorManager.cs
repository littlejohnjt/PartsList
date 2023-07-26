using Newtonsoft.Json;
using PartsList.Shared.Models;
using static System.Net.WebRequestMethods;
using System.Net;

namespace PartsList.Client.Services;

public class VendorManager : APIRepository<Vendor>
{
    public VendorManager(HttpClient httpClient) 
        : base(httpClient, "vendors", "Id") { }

    public async Task<IEnumerable<Vendor>> GetByVendorName(string VendorName)
    {
        try
        {
            var url = $"{_controllerName}/searchbyname/{WebUtility.HtmlEncode(VendorName)}";
            var result = await _httpClient.GetAsync(url);
            result.EnsureSuccessStatusCode();
            string responseBody = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<APIListOfEntityResponse<Vendor>>(responseBody);
            if (response.Success)
                return response.Data;
            else
                return new List<Vendor>();
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
