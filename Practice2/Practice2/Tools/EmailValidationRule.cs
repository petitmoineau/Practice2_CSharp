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
            
            if (r.Match(_email).Success)
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, $"Please enter correct email");
        }

        private object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                BindingExpression binding = (BindingExpression)value;

                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;

                object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);

                return propertyValue;
            }
            else
            {
                return value;
            }
        }
    }
}
