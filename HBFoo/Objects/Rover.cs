using HBFoo.Navigation;

namespace HBFoo.Objects
{
    public class Rover
    {
        public Rover(Point point, Compass compass) {
            Point = point;
            Direction = compass;
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

        public override bool Equals(object obj) 
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var castTo = obj as Rover;
            return castTo.Point.Equals(Point) && castTo.Direction.Equals(Direction);
        }
        public override int GetHashCode()
        {
            return this.Point.X * this.Point.Y; 
        }
    }
}