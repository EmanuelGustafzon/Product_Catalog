using Shared.Interfaces;
using Shared.Services;

namespace MauiApplication
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            string mainDir = FileSystem.Current.AppDataDirectory;
            IFileService fileService = new FileService(mainDir);
            fileService.WriteFile(Input.Text, "test.txt");
            string text = fileService.ReadFile("test.txt");
            Output.Text = text;
        }
    }

}
