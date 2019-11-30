using System.Runtime.Serialization;


namespace SimpleWebApiClient
{
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
}
