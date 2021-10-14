using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace MoviesTT.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarRated : ContentView
    {
        private Brush StarRated_TRUE;
        private Brush StarRated_FALSE;

        public StarRated()
        {

            InitializeComponent();
            //his.sta
            string _data = "M 249.398 80.078 L 288.242 197.145 L 413.959 197.145 L 312.25 269.493 L 351.098 386.568 L 249.396 314.209 L 147.697 386.569 L 186.545 269.497 L 84.838 197.139 L 210.553 197.145 L 249.398 80.078 Z";
            star5.Data = star4.Data = star3.Data = star2.Data = star1.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(_data);

            StarRated_TRUE = new SolidColorBrush((Color)Application.Current.Resources["StarRated_TRUE"]);
            StarRated_FALSE = new SolidColorBrush((Color)Application.Current.Resources["StarRated_FALSE"]);
            star5.Fill = star4.Fill = star3.Fill = star2.Fill = star1.Fill  = StarRated_FALSE;
            //Rated = 5;
        }

        
        /// <summary>
        /// La cantidad base a evaluar, para estimar el numero de estrellas a mostrar.
        /// </summary>
        public double RatedBase { get; set; } = 5;
        /// <summary>
        /// Especifica el número de estrellsa.
        /// </summary>
        private double _Rated = 0;

        public static readonly BindableProperty RatedProperty = BindableProperty.Create("Rated", typeof(double), typeof(ContentView), 0.0);
        public double Rated
        {
            get { return _Rated; }
            set
            {

                _Rated = value / (RatedBase/5);
                star1.Fill = (_Rated > 0) ? StarRated_TRUE : StarRated_FALSE;
                star2.Fill = (_Rated > 1) ? StarRated_TRUE : StarRated_FALSE;
                star3.Fill = (_Rated > 2) ? StarRated_TRUE : StarRated_FALSE;
                star4.Fill = (_Rated > 3) ? StarRated_TRUE : StarRated_FALSE;
                star5.Fill = (_Rated > 4) ? StarRated_TRUE : StarRated_FALSE;
            }
        }
    }
}