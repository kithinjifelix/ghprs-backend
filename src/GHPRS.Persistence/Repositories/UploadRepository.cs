using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GHPRS.Persistence.Repositories
{
    public class UploadRepository : Repository<Upload>, IUploadRepository
    {
        private readonly IQueryable<Upload> _entities;
        private readonly GhprsContext _context;
        private readonly ILogger<UploadRepository> _logger;
        public UploadRepository(GhprsContext context, ILogger<UploadRepository> logger) : base(context)
        {
            _entities = context.Uploads
                .Include(i => i.Template)
                .Include(i => i.User)
                .AsNoTracking();
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Upload> GetFullUploads()
        {
            return _entities;
        }

        public object GetDetailsById(int id)
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt }).FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Upload GetFullUploadById(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<object> GetList()
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Comments , s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt }).ToList();
            return result;
        }

        public IEnumerable<object> GetListByStatus(UploadStatus status)
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt }).Where(x => x.Status == status).ToList();
            return result;
        }

        public IEnumerable<object> GetListByUser(User user)
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt }).Where(x => x.User == user).ToList();
            return result;
        }

        public void InsertToTable(WorkSheet workSheet, DataTable data)
        {
            var insertScript = String.Empty;
            var insert = String.Empty;
            foreach (DataRow row in data.Rows)
            {
                string columns = String.Empty;
                string rows = String.Empty;
                foreach (var column in workSheet.Columns)
                {
                    try
                    {
                        if (column.Name != "Id")
                        {
                            rows += $" \"{row[column.Name]}\",";
                            columns += $" \"{column.Name}\",";
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message, e);
                    }
                }
                //remove trailing commas
                rows = rows.Remove(rows.Length - 1);
                columns = columns.Remove(columns.Length - 1);
                insert = $"INSERT INTO uploads.\"{workSheet.TableName}\" ({columns}) VALUES ({rows});";
            }
            insertScript += insert;
            try
            {
                var connectionString = _context.Database.GetConnectionString();
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
    }
}
