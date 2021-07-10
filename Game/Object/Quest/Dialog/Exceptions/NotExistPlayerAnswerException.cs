namespace Goguma.Game.Object.Quest.Dialog.Exceptions
{
  public class NotExistPlayerAnswerException : System.Exception
  {
    public override string ToString()
    {
      return "This player answer does not exist.";
    }
  }
}