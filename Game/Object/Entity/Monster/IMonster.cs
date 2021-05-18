﻿using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Drop;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity.Monster
{
  public interface IMonster
  {
    string Name { get; set; }
    CTexts Descriptions { get; set; }
    double Hp { get; set; }
    double MaxHp { get; set; }
    int Level { get; set; }

    double AttDmg { get; set; }
    double DefPer { get; set; }

    List<Skill.Skill> Skills { get; set; }
    double GivingGold { get; set; }
    double GivingExp { get; set; }
    DroppingItems DroppingItems { get; set; }
    AttackSyss AttSystem { get; set; }
    List<IBuffSkill> Buffs { get; set; }
    void PrintAbout(IPlayer player = null);
    void AddBuff(IBuffSkill skill);
    void RemoveBuff(IBuffSkill skill);
  }
}
