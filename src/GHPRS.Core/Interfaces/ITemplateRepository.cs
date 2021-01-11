using GHPRS.Core.Entities;
using GHPRS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GHPRS.Core.Interfaces
{
    public interface ITemplateRepository : IRepository<Template>
    {
        IEnumerable<object> GetList();
    }
}
