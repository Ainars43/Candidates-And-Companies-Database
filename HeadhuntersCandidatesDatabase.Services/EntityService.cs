using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Services;

public class EntityService<T> : DbService, IEntityService<T> where T : Entity
{
    public EntityService(IDatabaseContext context) : base(context) { }
    
    public IQueryable<T> Query()
    {
        return Query<T>();
    }

    public IEnumerable<T> Get()
    {
        return Get<T>();
    }

    public T GetByID(int id)
    {
        return GetByID<T>(id);
    }

    public void Create(T entity)
    {
        Create<T>(entity);
    }

    public void Update(T entity)
    {
        Update<T>(entity);
    }

    public void Delete(T entity)
    {
        Delete<T>(entity);
    }

    public bool Exists(T entity)
    {
        return Exists<T>(entity);
    }

    public bool Exists(int id)
    {
        return Exists<T>(id);
    }
}