using Xunit;
using HBFoo.Objects;
using HBFoo.Command;
using HBFoo.Navigation;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace HBFoo.Tests.Command
{

    public class CLITest
    {
        
        public CLITest()
        {

        }

        [Fact]
        public void CLIFistTest()
        {

            // 5 5
            // 1 2 N
            // LMLMLMLMM
            // 3 3 E
            // MMRMMRMRRM
            var inputExample = new MemoryStream();
            var inputsAsbytes = Encoding.ASCII.GetBytes("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM");
            var outputsAsbytes = Encoding.ASCII.GetBytes("1 3 N\n5 1 E");



            var reader = new StreamReader(new MemoryStream(inputsAsbytes), Encoding.UTF8);
            var outputStream = new MemoryStream();
            var writer = new StreamWriter(outputStream, Encoding.UTF8);
            // writer.Close();
            // outputStream.Close();

            var command = new CLI(reader, writer);
            command.Start();


            var inputAsString = Encoding.UTF8.GetString(inputsAsbytes);
            var outputAsString = Encoding.UTF8.GetString(outputStream.ToArray());

            Assert.Equal(inputAsString, outputAsString);
           
        }
    }
       
}