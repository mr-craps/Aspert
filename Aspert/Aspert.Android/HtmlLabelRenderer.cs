using System.ComponentModel;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Text.Method;
using Aspert;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
public class HtmlLabelRenderer : LabelRenderer
{
    public HtmlLabelRenderer(Context context) : base(context)
    {
    }

    protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
    {
        base.OnElementChanged(e);

        if (Control != null && e.NewElement != null)
            UpdateText();

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O && Control != null)
            Control.JustificationMode = JustificationMode.InterWord;
    }

    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);

        if (e.PropertyName == nameof(HtmlLabel.Text))
            UpdateText();
    }

    private void UpdateText()
    {
        if (string.IsNullOrWhiteSpace(Element?.Text))
        {
            Control.Text = string.Empty;
            return;
        }

        Control.TextFormatted = Build.VERSION.SdkInt >= BuildVersionCodes.N
            ? Html.FromHtml(Element.Text, FromHtmlOptions.ModeCompact)
#pragma warning disable CS0618 // Type or member is obsolete
            : Html.FromHtml(Element.Text);
#pragma warning restore CS0618 // Type or member is obsolete

        Control.MovementMethod = LinkMovementMethod.Instance;
    }
}