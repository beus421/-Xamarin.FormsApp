using System;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Override the OnAppearing method to load reminders when the page appears
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Load reminders from the database and set the ListView's ItemsSource
            RemindersListView.ItemsSource = await App.Database.GetRemindersAsync();
        }

        // Event handler for when a reminder is tapped in the ListView
        async void OnReminderTapped(object sender, ItemTappedEventArgs e)
        {
            // Check if the tapped item is not null
            if (e.Item != null)
            {
                // Cast the tapped item to a Reminder object
                var reminder = e.Item as Reminder;

                // Navigate to the EditReminderPage with the selected reminder
                await Navigation.PushAsync(new EditReminderPage(reminder));
            }
        }

        // Event handler for when the "+" button is clicked to add a new reminder
        async void OnAddReminderClicked(object sender, EventArgs e)
        {
            // Navigate to the EditReminderPage with no reminder (creating a new one)
            await Navigation.PushAsync(new EditReminderPage());
        }
    }
}
