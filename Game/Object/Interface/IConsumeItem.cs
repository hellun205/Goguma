namespace Goguma.Game.Object.Interface
{
  interface IConsumeItem : IItem
  {
    void UseItem(IPlayer toPlayer);
  }
}
