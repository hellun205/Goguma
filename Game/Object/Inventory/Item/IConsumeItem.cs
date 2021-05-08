namespace Goguma.Game.Object.Interface
{
  interface IConsumeItem : IItem
  {
    ItemEffect Effect { get; set; }
    new void UseItem(IPlayer toPlayer);

    new void DescriptionItem();
  }
}
