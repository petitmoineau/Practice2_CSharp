using System;
using System.Threading;
using Practice2.Tools;

namespace Practice2.Model
{
    class Person
    {
        public Person(string name, string surname, string email, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            Email = email;
            Birthday = birthday;
        }
        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            Email = email;
        }
        public Person(string name, string surname, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            Birthday = birthday;
        }

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        DateTime currentDate = DateTime.Now;
        private int _age;

        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;
        
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public DateTime Birthday 
        { 
            get => _birthday;
            set
            {
                _birthday = value.Date;

                
            }
        }
        public string Email { get => _email; set => _email = value; }

        public int Age { get => _age; internal set => _age = value; }

        public bool IsAdult { get => _isAdult; internal set => _isAdult = value; }

        public bool IsBirthday { get => _isBirthday; internal set => _isBirthday = value; }

        public string SunSign { get => _sunSign; internal set => _sunSign = value; }

        public string ChineseSign { get => _chineseSign; internal set => _chineseSign = value; }
    }
}
