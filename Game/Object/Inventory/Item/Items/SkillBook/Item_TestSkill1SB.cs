using System;
using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class Item_TestSkill1SB : CSkillBook
  {
    public override ItemList Material => ItemList.SKILLBOOK_TEST_SKILL1;

    public static readonly IItem Instance = new Item_TestSkill1SB();

    public override SkillList SkillToReceive => SkillList.TestSkill1;

    public Item_TestSkill1SB() : base() { }
  }
}