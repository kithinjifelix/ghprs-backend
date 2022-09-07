using Microsoft.AspNetCore.Http;
using System;

namespace GHPRS.Core.Models
{
    public class UploadModel
    {
        public int TemplateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IFormFile File { get; set; }
    }
}
