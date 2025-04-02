namespace LetterBoxedDupe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
        }
        protected override Window CreateWindow(IActivationState? activationState) 
        {
            return new Window(DetermineStartupPage());
        }

        private static Page DetermineStartupPage()
        {
            return new MainPage();
        }
    }
}
