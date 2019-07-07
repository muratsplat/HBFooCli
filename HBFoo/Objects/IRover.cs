using HBFoo.Navigation;
using System;

namespace HBFoo.Objects
{
    interface IRover
    {   

       Point UpperRight
        {
            get;
            set;
        }
        Point LowerLeft
        {
            get;
            set;
        }
        Point Point
        {
            get;
            set;
        }
        Compass Direction
        {
            get;
            set;
        }
        Guid ID
        {
            get;
            set;
        }
      bool Equals(object obj);
      void TurnRight();
      void TurnLeft();
      void Move();
      string GetPosition(); 
    }

    
}