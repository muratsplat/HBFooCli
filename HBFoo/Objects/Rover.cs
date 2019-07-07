using HBFoo.Navigation;
using System;

namespace HBFoo.Objects
{
    public class Rover : IRover
    {
        public Rover(Point point, Compass compass) {
            Point = point;
            Direction = compass;
            ID = Guid.NewGuid();
        }

    /*
        The first line of input is the upper-right coordinates of the plateau, 
        the lower-left coordinates are assumed to be 0,0.
     */
        private Point upperRight;
        public Point UpperRight
        {
            get { return upperRight; }
            set { upperRight = value; }
        }
        
        private Point lowerLeft;
        public Point LowerLeft
        {
            get { return lowerLeft; }
            set { lowerLeft = value; }
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
                Direction = new Compass(360 - 90);
                return;
            }
            Direction = new Compass(Direction.Value - 90);
        }

        public void Move()
        {
           if (Direction.Equals(Compass.FromChar("N"))) {
               if (UpperRight == null) {
                    Point.Y++;
               } else if ( Point.Y < UpperRight.Y ) {
                    Point.Y++;
               }
               return;
           }

           if (Direction.Equals(Compass.FromChar("S"))) {
               if (LowerLeft == null) {
                   Point.Y--;
                } else if( Point.Y > LowerLeft.Y ) {
                    Point.Y--;
               }
               return;
           }
           if (Direction.Equals(Compass.FromChar("W"))) {
                if (LowerLeft == null) {
                   Point.X--;
                } else if ( Point.X > LowerLeft.X) {
                   Point.X--;
               }
               return;
           }

            if (UpperRight == null) {
                Point.X++;
                return;
            } else if (Point.X < UpperRight.X) {
               Point.X++;
           }
        }

        public string GetPosition() {
            return String.Format("{0} {1} {2}", Point.X, Point.Y, Direction.ToString());
        }
    }
}