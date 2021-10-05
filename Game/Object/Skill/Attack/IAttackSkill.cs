using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Skill.Attack
{
  public interface IAttackSkill : ISkill
  {
    AttackType DamageType { get; }
    string DamageTypeString { get; }
    AttackEffect Effect { get; }
  }
}