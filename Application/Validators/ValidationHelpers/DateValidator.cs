using System.Text.RegularExpressions;

namespace Application.Validators.ValidationHelpers
{
    public static class DateValidator
    {
        public static bool IsDateValid(string date)
        {
            Regex regex = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])[\.\-](0?[1-9]|1[012])[\.\-]\d{4}$");

            return regex.IsMatch(date);
        }
    }
}
