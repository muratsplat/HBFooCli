using Xunit;
using HBFoo.Objects;
using HBFoo.Navigation;

namespace HBFoo.Tests.Objects
{

    public class RoverTest
    {
        public RoverTest()
        {
            new Rover(new Point(1, 1), Compass.Of(Directions.N));
        }

        [Fact]
        public void RoverEquals()
        {
            var rover1 = new Rover(new Point(1, 1), Compass.Of(Directions.N));
            var rover2 = new Rover(new Point(1, 1), Compass.Of(Directions.N));
            Assert.False(rover1.Equals(rover2));

            Assert.True(rover1.Equals(rover1));

            var rover3 = new Rover(new Point(1, 3), Compass.Of(Directions.N));
            var rover4 = new Rover(new Point(1, 2), Compass.Of(Directions.N));
            Assert.False(rover3.Equals(rover4));
        }

        [Fact]
        public void RoverMove()
        {
            var rover1 = new Rover(new Point(0, 0), Compass.Of(Directions.N));
            rover1.Move();
            rover1.Move();
            rover1.Move();
            rover1.Move();
            Assert.Equal("0 4 N", rover1.GetPosition());
        }

        [Fact]
        public void TurnRight()
        {
            var rover1 = new Rover(new Point(0, 0), Compass.Of(Directions.N));
            rover1.TurnRight();
            rover1.TurnRight();
            rover1.TurnRight();
            rover1.TurnRight();
            Assert.Equal("0 0 N", rover1.GetPosition());

            rover1.TurnRight();
            Assert.Equal("0 0 E", rover1.GetPosition());
        }

        [Fact]
        public void TurnLeft()
        {
            var rover1 = new Rover(new Point(0, 0), Compass.Of(Directions.N));
            rover1.TurnLeft();
            rover1.TurnLeft();
            rover1.TurnLeft();
            rover1.TurnLeft();
            rover1.TurnLeft();
            Assert.Equal("0 0 W", rover1.GetPosition());

            rover1.TurnRight();
            Assert.Equal("0 0 N", rover1.GetPosition());
        }

        [Fact]
        public void MoreComplex()
        {
            // Rover 1
            // 1 2 N
            // LM LM LM L MM
            // Expected: 
            // 1 3 N
            
            // Rover 2
            // 3 3 E
            // MMRMMRMRRM
            var rover1 = new Rover(new Point(1, 2), Compass.Of(Directions.N));
            rover1.UpperRight = new Point(5, 5);
            rover1.LowerLeft = new Point(0, 0);
            rover1.TurnLeft(); 
            rover1.Move();

            rover1.TurnLeft();
            rover1.Move();

            rover1.TurnLeft();
            rover1.Move();

            rover1.TurnLeft();

            rover1.Move();
            rover1.Move();
            Assert.Equal("1 3 N", rover1.GetPosition());
            

            // Rover 2
            // 3 3 E
            // MM RM MR MR RM
            // Expected: 5 1 E
            var rover2 = new Rover(new Point(3, 3), Compass.Of(Directions.E));
            rover2.UpperRight = new Point(5, 5);
            rover2.LowerLeft = new Point(0, 0);
            
            rover2.Move();
            rover2.Move();

            rover2.TurnRight();
            rover2.Move();

            rover2.Move();
            rover2.TurnRight();

            rover2.Move();
            rover2.TurnRight();
            
            rover2.TurnRight();
            rover2.Move();

            Assert.Equal("5 1 E", rover2.GetPosition());
        }
    }
}