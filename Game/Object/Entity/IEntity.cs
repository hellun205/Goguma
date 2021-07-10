using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Entity
{
  public interface IEntity
  {
    string Name { get; set; }
    EntityType Type { get; }
    double Hp { get; set; }
    double MaxHp { get; set; }
    int Level { get; set; }
    double AttDmg { get; set; }
    double DefPer { get; set; }
    double CritDmg { get; set; }
    double CritPer { get; set; }
    double IgnoreDef { get; set; }
    List<ISkill> Skills { get; set; }
    List<IBuffSkill> Buffs { get; set; }
    void Information();
    void AddBuff(IBuffSkill skill);
    void RemoveBuff(IBuffSkill skill);
    double CalAttDmg(IEntity entity, out bool isCrit);
    double CalAttDmg(IAttackSkill attackSkill, IEntity entity, out bool isCrit);
    CTexts GetHpBar(bool withPercentage = true, double plus = 0);
    bool IsDead { get; }
  }
}