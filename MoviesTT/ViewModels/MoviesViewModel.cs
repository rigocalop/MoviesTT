using MoviesTT.Models;
using System.Collections.Generic;using System.Collections.ObjectModel;using System.Threading.Tasks;

namespace MoviesTT.ViewModels
{
    public class MoviesViewModel: base_Model
    {
        private IList<Movie> bak_TopRated;
        private IList<Movie> bak_UpComming;
        private IList<Movie> bak_Popular;
        public ObservableCollection<Movie> TopRated { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> UpComming { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> Popular { get; set; } = new ObservableCollection<Movie>();

        public MoviesViewModel()
        {
            //Task<IList<Movie>>
            //"/2CAL2433ZeIihfX1Hb2139CX0pW.jpg"
        }

       

        
        public void RefreshData(string _filter="")
        {
            _FilterSearch_byList(_filter, bak_TopRated, TopRated);
            _FilterSearch_byList(_filter, bak_UpComming, UpComming);
            _FilterSearch_byList(_filter, bak_Popular, Popular);
        }

        private void  _FilterSearch_byList(string _filter, IList<Movie> _source, ObservableCollection<Movie> _target)
        {
            _target.Clear();
            foreach (var _item in _source)
            {
                if (_filter.Length < 3 || (_filter.Length >= 3 && (_item.title.ToUpper()).IndexOf(_filter.ToUpper()) >= 0)) _target.Add(_item);
            }
        }

        public async Task Start()
        {
            bak_TopRated = await Services.svMovieDB.TopRated(10);
            bak_UpComming = await Services.svMovieDB.UpComming(10);
            bak_Popular = await Services.svMovieDB.Popular(10);
        }
    
    }
}
