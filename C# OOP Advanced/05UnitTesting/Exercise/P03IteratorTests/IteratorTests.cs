namespace P03IteratorTests
{
    using NUnit.Framework;
    using P03Iterator;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class IteratorTests
    {
        ListIterator listIterator;

        [Test]
        public void CannotBeInitializedWithNullData()
        {
            string[] testData = new string[] { null };
            Assert.Throws<ArgumentNullException>(() => this.listIterator = new ListIterator(testData));
        }

        [Test]
        public void CannotBeInitializedWithNullElement()
        {
            string[] testData = new string[] { "Pesho", null, "Gosho" };
            Assert.Throws<ArgumentNullException>(() => this.listIterator = new ListIterator(testData));
        }

        [Test]
        public void InitializeDataCountCorrectly()
        {
            this.listIterator = new ListIterator();
            var expectedValue = 0;

            FieldInfo[] fields = this.listIterator.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var data = (List<string>)fields.FirstOrDefault(f => f.Name == "data").GetValue(this.listIterator);

            Assert.AreEqual(data.Count, expectedValue);
        }

        [Test]
        public void InitializeCurrentIndexCorrectry()
        {
            this.listIterator = new ListIterator();
            var expectedValue = 0;

            FieldInfo[] fields = this.listIterator.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var currenIndex = (int)fields.FirstOrDefault(f => f.Name == "currentIndex").GetValue(this.listIterator);

            Assert.AreEqual(currenIndex, expectedValue);
        }

        [Test]
        public void InitializeDataCorrectly()
        {
            this.listIterator = new ListIterator("Pesho", "Gosho", "Stamat");
            List<string> expectedValue = new List<string> { "Pesho", "Gosho", "Stamat" };

            FieldInfo[] fields = this.listIterator.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var data = (List<string>)fields.FirstOrDefault(f => f.Name == "data").GetValue(this.listIterator);

            Assert.AreEqual(data, expectedValue);
        }

        [Test]
        public void HasNextReturnsTrueIfFreeIndices()
        {
            this.listIterator = new ListIterator("Pesho", "Gosho", "Stamat");
            var expectedValue = true;

            Assert.AreEqual(this.listIterator.HasNext(), expectedValue);
        }

        [Test]
        public void HasNextReturnsFalseIfLastIndex()
        {
            this.listIterator = new ListIterator("Pesho");
            var expectedValue = false;

            Assert.AreEqual(this.listIterator.HasNext(), expectedValue);
        }

        [Test]
        public void HasNextReturnsFalseIfEmptyData()
        {
            this.listIterator = new ListIterator();
            var expectedValue = false;

            Assert.AreEqual(this.listIterator.HasNext(), expectedValue);
        }

        [Test]
        public void MoveReturnsTrueIfCanMoove()
        {
            this.listIterator = new ListIterator("Pesho", "Gosho", "Stamat");
            var expectedValue = true;

            Assert.AreEqual(this.listIterator.Move(), expectedValue);
        }

        [Test]
        public void MoveReturnsFalseIfCannotMove()
        {
            this.listIterator = new ListIterator("Pesho");
            var expectedValue = false;

            Assert.AreEqual(this.listIterator.Move(), expectedValue);
        }

        [Test]
        public void MoveReturnsFalseIfEmptyData()
        {
            this.listIterator = new ListIterator();
            var expectedValue = false;

            Assert.AreEqual(this.listIterator.Move(), expectedValue);
        }

        [Test]
        public void MovesCurrentIndex()
        {
            this.listIterator = new ListIterator("Pesho", "Gosho", "Stamat");
            var expectedValue = 1;

            this.listIterator.Move();
            FieldInfo[] fields = this.listIterator.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var currentIndex = (int)fields.FirstOrDefault(f => f.Name == "currentIndex").GetValue(listIterator);

            Assert.AreEqual(currentIndex, expectedValue);
        }

        [Test]
        public void MovesDoesntMoveIndexIfFalse()
        {
            this.listIterator = new ListIterator("Pesho");
            var expectedValue = 0;

            this.listIterator.Move();
            FieldInfo[] fields = this.listIterator.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var currentIndex = (int)fields.FirstOrDefault(f => f.Name == "currentIndex").GetValue(listIterator);

            Assert.AreEqual(currentIndex, expectedValue);
        }

        [Test]
        public void PrintReturnsElementOnCurrentIndex()
        {
            this.listIterator = new ListIterator("Pesho", "Gosho", "Stamat");

            FieldInfo[] fields = this.listIterator.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var currentIndex = (int)fields.FirstOrDefault(f => f.Name == "currentIndex").GetValue(listIterator);
            var data = (List<string>)fields.FirstOrDefault(f => f.Name == "data").GetValue(listIterator);

            var expectedValue = data[currentIndex];

            Assert.AreEqual(this.listIterator.Print(), expectedValue);
        }

        [Test]
        public void PrintThrowsExceptionIfEmptyData()
        {
            this.listIterator = new ListIterator();

            Assert.That(() => this.listIterator.Print(),
                Throws.InvalidOperationException.
                With.Message.EqualTo("Invalid Operation!"));
        }
    }
}
