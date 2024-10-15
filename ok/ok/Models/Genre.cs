using SQLite;

namespace ok.Models
{
  public class Genre
  {
      [PrimaryKey, AutoIncrement]
      public int Id { get; set; }

      public string Name { get; set; }
  }
}

