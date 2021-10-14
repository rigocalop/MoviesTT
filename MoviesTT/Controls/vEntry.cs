using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MoviesTT.Controls
{
    [DesignTimeVisible(true)]
    public class vEntry : Entry
    {
        
        public vEntry()
        {
            BackgroundColor = Color.Transparent;
            VerticalOptions = LayoutOptions.Center;
            BorderColor = Color.Transparent;
            //BorderThickness = 1;
            this.Keyboard = Keyboard;

        }

        public Boolean SmsEntry { get; set; }

        //BORDER THICKNESS
        public static BindableProperty BorderThicknessProperty = BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(vEntry), 2);
        public int BorderThickness { get => (int)GetValue(BorderThicknessProperty); set => SetValue(BorderThicknessProperty, value); }

        //BORDER COLOR
        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(vEntry), Color.Red);
        public Color BorderColor { get => (Color)GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }

        //CORNER RADIUS
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(vEntry), 0);
        public int CornerRadius { get => (int)GetValue(CornerRadiusProperty); set => SetValue(CornerRadiusProperty, value); }

        //PADDING
        public static BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(vEntry), new Thickness(5));
        public Thickness Padding { get => (Thickness)GetValue(PaddingProperty); set => SetValue(PaddingProperty, value); }
    }
}
