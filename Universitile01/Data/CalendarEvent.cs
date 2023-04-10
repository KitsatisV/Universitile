namespace Universitile01.Data
{
    public class CalendarEvent
    {
        private string _title;
        private string _description;
        private DateTime _dateStart;
        private DateTime _dateEnd;

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
        public DateTime Start
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }
        public DateTime End
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }

        public CalendarEvent(string title, string description, DateTime dateStart, DateTime dateEnd)
        {
            this._title = title;
            this._description = description;
            this._dateStart = dateStart;
            this._dateEnd = dateEnd;
        }
    }
}
