namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using MXGP.Models.Races.Contracts;
    using Contracts;

    public class RaceRepository:IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IRace GetByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRace> GetAll() => this.models.AsReadOnly();

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
