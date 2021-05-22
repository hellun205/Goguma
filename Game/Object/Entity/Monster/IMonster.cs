﻿using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item.Drop;

namespace Goguma.Game.Object.Entity.Monster
{
  public interface IMonster : IEntity
  {
    CTexts Descriptions { get; set; }
    double GivingGold { get; set; }
    double GivingExp { get; set; }
    DroppingItems DroppingItems { get; set; }
    AttackSyss AttSystem { get; set; }
  }
}
