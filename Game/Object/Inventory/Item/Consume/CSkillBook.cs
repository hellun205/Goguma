using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

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
    public override string GetString => "스킬 북";
    public override int MaxCount => 1;

    public CSkillBook() : base() { }

    public CSkillBook(in CSkillBook item) : base(item)
    {
      SkillToReceive = item.SkillToReceive;
    }

    public override void DescriptionItem()
    {
      var player = InGame.player;
      PrintText("\n");
      SkillToReceive.Information(false);
      PrintText("\n 사용 시 위 스킬을 획득합니다.");
    }

    public override void UseItem(IPlayer player)
    {
      player.Skills.Add(SkillToReceive);
    }

    public override IItem GetInstance()
    {
      return new CSkillBook(this);
    }

  }
}