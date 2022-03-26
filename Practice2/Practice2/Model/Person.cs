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
                Thread threadAge = new Thread(() => CountTools.CountAge(currentDate, Birthday, out _age));
                threadAge.Start();

                Thread.Sleep(200);

                if (!threadAge.IsAlive)
                {
                    if (Age < 18) IsAdult = false;
                    else IsAdult = true;

                    IsBirthday = CountTools.CountIsBirthday(currentDate, Birthday);

                    Thread threadSunSign = new Thread(() => CountTools.CountSunSign(Birthday, out _sunSign));
                    Thread threadChineseSign = new Thread(() => CountTools.CountChineseSign(Birthday, out _chineseSign));

                    threadSunSign.Start();
                    threadChineseSign.Start();

                    if (threadSunSign.IsAlive || threadChineseSign.IsAlive)
                        Thread.Sleep(400);
                }
            }
        }
        public string Email { get => _email; set => _email = value; }

        public int Age { get => _age; private set => _age = value; }

        public bool IsAdult { get => _isAdult; private set => _isAdult = value; }

        public bool IsBirthday { get => _isBirthday; private set => _isBirthday = value; }

        public string SunSign { get => _sunSign; private set => _sunSign = value; }

        public string ChineseSign { get => _chineseSign; private set => _chineseSign = value; }
    }
}
