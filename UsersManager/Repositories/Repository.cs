using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UsersManager.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbContext _context;


        public Repository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> AddElement(T element)
        {
            await _context.Set<T>().AddAsync(element);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteElement(T element)
        {
            var isElementExis = await _context.Set<T>().FindAsync(element);
            if(isElementExis != null)
            {
                _context.Set<T>().Remove(element);
                return await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"{nameof(T)} can't be found!");
            }    
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return  await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetElementByKey(int id)
        {
            var element = await _context.Set<T>().FindAsync(id);
            if(element != null)
            {
                return element;
            }
            else
            {
                throw new ArgumentException($"Can't find {nameof(T)}");
            }    
        }

        public virtual async Task<IEnumerable<T>> GetElementsWithFilter(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsQueryable().Where(predicate).ToListAsync();
        }

        public virtual async Task<int> UpdateElement(T element)
        {
            _context.Set<T>().Update(element);
            return await _context.SaveChangesAsync();
        }
    }
}
