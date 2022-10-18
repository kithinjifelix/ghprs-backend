using System.Collections.Generic;

namespace GHPRS.Core.Interfaces;

public interface IEtlDataRepository<T> where T : class
{
    IEnumerable<T> GetAll();
        
    IEnumerable<TC> ExecQuery<TC>(string selectStatement);
}