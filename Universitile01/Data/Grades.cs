namespace Universitile01.Data
{
    public class Grades
    {
        private string _module;
        private int _grade;

        public string Module
        {
            get { return _module; }
            set { _module = value; }
        }
        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public Grades()
        {

        }
        public Grades(string module, int grade)
        {
            _module = module;
            _grade = grade;
        }
    }
}
