using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Fd.Droid.Renderers;
using MoviesTT.Controls;

[assembly: ExportRenderer(typeof(vEntry), typeof(vEntryRenderer))]

namespace Fd.Droid.Renderers
{
    public class vEntryRenderer : EntryRenderer
    {
        public vEntryRenderer(Context context) : base(context)
        {
        }

        public vEntry ElementV2 => Element as vEntry;
        protected override FormsEditText CreateNativeControl()
        {
            var control = base.CreateNativeControl();
            UpdateBackground(control);
            return control;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
            //IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
            //JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.comparte_cursor);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == vEntry.CornerRadiusProperty.PropertyName) UpdateBackground();
            else if (e.PropertyName == vEntry.BorderThicknessProperty.PropertyName) UpdateBackground();
            else if (e.PropertyName == vEntry.BorderColorProperty.PropertyName) UpdateBackground();

            base.OnElementPropertyChanged(sender, e);
        }

        protected override void UpdateBackgroundColor()
        {
            UpdateBackground();
        }
        protected void UpdateBackground(FormsEditText control)
        {
            if (control == null) return;

            var gd = new GradientDrawable();
            gd.SetColor(Element.BackgroundColor.ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(ElementV2.CornerRadius));
            gd.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());
            control.SetBackground(gd);

            var padTop = (int)Context.ToPixels(ElementV2.Padding.Top);
            var padBottom = (int)Context.ToPixels(ElementV2.Padding.Bottom);
            var padLeft = (int)Context.ToPixels(ElementV2.Padding.Left);
            var padRight = (int)Context.ToPixels(ElementV2.Padding.Right);

            control.SetPadding(padLeft, padTop, padRight, padBottom);
        }
        protected override void UpdateBackground() => UpdateBackground(Control);
    }
}