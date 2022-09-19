using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace GHPRS.Persistence.Repositories
{
    public class UploadRepository : Repository<Upload>, IUploadRepository
    {
        private readonly GhprsContext _context;
        private readonly DataContext _dataContext;
        private readonly IQueryable<Upload> _entities;
        private readonly ILogger<UploadRepository> _logger;

        public UploadRepository(GhprsContext context, DataContext dataContext, ILogger<UploadRepository> logger) :
            base(context)
        {
            _entities = context.Uploads
                .Include(i => i.Template)
                .Include(i => i.User).ThenInclude(z => z.Person)
                .AsNoTracking();
            _context = context;
            _dataContext = dataContext;
            _logger = logger;
        }

        public IEnumerable<Upload> GetFullUploads()
        {
            return _entities.OrderBy(n => n.Name);
        }

        public object GetDetailsById(int id)
        {
            var result = _entities.Select(s => new
                    {s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt, s.UploadStatus})
                .FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Upload GetFullUploadById(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<object> GetList()
        {
            var result = _entities.Select(s => new
                    {s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt, s.UploadStatus})
                .OrderBy(n => n.Name)
                .ToList();
            return result;
        }

        public IEnumerable<object> GetListByStatus(UploadStatus status)
        {
            var result = _entities
                .Select(s => new
                    {s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt, s.UploadStatus})
                .Where(x => x.Status == status).OrderBy(n => n.Name).ToList();
            return result;
        }

        public IEnumerable<object> GetListByUser(User user)
        {
            var result = _entities
                .Select(s => new
                    {s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt, s.UploadStatus})
                .Where(x => x.User == user).OrderBy(n => n.Name).ToList();
            return result;
        }

        public void InsertToTable(WorkSheet workSheet, DataTable data, string uploadBatch, Guid uploadBatchGuid)
        {
            var insertScript = string.Empty;
            foreach (DataRow row in data.Rows)
            {
                var columns = string.Empty;
                var rows = string.Empty;
                foreach (var column in workSheet.Columns)
                    try
                    {
                        if (column.Name != "Id")
                        {
                            string r;
                            if (column.Type == "NUMERIC")
                            {
                                if (row[column.Name].ToString()?.Trim() == "" ||
                                    row[column.Name].ToString()?.Trim() == "-" ||
                                    row[column.Name].ToString()?.ToLower().Trim() == "o")
                                {
                                    r = null;
                                }
                                else
                                {
                                    var str = $"{row[column.Name]}";
                                    r = EscapeSqlCharacters(str);
                                }
                            }
                            else
                            {
                                r = EscapeSqlCharacters(row[column.Name].ToString());
                            }

                            rows += r == null ? $"NULL, " : $" \'{r}\',";
                            columns += $" \"{column.Name}\",";
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message, e);
                    }

                rows += $" \'{uploadBatch}\',";
                columns += " \"Upload_Batch\",";
                var reportDate = CreateReportDate(row);
                rows += $" \'{reportDate.ToString("yyyy-MM-dd")}\',";
                columns += " \"Report Date\",";
                rows += $" \'{uploadBatchGuid}\',";
                columns += " \"UploadBatchGuid\",";
                //remove trailing commas
                rows = rows.Remove(rows.Length - 1);
                columns = columns.Remove(columns.Length - 1);
                var tableName = workSheet.TableName;
                if (workSheet.Name == "Facility Data")
                {
                    tableName = "StagingFacilityData";
                }
                else if (workSheet.Name == "Community Data")
                {
                    tableName = "StagingCommunityData";
                }
                else if (workSheet.Name == "TB")
                {
                    tableName = "StagingTBData";
                }
                var insert = $"INSERT INTO public.\"{tableName}\" ({columns}) VALUES ({rows});";
                insertScript += insert;
            }

            try
            {
                string connectionString;
                if (workSheet.Name == "Facility Data" || workSheet.Name == "Community Data")
                {
                    connectionString = _context.Database.GetConnectionString();
                }
                else
                {
                    connectionString = _dataContext.Database.GetConnectionString();
                }
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = insertScript;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public void UpdateStatus(int id, UploadStatus status)
        {
            var upload = GetById(id);
            upload.Status = status;
            _context.SaveChanges();
        }

        public void DeleteFromTable(string tableName, string uploadBatch, Guid uploadBatchGuid)
        {
            var deleteScript = $"DELETE FROM public.\"{tableName}\" WHERE \"Upload_Batch\" = \'{uploadBatch}\' AND \"UploadBatchGuid\" = \'{uploadBatchGuid}\'; ";
            try
            {
                string connectionString;
                if (tableName == "stg_facility_data" || tableName == "stg_community_data")
                {
                    connectionString = _context.Database.GetConnectionString();
                }
                else
                    connectionString = _dataContext.Database.GetConnectionString();
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = deleteScript;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public void UpdateUploadStatus(int id, string uploadStatus)
        {
            try
            {
                var connectionString = _context.Database.GetConnectionString();
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = $"UPDATE public.\"Uploads\" SET \"UploadStatus\" = \'{uploadStatus}\', \"IsProcessed\" = true WHERE \"Id\" = {id}";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private DateTime CreateReportDate(DataRow row)
        {
            try
            {
                object month = null;
                try
                {
                    month = row["Month"];
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                }

                object monthNumber = null;
                try
                {
                    DataColumnCollection Columns = row.Table.Columns;
                    if (Columns.Contains("Month_Num"))
                    {
                        monthNumber = row["Month_Num"];
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                }

                object year = null;
                try
                {
                    year = row["Year"];
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                }

                if (year != null && monthNumber != null)
                    try
                    {
                        var dateString = $"{year}-{monthNumber}-28";
                        return DateTime.Parse(dateString);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message, e);
                        return new DateTime();
                    }

                if (year != null && month != null)
                    try
                    {
                        var dateString = $"{year}-{month}-28";
                        return DateTime.Parse(dateString);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message, e);
                        return new DateTime();
                    }
            }
            catch (Exception e)
            {
                return new DateTime();
            }

            return new DateTime();
        }

        private string EscapeSqlCharacters(string input)
        {
            if (input.Contains('\''))
            {
                var output = input.Replace("\'", "\'\'");
                return output;
            }

            if (input.Contains('\"'))
            {
                var output = input.Replace("\"", "\"\"");
                return output;
            }

            return input;
        }
    }
}