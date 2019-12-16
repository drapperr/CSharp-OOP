namespace AquaShop.Models.Aquariums
{
    using System;

    using AquaShop.Models.Fish.Contracts;

    public class FreshwaterAquarium : Aquarium
    {
        private const int InitialCapacity = 50;

        public FreshwaterAquarium(string name)
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
