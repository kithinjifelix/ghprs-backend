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

        public IEnumerable<Object> GetAllFileUploads()
        {
            return _context.FileUploads.Select(s => new { s.Id, s.UploadDate, s.ContentType, s.User, s.CreatedAt, s.Name, s.Status, s.UpdatedAt });
        }

        public FileUploads GetPendingUploads(string uploadType)
        {
            return _entities.FirstOrDefault(x => x.Status == "Processing" && x.UploadType == uploadType);
        }
    }
}
