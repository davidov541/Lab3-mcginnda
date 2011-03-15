using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
    {
        private readonly DateTime start = new DateTime(2011, 6, 27);
        private readonly DateTime end = new DateTime(2011, 7, 4);
        private readonly int miles = 1000;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(start, end, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightCannotHaveNegativeMilesSinceNegativeMilesAreNotRealisticInRealWorldSituationsUnlessYouAreATheoreticalPhysicist()
        {
            new Flight(start, end, -1);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightDetectsNegativeTime()
        {
            new Flight(end, start, miles);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForSevenDayTrip()
        {
            var target = new Flight(start, end, miles);
            Assert.AreEqual(340, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwelveDayTrip()
        {
            var target = new Flight(start, end.AddDays(5), miles);
            Assert.AreEqual(440, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForDayTrip()
        {
            var target = new Flight(start, start, miles);
            Assert.AreEqual(200, target.getBasePrice());
        }
	}
}
