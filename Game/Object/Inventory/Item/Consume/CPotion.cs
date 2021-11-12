using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item.Consume
{
  [Serializable]
  public abstract class CPotion : ConsumeItem
  {
    public abstract PotionEffect Effect { get; }

    public override ConsumeItemType CType => ConsumeItemType.POTION;

    public CPotion() : base() { }

    public override CTexts EffectInfo()
    {
      var player = InGame.player;
      var resCt = new CTexts();

      if (Effect.IncreaseGold != 0) resCt.Append($"{{\n골드 획득 : }}").Append(NumberColor(Effect.IncreaseGold, "G")).Append($"{{ ( {player.Gold} G }}").Append(NumberColor(Effect.IncreaseGold, "G")).Append("{ → }").Append(NumberColor(player.Gold + Effect.IncreaseGold, "G")).Append("{ )}");

      if (Effect.IncreaseExp != 0) resCt.Append($"{{\n경험치 획득 : }}").Append(NumberColor(Effect.IncreaseExp)).Append($"{{ ( {player.Exp} }}").Append(NumberColor(Effect.IncreaseExp)).Append("{ → }").Append(NumberColor(player.Exp + Effect.IncreaseExp)).Append("{ )}");


      if (Effect.HealHp != 0) resCt.Append($"{{\n체력 회복 : }}").Append(NumberColor(Effect.HealHp)).Append($"{{ ( {player.Hp} }}").Append(NumberColor(Effect.HealHp)).Append("{ → }").Append(NumberColor(Math.Min(player.Hp + Effect.HealHp, player.MaxHp))).Append("{ )}");

      if (Effect.HealEp != 0) resCt.Append($"{{\n에너지 회복 : }}").Append(NumberColor(Effect.HealEp)).Append($"{{ ( {player.Ep} }}").Append(NumberColor(Effect.HealEp)).Append("{ → }").Append(NumberColor(Math.Min(player.Ep + Effect.HealEp, player.MaxEp))).Append("{ )}");


      if (Effect.IncreaseMaxHp != 0) resCt.Append($"{{\n최대 체력 {{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseMaxHp)).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(Effect.IncreaseMaxHp)).Append("{ → }").Append(NumberColor(player.MaxHp + Effect.IncreaseMaxHp)).Append("{ )}");

      if (Effect.IncreaseMaxEp != 0) resCt.Append($"{{\n최대 에너지 {{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseMaxEp)).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(Effect.IncreaseMaxEp)).Append("{ → }").Append(NumberColor(player.MaxEp + Effect.IncreaseMaxEp)).Append("{ )}");

      if (Effect.IncreaseAttDmg != 0) resCt.Append($"{{\n공격력 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseAttDmg)).Append($"{{ ( {player.PhysicalDamage} }}").Append(NumberColor(Effect.IncreaseAttDmg)).Append("{ → }").Append(NumberColor(player.PhysicalDamage + Effect.IncreaseAttDmg)).Append("{ )}");

      if (Effect.IncreaseCritDmg != 0) resCt.Append($"{{\n크리티컬 데미지 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseCritDmg, "%")).Append($"{{ ( {player.CriticalDamage} % }}").Append(NumberColor(Effect.IncreaseCritDmg, "%")).Append("{ → }").Append(NumberColor(player.CriticalDamage + Effect.IncreaseCritDmg, "%")).Append("{ )}");

      if (Effect.IncreaseCritPer != 0) resCt.Append($"{{\n크리티컬 확률 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseCritPer, "%")).Append($"{{ ( {player.CriticalPercent} % }}").Append(NumberColor(Effect.IncreaseCritPer, "%")).Append("{ → }").Append(NumberColor(player.CriticalPercent + Effect.IncreaseCritPer, "%")).Append("{ )}");

      if (Effect.IncreaseIgnoreDef != 0) resCt.Append($"{{\n방어율 무시 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseIgnoreDef, "%")).Append($"{{ ( {player.PhysicalPenetration} % }}").Append(NumberColor(Effect.IncreaseIgnoreDef, "%")).Append("{ → }").Append(NumberColor(player.PhysicalPenetration + Effect.IncreaseIgnoreDef, "%")).Append("{ )}");

      if (Effect.IncreaseDefPer != 0) resCt.Append($"{{\n방어율 }}{{영구,{Colors.txtDanger}}}{{ 증가 : }}").Append(NumberColor(Effect.IncreaseDefPer, "%")).Append($"{{ ( {player.PhysicalDefense} % }}").Append(NumberColor(Effect.IncreaseDefPer, "%")).Append("{ → }").Append(NumberColor(player.PhysicalDefense + Effect.IncreaseDefPer, "%")).Append("{ )}");


      if (Effect.InBattleMaxHp != 0) resCt.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{최대 체력 증가 : }}").Append(NumberColor(Effect.InBattleMaxHp)).Append($"{{ ( {player.MaxHp} }}").Append(NumberColor(Effect.InBattleMaxHp)).Append("{ → }").Append(NumberColor(player.MaxHp + Effect.InBattleMaxHp)).Append("{ )}");

      if (Effect.InBattleMaxEp != 0) resCt.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{최대 에너지 증가 : }}").Append(NumberColor(Effect.InBattleMaxEp)).Append($"{{ ( {player.MaxEp} }}").Append(NumberColor(Effect.InBattleMaxEp)).Append("{ → }").Append(NumberColor(player.MaxEp + Effect.InBattleMaxEp)).Append("{ )}");

      if (Effect.InBattleAttDmg != 0) resCt.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{공격력 증가 : }}").Append(NumberColor(Effect.InBattleAttDmg)).Append($"{{ ( {player.PhysicalDamage} }}").Append(NumberColor(Effect.InBattleAttDmg)).Append("{ → }").Append(NumberColor(player.PhysicalDamage + Effect.InBattleAttDmg)).Append("{ )}");

      if (Effect.InBattleCritDmg != 0) resCt.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{크리티컬 데미지 증가 : }}").Append(NumberColor(Effect.InBattleCritDmg, "%")).Append($"{{ ( {player.CriticalDamage} % }}").Append(NumberColor(Effect.InBattleCritDmg, "%")).Append("{ → }").Append(NumberColor(player.CriticalDamage + Effect.InBattleCritDmg, "%")).Append("{ )}");

      if (Effect.InBattleCritPer != 0) resCt.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{크리티컬 확률 증가 : }}").Append(NumberColor(Effect.InBattleCritPer, "%")).Append($"{{ ( {player.CriticalPercent} % }}").Append(NumberColor(Effect.InBattleCritPer, "%")).Append("{ → }").Append(NumberColor(player.CriticalPercent + Effect.InBattleCritPer, "%")).Append("{ )}");

      if (Effect.InBattleIgnoreDef != 0) resCt.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{방어율 무시 증가 : }}").Append(NumberColor(Effect.InBattleIgnoreDef, "%")).Append($"{{ ( {player.PhysicalPenetration} % }}").Append(NumberColor(Effect.InBattleIgnoreDef, "%")).Append("{ → }").Append(NumberColor(player.PhysicalPenetration + Effect.InBattleIgnoreDef, "%")).Append("{ )}");

      if (Effect.InBattleDefPer != 0) resCt.Append($"{{\n}}{{배틀 중 ,{Colors.txtDanger}}}{{방어율 증가 : }}").Append(NumberColor(Effect.InBattleDefPer, "%")).Append($"{{ ( {player.PhysicalDefense} % }}").Append(NumberColor(Effect.InBattleDefPer, "%")).Append("{ → }").Append(NumberColor(player.PhysicalDefense + Effect.InBattleDefPer, "%")).Append("{ )}");

      return resCt;
    }

    public override void UseItem(Player player)
    {
      player.Hp += Effect.HealHp;
      player.Ep += Effect.HealEp;
      player.PhysicalDamage += Effect.IncreaseAttDmg;
      player.PhysicalDefense += Effect.IncreaseDefPer;
      player.Gold += Effect.IncreaseGold;
      player.Exp += Effect.IncreaseExp;
    }

    public override CTexts UsedText()
    {
      return EffectInfo()
      .Combine("{\n포션을 사용하여 능력치가 증가했습니다.}");
    }
  }
}