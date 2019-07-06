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
    }  
}