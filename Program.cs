using System;
using System.Collections.Generic;



namespace SimpleWebApiClient
{
  class Program
  {
      static void Main(string[] args)
    {
      var URL = "http://localhost:3000/movies";
     
      var uniRESTresult = UniRestClient.GetMoviesUsingUniREST(URL);

      Console.WriteLine("\n Printing Results using result from UNIRest FOR AP Stream");
      PrintResult(uniRESTresult);

      var dClient = new DotNetClient();
      var movies = dClient.GetMoviesUsingDonetStream(URL).Result;
      Console.WriteLine("\n Printing Results using result from DotNET Stream");
      PrintResult(movies);

      Console.ReadKey();
    }

    private static void PrintResult(List<MoviesModel> movies)
    {
      foreach (var mv in movies)
      {
        System.Console.WriteLine($"\nID# {mv.Id}");
        System.Console.WriteLine($"name# {mv.Name}");

        Console.WriteLine("NEXT MOVIE \n");
      }
    }

   

  

   


}






}
