using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttackSystem;
using Goguma.Game.Object.Inventory.Item.Drop;

namespace Goguma.Game.Object.Entity.Monster
{
  public interface IMonster : IEntity
  {
    CTexts Descriptions { get; }
    double GivingGold { get; }
    double GivingExp { get; }
    DroppingItems DroppingItems { get; }
    AttackSyss AttSystem { get; set; }
    MonsterList Material { get; }
  }
}
