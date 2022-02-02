using System;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace GHPRS.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}