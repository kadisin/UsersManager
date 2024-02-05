using Microsoft.EntityFrameworkCore;

namespace UsersManager.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;


        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<int> AddElement(T element)
        {
            _dbSet.Add(element);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteElement(T element)
        {
            var isElementExis = _dbSet.Find(element);
            if(isElementExis != null)
            {
                _dbSet.Remove(element);
                return await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"{nameof(T)} can't be found!");
            }    
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return  await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetElementByKey(int id)
        {
            var element = _dbSet.Find(id);
            if(element != null)
            {
                return element;
            }
            else
            {
                throw new ArgumentException($"Can't find {nameof(T)}");
            }    
        }

        public IEnumerable<T> GetElementsWithFilter(Func<T, bool> filter)
        {
            var elements = _dbSet.Where(x => filter(x) == true);
            return  elements.AsEnumerable<T>();
        }

        public async Task<int> UpdateElement(T element)
        {
            _context.Entry(element).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
