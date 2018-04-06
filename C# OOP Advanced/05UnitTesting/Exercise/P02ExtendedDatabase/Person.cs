namespace P02ExtendedDatabase
{
    public class Person
    {
        public Person(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}
