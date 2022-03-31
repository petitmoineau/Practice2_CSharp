using System;
using System.Windows;

namespace Practice2.Exceptions
{
    [Serializable()]
    public class NotBornException : Exception
    {
        public NotBornException (string message)
            : base(message)
        {
            MessageBox.Show(message);
        }
    }
}
