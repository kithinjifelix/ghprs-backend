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
            try
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
                    if (worksheet.Name == "TB")
                    {
                        excelAsTable.Columns.Add("Mechanism ID");
                        excelAsTable.Columns.Add("Partner");
                        excelAsTable.Columns.Add("Reporting Month");
                        excelAsTable.Columns.Add("Year");
                        excelAsTable.Columns.Add("Region");
                        excelAsTable.Columns.Add("District");
                        excelAsTable.Columns.Add("Health Facility");
                        excelAsTable.Columns.Add("Facility ID");
                        excelAsTable.Columns.Add("TB Detection Male 0 - 14");
                        excelAsTable.Columns.Add("TB Detection Male 15+");
                        excelAsTable.Columns.Add("TB Detection Female 0 - 14");
                        excelAsTable.Columns.Add("TB Detection Female 15+");
                        excelAsTable.Columns.Add("Bacteriological Diagnosis Coverage (Pulmonary TB) 0 - 14");
                        excelAsTable.Columns.Add("Bacteriological Diagnosis Coverage (Pulmonary TB) 15+");

                        return excelAsTable;
                    }
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
                
                if (sheet == "Configuration")
                {
                    var excelAsTable = new DataTable();
                    excelAsTable.Columns.Add("SheetName");
                    excelAsTable.Columns.Add("Range");
                    
                    string[,] sheetNames = new string[3, 2] {{ "Facility Data", "A5:DD1000" }, {"TB", "A4:I41000"},{"Community Data", "A5:BJ1000"}};
                    for (int i = 0; i < 3; i++)
                    {
                        var row = excelAsTable.Rows.Add();
                        row[0] = sheetNames[i, 0];
                        row[1] = sheetNames[i, 1];
                    }
                    return excelAsTable;
                }

                _logger.LogError("Worksheet does not exist!");
                throw new Exception("Worksheet does not exist!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}