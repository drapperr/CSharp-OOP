using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {

        public AddCollection()
        {
            Items=new List<string>();
        }
        public List<string> Items { get; protected set; }

        public virtual int Add(string item)
        {
            Items.Add(item);
            return Items.Count - 1;
        }
    }
}
