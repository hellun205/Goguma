using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goguma.Game.Object.Interface;
using Goguma.Game.Object.Inventory;

namespace Goguma.Game.Object.Interface
{
  interface IPlayer
  {
    string Name { get; set; }

    Inventory.Inventory Inventory { get; set; }

    int Hp { get; set; }
    int Ep { get; set; }

    int MaxHp { get; set; }
    int MaxEp { get; set; }

    int Level { get; }
    int Exp { get; set; }
    int Gold { get; set; }

    int AttDmg { get;  }
    int ItemDmg { get; set; }

    int DefPer { get; set; }

    object Skill { get; set; }

    void AttackMonster(IMonster moster);

    void UseConsumedItem();

    void UseSkill();
  }
}
