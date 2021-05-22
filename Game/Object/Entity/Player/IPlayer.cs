using Goguma.Game.Object.Map;

namespace Goguma.Game.Object.Entity.Player
{
  public interface IPlayer : IEntity
  {
    Inventory.Inventory Inventory { get; set; }
    Location Loc { get; }
    double Ep { get; set; }
    double MaxEp { get; set; }

    double Exp { get; set; }
    double MaxExp { get; set; }
    double IncreaseMaxExp { get; set; }
    double IncreaseMaxHp { get; set; }
    double IncreaseMaxEp { get; set; }
    double IncreaseAttDmg { get; set; }
    double Gold { get; set; }
  }
}
