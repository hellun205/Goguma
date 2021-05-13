using System.Collections.Generic;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Map;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity.Player
{
  interface IPlayer
  {
    string Name { get; set; }

    Inventory.Inventory Inventory { get; set; }
    MapList Map { get; set; }
    double Hp { get; set; }
    double Ep { get; set; }

    double MaxHp { get; set; }
    double MaxEp { get; set; }

    int Level { get; }
    double Exp { get; set; }
    double MaxExp { get; set; }
    double IncreaseMaxExp { get; set; }
    double Gold { get; set; }

    double AttDmg { get; set; }

    double DefPer { get; set; }

    List<ISkill> Skills { get; set; }
    List<IBuffSkill> Buffs { get; set; }
    void PrintAbout();
  }
}
