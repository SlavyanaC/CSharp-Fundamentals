namespace P08CustomLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DynamicList<int> collection = new DynamicList<int>();
            collection.Add(1);
            collection.Add(3);
            collection.Add(5);

            collection.Contains(2);

            collection.IndexOf(4);

            collection.Remove(3);
            collection.RemoveAt(0);
        }
    }
}
