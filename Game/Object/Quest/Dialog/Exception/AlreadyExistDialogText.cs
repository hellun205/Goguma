namespace Goguma.Game.Object.Quest.Dialog.Exception
{
  public class AlreadyExistDialogText : System.Exception
  {
    public override string ToString()
    {
      return "This DialogText is already exist at DialogText List.";
    }
  }
}