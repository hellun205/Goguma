using System;
using System.Collections.Generic;
using Gogu_Remaster.Game.Object.Map;
using Goguma.Game.Object.Map;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity.Player
{
  public interface IPlayer
  {
    string Name { get; set; }

    Inventory.Inventory Inventory { get; set; }
    [Obsolete]
    MapList Map { get; set; }
    Location Loc { get; }
    double Hp { get; set; }
    double Ep { get; set; }

    double MaxHp { get; set; }
    double MaxEp { get; set; }

    int Level { get; }
    double Exp { get; set; }
    double MaxExp { get; set; }
    double IncreaseMaxExp { get; set; }
    double IncreaseMaxHp { get; set; }
    double IncreaseMaxEp { get; set; }
    double IncreaseAttDmg { get; set; }
    double Gold { get; set; }

    double AttDmg { get; set; }

    double DefPer { get; set; }

    List<ISkill> Skills { get; set; }
    List<IBuffSkill> Buffs { get; set; }
    void PrintAbout();
  }
}
