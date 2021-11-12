using System;
using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemTestSkill2Sb : CSkillBook
  {
    public override ItemList Material => ItemList.SKILLBOOK_TEST_SKILL2;

    public static readonly IItem Instance = new ItemTestSkill2Sb();

    public override SkillList SkillToReceive => SkillList.TEST_SKILL2;

    public ItemTestSkill2Sb() : base() { }
  }
}