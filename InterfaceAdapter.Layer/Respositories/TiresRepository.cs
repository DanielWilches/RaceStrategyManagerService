using Application.Layer.Interfaces;
using Domain.Layer.Entities;
using InterfaceAdapter.Layer.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterfaceAdapter.Layer.Respositories
{
    /// <summary>
    /// tires repository that implements the IRepository interface for TiresEntity
    /// </summary>
    public class TiresRepository : IRepository<TiresEntity>
    {
        private readonly AppDbContext _dbContext;
        public TiresRepository(AppDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        ///  get all tires from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TiresEntity>> GetAllAsync() => await _dbContext.Tires.ToListAsync();

        /// <summary>
        /// get a tire by its id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TiresEntity?> GetByIdAsync(int id) => await _dbContext.Tires.FindAsync(id);

        /// <summary>
        /// get a list of tires that match the given predicate from the database
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TiresEntity>> ListAsync(Expression<Func<TiresEntity, bool>> predicate) => await _dbContext.Tires.Where(predicate).ToListAsync();

        /// <summary>
        /// add a new tire to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(TiresEntity entity)
        {
            await _dbContext.Tires.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// update an existing tire in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TiresEntity entity)
        {
            _dbContext.Tires.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete a tire by its id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            TiresEntity? entity = await _dbContext.Tires.FindAsync(id);

            if (entity == null)
                return;

            _dbContext.Tires.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
