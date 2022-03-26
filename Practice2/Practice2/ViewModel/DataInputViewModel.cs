using Practice2.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Practice2.Tools;
using System.Windows;
using Practice2.View;
using System.Globalization;

namespace Practice2.ViewModel
{
    class DataInputViewModel : INotifyPropertyChanged
    {
        Person _person = new Person(null, null, null);
        static CultureInfo ci = new CultureInfo("en-US");
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
            if (_person.Age < 0 || _person.Age > 135)
                MessageBox.Show($"Date is wrong!");
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
                && evr.Validate(_person.Email, ci).IsValid && _person.Birthday != default;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
