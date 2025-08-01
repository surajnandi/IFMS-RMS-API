﻿using Microsoft.EntityFrameworkCore.Storage;
using RMS.Helpers;

namespace RMS.Dal.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IExecutionStrategy CreateExecutionStrategy();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        Task RollbackTransactionAsync(IDbContextTransaction transaction);
        void SaveChangesManaged();
        Task SaveChangesAManaged(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<PaginatedResponseObject<IEnumerable<T>>> GetAllDynamicAsync(QueryParameters queryParameters);
        Task ExecuteStoredProcedureAsync(string storedProcedureName, Dictionary<string, object> parameters);
    }
}
