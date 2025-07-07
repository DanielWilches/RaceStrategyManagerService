using Application.Layer.Interfaces;
using Domain.Layer.Entities;
using InterfaceAdapter.Layer.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterfaceAdapter.Layer.Respositories
{
    /// <summary>
    /// clients repository that implements the IRepository interface for ClientsEntity
    /// </summary>
    public class ClientsRepository : IRepository<ClientsEntity>
    {
        private readonly AppDbContext _dbContext;
        public ClientsRepository(AppDbContext dbContext) => _dbContext = dbContext;
       
        /// <summary>
        /// get all clients from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClientsEntity>> GetAllAsync() => await _dbContext.Clients.ToListAsync();

        /// <summary>
        /// get a client by its id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClientsEntity?> GetByIdAsync(int id) => await _dbContext.Clients.FindAsync(id);

        /// <summary>
        /// get a list of clients that match the given predicate from the database
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClientsEntity>> ListAsync(Expression<Func<ClientsEntity, bool>> predicate) => await _dbContext.Clients.Where(predicate).ToListAsync();

        /// <summary>
        /// add a new client to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(ClientsEntity entity)
        {
            await _dbContext.Clients.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// update an existing client in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(ClientsEntity entity)
        {
            _dbContext.Clients.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// delete a client by its id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            ClientsEntity? entity = await _dbContext.Clients.FindAsync(id);

            if (entity == null)
                return;

            _dbContext.Clients.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
