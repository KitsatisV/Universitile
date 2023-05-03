namespace Universitile01.Data
{
	public class Session
	{
		private string _module;
		private string _date;
		private int _currentSession;
		private int _totalSessions;
		private string _attendance;
        private string _files;
        public string Module
		{
			get { return _module; }
			set { _module = value; }
		}
		public string Date
		{
			get { return _date; }
			set { _date = value; }
		}
		public int CurrentSession
		{
			get { return _currentSession; }
			set { _currentSession = value; }
		}
		public int TotalSessions
		{
			get { return _totalSessions; }
			set { _totalSessions = value; }
		}
		public string Attendance
		{
			get { return _attendance; }
			set { _attendance = value; }
		}
        public string Files
        {
            get { return _files; }
            set { _files = value; }
        }

        public Session() { }
        public Session(string module, string date, int currentSession, int totalSessions, string attendance, string files)
        {
            _module = module;
			_date = date;
			_currentSession = currentSession;
			_totalSessions = totalSessions;
			_attendance = attendance;
			_files = files;
        }
    }
}
