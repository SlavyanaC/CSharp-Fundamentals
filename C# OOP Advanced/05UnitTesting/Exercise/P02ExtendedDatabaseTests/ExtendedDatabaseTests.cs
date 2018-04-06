namespace P02ExtendedDatabaseTests
{
    using NUnit.Framework;
    using P02ExtendedDatabase;
    using System.Collections.Generic;
    using System;

    public class ExtendedDatabaseTests
    {
        public class DatabaseTest
        {
            private const int Capacity = 16;
            private const int testNumber = 5;
            private Person testPerson = new Person(1, "Pesho");

            private Database database = new Database();

            [SetUp]
            public void Init()
            {
                this.database = new Database(new Person[testNumber]);
            }

            [Test]
            public void InitializeThrowsExceptionIfMoreThanCapacity()
            {
                Assert.That(() => this.database = new Database(new Person[Capacity + 1]),
                    Throws.InvalidOperationException.
                    With.Message.EqualTo(ErrorMessages.LengthMoreThanCapacity));
            }

            [Test]
            public void AddsNewElementAtTheEnd()
            {
                this.database.Add(testPerson);
                Assert.That(this.database.CurrentIndex, Is.EqualTo(testNumber + 1), "Add command adds element at the end");
            }

            [Test]
            public void AddThrowsExceptionIfMoreThanCapacity()
            {
                this.database = new Database(new Person[Capacity]);
                Assert.That(() => this.database.Add(testPerson),
                    Throws.InvalidOperationException.
                    With.Message.EqualTo(ErrorMessages.LengthMoreThanCapacity));
            }

            [Test]
            public void AddThrowsExceptionIfUsernameIsTaken()
            {
                this.database.Add(testPerson);
                Assert.That(() => this.database.Add(new Person(2, testPerson.Name)),
                    Throws.InvalidOperationException.
                    With.Message.EqualTo(ErrorMessages.UsernameIsTaken));
            }

            [Test]
            public void AddThrowsExceptionIfIdIsTaken()
            {
                this.database.Add(testPerson);
                Assert.That(() => this.database.Add(new Person(testPerson.Id, "Gosho")),
                    Throws.InvalidOperationException.
                    With.Message.EqualTo(ErrorMessages.IdIsTaken));
            }

            [Test]
            public void RemovesLastElement()
            {
                this.database.Remove();
                Assert.That(this.database.CurrentIndex, Is.EqualTo(testNumber - 1), "Remove command removes last element");
            }

            [Test]
            public void RemoveThrowsExceptionWhenDataIsEmpty()
            {
                this.database = new Database();
                Assert.That(() => this.database.Remove(),
                    Throws.InvalidOperationException
                    .With.Message.EqualTo(ErrorMessages.EmptyData));
            }

            [Test]
            public void FindByUserNameReturnsCorrectUser()
            {
                this.database.Add(testPerson);
                Person wantedPerson = this.database.FindByUsername(testPerson.Name);
                Assert.AreEqual(testPerson, wantedPerson);
            }

            [Test]
            public void FindByUsernameThrowsExceptionIfNoSuchUsername()
            {
                this.database.Add(testPerson);
                Assert.That(() => this.database.FindByUsername("Gosho"),
                    Throws.InvalidOperationException.
                    With.Message.EqualTo(ErrorMessages.UsernameDoesntExist));
            }

            [Test]
            public void FindByUsernamaThrowsExceptionIfParameturIsNull()
            {
                this.database.Add(testPerson);
                Assert.That(() => this.database.FindByUsername(null),
                    Throws.ArgumentNullException.
                    With.Message.EqualTo(ErrorMessages.InvalidUsername));
            }

            [Test]
            public void FindByUsernameIsCaseSensitive()
            {
                this.database.Add(testPerson);
                Assert.That(() => this.database.FindByUsername("PeShO"),
                    Throws.InvalidOperationException.
                    With.Message.EqualTo(ErrorMessages.UsernameDoesntExist));
            }

            [Test]
            public void FindByIdReturnsCorrectUser()
            {
                this.database.Add(testPerson);
                Person wantedPerson = this.database.FindById(testPerson.Id);
                Assert.AreEqual(testPerson, wantedPerson);
            }

            [Test]
            public void FindByIdThrowsExceptionIfNoSuchId()
            {
                this.database.Add(testPerson);
                Assert.That(() => this.database.FindById(2),
                    Throws.InvalidOperationException.
                    With.Message.EqualTo(ErrorMessages.IdDoesNotExist));
            }

            [Test]
            public void FindByIdThrowsExceptionIfIdIsNegative()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(int.MinValue));
            }

            [Test]
            public void FetchReturnsData()
            {
                Assert.True(this.database.Fetch() is IEnumerable<Person>);
            }

            [Test]
            public void FetchReturnsCorrectCountOfElements()
            {
                Person[] testData = this.database.Fetch();
                Assert.That(testData.Length, Is.EqualTo(testNumber), "Fetch returns correct count of elements");
            }
        }
    }
}
