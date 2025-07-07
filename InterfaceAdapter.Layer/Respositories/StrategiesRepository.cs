using Application.Layer.Interfaces;
using Domain.Layer.DTOs;
using Domain.Layer.Entities;
using InterfaceAdapter.Layer.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterfaceAdapter.Layer.Respositories
{
    /// <summary>
    /// strategies repository that implements the IRepository interface for StrategiesEntity
    /// </summary>
    public class StrategiesRepository : IRepository<StrategiesEntity>
    {
        private readonly AppDbContext _dbContext;
        public StrategiesRepository(AppDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// get all strategies from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StrategiesEntity>> GetAllAsync() => await _dbContext.Strategies.ToListAsync();


        /// <summary>
        /// get a strategy by its id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StrategiesEntity?> GetByIdAsync(int id) => await _dbContext.Strategies.FindAsync(id);

        /// <summary>
        /// get a list of strategies that match the given predicate from the database
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StrategiesEntity>> ListAsync(Expression<Func<StrategiesEntity, bool>> predicate) => await _dbContext.Strategies.Where(predicate).ToListAsync();

        /// <summary>
        /// add a new strategy to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(StrategiesEntity entity)
        {
            await _dbContext.Strategies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// update an existing strategy in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(StrategiesEntity entity)
        {
            _dbContext.Strategies.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete a strategy by its id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            StrategiesEntity? entity = await _dbContext.Strategies.FindAsync(id);

            if (entity == null)
                return;

            _dbContext.Strategies.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    
        public async Task<IEnumerable<StrategiesPilotClientDTO>> ExecuteSP(string sp)
        {
            var prueba = await _dbContext.Database
                .SqlQuery<StrategiesPilotClientDTO>($"EXEC {sp}")
                .ToListAsync();
            return prueba;
        }
    }
}
