using System;

namespace GHPRS.Core.Utilities
{
    public static class Utility
    {
        public static string TruncateLongString(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static dynamic ConvertToType(object obj)
        {
            return Convert.ChangeType(obj, obj.GetType());
        }

        public static int ExcelColumnNameToNumber(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");

            columnName = columnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += (columnName[i] - 'A' + 1);
            }

            return sum;
        }

        public static Tuple<int, int> ExcelRowAndColumn(string excelAddress)
        {
            int startIndex = excelAddress.IndexOfAny("0123456789".ToCharArray());
            int column = Utility.ExcelColumnNameToNumber(excelAddress.Substring(0, startIndex));
            int row = Int32.Parse(excelAddress.Substring(startIndex));
            return new Tuple<int, int>(row, column);
        }
    }
}
