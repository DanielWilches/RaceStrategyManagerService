using Application.Layer.Interfaces;
using Domain.Layer.Entities;
using InterfaceAdapter.Layer.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAdapter.Layer.Respositories
{
    /// <summary>
    ///  api keys repository that implements the IRepository interface for ApiKeysEntity
    /// </summary>
    public class ApiKeysRepository : IRepository<ApiKeysEntity>
    {
        private readonly AppDbContext _dbContext;
        public ApiKeysRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// get all api keys from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApiKeysEntity>> GetAllAsync() => await _dbContext.ApiKeys.ToListAsync();

        /// <summary>
        /// get an api key by its id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async  Task<ApiKeysEntity?> GetByIdAsync(int id) => await _dbContext.ApiKeys.FindAsync(id);

        /// <summary>
        /// get a list of api keys that match the given predicate from the database
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ApiKeysEntity>> ListAsync(Expression<Func<ApiKeysEntity, bool>> predicate) => await _dbContext.ApiKeys.Where(predicate).ToListAsync();

        /// <summary>
        /// add a new api key to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(ApiKeysEntity entity)
        {
            await _dbContext.ApiKeys.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// update an existing api key in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(ApiKeysEntity entity)
        {
            _dbContext.ApiKeys.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete an existing api key from the database by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            ApiKeysEntity? entity = await _dbContext.ApiKeys.FindAsync(id);

            if (entity == null)
                return;

            _dbContext.ApiKeys.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
