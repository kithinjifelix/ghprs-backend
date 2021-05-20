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

        public UploadRepository(GhprsContext context, DataContext dataContext, ILogger<UploadRepository> logger) : base(context)
        {
            _entities = context.Uploads
                .Include(i => i.Template)
                .Include(i => i.User)
                .AsNoTracking();
            _context = context;
            _dataContext = dataContext;
            _logger = logger;
        }

        public IEnumerable<Upload> GetFullUploads()
        {
            return _entities;
        }

        public object GetDetailsById(int id)
        {
            var result = _entities.Select(s => new
                    {s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt})
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
                    {s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt})
                .ToList();
            return result;
        }

        public IEnumerable<object> GetListByStatus(UploadStatus status)
        {
            var result = _entities
                .Select(s => new
                    {s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt})
                .Where(x => x.Status == status).ToList();
            return result;
        }

        public IEnumerable<object> GetListByUser(User user)
        {
            var result = _entities
                .Select(s => new
                    {s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt})
                .Where(x => x.User == user).ToList();
            return result;
        }

        public void InsertToTable(WorkSheet workSheet, DataTable data, string uploadBatch)
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
                            rows += $" \'{row[column.Name]}\',";
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
                rows += $" \'{reportDate}\',";
                columns += " \"Report Date\",";
                //remove trailing commas
                rows = rows.Remove(rows.Length - 1);
                columns = columns.Remove(columns.Length - 1);
                var insert = $"INSERT INTO public.\"{workSheet.TableName}\" ({columns}) VALUES ({rows});";
                insertScript += insert;
            }

            try
            {
                var connectionString = _dataContext.Database.GetConnectionString();
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

        public void DeleteFromTable(string tableName, string uploadBatch)
        {
            var deleteScript = $"DELETE FROM public.\"{tableName}\" WHERE \"Upload_Batch\" = \'{uploadBatch}\'; ";
            try
            {
                var connectionString = _dataContext.Database.GetConnectionString();
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

        private DateTime CreateReportDate(DataRow row)
        {
            try
            {
                var month = row["Month"];
                var monthNumber = row["Month_Num"];
                var year = row["Year"];
                if (year != null && monthNumber != null)
                {
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
                }
                if (year != null && month != null)
                {
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
            }
            catch (Exception)
            {
                return new DateTime();
            }

            return new DateTime();
        }
    }
}