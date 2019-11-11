﻿namespace MilitaryElite.Contracts
{
    using Enums;

    public interface IMission
    {
        string CodeName { get;}

        string State { get;}

        void CompleteMission();
    }
}
