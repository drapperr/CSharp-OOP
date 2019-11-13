namespace CollectionHierarchy
{
    public  class AddRemoveCollection:AddCollection,IAddRemoveCollection
    {
        public override int Add(string item)
        {
            Items.Insert(0,item);
            return 0;
        }

        public virtual string Remove()
        {
            string item = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            return item;
        }
    }
}
