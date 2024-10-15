using SQLite;

namespace ok.Models {
  public class Author
  {
      [PrimaryKey, AutoIncrement]
      public int Id { get; set; }

      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime BirthOfDate { get; set; }
      public string Description { get; set; }

      public Author()
      {
          FirstName = string.Empty;
          LastName = string.Empty;
          BirthOfDate = DateTime.MinValue;
          Description = string.Empty;
      }
  }

}
