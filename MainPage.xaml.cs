using System;

namespace GeekSpeak
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();

        List<string> _quotes = new List<string>();

        int _index;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();
            InitiateApp();
        }

        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("GeekQuotes.txt");
            using var reader = new StreamReader(stream);

            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                _quotes.Add(line);
            }
        }

        private void btnGenerate_Clicked(object sender, EventArgs e) => InitiateApp();

        private void InitiateApp()
        {
            if (_quotes.Count > 0)
            {
                List<GradientStop> gradientStops = new List<GradientStop> { gstop1, gstop2, gstop3, gstop4, gstop5 };

                foreach (GradientStop gradientStop in gradientStops)
                {
                    gradientStop.Color = Color.FromRgb(red: Random.Shared.Next(0, 256),
                                                       green: Random.Shared.Next(0, 256),
                                                       blue: Random.Shared.Next(0, 256));
                }

                _index = random.Next(_quotes.Count);
                lblQuotes.Text = _quotes[_index];
            }
            else
                lblQuotes.Text = "Generating....";
        }
    }

}
