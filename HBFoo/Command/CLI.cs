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

    public CLI(TextReader input, IWriter output)
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

    private Regex plateue = new Regex(@"^\d$", RegexOptions.Compiled | RegexOptions.IgnoreCase); 
    private Regex roverInit = new Regex(@"^\d{1}\s\d{1}\s[NEWS]", RegexOptions.Compiled | RegexOptions.IgnoreCase); 
    private Regex commands = new Regex(@"^\w[LMR]", RegexOptions.Compiled | RegexOptions.IgnoreCase); 
    private Plateue mars;


    private IWriter _output;
    public IWriter Out
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
            lineNumber++;
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
                if (rovers.Count == 0) {
                    throw new Exception("There is not rover which landed on mars!");
                }
                mars.Move(rovers[0], line);

                Out.WriteLine(rovers[0].GetPosition());
                mars.CallStation(rovers[0]);
                rovers.Remove(rovers[0]);
            }
        }

        Out.Close();
    }
  }

}