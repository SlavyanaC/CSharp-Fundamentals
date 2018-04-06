namespace P01Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int CAPACITY = 16;

        private int[] data;
        public int CurrentIndex { get; private set; }

        public Database(params int[] elements)
        {
            this.data = new int[CAPACITY];
            this.CurrentIndex = 0;
            FillData(elements);
        }

        private void FillData(int[] elements)
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

        public void Add(int element)
        {
            if (this.CurrentIndex == CAPACITY)
            {
                throw new InvalidOperationException(ErrorMessages.LengthMoreThanCapacity);
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

        public int[] Fetch() => this.data.Take(this.CurrentIndex).ToArray();
    }
}
