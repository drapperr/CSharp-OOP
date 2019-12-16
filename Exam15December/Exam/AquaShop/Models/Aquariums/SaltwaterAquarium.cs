namespace AquaShop.Models.Aquariums
{
    using System;

    using AquaShop.Models.Fish.Contracts;

    public class SaltwaterAquarium : Aquarium
    {

        private const int InitialCapacity = 25;

        public SaltwaterAquarium(string name)
            : base(name, InitialCapacity)
        {
        }

        public override void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.Fish.Add(fish);
        }
    }
}
