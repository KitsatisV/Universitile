namespace Universitile01.Data
{
    public class Announcement
    {
        private string  _title;
        private string  _description;
        private string  _date;
        private string  _school;
        private string  _direction;
        private bool    _importance;
        private bool    _isNotRead;

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
        public bool Importance
        {
            get { return _importance; }
            set { _importance = value; }
        }
        public bool IsNotRead
        {
            get { return _isNotRead; }
            set { _isNotRead = value; }
        }

        public Announcement(string title, string description, string date, string school, string direction, bool importance, bool isNotRead)
        {
            this._title = title;
            this._description = description;
            this._date = date;
            this._school = school;
            this._direction = direction;
            this._importance = importance;
            this._isNotRead = isNotRead;
        }
    }
}
