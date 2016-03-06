using System.Collections.Generic;
using SimlyFooball.Models;

namespace SimlyFooball.DataAccess
{
  public interface IPlayerRepository : IRepository<Player>
  {
      List<Player> GetAviable();
  }
}
