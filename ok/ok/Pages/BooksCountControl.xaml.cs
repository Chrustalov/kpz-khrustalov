using Microsoft.Maui.Controls;
using ok.ViewModels;

namespace ok.Views
{
    public partial class BooksCountControl : ContentView
    {
        private BooksCountControlViewModel booksCountControlViewModel;

        public BooksCountControl()
        {
            InitializeComponent();
            
            booksCountControlViewModel = new BooksCountControlViewModel();
            this.BindingContext = booksCountControlViewModel;

            LoadData();
        }

        private async void LoadData()
        {
            await booksCountControlViewModel.LoadBooksCountAsync();
        }

        public static readonly BindableProperty CountProperty =
            BindableProperty.Create(nameof(Count), typeof(int), typeof(BooksCountControl), 0, propertyChanged: OnCountChanged);

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        private static void OnCountChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BooksCountControl)bindable;
            control.StartAnimation();
        }

        private void StartAnimation()
        {
            var animation = new Animation(v => ScoreLabel.Opacity = v, 0, 1);
            animation.Commit(this, "FadeIn", length: 1000, easing: Easing.Linear);
        }
    }
}
