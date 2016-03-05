using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimlyFooball.Models;

namespace SimlyFooball.DataAccess
{
  public class TeamRepository
  {
    private readonly FootballDbEntities _db = new FootballDbEntities();

    public Team GetTeamById(long id)
    {
      return _db.Team.FirstOrDefault(x => x.Id == id);
    }

    public List<Team> GetListOfAllTeams()
    {
      return _db.Team.ToList();
    }

    public void AddNewTeam(Team team)
    {
      _db.Team.Add(team);
      _db.SaveChanges();
    }

    public void SaveChangesInTeam(Team team)
    {
      _db.Entry(team).State = EntityState.Modified;
      _db.SaveChanges();
    }

    public void RemoveTeam(long id)
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