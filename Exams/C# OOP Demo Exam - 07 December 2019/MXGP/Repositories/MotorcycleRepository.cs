using System.Linq;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Model == name);
        }
    }
}
