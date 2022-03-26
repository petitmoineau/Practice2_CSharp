using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;

namespace Practice2.Tools
{
    class EmailValidationRule : ValidationRule
    {
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string _email = GetBoundValue(value) as string;

            Regex r = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if(_email == null) return new ValidationResult(false, $"Please enter email");
            else
            {
                if (r.Match(_email).Success)
                {
                    return ValidationResult.ValidResult;
                }
                else
                    return new ValidationResult(false, $"Please enter correct email");
            }
        }

        private object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                // ValidationStep was UpdatedValue or CommittedValue (Validate after setting)
                // Need to pull the value out of the BindingExpression.
                BindingExpression binding = (BindingExpression)value;

                // Get the bound object and name of the property
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;

                // Extract the value of the property.
                object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                // This is what we want.
                return propertyValue;
            }
            else
            {
                return value;
            }
        }
    }
}
