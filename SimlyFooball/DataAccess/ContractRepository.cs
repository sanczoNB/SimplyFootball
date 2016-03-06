using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimlyFooball.Models;


namespace SimlyFooball.DataAccess
{
  public class ContractRepository : IContractRepository
  {
    private readonly FootballDbEntities _db = new FootballDbEntities();

    public Contract GetById(long id)
    {
      return _db.Contracts.Find(id);
    }

    public List<Contract> GetAll()
    {
      return _db.Contracts.Include(e => e.Player).Include(e => e.Team).ToList();
    }

    public void Add(Contract item)
    {
      _db.Contracts.Add(item);
      _db.SaveChanges();
    }

    public void Remove(long id)
    {
      Contract employeesInClub = _db.Contracts.Find(id);
      _db.Contracts.Remove(employeesInClub);
      _db.SaveChanges();
    }

    public void Update(Contract item)
    {
      _db.Entry(item).State = EntityState.Modified;
      _db.SaveChanges();
    }

    public void Dispose()
    {
      _db.Dispose();
    }
  }
}