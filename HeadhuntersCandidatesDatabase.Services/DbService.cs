using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using HeadhuntersCandidatesDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadhuntersCandidatesDatabase.Services;

public class DbService : IDbService
{
    protected readonly IDatabaseContext _context;

    public DbService(IDatabaseContext context)
    {
        _context = context;
    }

    public void Create<T>(T entity) where T : Entity
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete<T>(T entity) where T : Entity
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public void Update<T>(T entity) where T : Entity
    {
        _context.Entry<T>(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public IEnumerable<T> Get<T>() where T : Entity
    {
        return _context.Set<T>().ToList();
    }

    public T GetByID<T>(int id) where T : Entity
    {
        return _context.Set<T>().SingleOrDefault(c => c.Id == id);
    }

    public IQueryable<T> Query<T>() where T : Entity
    {
        return _context.Set<T>();
    }

    public bool Exists<T>(T entity) where T : Entity
    {
        return _context.Set<T>().Any(t => t.Equals(entity));
    }

    public bool Exists<T>(int id) where T : Entity
    {
        return _context.Set<T>().Any(t => t.Id == id);
    }
}

    

