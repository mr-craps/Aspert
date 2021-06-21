using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hyperlink : ContentView
    {
        public static readonly BindableProperty LinkProperty = BindableProperty.Create(nameof(Link), typeof(string), typeof(Hyperlink), default(string), BindingMode.OneWay);
        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(Hyperlink), default(FontAttributes), BindingMode.OneWay);
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(Hyperlink), default(string), BindingMode.OneWay);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(Hyperlink), default(double), BindingMode.OneWay);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Hyperlink), default(string), BindingMode.OneWay);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Hyperlink), Color.LightBlue, BindingMode.OneWay);
        public static readonly BindableProperty TextDecorationsProperty = BindableProperty.Create(nameof(TextDecorations), typeof(TextDecorations), typeof(Hyperlink), TextDecorations.Underline, BindingMode.OneWay);
        public static readonly BindableProperty TextTransformProperty = BindableProperty.Create(nameof(TextTransform), typeof(TextTransform), typeof(Hyperlink), default(TextTransform), BindingMode.OneWay);

        public string Link
        {
            get => (string)GetValue(LinkProperty);
            set => SetValue(LinkProperty, value);
        }

        public FontAttributes FontAttributes
        {
            get => (FontAttributes)GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public TextDecorations TextDecorations
        {
            get => (TextDecorations)GetValue(TextDecorationsProperty);
            set => SetValue(TextDecorationsProperty, value);
        }

        public TextTransform TextTransform
        {
            get => (TextTransform)GetValue(TextTransformProperty);
            set => SetValue(TextTransformProperty, value);
        }

        public ICommand OpenLink { get; } = new Command<string>(async url => await Launcher.OpenAsync(url));

        public Hyperlink()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}