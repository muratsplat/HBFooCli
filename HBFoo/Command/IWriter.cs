

namespace HBFoo.Command
{
  public interface IWriter
  {
    void WriteLine(string value);
    void Close();
  }
}