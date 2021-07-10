using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  public class Item_TestSkill1SB : CSkillBook
  {
    public override ItemList Material => ItemList.SKILLBOOK_TEST_SKILL1;

    public override SkillList SkillToReceive => SkillList.TestSkill1;

    public Item_TestSkill1SB() : base() { }
  }
}