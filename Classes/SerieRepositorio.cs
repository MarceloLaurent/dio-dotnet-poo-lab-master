using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
  public class SerieRepositorio : IRepositorio<Serie>
  {
    private List<Serie> listaSerie = new List<Serie>();

    public void Create(Serie objeto)
    {
      listaSerie.Add(objeto);
    }

    public List<Serie> GetAll()
    {
      return listaSerie;
    }

    public Serie GetById(int id)
    {
      return listaSerie[id];
    }

    public int NextId()
    {
      return listaSerie.Count;
    }

    public void Update(int id, Serie objeto)
    {
      listaSerie[id] = objeto;
    }

    public void Delete(int id)
    {
      listaSerie[id].Excluir();
    }
  }
}