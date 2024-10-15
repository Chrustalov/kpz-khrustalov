using System.ComponentModel;
using ok.Services.BookService;

namespace ok.ViewModels
{
    public class BooksCountControlViewModel : INotifyPropertyChanged
    {
        private int _count;
        private readonly BookService bookService;

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public BooksCountControlViewModel() 
        {
            bookService = new BookService();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadBooksCountAsync()
        {
            await Task.Delay(1000);
            var items = await bookService.getBooksAsync();
            Count = items.Count();
        }
    }
}
