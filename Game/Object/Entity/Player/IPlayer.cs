using Goguma.Game.Console;
using Goguma.Game.Object.Map;
using Goguma.Game.Object.Quest;

namespace Goguma.Game.Object.Entity.Player
{
  public interface IPlayer : IEntity
  {
    Inventory.Inventory Inventory { get; set; }
    QuestSys Quest { get; set; }
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
    CTexts GetEpBar(bool withPercentage = true, double plus = 0);
    CTexts GetExpBar(bool withPercentage = true, double plus = 0);
  }
}
