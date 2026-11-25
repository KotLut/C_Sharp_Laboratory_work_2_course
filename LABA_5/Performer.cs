using System;

namespace LABA_5
{
    internal class Performer
    {
        private int _id;
        private int _age;
        private string _citizenship;

        public Performer()
        {
            _id = 0;
            _age = 0;
            _citizenship = "";
        }

        public Performer(int id, int age, string citizenship)
        {
            _id = id;
            _age = age;
            _citizenship = citizenship;
        }

        public Performer(Performer other)
        {
            _id = other._id;
            _age = other._age;
            _citizenship = other._citizenship;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Citizenship
        {
            get { return _citizenship; }
            set { _citizenship = value; }
        }

        public override string ToString()
        {
            return "Код: " + _id + ", возраст: " + _age + ", гражданство: " + _citizenship;
        }
    }
}