namespace Universitile01
{
    public class Teacher
    {
        private string _name;
        private string _surname;
        private string _modules;
        private string _department;
        private string _email;
        private string _phone;

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
        public string Modules
        {
            get { return _modules; }
            set { _modules = value; }
        }
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public Teacher(string name, string surname, string modules, string department, string email, string phone) 
        {
            this._name = name;
            this._surname = surname;
            this._modules = modules;
            this._department = department;
            this._email = email;
            this._phone = phone;
        }
    }
}
