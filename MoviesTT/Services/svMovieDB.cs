using MoviesTT.Models;using sw.JAR;
using System.Collections.Generic;using System.Text.Json;using System.Threading.Tasks;

namespace MoviesTT.Services
{
    public static class svMovieDB
    {
        public const string URL = "https://api.themoviedb.org/3/movie/";
        public const string API_KEY = "f7cff9984bcfe077586b60a84cac9950";
        public const string IMAGE_URL = "https://image.tmdb.org/t/p";

        public static async Task<IList<MovieCredit>> MovieCredits(long iMovieID, int iMaxItems = 10)
        {
            resJAR _res = await sw.JAR.Execute.mode0($@"{URL}{iMovieID}/credits?api_key={API_KEY}&language=en-US");
            IList<MovieCredit> _ret = new List<MovieCredit>();
            if (_res.StatusCode != 200) return _ret;
            JsonDocument _document = JsonDocument.Parse(_res.ResponseJDATA);
            JsonElement _root = _document.RootElement;
            JsonElement _cast = _root.GetProperty("cast");

            foreach (JsonElement _cursor in _cast.EnumerateArray())
            {
                MovieCredit _credits = new MovieCredit();
                _credits.id = _cursor.GetProperty("id").GetInt64();
                _credits.name = _cursor.GetProperty("name").GetString();
                _credits.profile_path = $@"{IMAGE_URL}/w185{_cursor.GetProperty("profile_path").GetString()}";
                _ret.Add(_credits);
                if (iMaxItems != 0 && _ret.Count == iMaxItems) break;
            }
            return _ret;
        }
        public static async Task<Movie> MovieDetail(long iMovieID)
        {
            resJAR _res = await sw.JAR.Execute.mode0($@"{URL}{iMovieID}?api_key={API_KEY}&language=en-US");
            Movie _movie = new Movie();
            if (_res.StatusCode != 200) return _movie;

            JsonDocument _document = JsonDocument.Parse(_res.ResponseJDATA);
            JsonElement _root = _document.RootElement;
            _movie.id = _root.GetProperty("id").GetInt64();
            _movie.title = _root.GetProperty("title").GetString();
            _movie.overview = _root.GetProperty("overview").GetString();
            _movie.vote_average = _root.GetProperty("vote_average").GetDouble();
            _movie.poster_path = $@"{IMAGE_URL}/w500{_root.GetProperty("poster_path").GetString()}";
            _movie.backdrop_path = $@"{IMAGE_URL}/w500{_root.GetProperty("backdrop_path").GetString()}";
            _movie.release = _root.GetProperty("release_date").GetString().Substring(0,4);


            // carga del genero
            JsonElement _genres = _root.GetProperty("genres");
            foreach (JsonElement _je0 in _genres.EnumerateArray())
            {
                string _genero = _je0.GetProperty("name").GetString();
                _movie.genres += ((_movie.genres == "") ? "" : ", ") + _genero;
            }

            //carga de estudio.
            JsonElement _companies = _root.GetProperty("production_companies");
            foreach (JsonElement _je0 in _companies.EnumerateArray())
            {
                string _studio = _je0.GetProperty("name").GetString();
                _movie.studio += ((_movie.studio == "") ? "" : ", ") + _studio;
            }

            return _movie;
        }
        public static async Task<IList<Movie>> TopRated(int iMaxItems=0)
        {
            resJAR _res = await sw.JAR.Execute.mode0($@"{URL}top_rated?api_key={API_KEY}&language=en-US&page=1");
            return Convert_ToList(_res, iMaxItems);
        }

        public static async Task<IList<Movie>> UpComming(int iMaxItems = 0)
        {
            resJAR _res = await sw.JAR.Execute.mode0($@"{URL}upcoming?api_key={API_KEY}&language=en-US&page=1");
            return Convert_ToList(_res, iMaxItems);
        }
        public static async Task<IList<Movie>> Popular(int iMaxItems = 0)
        {
            resJAR _res = await sw.JAR.Execute.mode0($@"{URL}popular?api_key={API_KEY}&language=en-US&page=1");
            return Convert_ToList(_res, iMaxItems);
        }



        private static IList<Movie> Convert_ToList(resJAR _res, int iMaxItems=0)
        {
            IList<Movie> _ret = new List<Movie>();
            if (_res.StatusCode != 200) return _ret;

            JsonDocument _document = JsonDocument.Parse(_res.ResponseJDATA);
            JsonElement _root = _document.RootElement;
            JsonElement _results = _root.GetProperty("results");

            foreach (JsonElement _cursor in _results.EnumerateArray())
            {
                Movie _newmovie = new Movie();
                _newmovie.id = _cursor.GetProperty("id").GetInt64();
                _newmovie.title = _cursor.GetProperty("title").GetString();
                _newmovie.overview = _cursor.GetProperty("overview").GetString();
                _newmovie.poster_path = $@"{IMAGE_URL}/w500{_cursor.GetProperty("poster_path").GetString()}";
                _newmovie.backdrop_path = $@"{IMAGE_URL}/w500{_cursor.GetProperty("backdrop_path").GetString()}";

                _newmovie.vote_average = _cursor.GetProperty("vote_average").GetDouble();
                _ret.Add(_newmovie);
                if (iMaxItems != 0 && _ret.Count == iMaxItems) break;
            }
            return _ret;
        }
    }
}
