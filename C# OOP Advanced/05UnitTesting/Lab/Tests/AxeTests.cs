namespace Tests
{
    using NUnit.Framework;

    public class AxeTests
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
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack");
        }

        [Test]
        public void BrokenAxeCannotAttack()
        {
            this.axe = new Axe(1, 1);

            axe.Attack(dummy);
            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
