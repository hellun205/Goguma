using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item.Drop;

namespace Goguma.Game.Object.Entity.Monster
{
  public interface IMonster : IEntity
  {
    CTexts Descriptions { get; }
    double GivingGold { get; }
    double GivingExp { get; }
    DroppingItems DroppingItems { get; }
    AttackSyss AttSystem { get; }
  }
}
