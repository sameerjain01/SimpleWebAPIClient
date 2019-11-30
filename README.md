# Simple Web ApiClient
This is simple webApI client using DotNet Core, UniRest and JSON DB server for DB rest calls.


## Description
Every time I write API client while doing a Proof of Concept on integrations, I have dilema to 
  1. QUICK and DIRTY
  2. PRODUCTISE

Since, there is opportunity cost for either of approach either of the choice can have make the cycle longer.

I found these two tool to help find a balance between two approaches and cut down on my development time without sacrificing code quality. 
  1. UniRest Client 
  2. JSON Server: Setup a full fake REST API with zero coding in less than 30 seconds (seriously)(copied this line from the   description)

<br/><br/>

## Behaviour
You can use either command line command such 
 ```dotnet
 dotnet restore
 ```
  or
  ```dotnet
  dotnet build
```
Since this is console program it is very eay to follow. 

The code has two classes
  1. UniRestClient: This class provides a static function to make a RESTFul call to URL passed
      ``` dotnet
      
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
      ```
      
      
  2. DotNetClient: Simple dotnet GET RESTful client call
      ``` dotnet
         
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

      ```

3. The program class a simple JSON-SERVER (I have attached the DB JSON file in the code for reference).
    User can revier the JSON call to JSON server from console

      ```
      Start your JSON Server
      PS <Your directory of JSON file> json-server --watch moviesDB2.json
       \{^_^}/ hi!

        Loading moviesDB2.json
        Done

        Resources
        http://localhost:3000/movies

        Home
        http://localhost:3000

        Type s + enter at any time to create a snapshot of the database
        Watching...

      GET /movies 200 8.778 ms - 317
      POST /movies 201 7.192 ms - 14
      POST /movies/10 404 4.628 ms - 2
      GET /movies/10 200 3.237 ms - 92
      ```

      The program builds the collection of MoviesModel
      ``` dotnet

      [DataContract(Name = "movies")]
        public class MoviesModel
        {
          [DataMember(Name = "id")]
          public int Id { get; set; }

          [DataMember(Name = "NameOfMovie")]
          public string Name { get; set; }

          [DataMember(Name = "YearOfRelease")]
          public string Year { get; set; }

          [DataMember(Name = "Revenue")]
          public float Revenue { get; set; }

          public MoviesModel()
          { 
          }

          public MoviesModel(int id, string name, string year, float revenue)
          {
            Id = id;
            Name = name;
            Year = year;
            Revenue = revenue;
          }
        }
      ```

## Built With
1. C#
2. JSON Server
3. UniRest
4. RESTFul API
5. Visual Studio 2019
6. DotNET Core
7. DotNet Data Contract
8. DotNet Serializer


<br/><br/>

## Author
* Sameer

## Known Issues
Since this is very simplistic project meant for re-use in other project, this may have bugs, please use this guide a starting point and build on top of it. 

My plan is to use Generic in the RestFul Client so this could be generalized for different model without making code changes or duplication.

## Licence
Under MIT Licence. Please feel free to use and extend.

## References
- [Unirest for .Net](https://github.com/Kong/unirest-net)

- [JSON Server](https://github.com/typicode/json-server)

- [REST client](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient#processing-the-json-result)

## Acknowledgement
  1. GitHub Community
  2. DotNet Tutorials


