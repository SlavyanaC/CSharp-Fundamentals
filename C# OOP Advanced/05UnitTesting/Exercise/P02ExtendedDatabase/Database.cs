namespace P02ExtendedDatabase
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int CAPACITY = 16;

        private Person[] data;
        public int CurrentIndex { get; private set; }

        public Database(params Person[] elements)
        {
            this.data = new Person[CAPACITY];
            this.CurrentIndex = 0;
            FillData(elements);
        }

        private void FillData(Person[] elements)
        {
            if (elements.Length > CAPACITY)
            {
                throw new InvalidOperationException(ErrorMessages.LengthMoreThanCapacity);
            }

            foreach (var element in elements)
            {
                this.data[this.CurrentIndex] = element;
                this.CurrentIndex++;
            }
        }

        public void Add(Person element)
        {
            if (this.CurrentIndex == CAPACITY)
            {
                throw new InvalidOperationException(ErrorMessages.LengthMoreThanCapacity);
            }

            if (this.data.Any(p => p?.Name == element.Name))
            {
                throw new InvalidOperationException(ErrorMessages.UsernameIsTaken);
            }

            if (this.data.Any(p => p?.Id == element.Id))
            {
                throw new InvalidOperationException(ErrorMessages.IdIsTaken);
            }

            data[this.CurrentIndex] = element;
            this.CurrentIndex++;
        }

        public void Remove()
        {
            if (this.CurrentIndex == 0)
            {
                throw new InvalidOperationException(ErrorMessages.EmptyData);
            }

            this.CurrentIndex--;
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(username, ErrorMessages.InvalidUsername);
            }

            if (this.data.FirstOrDefault(p => p?.Name == username) == null)
            {
                throw new InvalidOperationException(ErrorMessages.UsernameDoesntExist);
            }

            Person person = this.data.FirstOrDefault(p => p?.Name == username);
            return person;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(ErrorMessages.InvalidId);
            }
            if (this.data.FirstOrDefault(p => p?.Id == id) == null)
            {
                throw new InvalidOperationException(ErrorMessages.IdDoesNotExist);
            }

            Person person = this.data.FirstOrDefault(p => p?.Id == id);
            return person;
        }

        public Person[] Fetch() => this.data.Take(this.CurrentIndex).ToArray();
    }
}
