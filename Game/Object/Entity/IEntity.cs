using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Skill;
using Goguma.Game.Object.Skill.Attack;
using Goguma.Game.Object.Skill.Buff;

namespace Goguma.Game.Object.Entity
{
  public interface IEntity
  {
    string Name { get; set; }
    CTexts DisplayName { get; }
    ClassType Class { get; }
    EntityType Type { get; }
    double Hp { get; set; }
    double MaxHp { get; set; }
    int Level { get; set; }
    double PhysicalDamage { get; set; }
    double MagicDamage { get; set; }
    double PhysicalDefense { get; set; }
    double MagicDefense { get; set; }
    double CriticalDamage { get; set; }
    double CriticalPercent { get; set; }
    double PhysicalPenetration { get; set; }
    double MagicPenetration { get; set; }
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