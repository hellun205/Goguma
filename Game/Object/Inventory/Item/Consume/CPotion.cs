using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  [Serializable]
  class CPotion : ConsumeItem
  {
    public PotionEffect Effect { get; set; }
    public override string GetString => "포션";
    public CPotion() : base() { }
    public CPotion(in CPotion item) : base(item)
    {
      Effect = item.Effect;
    }

    public override CTexts EffectInfo()
    {
      var player = InGame.player;
      var resCT = new CTexts();

      if (Effect.IncreaseGold != 0) resCT.Append($"{{\n골드 획득 : }}").Append(NumberColor(Effect.IncreaseGold, "G")).Append($"{{ ( {player.Gold} G }}").Append(NumberColor(Effect.IncreaseGold, "G")).Append("{ → }").Append(NumberColor(player.Gold + Effect.IncreaseGold, "G")).Append("{ )}");

      if (Effect.IncreaseExp != 0) resCT.Append($"{{\n경험치 획득 : }}").Append(NumberColor(Effect.IncreaseExp)).Append($"{{ ( {player.Exp} }}").Append(NumberColor(Effect.IncreaseExp)).Append("{ → }").Append(NumberColor(player.Exp + Effect.IncreaseExp)).Append("{ )}");


      if (Effect.HealHp != 0) resCT.Append($"{{\n체력 회복 : }}").Append(NumberColor(Effect.HealHp)).Append($"{{ ( {player.Hp} }}").Append(NumberColor(Effect.HealHp)).Append("{ → }").Append(NumberColor(Math.Min(player.Hp + Effect.HealHp, player.MaxHp))).Append("{ )}");

      if (Effect.HealEp != 0) resCT.Append($"{{\n에너지 회복 : }}").Append(NumberColor(Effect.HealEp)).Append($"{{ ( {player.Ep} }}").Append(NumberColor(Effect.HealEp)).Append("{ → }").Append(NumberColor(Math.Min(player.Ep + Effect.HealEp, player.MaxEp))).Append("{ )}");


      if (Effect.IncreaseMaxHp != 0) resCT.Append($"{{\n최대 체력 {{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseMaxHp)).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(Effect.IncreaseMaxHp)).Append("{ → }").Append(NumberColor(player.MaxHp + Effect.IncreaseMaxHp)).Append("{ )}");

      if (Effect.IncreaseMaxEp != 0) resCT.Append($"{{\n최대 에너지 {{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseMaxEp)).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(Effect.IncreaseMaxEp)).Append("{ → }").Append(NumberColor(player.MaxEp + Effect.IncreaseMaxEp)).Append("{ )}");

      if (Effect.IncreaseAttDmg != 0) resCT.Append($"{{\n공격력 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseAttDmg)).Append($"{{ ( {player.AttDmg} }}").Append(NumberColor(Effect.IncreaseAttDmg)).Append("{ → }").Append(NumberColor(player.AttDmg + Effect.IncreaseAttDmg)).Append("{ )}");

      if (Effect.IncreaseCritDmg != 0) resCT.Append($"{{\n크리티컬 데미지 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseCritDmg, "%")).Append($"{{ ( {player.CritDmg} % }}").Append(NumberColor(Effect.IncreaseCritDmg, "%")).Append("{ → }").Append(NumberColor(player.CritDmg + Effect.IncreaseCritDmg, "%")).Append("{ )}");

      if (Effect.IncreaseCritPer != 0) resCT.Append($"{{\n크리티컬 확률 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseCritPer, "%")).Append($"{{ ( {player.CritPer} % }}").Append(NumberColor(Effect.IncreaseCritPer, "%")).Append("{ → }").Append(NumberColor(player.CritPer + Effect.IncreaseCritPer, "%")).Append("{ )}");

      if (Effect.IncreaseIgnoreDef != 0) resCT.Append($"{{\n방어율 무시 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseIgnoreDef, "%")).Append($"{{ ( {player.IgnoreDef} % }}").Append(NumberColor(Effect.IncreaseIgnoreDef, "%")).Append("{ → }").Append(NumberColor(player.IgnoreDef + Effect.IncreaseIgnoreDef, "%")).Append("{ )}");

      if (Effect.IncreaseDefPer != 0) resCT.Append($"{{\n방어율 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseDefPer, "%")).Append($"{{ ( {player.DefPer} % }}").Append(NumberColor(Effect.IncreaseDefPer, "%")).Append("{ → }").Append(NumberColor(player.DefPer + Effect.IncreaseDefPer, "%")).Append("{ )}");


      if (Effect.InBattleMaxHp != 0) resCT.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{최대 체력 증가 : }}").Append(NumberColor(Effect.InBattleMaxHp)).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(Effect.InBattleMaxHp)).Append("{ → }").Append(NumberColor(player.MaxHp + Effect.InBattleMaxHp)).Append("{ )}");

      if (Effect.InBattleMaxEp != 0) resCT.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{최대 에너지 증가 : }}").Append(NumberColor(Effect.InBattleMaxEp)).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(Effect.InBattleMaxEp)).Append("{ → }").Append(NumberColor(player.MaxEp + Effect.InBattleMaxEp)).Append("{ )}");

      if (Effect.InBattleAttDmg != 0) resCT.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{공격력 증가 : }}").Append(NumberColor(Effect.InBattleAttDmg)).Append($"{{ ( {player.AttDmg} }}").Append(NumberColor(Effect.InBattleAttDmg)).Append("{ → }").Append(NumberColor(player.AttDmg + Effect.InBattleAttDmg)).Append("{ )}");

      if (Effect.InBattleCritDmg != 0) resCT.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{크리티컬 데미지 증가 : }}").Append(NumberColor(Effect.InBattleCritDmg, "%")).Append($"{{ ( {player.CritDmg} % }}").Append(NumberColor(Effect.InBattleCritDmg, "%")).Append("{ → }").Append(NumberColor(player.CritDmg + Effect.InBattleCritDmg, "%")).Append("{ )}");

      if (Effect.InBattleCritPer != 0) resCT.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{크리티컬 확률 증가 : }}").Append(NumberColor(Effect.InBattleCritPer, "%")).Append($"{{ ( {player.CritPer} % }}").Append(NumberColor(Effect.InBattleCritPer, "%")).Append("{ → }").Append(NumberColor(player.CritPer + Effect.InBattleCritPer, "%")).Append("{ )}");

      if (Effect.InBattleIgnoreDef != 0) resCT.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{방어율 무시 증가 : }}").Append(NumberColor(Effect.InBattleIgnoreDef, "%")).Append($"{{ ( {player.IgnoreDef} % }}").Append(NumberColor(Effect.InBattleIgnoreDef, "%")).Append("{ → }").Append(NumberColor(player.IgnoreDef + Effect.InBattleIgnoreDef, "%")).Append("{ )}");

      if (Effect.InBattleDefPer != 0) resCT.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{방어율 증가 : }}").Append(NumberColor(Effect.InBattleDefPer, "%")).Append($"{{ ( {player.DefPer} % }}").Append(NumberColor(Effect.InBattleDefPer, "%")).Append("{ → }").Append(NumberColor(player.DefPer + Effect.InBattleDefPer, "%")).Append("{ )}");

      return resCT;
    }

    public override void UseItem(IPlayer player)
    {
      player.Hp += Effect.HealHp;
      player.Ep += Effect.HealEp;
      player.AttDmg += Effect.IncreaseAttDmg;
      player.DefPer += Effect.IncreaseDefPer;
      player.Gold += Effect.IncreaseGold;
      player.Exp += Effect.IncreaseExp;
    }
    public override IItem GetInstance()
    {
      return new CPotion(this);
    }

    public override CTexts UsedText()
    {
      return EffectInfo()
      .Combine("{\n위 능력치들이 증가하였습니다.}");
    }
  }
}