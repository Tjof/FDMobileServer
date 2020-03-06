using Xamarin.Forms;
using FindDrugMobile.Droid.ControlHelpers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
[assembly: ExportRenderer(typeof(Entry), typeof(XEntryRenderer))]
namespace FindDrugMobile.Droid.ControlHelpers
{
    [System.Obsolete]
    public class XEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}