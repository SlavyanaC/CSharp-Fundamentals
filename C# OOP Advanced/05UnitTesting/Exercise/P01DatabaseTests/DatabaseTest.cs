namespace DatabaseTests
{
    using NUnit.Framework;
    using P01Database;
    using System.Collections.Generic;

    public class DatabaseTest
    {
        private const int Capacity = 16;
        private const int testNumber = 5;

        private Database database = new Database();

        [SetUp]
        public void Init()
        {
            this.database = new Database(new int[testNumber]);
        }

        [Test]
        public void ThrowsExceptionIfInitializedWithMoreThanCapacity()
        {
            Assert.That(() => this.database = new Database(new int[Capacity + 1]),
                Throws.InvalidOperationException.
                With.Message.EqualTo(ErrorMessages.LengthMoreThanCapacity));
        }

        [Test]
        public void AddCommandAddsNewElementAtTheEnd()
        {
            this.database.Add(testNumber);
            Assert.That(this.database.CurrentIndex, Is.EqualTo(testNumber + 1), "Add command adds element at the end");
        }

        [Test]
        public void AddCommandThrowsExceptionIfMoreThanCapacity()
        {
            this.database = new Database(new int[Capacity]);
            Assert.That(() => this.database.Add(testNumber),
                Throws.InvalidOperationException.
                With.Message.EqualTo(ErrorMessages.LengthMoreThanCapacity));
        }

        [Test]
        public void RemoveCommandRemovesLastElement()
        {
            this.database.Remove();
            Assert.That(this.database.CurrentIndex, Is.EqualTo(testNumber - 1), "Remove command removes last element");
        }

        [Test]
        public void RemoveCommandThrowsExceptionWhenDataIsEmpty()
        {
            this.database = new Database();
            Assert.That(() => this.database.Remove(),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ErrorMessages.EmptyData));
        }

        [Test]
        public void FetchCommandReturnsData()
        {
            Assert.True(this.database.Fetch() is IEnumerable<int>);
        }

        [Test]
        public void FetchCommandReturnsCorrectCountOfElements()
        {
            int[] testData = this.database.Fetch();
            Assert.That(testData.Length, Is.EqualTo(testNumber), "Fetch returns correct count of elements");
        }
    }
}
