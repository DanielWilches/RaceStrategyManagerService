using Application.Layer.Interfaces;
using Domain.Layer.DTOs;
using Domain.Layer.Entities;
using InterfaceAdapter.Layer.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterfaceAdapter.Layer.Respositories
{
    /// <summary>
    /// pilits repository that implements the IRepository interface for PilotsEntity
    /// </summary>
    public class PilotsRespository : IRepository<PilotsEntity>
    {
        private readonly AppDbContext _dbContext;
        public PilotsRespository(AppDbContext dbContext) => _dbContext = dbContext; 

        /// <summary>
        /// get all pilots from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PilotsEntity>> GetAllAsync() => await _dbContext.Pilots.ToListAsync();

        /// <summary>
        /// get a pilot by its id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PilotsEntity?> GetByIdAsync(int id) => await _dbContext.Pilots.FindAsync(id);

        /// <summary>
        /// get a list of pilots that match the given predicate from the database
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PilotsEntity>> ListAsync(Expression<Func<PilotsEntity, bool>> predicate) => await _dbContext.Pilots.Where(predicate).ToListAsync();

        /// <summary>
        /// add a new pilot to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(PilotsEntity entity)
        {
            await _dbContext.Pilots.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// update an existing pilot in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(PilotsEntity entity)
        {
            _dbContext.Pilots.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete a pilot from the database by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            PilotsEntity? entity = await _dbContext.Pilots.FindAsync(id);

            if (entity == null)
                return;

            _dbContext.Pilots.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<StrategiesPilotClientDTO>> ExecuteSP(string sp)
        {
            throw new NotImplementedException();
        }
    }
}
