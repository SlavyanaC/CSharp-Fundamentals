namespace UnitTests
{
    using NUnit.Framework;
    using P01Database;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class DatabaseTests
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
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { -8561, 98745 })]
        [TestCase(new int[] { })]
        public void TestValidConstructor(int[] values)
        {
            this.database = new Database(values);

            var fieldInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(int[]));

            int[] actualValues = (int[])fieldInfo.GetValue(this.database);
            int[] buffer = new int[actualValues.Length - values.Length];
            Assert.That(actualValues, Is.EquivalentTo(values.Concat(buffer)));
        }

        [Test]
        public void ConstructorThrowsExceptionIfInitializedWithMoreThanCapacity()
        {
            Assert.That(() => this.database = new Database(new int[Capacity + 1]),
                Throws.InvalidOperationException.
                With.Message.EqualTo(ErrorMessages.LengthMoreThanCapacity));
        }

        [Test]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void AddCommandAddsNewElementAtTheEnd(int value)
        {
            this.database = new Database();
            this.database.Add(value);

            var dataInfo = typeof(Database)
               .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
               .First(f => f.FieldType == typeof(int[]));

            var currentIndexInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(int));

            int firstElement = ((int[])dataInfo.GetValue(this.database)).First();
            Assert.That(firstElement, Is.EqualTo(value));

            int valuesCount = (int)currentIndexInfo.GetValue(this.database);
            Assert.That(valuesCount, Is.EqualTo(1));
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
