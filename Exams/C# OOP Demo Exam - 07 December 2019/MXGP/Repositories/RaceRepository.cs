using System.Linq;
using MXGP.Models.Races.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
