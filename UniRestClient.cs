
using System.Collections.Generic;
using System.Threading.Tasks;
using unirest;

namespace SimpleWebApiClient
{
  /// <summary>
  /// Client to get the results, notice there is no instance of http client
  /// </summary>
  public class UniRestClient
  {
    /// <summary>
    /// Contructor
    /// </summary>
    public UniRestClient()
    {
    }

    /// <summary>
    /// Get Call to get the list of movies
    /// </summary>
    /// <param name="URL"></param>
    /// <returns></returns>
    public static List<MoviesModel> GetMoviesUsingUniREST(string URL)
    {
      List<MoviesModel> returnVal = null;

      Task<HttpResponse<List<MoviesModel>>> httpResponse = Unirest.get(URL)
                                                      .header("accept", "application/json") //You can also pass dictionary of headers
                                                      .asJsonAsync<List<MoviesModel>>();

      if (!(httpResponse is null) && (httpResponse.Result != null) && (httpResponse.Result.Code == 200))
      {
        returnVal = httpResponse.Result.Body;

      }

      return returnVal;
    }

  }
}
