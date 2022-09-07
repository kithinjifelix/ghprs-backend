using System;
using System.Data;
using System.IO;
using System.Linq;
using GHPRS.Core.Interfaces;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;

namespace GHPRS.Core.Services
{
    public class ExcelService : IExcelService
    {
        private readonly ILogger<ExcelService> _logger;

        public ExcelService(ILogger<ExcelService> logger)
        {
            _logger = logger;
        }

        public DataTable ReadExcelWorkSheet(MemoryStream fileStream, string sheet, int startRow, int startColumn)
        {
            using var excelPack = new ExcelPackage();
            //Load excel stream
            using (fileStream)
            {
                excelPack.Load(fileStream);
            }

            //select worksheet
            var worksheet = excelPack.Workbook.Worksheets.FirstOrDefault(w => w.Name == sheet);

            if (worksheet != null)
            {
                var excelAsTable = new DataTable();
                foreach (var firstRowCell in worksheet.Cells[startRow, startColumn, startRow,
                        worksheet.Dimension.End.Column])
                    //Get column details
                    if (!string.IsNullOrEmpty(firstRowCell.Text))
                        excelAsTable.Columns.Add(firstRowCell.Text);

                //Get row details
                for (var rowNum = startRow + 1; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                {
                    var wsRow = worksheet.Cells[rowNum, 1, rowNum, excelAsTable.Columns.Count];
                    var row = excelAsTable.Rows.Add();
                    foreach (var cell in wsRow) row[cell.Start.Column - 1] = cell.Text;
                }

                return excelAsTable;
            }

            _logger.LogError("Worksheet does not exist!");
            throw new Exception("Worksheet does not exist!");
        }
    }
}