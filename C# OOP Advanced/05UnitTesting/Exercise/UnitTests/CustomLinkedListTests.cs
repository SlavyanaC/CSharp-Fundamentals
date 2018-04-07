namespace UnitTests
{
    using NUnit.Framework;
    using P08CustomLinkedList;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CustomLinkedListTests
    {
        DynamicList<string> list;
        private const string firstTestElement = "Stamat";
        private const string secondTestElement = "Prokop";
        private const string thirdTestElement = "Ivan";

        [SetUp]
        public void Init()
        {
            this.list = new DynamicList<string>();
        }

        [Test]
        public void AddsItemToEmptyList()
        {
            this.list.Add(firstTestElement);

            FieldInfo[] fields = this.list.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var head = fields.FirstOrDefault(f => f.Name == "head").GetValue(this.list);
            var headFields = head.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var headElement = headFields.FirstOrDefault(f => f.Name == "<Element>k__BackingField").GetValue(head);

            var tail = fields.FirstOrDefault(f => f.Name == "tail").GetValue(this.list);
            var tailFields = tail.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var tailElement = tailFields.FirstOrDefault(f => f.Name == "<Element>k__BackingField").GetValue(tail);

            Assert.AreEqual(headElement, tailElement, firstTestElement);
        }

        [Test]
        public void AddsItemToNonEmptyList()
        {
            this.list.Add(firstTestElement);
            this.list.Add(secondTestElement);

            FieldInfo[] fields = this.list.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var tail = fields.FirstOrDefault(f => f.Name == "tail").GetValue(this.list);
            var tailFields = tail.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var tailElement = tailFields.FirstOrDefault(f => f.Name == "<Element>k__BackingField").GetValue(tail);

            Assert.AreEqual(tailElement, secondTestElement);
        }

        [Test]
        public void RemoveAtThrowsExceptionIfIndexIsNegative()
        {
            this.list.Add(firstTestElement);
            var index = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => this.list.RemoveAt(index));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveAtThrowsExceptionIfIndexEqualOrMoreThanCount(int index)
        {
            this.list.Add(firstTestElement);
            Assert.Throws<ArgumentOutOfRangeException>(() => this.list.RemoveAt(index));
        }

        [Test]
        public void RemoveAtDecreasesCount()
        {
            this.list.Add(firstTestElement);
            this.list.Add(secondTestElement);

            var count = this.list.Count;
            this.list.RemoveAt(0);

            Assert.That(this.list.Count, Is.EqualTo(count - 1), "RemoveAt command removes element from list");
        }

        [Test]
        public void RemoveAtRemovesCorrectElement()
        {
            this.list.Add(firstTestElement);
            this.list.Add(secondTestElement);
            var index = 0;

            var elementBeforeRemove = this.list[index];
            this.list.RemoveAt(index);
            var elementAfterRemove = this.list[index];

            Assert.AreNotEqual(elementBeforeRemove, elementAfterRemove);
        }

        [Test]
        [TestCase(secondTestElement)]
        [TestCase(thirdTestElement)]
        public void RemoveDoesReturnsNegativeNumberIfElementNotFound(string testElement)
        {
            this.list.Add(firstTestElement);
            Assert.That(this.list.Remove(testElement), Is.EqualTo(-1), "Remove returns -1 if element not found");
        }

        [Test]
        public void RemovesElementFromList()
        {
            this.list.Add(firstTestElement);
            this.list.Add(secondTestElement);

            var count = this.list.Count;
            this.list.Remove(secondTestElement);

            Assert.That(this.list.Count, Is.EqualTo(count - 1), "Remove command removes element from list");
        }

        [Test]
        [TestCase(secondTestElement)]
        [TestCase(thirdTestElement)]
        public void IndexOfReturnsNegativeNumberIfElementNotFound(string testElement)
        {
            this.list.Add(firstTestElement);
            Assert.That(this.list.IndexOf(testElement), Is.EqualTo(-1), "IndexOf command returns -1 if element not found");
        }

        [Test]
        public void IndexOfReturnsCorrectIndexOfElement()
        {
            this.list.Add(firstTestElement);
            this.list.Add(secondTestElement);

            var secondElementIndex = 1;

            Assert.That(this.list.IndexOf(secondTestElement), Is.EqualTo(secondElementIndex));
        }

        [Test]
        public void ContainsReturnsTrueIfElementFound()
        {
            this.list.Add(firstTestElement);

            Assert.That(this.list.Contains(firstTestElement), "Contains command returns true if element is found");
        }

        [Test]
        [TestCase(secondTestElement)]
        [TestCase(thirdTestElement)]
        public void ContainsReturnsFalseIfElementNotFound(string testElement)
        {
            this.list.Add(firstTestElement);

            Assert.IsFalse(this.list.Contains(testElement), "Contains command returns false if element not found");
        }
    }
}