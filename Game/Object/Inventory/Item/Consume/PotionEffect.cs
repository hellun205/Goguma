using System;

[Serializable]
public struct PotionEffect
{
  public double IncreaseMaxHp { get; set; }
  public double IncreaseMaxEp { get; set; }
  public double IncreaseAttDmg { get; set; }
  public double IncreaseDefPer { get; set; }
  public double IncreaseCritDmg { get; set; }
  public double IncreaseCritPer { get; set; }
  public double IncreaseIgnoreDef { get; set; }
  public double IncreaseGold { get; set; }
  public double IncreaseExp { get; set; }

  public int InBattleTurn { get; set; }
  public double InBattleMaxHp { get; set; }
  public double InBattleMaxEp { get; set; }
  public double InBattleAttDmg { get; set; }
  public double InBattleDefPer { get; set; }
  public double InBattleCritDmg { get; set; }
  public double InBattleCritPer { get; set; }
  public double InBattleIgnoreDef { get; set; }

  public double HealHp { get; set; }
  public double HealEp { get; set; }

}