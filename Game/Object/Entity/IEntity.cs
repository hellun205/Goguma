using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity
{
  public interface IEntity
  {
    string Name { get; set; }
    double Hp { get; set; }
    double MaxHp { get; set; }
    int Level { get; set; }
    double AttDmg { get; set; }
    double DefPer { get; set; }
    List<ISkill> Skills { get; set; }
    List<IBuffSkill> Buffs { get; set; }
    void PrintAbout();
    void AddBuff(IBuffSkill skill);
    void RemoveBuff(IBuffSkill skill);
  }
}