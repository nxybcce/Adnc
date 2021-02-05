﻿using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Adnc.Core.Shared.Entities;

namespace Adnc.Core.Shared.IRepositories
{
    public interface IEfRepository<TEntity> : IRepository<TEntity>
       where TEntity : EfEntity
    {
        IQueryable<TrdEntity> GetAll<TrdEntity>(bool writeDb = false) where TrdEntity : EfEntity;

        IQueryable<TEntity> GetAll(bool writeDb = false);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool writeDb = false);

        Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null, bool writeDb = false);

        Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null, bool writeDb = false);

        Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<int> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<int> DeleteAsync(long keyValue, CancellationToken cancellationToken = default);

        Task<int> DeleteRangeAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);

        Task<int> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions);

        Task<int> UpdateRangeAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> upDateExpression, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default);

        Task<TEntity> FindAsync(long keyValue, bool writeDb = false, CancellationToken cancellationToken = default);

        Task<TEntity> FetchAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression = null, bool ascending = false, bool writeDb = false, CancellationToken cancellationToken = default);

        Task<IPagedModel<TEntity>> PagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool ascending = false, bool writeDb = false, CancellationToken cancellationToken = default);

    }
}
