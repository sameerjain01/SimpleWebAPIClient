using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApiClient
{

  /// <summary>
  /// Class to initialize the Dotnet
  /// </summary>
  public class DotNetClient
  {
    /// <summary>
    /// Instance of HTTP CLIENT
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Constructor where we initialize the httpclient instance
    /// </summary>
    public DotNetClient()
    {
      _httpClient = new HttpClient();
    }

    /// <summary>
    /// This metho
    /// </summary>
    /// <param name="URL"></param>
    /// <returns></returns>
    public async Task<List<MoviesModel>> GetMoviesUsingDonetStream(string URL)
    {
      List<MoviesModel> retResult = null;


      _httpClient.DefaultRequestHeaders.Accept.Clear();
      _httpClient.DefaultRequestHeaders.Accept.Add(
          new MediaTypeWithQualityHeaderValue(("application/json")));


      using (var streamTask = _httpClient.GetStreamAsync(URL))
      {
        var serializer = new DataContractJsonSerializer(typeof(List<MoviesModel>));
        retResult = serializer.ReadObject(await streamTask) as List<MoviesModel>;
      }

      return retResult;
    }
  }
}
