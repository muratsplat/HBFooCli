
using System;

namespace HBFoo.Navigation
{
    public class Compass
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public Compass(int value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return Enum.GetName(typeof(Directions), Value);
        }

        public static Compass Of(Directions direction)
        {
            return new Compass((int)direction);
        }

        public static Compass Of(int degree)
        {
            return new Compass(degree);
        }

        public static Compass FromChar(string sembol)
        {
            switch (sembol)
            {
                case "N": return Compass.Of(Directions.N);
                case "E": return Compass.Of(Directions.E);
                case "S": return Compass.Of(Directions.S);
                case "W": return Compass.Of(Directions.W);
            }
            throw new System.Exception("Direction could not parsed!");
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var castTo = obj as Compass;
            return Value == castTo.Value;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Value;
        }
    }
}