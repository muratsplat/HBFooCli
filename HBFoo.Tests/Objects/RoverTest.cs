using Xunit;
using HBFoo.Objects;
using HBFoo.Navigation;

namespace HBFoo.Tests.Objects
{

    public class RoverTest
    {
        public RoverTest()
        {
            // new Rover();
        }

        [Fact]
        public void RoverEquals()
        {
            var rover1 = new Rover(new Point(1, 1), Compass.Of(Directions.N));
            var rover2 = new Rover(new Point(1, 1), Compass.Of(Directions.N));
            Assert.True(rover1.Equals(rover2));

            var rover3 = new Rover(new Point(1, 3), Compass.Of(Directions.N));
            var rover4 = new Rover(new Point(1, 2), Compass.Of(Directions.N));
            Assert.False(rover3.Equals(rover4));
        }
    }

    
}