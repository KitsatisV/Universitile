namespace Universitile01.Data
{
    public class Announcement
    {
        private string _title;
        private string _description;
        private string _date;
        private string _school;
        private string _direction;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string School
        {
            get { return _school; }
            set { _school = value; }
        }
        public string Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Announcement(string title, string description, string date, string school, string direction)
        {
            this._title = title;
            this._description = description;
            this._date = date;
            this._school = school;
            this._direction = direction;
        }
    }
}
