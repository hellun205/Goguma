using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Skill
{
  public interface IAttackSkill : ISkill
  {
    WeaponEffect Effect { get; set; }
  }
}