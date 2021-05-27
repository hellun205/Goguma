using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Skill;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  [Serializable]
  class CSkillBook : ConsumeItem
  {
    private ISkill skill;
    public ISkill SkillToReceive
    {
      get => skill;
      set
      {
        skill = value;
        base.Descriptions = CTexts.Make($"{{사용 하면 다음 스킬을 획득할 수 있다.\n  }}{{▶ ,{Colors.txtInfo}}}{{[ {Skill.Skill.GetTypeString(SkillToReceive.Type)} 스킬 ],{Colors.txtWarning}}}{{ {SkillToReceive.Name.ToString()},{Colors.txtInfo}}}");
      }
    }
    public override ConsumeItemType CType => ConsumeItemType.SKILL_BOOK;
    public override int MaxCount => 1;

    public CSkillBook() : base() { }

    public CSkillBook(in CSkillBook item) : base(item)
    {
      SkillToReceive = item.SkillToReceive;
    }

    public override CTexts EffectInfo()
    {
      return new CTexts()
      .Append(SkillToReceive.Info(35))
      .Append($"{{\n사용 시 위 스킬을 획득합니다.}}");
    }

    public override void UseItem(IPlayer player)
    {
      player.Skills.Add(SkillToReceive);
    }

    public override IItem GetInstance()
    {
      return new CSkillBook(this);
    }

    public override CTexts UsedText()
    {
      return new CTexts()
      .Append(SkillToReceive.Info(35))
      .Append($"{{\n스킬 북을 사용하여 스킬을 획득하였습니다.}}");
    }
  }
}