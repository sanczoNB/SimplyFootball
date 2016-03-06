using System.Collections.Generic;

namespace SimlyFooball.DataAccess
{
  public interface IRepository<T>
  {
    T GetById(long id);
    List<T> GetAll();
    void Add(T item);
    void Remove(long id);
    void Update(T item);
    void Dispose();
  }
}