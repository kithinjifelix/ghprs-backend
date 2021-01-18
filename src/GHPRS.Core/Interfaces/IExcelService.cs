using System.IO;

namespace GHPRS.Core.Interfaces
{
    public interface IExcelService
    {
        object ReadExcelWorkSheet(MemoryStream fileStream, string sheet, int startRow);
    }
}
