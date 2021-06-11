using Android.Content;
using Android.OS;
using Android.Text;
using Aspert;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(JustifiedLabel), typeof(JustifiedLabelRenderer))]
public class JustifiedLabelRenderer : LabelRenderer
{
    public JustifiedLabelRenderer(Context context) : base(context)
    {
    }

    protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
    {
        base.OnElementChanged(e);

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O && Control != null)
            Control.JustificationMode = JustificationMode.InterWord;
    }
}