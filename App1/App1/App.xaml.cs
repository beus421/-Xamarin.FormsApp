using System;
using System.IO;
using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        static DatabaseHelper database;

        public static DatabaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Reminders.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}
