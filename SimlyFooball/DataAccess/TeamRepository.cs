using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimlyFooball.Models;

namespace SimlyFooball.DataAccess
{
  public class TeamRepository : ITeamRepository
  {
    private readonly FootballDbEntities _db = new FootballDbEntities();

    public Team GetById(long id)
    {
      return _db.Team.FirstOrDefault(x => x.Id == id);
    }

    public List<Team> GetAll()
    {
      return _db.Team.ToList();
    }

    public void Add(Team team)
    {
      _db.Team.Add(team);
      _db.SaveChanges();
    }

    public void Update(Team team)
    {
      _db.Entry(team).State = EntityState.Modified;
      _db.SaveChanges();
    }

    public void Remove(long id)
    {
      Team team = _db.Team.Find(id);
      _db.Team.Remove(team);
      _db.SaveChanges();
    }

    public void Dispose()
    {
      _db.Dispose();
    }
  }
}