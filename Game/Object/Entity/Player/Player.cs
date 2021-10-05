using System;
using Colorify;
using Goguma.Game.Object.Map;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using Goguma.Game.Object.Map.Town;
using Goguma.Game.Object.Inventory.Item.Equipment;
using Goguma.Game.Object.Quest;
using System.Collections.Generic;
using Goguma.Game.Object.Entity.Monster;
using System.Linq;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Entity.Npc;
using Goguma.Game.Object.Skill.Buff;
using Goguma.Game.Object.Skill.Attack;

namespace Goguma.Game.Object.Entity.Player
{
  [Serializable]
  public class Player : Entity
  {
    public override EntityType Type => EntityType.PLAYER;

    public Inventory.Inventory Inventory { get; set; }

    public QuestSys Quest { get; set; }

    public List<QuestList> CompletedQuests { get; set; }

    public Location Loc { get; set; }

    public Gender Gender { get; set; }

    public List<Entitys> KilledMobs { get; set; }

    public List<PartyNpc> PartyNpcs { get; set; }

    public int PartyCount => PartyNpcs.Count;

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

    public override double MaxHp
    {
      get => Math.Round(maxHp + GetEquipEffect.MaxHp + BuffsIncrease.MaxHp, 2);
      set => maxHp = Math.Max(0, value);
    }

    public override double PhysicalDefense
    {
      get => Math.Round(physicalDefense + GetEquipEffect.DefPer + BuffsIncrease.PhysicalDefense, 2);
      set => physicalDefense = Math.Max(0, value);
    }

    public override double PhysicalDamage
    {
      get => Math.Round(physicalDamage + GetWeaponEffect.PhysicalDamage + BuffsIncrease.PhysicalDamage, 2);
      set => physicalDamage = Math.Max(0, value);
    }

    public override double PhysicalPenetration
    {
      get => Math.Round(magicPenetration + GetWeaponEffect.MagicPenetration + BuffsIncrease.MagicPenetration, 2);
      set => magicPenetration = Math.Max(0, value);
    }

    public override double MagicDefense
    {
      get => Math.Round(physicalDefense + GetEquipEffect.DefPer + BuffsIncrease.PhysicalDefense, 2);
      set => physicalDefense = Math.Max(0, value);
    }

    public override double MagicDamage
    {
      get => Math.Round(physicalDamage + GetWeaponEffect.PhysicalDamage + BuffsIncrease.PhysicalDamage, 2);
      set => physicalDamage = Math.Max(0, value);
    }

    public override double MagicPenetration
    {
      get => Math.Round(physicalPenetration + GetWeaponEffect.PhysicalPenetration + BuffsIncrease.PhysicalPenetration, 2);
      set => physicalPenetration = Math.Max(0, value);
    }

    public override double CriticalDamage
    {
      get => Math.Round(criticalDamage + GetWeaponEffect.CritDmg + BuffsIncrease.CriticalDamage, 2);
      set => criticalDamage = Math.Max(0, value);
    }

    public override double CriticalPercent
    {
      get => Math.Round(criticalPercent + GetWeaponEffect.CritPer + BuffsIncrease.CriticalPercent, 2);
      set => criticalPercent = Math.Max(0, value);
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
          PhysicalDamage += IncreaseAttDmg;
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
      Quest = new();
      CompletedQuests = new();
      KilledMobs = new();
      MaxHp = 50;
      MaxEp = 30;
      Hp = MaxHp;
      Ep = MaxEp;
      Level = 1;
      MaxExp = 20;
      Exp = 0;
      physicalDamage = 4;
      physicalDefense = 0;
      IncreaseMaxExp = 2;
      IncreaseAttDmg = 2;
      IncreaseMaxHp = 10;
      IncreaseMaxEp = 5;
      Gender = Gender.MALE;
      PartyNpcs = new();
    }

    public Player(string name) : this()
    {
      Name = name;
    }

    public void Heal(double heal)
    {
      Hp = Hp + heal;
    }

    public override void AddBuff(IBuffSkill skill)
    {
      Buffs.Add(skill);
      if (skill.Effect.Hp != 0)
        Hp += skill.Effect.Hp;
      if (skill.Effect.Ep != 0)
        Ep += skill.Effect.Ep;
    }

    protected override CTexts Info()
    {
      return new CTexts()
      .Append($"{{\n{GetSep(40, $"{Name} [ Lv. {Level} ]")}}}")
      .Append("{\n경험치 : }")
      .Append(GetExpBar())
      .Append($"{{\n골드 : }}{{{Gold} G,{Colors.txtWarning}}}")
      .Append($"{{\n위치 : }}{{{Loc.Loc},{Colors.txtInfo}}}")
      .Append($"{{\n{GetSep(40)}}}")
      .Append("{\n체력 : }")
      .Append(GetHpBar())
      .Append("{\n에너지 : }")
      .Append(GetEpBar())
      .Append($"{{\n물리 공격력 : }}{{{PhysicalDamage},{Colors.txtDanger}}}")
      .Append($"{{\n마법 공격력 : }}{{{MagicDamage},{Colors.txtInfo}}}")

      .Append($"{{\n물리 관통력 : }}{{{PhysicalPenetration},{Colors.txtDanger}}}")
      .Append($"{{\n마법 관통력 : }}{{{MagicPenetration},{Colors.txtInfo}}}")

      .Append($"{{\n물리 방어력 : }}{{{PhysicalDefense},{Colors.txtDanger}}}{{ ( {Math.Round(1 - (100 / (100 + PhysicalDefense)), 2)} % )}}")
      .Append($"{{\n마법 방어력 : }}{{{MagicDefense},{Colors.txtInfo}}}{{ ( {Math.Round(1 - (100 / (100 + MagicDefense)), 2)} % )}}")

      .Append($"{{\n치명타 데미지 : }}{{{CriticalDamage} %,{Colors.txtWarning}}}")
      .Append($"{{\n치명타 확률 : }}{{{CriticalPercent} %,{Colors.txtWarning}}}")
      .Append($"{{\n{GetSep(40)}}}");
    }

    public double RequiredForLevelUp()
    {
      return MaxExp - Exp;
    }

    public override string ToString()
    {
      return base.ToString();
    }

    public CTexts GetEpBar(bool withPercentage = true, double plus = 0)
    {
      var bar = GetPerStr(Ep + plus, MaxEp, ColorByHp(Ep + plus, MaxEp));
      if (withPercentage)
        return bar.Combine(CTexts.Make($"{{ [ }}{{{Ep + plus} / {MaxEp},{ColorByHp(Ep + plus, MaxEp)}}}{{ ]}}"));
      else
        return bar;
    }

    public CTexts GetExpBar(bool withPercentage = true, double plus = 0)
    {
      var bar = GetPerStr(Exp + plus, MaxExp);
      if (withPercentage)
        return bar.Combine(CTexts.Make($"{{ [ }}{{{Exp + plus} / {MaxExp},{Colors.txtWarning}}}{{ ]}}"));
      else
        return bar;
    }

    public void KillMob(MonsterList monster)
    {
      int containsIndex = 0;
      var contains = false;
      for (var i = 0; i < KilledMobs.Count; i++)
      {
        if (KilledMobs[i].Mob == monster)
        {
          containsIndex = i;
          contains = true;
          break;
        }
      }

      if (contains)
      {
        KilledMobs[containsIndex].Kill();
      }
      else
      {
        KilledMobs.Add(new(monster, 0));
        KilledMobs[^1].Kill();
      }

      var killEntityQuests = (from qst in Quest.Quests
                              where (qst.Type == QuestType.KILL_ENTITY)
                              select qst).Cast<QKillEntity>().ToList();

      foreach (var qst in killEntityQuests)
      {
        qst.OnKillEntity(monster);
      }
    }

    public void ReceiveGold(int value)
    {
      PrintCText($"{{\n\n  }}{{{value} G,{Colors.txtWarning}}}{{를 획득했습니다. }}{{( 현재 {Gold + value} G를 보유하고 있습니다. ),{Colors.txtPrimary}}}");
      Pause(false);
      Gold += value;
    }

    public void ReceiveExp(double value)
    {
      PrintCText(CTexts.Make($"{{\n\n  }}{{{value} Exp,{Colors.txtSuccess}}}{{를 획득했습니다. ( }}").Combine(GetExpBar(true, value)).Combine("{ )}"));
      Pause(false);
      Exp += value;
    }

    public void ReceiveItem(ItemPair value)
    {
      PrintCText(CTexts.Make($"{{\n\n  아이템 }}").Combine(value.ItemM.DisplayName).Combine($"{{ {(value.Count == 1 ? "(을)를" : $"{value.Count}개를")} 획득했습니다. }}"));
      Pause(false);
      Inventory.GetItem(value);
    }

    public void ReceiveItems(ItemPair[] values)
    {
      foreach (var value in values)
      {
        Inventory.GetItem(value);
        PrintCText(CTexts.Make($"{{\n\n  아이템 }}").Combine(value.ItemM.DisplayName).Combine($"{{ {(value.Count == 1 ? "(을)를" : $"{value.Count}개를")} 획득했습니다. \n}}"));
      }
      Pause(false);
    }

    public bool CompleteQuest(QuestList quest)
    {
      var cond = CompletedQuests.Contains(quest);
      if (cond)
      {
        PrintCText($"{{  {Questss.GetQuestInstance(quest).Name},{Colors.txtInfo}}}{{(은)는 이미 완료한 퀘스트입니다.\n}}");
        Pause();
      }
      else
      {
        CompletedQuests.Add(quest);
        PrintCText($"{{  {Questss.GetQuestInstance(quest).Name},{Colors.txtInfo}}}{{(을)를 완료하셨습니다.\n}}");
        Pause();
      }
      Quest.Remove(quest);
      return !cond;
    }

    public void MeetNpc(NpcList npc)
    {
      var quests = (from quest in Quest.Quests
                    where quest.Type == QuestType.MEET_NPC
                    select quest).Cast<QMeetNpc>().ToList();
      foreach (var qst in quests)
      {
        qst.OnMeetNpc(npc);
      }
    }


  }
}
