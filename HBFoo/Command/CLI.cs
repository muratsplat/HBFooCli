using System;
using System.IO;
using HBFoo.Navigation;
using HBFoo.Objects;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HBFoo.Command
{
  public class CLI
  {

    public CLI(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }
    private TextReader _input;
    public TextReader In
    {
        get { return _input; }
        set { _input = value; }
    }

    private Regex plateue = new Regex(@"^(\d+)\s(\d+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase); 
    private Regex roverInit = new Regex(@"^(\d+)\s(\d+)\s([NSEW])$", RegexOptions.Compiled | RegexOptions.IgnoreCase); 
    private Regex commands = new Regex(@"^([LRM]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase); 
    private Plateue mars;


    private TextWriter _output;
    public TextWriter Out
    {
        get { return _output; }
        set { _output = value; }
    }

    public void Start()
    {
        var lineNumber = 0;
        var rovers = new List<IRover>();

        while (In.Peek() >= 0) 
        {
            ++lineNumber;
            var line = In.ReadLine(); 
            // end of it
            if (line == null) {
                break;
            }

            if (plateue.Match(line).Success || mars == null) {
                var segment = line.Split(" ");
                var x = Int32.Parse(segment[0]);
                var y = Int32.Parse(segment[1]);
                mars = new Plateue(new Point(x, y), new Point(0, 0));
                continue;
            }

            if (roverInit.Match(line).Success) {
                // 1 2 N
                var segment = line.Split(" ");
                var x = Int32.Parse(segment[0]);
                var y = Int32.Parse(segment[1]);
                var d = segment[2];

                if (mars != null) {
                    var rover = new Rover(new Point(x,y), Compass.FromChar(d));
                    rovers.Add(mars.AddRover(rover));
                }
                continue;
            }

            if (commands.Match(line).Success) {
                List<string> cmds = new List<string>(line.Split('\\'));
                if (lineNumber != 0 && lineNumber % 2 == 0 ) {
                    var roverOrder = lineNumber /2;
                    if (rovers.Count == 0) {
                        throw new Exception("There is not rover which landed on mars!");
                    }
                    foreach (var cmd in cmds)
                    {
                        mars.Move(rovers[0], cmd);
                    }

                    Out.WriteLine(rovers[0].GetPosition());

                    System.Console.Out.WriteLine(rovers[0].GetPosition());
                    mars.CallStation(rovers[0]);
                    rovers.Remove(rovers[0]);
                    
                }
            }
        }
    }
  }

}