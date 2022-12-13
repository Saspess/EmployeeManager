namespace Application.Helpers.MappingHelpers
{
    public static class AddressChecker
    {
        public static string Check(string houseCode)
        {
            if(houseCode != null)
            {
                return $"/{houseCode}";
            }
            else
            {
                return "";
            }
        }

        public static string Check(int? flat)
        {
            if (flat != null)
            {
                return $" {flat}";
            }
            else
            {
                return "";
            }
        }
    }
}
