using HBFoo.Navigation;
using System;
namespace HBFoo.Objects
{
    public class Rover
    {
        public Rover(Point point, Compass compass) {
            Point = point;
            Direction = compass;
            ID = Guid.NewGuid();
        }
        private Point point;
        public Point Point
        {
            get { return point; }
            set { point = value; }
        }
        private Compass direction;
        public Compass Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        private Guid id;
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
        
        public override bool Equals(object obj) 
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var castTo = obj as Rover;
            return castTo.Point.Equals(Point) 
                && castTo.Direction.Equals(Direction) 
                && castTo.ID.Equals(ID);
        }
        
        public override int GetHashCode()
        {
            return this.Point.X * this.Point.Y; 
        }

        public void TurnRight()
        {
            var turnDirection =  Direction.Value + 90;
            if (turnDirection >= 360 ) {
                Direction = Compass.Of(Directions.N);
                return;
            }

            Direction = new Compass(turnDirection);
        }
        public void TurnLeft()
        {
            if (Direction.Value == 0 ) {
                Direction = Compass.Of(360 - 90);
                return;
            }
            Direction = new Compass(Direction.Value - 90);
        }

        public void Move()
        {
           if (Direction.Equals(Compass.FromChar("N"))) {
               Point.Y++;
               return;
           }
           if (Direction.Equals(Compass.FromChar("S"))) {
               Point.Y--;
               return;
           }
           if (Direction.Equals(Compass.FromChar("W"))) {
               Point.X--;
               return;
           }
           Point.X++;
        }
    }
}