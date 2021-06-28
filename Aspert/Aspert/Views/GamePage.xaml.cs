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
        private readonly Dictionary<int, string> _matches;
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

            _matches = new Dictionary<int, string>();
            _shown = new bool[16];
            _stopwatch = new Stopwatch();

            var imagePaths = Enumerable.Range(1, 12).Select(x => $"m{x}.png").ToArray();
            var random = new Random();
            var indexes = Enumerable.Range(0, 16).ToArray();


            var count = 16;
            while (count > 1)
            {
                var index = random.Next(count--);
                var temp = indexes[count];

                indexes[count] = indexes[index];
                indexes[index] = temp;
            }

            var pathIndexes = indexes.Where(x => x < 12).Take(8).ToArray();

            for (var index = 0; index < 8; index++)
            {
                _matches.Add(indexes[index * 2], imagePaths[pathIndexes[index]]);
                _matches.Add(indexes[(index * 2) + 1], imagePaths[pathIndexes[index]]);
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

            _shown[index] = true;
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
                    "SÍ");
                return;
            }
            else if (_revealed % 2 == 0)
            {
                if (_matches[index] != _matches[_previous])
                {
                    await DisplayAlert("¡Incorrecto!", "El par elegido no coincide. ¡Sigue intentando!", "Ok");

                    _shown[index] = false;
                    _shown[_previous] = false;
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