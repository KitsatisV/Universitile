namespace Universitile01.Data
{
    public class Module
    {
		private string _name;
        private string _school;
        private string _direction;
        private string _teachers;

        public string Name
		{
			get { return _name; }
			set { _name = value; }
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
        public string Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }

        public Module(string name, string school, string direction, string teachers) 
        {
            this._name = name;
            this._school = school;
            this._direction = direction;
            this._teachers = teachers;
        }
    }
}
