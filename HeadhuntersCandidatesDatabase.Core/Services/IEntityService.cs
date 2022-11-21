using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services;

public interface IEntityService<T> where T : Entity
{
    IQueryable<T> Query();
    IEnumerable<T> Get();
    T GetByID(int id);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    bool Exists(T entity);
    bool Exists(int id);
}