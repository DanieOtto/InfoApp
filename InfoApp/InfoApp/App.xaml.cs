using InfoApp.Services;
using InfoApp.Views;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfoApp
{
    public partial class App : Application
    {
        private static AppSettings appSettings;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        public void ShowMainPage()
        {
            MainPage = new AppShell();
        }

        public static AppSettings AppSettings
        {
            get
            {
                if (appSettings == null)
                    LoadAppSettings();

                return appSettings;
            }
        }

        private static void LoadAppSettings()
        {
            var appSettingsResourceStream = Assembly.GetAssembly(typeof(AppSettings)).GetManifestResourceStream("InfoApp.AppSettings.json");

            if (appSettingsResourceStream == null)
                return;

            using (var streamReader = new StreamReader(appSettingsResourceStream))
            {
                var jsonString = streamReader.ReadToEnd();
                appSettings = JsonConvert.DeserializeObject<AppSettings>(jsonString);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
