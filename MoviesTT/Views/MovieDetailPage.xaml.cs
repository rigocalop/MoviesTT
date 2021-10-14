using MoviesTT.Models;using MoviesTT.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;using Xamarin.Forms.Xaml;

namespace MoviesTT.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetailPage : ContentPage
	{
		private Movie _Movie;
		private ObservableCollection<MovieCredit> _MovieCredits = new ObservableCollection<MovieCredit>();
		public MovieDetailPage(long iMovieID)
		{
			InitializeComponent();
			this.Appearing += async (s, e) =>
			{
				//carga de los datos generales de la MOVIE
				_Movie = await svMovieDB.MovieDetail(iMovieID);
				this.BindingContext = _Movie;
				
				//carga de CREDITOS
				var _list_credits = await svMovieDB.MovieCredits(iMovieID, 10);
				foreach(var _c0 in _list_credits) _MovieCredits.Add(_c0);
				this.CREDITS.ItemsSource = _MovieCredits;
				
				//actualización de otros valores.
				STARS.Rated = _Movie.vote_average;
			};

			// Configurar botton BACK
			var _tapback = new TapGestureRecognizer();
			_tapback.Tapped += async (s, e) => await Application.Current.MainPage.Navigation.PopModalAsync();
			_BACK.GestureRecognizers.Add(_tapback);

		}
	}
}