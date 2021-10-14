using MoviesTT.Controls;using MoviesTT.Models;using MoviesTT.ViewModels;
using System.Linq;using System.Threading.Tasks;using Xamarin.Forms;

namespace MoviesTT
{
    public partial class MoviesPage : ContentPage
    {
        public MoviesViewModel vm = new MoviesViewModel();

        public MoviesPage()
        {
            InitializeComponent();
            BindingContext = vm;
            Task t1 = Task.Run(async () => await vm.Start());
            t1.Wait();
            vm.RefreshData();

            MessagingCenter.Subscribe<ContentViewBC>(this, "MOVIE", (_BC) => this.BindingContextChanged(_BC));
            Search.TextChanged += (s, e) => vm.RefreshData(e.NewTextValue);
        }

        public new void BindingContextChanged(ContentViewBC _BC)
        {
            if (_BC == null || _BC.BindingContext == null) return;
            Movie _movie = (Movie)_BC.BindingContext;
            var _vote_average = _BC.FindByName<StarRated>("vote_average");
            _vote_average.Rated = _movie.vote_average;
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0) return;
            Movie _movie = (e.CurrentSelection.FirstOrDefault() as Movie);
            await this.Navigation.PushModalAsync(new MoviesTT.Views.MovieDetailPage(_movie.id));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
