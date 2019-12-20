namespace ViceCity.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using ViceCity.Models.Guns.Contracts;
    using Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }

        public IGun Find(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }
    }
}
