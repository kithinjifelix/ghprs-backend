using GHPRS.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Linq;

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
            using (var excelPack = new ExcelPackage())
            {
                //Load excel stream
                using (fileStream)
                {
                    excelPack.Load(fileStream);
                }

                //select worksheet
                var worksheet = excelPack.Workbook.Worksheets.FirstOrDefault(w => w.Name == sheet);

                if (worksheet != null)
                {
                    DataTable excelAsTable = new DataTable();
                    foreach (var firstRowCell in worksheet.Cells[startRow, startColumn, startRow, worksheet.Dimension.End.Column])
                    {
                        //Get colummn details
                        if (!string.IsNullOrEmpty(firstRowCell.Text))
                        {
                            excelAsTable.Columns.Add(firstRowCell.Text);
                        }
                    }

                    //Get row details
                    for (int rowNum = startRow + 1 ; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = worksheet.Cells[rowNum, 1, rowNum, excelAsTable.Columns.Count];
                        DataRow row = excelAsTable.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }

                    //Get everything as generics and let end user decides on casting to required type
                    //var generatedType = JsonConvert.DeserializeObject<object>(JsonConvert.SerializeObject(excelAsTable));
                    return excelAsTable;
                    //return (T)Convert.ChangeType(generatedType, typeof(T));
                }
                else
                {
                    _logger.LogError("Worksheet does not exist!");
                    throw new Exception("Worksheet does not exist!");
                }
            }
        }
    }
}
