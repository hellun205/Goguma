using System;
using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemTestSkill1Sb : CSkillBook
  {
    public override ItemList Material => ItemList.SKILLBOOK_TEST_SKILL1;

    public static readonly IItem Instance = new ItemTestSkill1Sb();

    public override SkillList SkillToReceive => SkillList.TEST_SKILL1;

    public ItemTestSkill1Sb() : base() { }
  }
}