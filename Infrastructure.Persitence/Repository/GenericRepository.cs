using AgendaMedica.Core.Application.Interface.Repository;
using Infrastructure.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persitence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ScheduleAppointmentContext _context;


        public GenericRepository(ScheduleAppointmentContext scheduleAppointmentContext)
        {
            _context = scheduleAppointmentContext;

        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context!.Set<T>()!.FindAsync(id)!;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
