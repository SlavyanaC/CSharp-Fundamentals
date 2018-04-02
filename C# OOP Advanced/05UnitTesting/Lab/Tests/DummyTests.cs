namespace Tests
{
    using NUnit.Framework;

    class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(10, 10);
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
           this.dummy = new Dummy(20, 20);

            dummy.TakeAttack(axe.AttackPoints);
            Assert.That(dummy.Health, Is.EqualTo(10), "Dummy loses health if attacked");
        }

        [Test]
        public void DeadDummyThrowExceptionIfAttacked()
        {
            dummy.TakeAttack(axe.AttackPoints);
            Assert.That(() => dummy.TakeAttack(axe.AttackPoints),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            var expextedXP = 10;

            dummy.TakeAttack(11);
            Assert.AreEqual(expextedXP, dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
        }
    }
}
