using GHPRS.Core.Interfaces;
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
        public DataTable ReadExcelWorkSheet(MemoryStream fileStream, string sheet, int startRow)
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
                    foreach (var firstRowCell in worksheet.Cells[startRow, 1, startRow, worksheet.Dimension.End.Column])
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
                    throw new Exception("Worksheet does not exist!");
                }
            }
        }
    }
}
