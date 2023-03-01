using System.Collections.Generic;
using GHPRS.Core.Models;

namespace GHPRS.Core.Interfaces;

public interface IEtlDataRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    PagedList<T> GetAll(ETLParameters ownerParameters);
    IEnumerable<TC> ExecQuery<TC>(string selectStatement);
}