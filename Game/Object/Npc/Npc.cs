namespace Goguma.Game.Object.Npc
{
  public abstract class Npc
  {
    public string Name { get; protected set; }
    public abstract NpcType Type { get; }
    public string TypeString => Npcs.GetNpcTypeToString(Type);
    public abstract void OnUse();
  }
}
