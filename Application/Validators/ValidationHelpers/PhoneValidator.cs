

using System.Text.RegularExpressions;

namespace Application.Validators.ValidationHelpers
{
    public static class PhoneValidator
    {
        public static bool IsPhoneValid(string phone)
        {
            Regex regex = new Regex(@"(^\+\d{1,2})?((\(\d{3}\))|(\-?\d{3}\-)|(\d{3}))((\d{3}\-\d{4})|(\d{3}\-\d\d\-\d\d)|(\d{7})|(\d{3}\-\d\-\d{3}))");

            return regex.IsMatch(phone);
        }
    }
}
