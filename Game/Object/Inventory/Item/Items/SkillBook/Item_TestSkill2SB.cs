using System;
using Goguma.Game.Object.Inventory.Item.Consume;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Inventory.Item.Items
{
  [Serializable]
  public class ItemTestSkill2Sb : CSkillBook
  {
    public override ItemList Material => ItemList.SkillbookTestSkill2;

    public static readonly IItem Instance = new ItemTestSkill2Sb();

    public override SkillList SkillToReceive => SkillList.TestSkill2;

    public ItemTestSkill2Sb() : base() { }
  }
}