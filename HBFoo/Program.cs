using System;
using HBFoo.Command;

namespace HBFoo
{
    class Program
    {
    static void Main(string[] args)  {
          
      var cmd = new CLI(Console.In, new Writer(Console.Out));
      cmd.Start();
    } 
  }
}
