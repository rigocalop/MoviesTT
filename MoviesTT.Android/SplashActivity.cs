using Android.Content;
using Android.OS;
using AndroidX.AppCompat.App;
using MoviesTT.Droid;

namespace Fd.Droid
{
    public abstract class SplashActivity : AppCompatActivity
    {

        private static bool ActivityStarted;
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (ActivityStarted && Intent != null && (Intent.Flags & Android.Content.ActivityFlags.ReorderToFront) != 0)
            {
                Finish();
                return;
            }

            ActivityStarted = true;
            //Window.SetStatusBarColor(Android.Graphics.Color.Argb(75, 50, 13, 150));
            base.OnCreate(savedInstanceState);
        }
    }
}
