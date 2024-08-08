using SQLite;

namespace App1
{
    public class Reminder
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }  // Make sure this property is included in your Reminder class
        public string Text { get; set; }
    }
}
