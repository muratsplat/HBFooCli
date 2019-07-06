namespace HBFoo.Navigation
{
    public class Point
    {
        public Point(int X, int Y) {
            this.x = X;
            this.y = Y;
        }

        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {   
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var castTo = obj as Point;
            return castTo.X == X && castTo.Y == Y;
        }    
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return X*Y;
        }    
    }
    
}