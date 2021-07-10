using System;
using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class Item_TestSkill2SB : CSkillBook
  {
    public override ItemList Material => ItemList.SKILLBOOK_TEST_SKILL2;

    public override SkillList SkillToReceive => SkillList.TestSkill1;

    public Item_TestSkill2SB() : base() { }
  }
}