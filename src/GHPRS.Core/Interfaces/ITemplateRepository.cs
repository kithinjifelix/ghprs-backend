using GHPRS.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace GHPRS.Core.Interfaces
{
    public interface ITemplateRepository : IRepository<Template>
    {
        IEnumerable<Template> GetAllFull();
        Template GetAllFullById(int id);
        IEnumerable<object> GetList(string role);
        object GetDetailsById(int id);
        void CreateTemplateTable(WorkSheet workSheet);
        void UpdateStaticTable(string tableName, List<string> columns);
        void UpdateStatus(int id, Template.TemplateStatus status);
    }
}
