using System;
using System.Text;
using Colorify;
using Goguma.Game.Object.Map;
using Goguma.Game.Console;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using Goguma.Game.Object.Map.Town;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Entity.Player
{
  [Serializable]
  public class Player : Entity, IPlayer
  {
    public override EntityType Type => EntityType.PLAYER;
    public Inventory.Inventory Inventory { get; set; }
    public Location Loc { get; set; }

    public double Ep
    {
      get => Math.Round(ep, 2);
      set => ep = Math.Min(value, MaxEp);
    }
    public double MaxEp
    {
      get => Math.Round(maxEp + GetEquipEffect.MaxEp + BuffsIncrease.MaxEp, 2);
      set => maxEp = Math.Max(0, value);
    }
    new public double MaxHp
    {
      get => Math.Round(maxHp + GetEquipEffect.MaxHp + BuffsIncrease.MaxHp, 2);
      set => maxHp = Math.Max(0, value);
    }
    new public double DefPer
    {
      get => Math.Round(defPer + GetEquipEffect.DefPer + BuffsIncrease.DefPer, 2);
      set => defPer = Math.Max(1, value);
    }
    new public double AttDmg
    {
      get => Math.Round(attDmg + GetWeaponEffect.AttDmg + BuffsIncrease.AttDmg, 2);
      set => attDmg = Math.Max(1, value);
    }

    public double Exp
    {
      get => exp;
      set
      {
        if (MaxExp > value)
          exp = value;
        else if (MaxExp <= value)
        {
          Level += 1; // Level Up
          AttDmg += IncreaseAttDmg;
          MaxHp += IncreaseMaxHp;
          MaxEp += IncreaseMaxEp;
          Hp = MaxHp;
          Ep = MaxEp;
          MaxExp += IncreaseMaxExp;
          PrintCText($"{{\nLevel UP! Lv. }} {{{Level}\n, {Colors.txtInfo}}}");
          Exp = Math.Max(0, value - MaxExp);
          Pause();
        }
      }
    }


    public double MaxExp { get; set; }

    public double IncreaseMaxExp
    {
      get => IncreaseMul(increaseMaxExp);
      set => increaseMaxExp = value;
    }
    public double IncreaseAttDmg
    {
      get => IncreaseMul(increaseAttDmg);
      set => increaseAttDmg = value;
    }
    // public int IncreaseDefPer
    // {
    //   get => IncreaseMul(increaseDefPer);
    //   set => increaseDefPer = value;
    // }
    public double IncreaseMaxHp
    {
      get => IncreaseMul(increaseMaxHp);
      set => increaseMaxHp = value;
    }
    public double IncreaseMaxEp
    {
      get => IncreaseMul(increaseMaxEp);
      set => increaseMaxEp = value;
    }
    public double Gold { get; set; }

    private EquipEffect GetEquipEffect => Inventory.Items.wearing.GetEquipEffect;
    private WeaponEffect GetWeaponEffect => Inventory.Items.wearing.GetWeaponEffect;
    private double increaseMaxExp;
    private double increaseAttDmg;
    //private int increaseDefPer;
    private double increaseMaxHp;
    private double increaseMaxEp;
    private double IncreaseMul(double i) { return i * (Level * 0.1); }
    private double ep;
    private double exp;
    private double maxEp;

    public Player() : base()
    {
      Inventory = new Inventory.Inventory(this);
      Loc = new Location(Towns.kks.Name, true);
      MaxHp = 50;
      MaxEp = 30;
      Hp = MaxHp;
      Ep = MaxEp;
      Level = 1;
      MaxExp = 20;
      Exp = 0;
      attDmg = 4;
      defPer = 0;
      IncreaseMaxExp = 2;
      IncreaseAttDmg = 2;
      IncreaseMaxHp = 10;
      IncreaseMaxEp = 5;
    }

    public Player(string name) : this()
    {
      Name = name;
    }

    public void Heal(double heal)
    {
      Hp = Hp + heal;
    }

    public override void Information()
    {
      // PrintText(this.ToString());
      PrintText($"\n{GetSep(40, $"{Name} [ Lv. {Level} ]")}");
      PrintText("\n경험치 : ");
      PrintCText(GetExpBar());
      PrintCText($"{{\n골드 : }}{{{Gold} G,{Colors.txtWarning}}}");
      PrintCText($"{{\n위치 : }}{{{Loc.Loc},{Colors.txtInfo}}}");
      PrintText($"\n{GetSep(40)}");
      PrintText("\n체력 : ");
      PrintCText(GetHpBar());
      PrintText("\n에너지 : ");
      PrintCText(GetEpBar());
      PrintCText($"{{ [ }}{{{Ep} / {MaxEp},{ColorByHp(Ep, MaxEp)}}}{{ ]}}");
      PrintCText($"{{\n공격력 : }}{{{AttDmg},{Colors.txtDanger}}}");
      PrintCText($"{{\n크리티컬 데미지 : }}{{{CritDmg} %,{Colors.txtDanger}}}");
      PrintCText($"{{\n크리티컬 확률 : }}{{{CritPer} %,{Colors.txtDanger}}}");
      PrintCText($"{{\n방어율 무시 : }}{{{IgnoreDef} %,{Colors.txtDanger}}}");
      PrintCText($"{{\n방어율 : }}{{{DefPer} %,{Colors.txtInfo}}}");
      PrintText($"\n{GetSep(40)}");

      Pause();
    }

    new public void AddBuff(IBuffSkill skill)
    {
      Buffs.Add(skill);
      if (skill.buff.Hp != 0)
        Hp += skill.buff.Hp;
      if (skill.buff.Ep != 0)
        Ep += skill.buff.Ep;
    }

    public override string ToString()
    {
      return new StringBuilder($"\n{GetSep(30, $"{Name}")}")
        .Append(CTexts.Make($"{{\nLv. : }} {{{Level}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nExp : }} {{{Exp} / {MaxExp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nGOLD : }} {{{Gold}, {Colors.txtWarning}}}"))
        .Append(($"\n{GetSep(30)}"))
        .Append(CTexts.Make($"{{\nHP : }} {{{Hp} / {MaxHp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nEP : }} {{{Ep} / {MaxEp}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nATT : }} {{{AttDmg}, {Colors.txtWarning}}}"))
        .Append(CTexts.Make($"{{\nDEF : }} {{{defPer} %, {Colors.txtWarning}}}"))
        .Append($"\n{GetSep(30)}")
        .Append($"\n위치 : {Loc.Loc}")
        .Append($"\n{GetSep(30)}")
        .ToString();
    }

    public double RequiredForLevelUp()
    {
      return MaxExp - Exp;
    }

    public CTexts GetEpBar(bool withPercentage = true)
    {
      var bar = GetPerStr(Ep, MaxEp, ColorByHp(Ep, MaxEp));
      if (withPercentage)
        return bar.Combine(CTexts.Make($"{{ [ }}{{{Ep} / {MaxEp},{ColorByHp(Ep, MaxEp)}}}{{ ]}}"));
      else
        return bar;
    }

    public CTexts GetExpBar(bool withPercentage = true)
    {
      var bar = GetPerStr(Exp, MaxExp);
      if (withPercentage)
        return bar.Combine(CTexts.Make($"{{ [ }}{{{Exp} / {MaxExp},{Colors.txtWarning}}}{{ ]}}"));
      else
        return bar;
    }
  }
}
