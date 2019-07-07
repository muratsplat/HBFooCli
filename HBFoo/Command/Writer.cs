using System.Text;
using System.IO;

namespace HBFoo.Command
{
  public class Writer : IWriter
  {

    public Writer(TextWriter proxy)
    {
      _proxy = proxy;
    }
    private TextWriter _proxy;
    public TextWriter Proxy
    {
        get { return _proxy; }
        set { Proxy = value; }
    }

    public void WriteLine(string value) 
    {
      Proxy.WriteLine(value);
    }
    public void Close() 
    {
      Proxy.Close();
    }

  }
}