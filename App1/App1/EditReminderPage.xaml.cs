using System;
using Xamarin.Forms;

namespace App1
{
    public partial class EditReminderPage : ContentPage
    {
        Reminder _reminder;

        public EditReminderPage(Reminder reminder = null)
        {
            InitializeComponent();

            if (reminder != null)
            {
                _reminder = reminder;
                ReminderText.Text = _reminder.Text;
            }
            else
            {
                _reminder = new Reminder();
            }
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            _reminder.Text = ReminderText.Text;
            await App.Database.SaveReminderAsync(_reminder);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_reminder.ID != 0)
            {
                await App.Database.DeleteReminderAsync(_reminder);
            }
            ReminderText.Text = string.Empty;
            await Navigation.PopAsync();
        }
    }
}
