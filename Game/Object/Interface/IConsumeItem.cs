namespace Goguma.Game.Object.Interface
{
  interface IConsumeItem : IItem
  {
    int HpE {get; set;}
    int EpE { get; set; }
    int ExpE { get; set; } 
    int AttDmgE { get; set; }
    int GoldE { get; set; }
    void UseItem(IPlayer toPlayer);
  }
}
