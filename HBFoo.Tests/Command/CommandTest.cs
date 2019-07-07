using Xunit;
using HBFoo.Objects;
using HBFoo.Command;
using HBFoo.Navigation;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using Moq;



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
        
            var inputsAsbytes = Encoding.UTF8.GetBytes("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM");


            var reader = new StreamReader(new MemoryStream(inputsAsbytes), Encoding.UTF8);
            var outputStream = new MemoryStream();
            var writer = new StreamWriter(outputStream, Encoding.UTF8);

            var mockWriter = new Mock<IWriter>();
            mockWriter.Setup(m => m.WriteLine("1 3 N"));
            mockWriter.Setup(m => m.WriteLine("5 1 E"));


            var command = new CLI(reader, mockWriter.Object);
            command.Start();
            writer.Close();
            outputStream.Close();

            mockWriter.Verify(foo => foo.WriteLine("1 3 N"));
            mockWriter.Verify(foo => foo.WriteLine("5 1 E"));



          
           
        }
    }
       
}