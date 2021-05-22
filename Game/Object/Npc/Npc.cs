namespace Goguma.Game.Object.Npc
{
  public abstract class Npc
  {
    public abstract string Name { get; }
    public abstract void OnUse();
  }
}
