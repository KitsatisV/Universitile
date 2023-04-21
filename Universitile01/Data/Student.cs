namespace Universitile01.Data
{
	public class Student
	{
		private string _name;
		private string _surname;
		private string _email;
		private string _school;
		private string _year;
		private string _dateOfBirth;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string Surname
		{
			get { return _surname; }
			set { _surname = value; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		public string School
		{
			get { return _school; }
			set { _school = value; }
		}
		public string Year
		{
			get { return _year; }
			set { _year = value; }
		}
		public string DateOfBirth
		{
			get { return _dateOfBirth; }
			set { _dateOfBirth = value; }
		}

        public Student() { }

        public Student(string name, string surname, string email, string school, string year, string dateOfBirth)
        {
            this._name = name;
			this._surname = surname;
			this._email = email;
			this._school = school;
			this._year = year;
			this._dateOfBirth = dateOfBirth;
        }
    }
}
