using System.Collections.Generic;

namespace CollectionHierarchy
{
    public interface IAddCollection
    {
        List<string> Items { get; }

        int Add(string item);
    }
}
