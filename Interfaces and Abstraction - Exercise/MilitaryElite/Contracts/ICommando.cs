namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ICommando
    {
        ICollection<IMission> Missions { get;}
    }
}
