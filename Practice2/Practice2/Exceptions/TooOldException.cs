using System;
using System.Windows;

namespace Practice2.Exceptions
{
    [Serializable()]
    class TooOldException : Exception
    {
        public TooOldException(string message)
            : base(message)
        {
            MessageBox.Show(message);
        }
    }
}
