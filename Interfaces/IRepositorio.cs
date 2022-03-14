using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
  public interface IRepositorio<T>
  {
    void Create(T entidade);
    List<T> GetAll();
    T GetById(int id);
    int NextId();
    void Update(int id, T entidade);
    void Delete(int id);
  }
}