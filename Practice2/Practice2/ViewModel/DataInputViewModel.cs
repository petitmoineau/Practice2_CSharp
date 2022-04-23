using Practice2.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Practice2.Tools;
using System.Windows;
using Practice2.View;
using Practice2.Exceptions;
using System.Globalization;

namespace Practice2.ViewModel
{
    class DataInputViewModel 
    {
        Person _person = new Person(null, null, null);
        EmailValidationRule evr = new EmailValidationRule();
        private RelayCommand<object> _proceed;


        public string Name
        {
            get
            {
                return _person.Name;
            }
            set
            {
                _person.Name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _person.Surname;
            }
            set
            {
                _person.Surname = value;
            }
        }
        public string Email
        {
            get
            {
                return _person.Email;
            }
            set
            {
                _person.Email = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return _person.Birthday;
            }
            set
            {
                _person.Birthday = value;
            }
        }
        public string IsAdult
        {
            get
            {
                if (_person.IsAdult) return "Yes";
                else return "No" ;
            }
        }

        public string IsBirthday
        {
            get
            {
                if (_person.IsBirthday) return "Yes";
                else return "No";
            }
        }
        public string SunSign
        {
            get
            {
                return _person.SunSign;
            }
        }
        public string ChineseSign
        {
            get
            {
                return _person.ChineseSign;
            }
        }

        public RelayCommand<object> Proceed
        {
            get
            {
                return _proceed ??= new RelayCommand<object>(_ => DoProceed(), CanExecute);
            }
        }

        public void DoProceed()
        {
            try
            {
                CheckDate();
            }
            catch
            {
                Console.WriteLine("Not ok");
            }
            
        }

        private async void CheckDate()
        {
            await CountTools.CountAll(DateTime.Now, Birthday);

            _person.IsBirthday = CountTools.isBirthday;
            _person.Age = CountTools.age;
            _person.SunSign = CountTools.sunSign;
            _person.ChineseSign = CountTools.chineseSign;

            if (_person.Age < 18) 
                _person.IsAdult = false;
            else 
                _person.IsAdult = true;

            if (_person.Age < 0)
                throw new NotBornException("Date is wrong! Person isn`t born yet");
            else if (_person.Age > 135)
                throw new TooOldException("Date is wrong! Person is already dead");
            else
            {
                if (_person.IsBirthday)
                    MessageBox.Show($"Happy {_person.Age}th birthday!");



                ShowData _showData = new ShowData();
                _showData.DataContext = this;
                _showData.Show();
            }
        }
        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_person.Name) && !String.IsNullOrWhiteSpace(_person.Surname)
                    && evr.Validate(_person.Email, new CultureInfo("en-US")).IsValid && _person.Birthday != default;
        }
    }
}
