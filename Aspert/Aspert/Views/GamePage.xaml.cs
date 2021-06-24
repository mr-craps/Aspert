using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Aspert.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aspert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        private readonly ImageButton[] _imageButtons;
        private readonly string[] _imagePaths;
        private readonly int[] _indexes;
        private readonly Dictionary<int, string> _matches;
        private readonly Random _random;
        private readonly bool[] _shown;
        private readonly Stopwatch _stopwatch;
        private int _revealed;
        private int _previous;
        private bool _gameFinished;

        public GamePage()
        {
            InitializeComponent();

            _imageButtons = new ImageButton[16];

            _imageButtons[0] = ib1;
            _imageButtons[1] = ib2;
            _imageButtons[2] = ib3;
            _imageButtons[3] = ib4;
            _imageButtons[4] = ib5;
            _imageButtons[5] = ib6;
            _imageButtons[6] = ib7;
            _imageButtons[7] = ib8;
            _imageButtons[8] = ib9;
            _imageButtons[9] = ib10;
            _imageButtons[10] = ib11;
            _imageButtons[11] = ib12;
            _imageButtons[12] = ib13;
            _imageButtons[13] = ib14;
            _imageButtons[14] = ib15;
            _imageButtons[15] = ib16;

            foreach (var imageButton in _imageButtons)
                imageButton.Clicked += OnImageButtonClicked;

            _imagePaths = new string[8];

            _imagePaths[0] = "close_aspert.png";
            _imagePaths[1] = "data_aspert.png";
            _imagePaths[2] = "edit_aspert.png";
            _imagePaths[3] = "logo_aspert.png";
            _imagePaths[4] = "notifications_aspert.png";
            _imagePaths[5] = "sync_aspert.png";
            _imagePaths[6] = "trashcan_aspert.png";
            _imagePaths[7] = "user_aspert.png";

            _random = new Random();
            _indexes = Enumerable.Range(0, 16).ToArray();
            _matches = new Dictionary<int, string>();
            _shown = new bool[16];
            _stopwatch = new Stopwatch();

            var count = 16;
            while (count > 1)
            {
                var index = _random.Next(count--);
                var temp = _indexes[count];

                _indexes[count] = _indexes[index];
                _indexes[index] = temp;
            }

            for (var index = 0; index < 8; index++)
            {
                _matches.Add(_indexes[index * 2], _imagePaths[index]);
                _matches.Add(_indexes[(index * 2) + 1], _imagePaths[index]);
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (height > width)
                grid.HeightRequest = width;
            else
                grid.WidthRequest = height;
        }

        private async void OnImageButtonClicked(object sender, EventArgs e)
        {
            if (_gameFinished)
                return;

            var imageButton = (ImageButton)sender;
            var index = Array.IndexOf(_imageButtons, imageButton);

            if (_shown[index])
                return;

            if (!_stopwatch.IsRunning)
                _stopwatch.Start();

            _revealed++;
            imageButton.Source = _matches[index];

            if (_revealed == 16)
            {
                _gameFinished = true;
                _stopwatch.Stop();

                var elapsed = _stopwatch.Elapsed.TotalSeconds;
                var isNewRecord = false;

                _stopwatch.Reset();

                if (SQLiteDB.Usuario.RecordMemoria == 0.0 ||
                    SQLiteDB.Usuario.RecordMemoria > elapsed)
                {
                    SQLiteDB.Usuario.RecordMemoria = elapsed;
                    isNewRecord = true;
                }

                await DisplayAlert(
                    "Felicidades!",
                    $"¡Has ganado! Tiempo: {elapsed}s {(isNewRecord ? "¡Nuevo récord!" : $"Record actual: {SQLiteDB.Usuario.RecordMemoria}s")}", 
                    "Yupi!");
                return;
            }
            else if (_revealed % 2 == 0)
            {
                var path = _matches[index];

                if (path == _matches[_previous])
                {
                    _shown[index] = true;
                    _shown[_previous] = true;
                }
                else
                {
                    await DisplayAlert("Incorrecto!", "El par elegido no coincide, sigue intentando!", "Ok");

                    imageButton.Source = null;
                    _imageButtons[_previous].Source = null;
                    _revealed -= 2;
                }
            }
            else
                _previous = index;
        }
    }
}