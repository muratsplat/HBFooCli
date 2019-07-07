using HBFoo.Navigation;
using System.Collections.Generic;
using System;

namespace HBFoo.Objects
{
    class Plateue {

        private Point _upperRight;
        public Point UpperRight
        {
            get { return _upperRight; }
            set { _upperRight = value; }
        }

        private Point _lowerLeft;
        public Point LowerLeft
        {
            get { return _lowerLeft; }
            set { _lowerLeft = value; }
        }
        
        private List<IRover> rovers = new List<IRover>();
        
        public Plateue(Point upperRight, Point lowerLeft)
        {
            _upperRight = upperRight;
            _lowerLeft = lowerLeft;
        }

        public IRover AddRover(IRover rover)
        {
            if (rovers.Exists( r => r.Equals(rover))) {
                throw new Exception("it is already exist. ");
            }
            rovers.Add(rover);
            return rover;
        }

        public void Move(IRover rover, string commands) 
        {
            // Todo: check the result
            var one = rovers.Find( r => r.Equals(rover));
            // The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, 
            // without moving from its current spot. 'M' means move forward one grid point, and maintain the same heading.
            foreach (var c in commands.ToCharArray())
            {
                switch (Convert.ToString(c))
                {
                    case "L": one.TurnLeft();
                        break;
                    case "R": one.TurnRight();
                        break;
                    case "M": one.Move();
                        break;
                }
            }
        }
        public void CallStation(IRover rover) 
        {
            // Todo: check the result
            var one = rovers.Find( r => r.Equals(rover) );
            rovers.Remove(one);
        }
        
    }  
}