using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GHPRS.Persistence.Repositories
{
    public class UploadRepository : Repository<Upload>, IUploadRepository
    {
        private readonly DbSet<Upload> _entities;
        private readonly GhprsContext _context;
        public UploadRepository(GhprsContext context) : base(context)
        {
            _entities = context.Set<Upload>();
            _context = context;
        }

        public object GetDetailsById(int id)
        {
            var result = _entities.Select(s => new { s.Id, s.Name, s.Comments, s.Status, s.ContentType, s.User, s.StartDate, s.EndDate, s.CreatedAt }).FirstOrDefault(x => x.Id == id);
            return result;
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

        public void InsertToTable(Template template, DataTable data)
        {
            var insertScript = String.Empty;
            var insert = String.Empty;
            foreach (DataRow row in data.Rows)
            {
                string columns = String.Empty;
                string rows = String.Empty;
                foreach (var column in template.Columns)
                {
                    if (column.Name != "Id")
                    {
                        columns += $"\"{column.Name}\", ";
                        rows += $"\"{row[column.Name]}\", ";
                    } 
                }
                insert = $"INSERT INTO public.\"{template.TableName}\" (\"{columns}\") VALUES (\"{rows}\");";
            }
            insertScript += insert;
            FormattableString formattableinsertScript = $"{insertScript}";
            try
            {
                _context.Database.ExecuteSqlInterpolated(formattableinsertScript);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
