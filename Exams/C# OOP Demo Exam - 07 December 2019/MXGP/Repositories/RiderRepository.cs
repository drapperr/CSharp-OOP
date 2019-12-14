namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using MXGP.Models.Riders.Contracts;
    using Contracts;

    public class RiderRepository:IRepository<IRider>
    {
        private readonly List<IRider> models;

        public RiderRepository()
        {
            this.models = new List<IRider>();
        }

        public IRider GetByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRider> GetAll() => this.models.AsReadOnly();

        public void Add(IRider model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRider model)
        {
            return this.models.Remove(model);
        }
    }
}
