using HBFoo.Navigation;
using System.Collections.Generic;
using System;

namespace HBFoo.Objects
{
    class Plateue {

        private Point upperRight;
        public Point UpperRight
        {
            get { return upperRight; }
            set { upperRight = value; }
        }

        private List<Rover> rovers = new List<Rover>();
        

        public Plateue(Point upperRight)
        {
            UpperRight = upperRight;
        }

        public void AddRover(Rover rover)
        {
            if (rovers.Exists( r => r.Equals(rover))) {
                throw new Exception("it is already exist. ");
            }
            rovers.Add(rover);
        }

        public void Move(Guid id, string commands) 
        {
            var one = rovers.Find( r => r.ID.Equals(id));
            // The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, 
            // without moving from its current spot. 'M' means move forward one grid point, and maintain the same heading.
            List<string> chars = new List<string>(commands.Split('\\'));
            foreach (var c in chars)
            {
                switch (c)
                {
                    case "L": one.TurnLeft();
                        break;
                    case "R": one.TurnRight();
                        break;
                    case "M": one.Move();
                        break;
                    default:
                        throw new Exception(String.Format("'${}' command is unknown!", c));
                }
            }
        
        }
    }  
}