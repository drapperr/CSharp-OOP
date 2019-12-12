using System.Collections.Generic;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        protected readonly List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public virtual T GetByName(string name)=> default;

        public IReadOnlyCollection<T> GetAll() => this.models.AsReadOnly();

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
