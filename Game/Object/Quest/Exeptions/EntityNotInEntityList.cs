namespace Goguma.Game.Object.Quest.Exceptions
{
  public class EntityNotInEntityList : System.Exception
  {
    public override string ToString()
    {
      return "This entity does not exist in the entity list.";
    }
  }
}