namespace P03Iterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator
    {
        private List<string> data;
        private int currentIndex;

        public ListIterator(params string[] collection)
        {
            InitializeData(collection);
            this.currentIndex = 0;
        }

        private void InitializeData(ICollection<string> collection)
        {
            if (collection == null || collection.Any(e => e == null))
            {
                throw new ArgumentNullException();
            }

            this.data = new List<string>(collection);
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext() => this.currentIndex < this.data.Count - 1;

        public string Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.data[this.currentIndex];
        }
    }
}