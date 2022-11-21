using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services;

public interface IDbService
{
    IQueryable<T> Query<T>() where T : Entity;
    IEnumerable<T> Get<T>() where T : Entity;
    T GetByID<T>(int id) where T : Entity;
    void Create<T>(T entity) where T : Entity;
    void Update<T>(T entity) where T : Entity;
    void Delete<T>(T entity) where T : Entity;
    bool Exists<T>(T entity) where T : Entity;
    bool Exists<T>(int id) where T : Entity;
}