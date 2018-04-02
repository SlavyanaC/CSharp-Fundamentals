namespace Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts;

    class HeroTests
    {
        private const int dummyExperience = 20;
        private const string HeroName = "Pesho";

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(t => t.GiveExperience()).Returns(dummyExperience);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

            Hero hero = new Hero(HeroName, fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);
            Assert.That(hero.Experience, Is.EqualTo(dummyExperience));
        }
    }
}
