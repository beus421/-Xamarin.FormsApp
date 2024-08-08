﻿using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Reminder>().Wait();
        }

        public Task<List<Reminder>> GetRemindersAsync()
        {
            return _database.Table<Reminder>().ToListAsync();
        }

        public Task<Reminder> GetReminderAsync(int id)
        {
            return _database.Table<Reminder>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveReminderAsync(Reminder reminder)
        {
            if (reminder.ID != 0)
            {
                return _database.UpdateAsync(reminder);
            }
            else
            {
                return _database.InsertAsync(reminder);
            }
        }

        public Task<int> DeleteReminderAsync(Reminder reminder)
        {
            return _database.DeleteAsync(reminder);
        }
    }
}
