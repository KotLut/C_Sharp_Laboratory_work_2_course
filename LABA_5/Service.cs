namespace LABA_5
{
    internal class Service
    {
        private int _id;
        private string _name;

        public Service()
        {
            _id = 0;
            _name = "";
        }

        public Service(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public Service(Service other)
        {
            _id = other._id;
            _name = other._name;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            return "Код: " + _id + ", название: " + _name;
        }
    }
}
