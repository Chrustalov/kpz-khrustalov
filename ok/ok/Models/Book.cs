using SQLite;

namespace ok.Models { 
  public class Book
  {
      [PrimaryKey, AutoIncrement]
      public int Id { get; set; }

      public string? Title { get; set; }
      public string? Description { get; set; }
      public int CountOfPages { get; set; }
      public string? Format { get; set; }
      public DateTime DateOfCreation { get; set; }
      public string? Language { get; set; }
  }
}
