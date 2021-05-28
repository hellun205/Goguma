namespace Goguma.Game.Object.Quest.Exceptions
{
  public class AlreadyExistEntity : System.Exception
  {
    public override string ToString()
    {
      return "This Entity is already exist at Kill Entity Quest";
    }
  }
}