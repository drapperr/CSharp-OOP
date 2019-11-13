namespace CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public override string Remove()
        {
            string item = Items[0];
            Items.RemoveAt(0);
            return item;
        }

        public int Used => Items.Count;
    }
}
