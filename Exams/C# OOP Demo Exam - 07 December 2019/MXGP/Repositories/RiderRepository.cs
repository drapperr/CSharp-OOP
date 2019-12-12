using System.Linq;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
