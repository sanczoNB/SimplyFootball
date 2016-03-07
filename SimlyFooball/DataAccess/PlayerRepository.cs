

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimlyFooball.Models;

namespace SimlyFooball.DataAccess
{
  public class PlayerRepository : IPlayerRepository
  {

    private readonly FootballDbEntities _db = new FootballDbEntities();

    public Player GetById(long id)
    {
      return _db.Players.FirstOrDefault(x => x.Id == id);
    }

    public List<Player> GetAll()
    {
      return _db.Players.ToList();
    }

    public void Add(Player player)
    {
      _db.Players.Add(player);
      _db.SaveChanges();
    }

    public void Update(Player player)
    {
      _db.Entry(player).State = EntityState.Modified;
      _db.SaveChanges();
    }

    public void Remove(long id)
    {
      Player player = _db.Players.Find(id);
      _db.Players.Remove(player);
      _db.SaveChanges();
    }

    public void Dispose()
    {
      _db.Dispose();
    }

    public List<Player> GetAviable()
    {
      return _db.Players.Where(p => p.Contracts.All(c => c.EndContractDate != null)).ToList();
    }
  }
}