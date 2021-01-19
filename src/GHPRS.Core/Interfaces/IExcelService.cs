using System.Data;
using System.IO;

namespace GHPRS.Core.Interfaces
{
    public interface IExcelService
    {
        DataTable ReadExcelWorkSheet(MemoryStream fileStream, string sheet, int startRow);
    }
}
