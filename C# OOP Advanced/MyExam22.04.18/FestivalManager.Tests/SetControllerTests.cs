// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void PerformerWithNoInstrument()
        {
            Set set = new Short("Set1");
            Stage stage = new Stage();

            TimeSpan duaration = TimeSpan.Parse("01:02");
            Song song = new Song("Song1", duaration);
            Performer performer = new Performer("Gosho", 24);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddPerformer(performer);

            SetController setController = new SetController(stage);

            string expectedMsg = "1. Set1:\r\n-- Did not perform";
            string actual = setController.PerformSets();

            Assert.That(actual, Is.EqualTo(expectedMsg));
        }

        [Test]
        public void SuccessfulMessage()
        {
            Stage stage = new Stage();
            TimeSpan duaration = TimeSpan.Parse("00:01:02");
            Song song = new Song("Song1", duaration);
            Performer performer = new Performer("Gosho", 24);

            Set set = new Short("Set1");

            Drums drums = new Drums();
            performer.AddInstrument(drums);

            set.AddPerformer(performer);
            set.AddSong(song);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddPerformer(performer);

            SetController setController = new SetController(stage);

            string expectedMsg = "1. Set1:\r\n-- 1. Song1 (01:02)\r\n-- Set Successful";
            string actual = setController.PerformSets();

            Assert.That(actual, Is.EqualTo(expectedMsg));
            Assert.That(drums.Wear, Is.EqualTo(80));
        }

        [Test]
        public void NoPerformer()
        {
            Set set = new Short("Set1");
            Stage stage = new Stage();

            TimeSpan duaration = TimeSpan.Parse("01:02");
            Song song = new Song("Song1", duaration);

            stage.AddSet(set);
            stage.AddSong(song);

            SetController setController = new SetController(stage);

            string expectedMsg = "1. Set1:\r\n-- Did not perform";
            string actual = setController.PerformSets();

            Assert.That(actual, Is.EqualTo(expectedMsg));
        }

        [Test]
        public void NoSong()
        {
            Stage stage = new Stage();
            TimeSpan duaration = TimeSpan.Parse("00:01:02");
            Performer performer = new Performer("Gosho", 24);

            Set set = new Short("Set1");

            Drums drums = new Drums();
            performer.AddInstrument(drums);

            set.AddPerformer(performer);

            stage.AddSet(set);
            stage.AddPerformer(performer);

            SetController setController = new SetController(stage);

            string expectedMsg = "1. Set1:\r\n-- Did not perform";
            string actual = setController.PerformSets();

            Assert.That(actual, Is.EqualTo(expectedMsg));
        }

        [Test]
        public void OnePerformerWitoutInstrument()
        {
            Stage stage = new Stage();
            TimeSpan duaration = TimeSpan.Parse("00:01:02");
            Song song = new Song("Song1", duaration);
            Performer performer = new Performer("Gosho", 24);

            Performer secondPerformer = new Performer("Pesho", 20);

            Set set = new Short("Set1");

            Drums drums = new Drums();
            performer.AddInstrument(drums);

            set.AddPerformer(performer);
            set.AddPerformer(secondPerformer);
            set.AddSong(song);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddPerformer(performer);

            SetController setController = new SetController(stage);

            string expectedMsg = "1. Set1:\r\n-- Did not perform";
            string actual = setController.PerformSets();

            Assert.That(actual, Is.EqualTo(expectedMsg));
        }
    }
}