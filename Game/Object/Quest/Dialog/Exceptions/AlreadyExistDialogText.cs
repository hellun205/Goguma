namespace Goguma.Game.Object.Quest.Dialog.Exceptions
{
  public class AlreadyExistDialogText : System.Exception
  {
    public override string ToString()
    {
      return "This DialogText is already exist at DialogText List.";
    }
  }
}