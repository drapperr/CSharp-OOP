using System;

namespace MilitaryElite.Models
{
    using Contracts;

    public class Spy : Solider, ISpy
    {
        public Spy(int id, string firstName, string lastName,int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get;}

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}Code Number: {this.CodeNumber}";
        }
    }
}
