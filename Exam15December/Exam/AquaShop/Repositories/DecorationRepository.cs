using System.Collections.Generic;
using System.Linq;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorationRepository;

        public DecorationRepository()
        {
            this.decorationRepository = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorationRepository.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.decorationRepository.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            return this.decorationRepository.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.decorationRepository.FirstOrDefault(d => d.GetType().Name == type);
        }
    }
}
