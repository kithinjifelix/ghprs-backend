using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GHPRS.Persistence.Repositories
{
    public class FileUploadRepository : Repository<FileUploads>, IFileUploadRepository
    {
        private readonly GhprsContext _context;
        private readonly IQueryable<FileUploads> _entities;

        public FileUploadRepository(GhprsContext context) : base(context)
        {
            _entities = context.FileUploads
                .AsNoTracking();
            _context = context;
        }

        public IEnumerable<Object> GetAllFileUploads(string status)
        {
            return _context.FileUploads.Select(s => new
                    { s.Id, s.UploadDate, s.ContentType, s.User, s.CreatedAt, s.Name, s.Status, s.UpdatedAt })
                .Where(z => z.Status.Contains(status));
        }

        public void UpdateFile(FileUploads entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.FileUploads.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public FileUploads GetPendingUploads(string uploadType)
        {
            return _entities.Include(f => f.User).ThenInclude(y => y.Person).FirstOrDefault(x => x.Status == "Processing" && x.UploadType == uploadType);
        }
    }
}
