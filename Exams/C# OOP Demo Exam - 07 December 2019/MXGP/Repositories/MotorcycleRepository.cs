namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using MXGP.Models.Motorcycles.Contracts;
    using Contracts;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> models;

        public MotorcycleRepository()
        {
            this.models=new List<IMotorcycle>();
        }

        public IMotorcycle GetByName(string name) => this.models.FirstOrDefault(x => x.Model == name);

        public IReadOnlyCollection<IMotorcycle> GetAll() => this.models.AsReadOnly();

        public void Add(IMotorcycle model)
        {
            this.models.Add(model);
        }

        public bool Remove(IMotorcycle model)
        {
            return this.models.Remove(model);
        }
    }
}
