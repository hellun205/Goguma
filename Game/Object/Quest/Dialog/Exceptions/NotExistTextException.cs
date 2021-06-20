namespace Goguma.Game.Object.Quest.Dialog.Exceptions
{
  public class NotExistTextException : System.Exception
  {
    public override string ToString()
    {
      return "This Text does not exist.";
    }
  }
}