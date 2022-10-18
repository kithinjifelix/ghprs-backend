using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GHPRS.Persistence.Repositories;

public class EtlDataRepository<T> : IEtlDataRepository<T> where T : class
{
    private readonly DbSet<T> _entities;
    protected readonly ETLContext _context;
    private IDbConnection _connection;
    
    public string ConnectionString => _context.Database.GetDbConnection().ConnectionString;

    public EtlDataRepository(ETLContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }
    
    public virtual IDbConnection GetConnection(bool open = true)
    {
        if (null == _connection)
        {
            if (_context.Database.IsNpgsql())
                _connection = new NpgsqlConnection(ConnectionString);
        }

        if (null == _connection)
            throw new Exception("Database provider error");

        if (_connection.State != ConnectionState.Open)
            _connection.Open();

        return _connection;
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.AsEnumerable();
    }

    public virtual IEnumerable<TC> ExecQuery<TC>(string selectStatement)
    {
        var entities =  GetConnection().Query<TC>(selectStatement);
        return entities;
    }
}