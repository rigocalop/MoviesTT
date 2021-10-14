using Xamarin.Forms;
namespace MoviesTT.Controls
{
    public class ContentViewBC: ContentView
    {
        public ContentViewBC()
        {
            this.BindingContextChanged += (s, e) => MessagingCenter.Send<ContentViewBC>(this, TargetBC);
        }
        public string TargetBC { get; set; } = "";
        public string TargetTAP { get; set; } = "";
    }
}
