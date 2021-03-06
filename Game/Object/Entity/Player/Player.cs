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
    public override EntityType Type => EntityType.Player;

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
      get => Math.Round(_ep, 2);
      set => _ep = Math.Min(value, MaxEp);
    }

    public double MaxEp
    {
      get => Math.Round(_maxEp + GetEquipEffect.MaxEp + BuffsIncrease.MaxEp, 2);
      set => _maxEp = Math.Max(0, value);
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
      get => _exp;
      set
      {
        if (MaxExp > value)
          _exp = value;
        else if (MaxExp <= value)
        {
          Level += 1; // Level Up
          Hp = MaxHp;
          Ep = MaxEp;
          MaxExp *= 1.4;
          PrintCText($"{{\nLevel UP! Lv. }} {{{Level}\n, {Colors.txtInfo}}}");
          Exp = Math.Max(0, value - MaxExp);
          Pause();
        }
      }
    }


    public double MaxExp { get; set; }

    public double Gold { get; set; }

    private EquipEffect GetEquipEffect => Inventory.Items.wearing.GetEquipEffect;
    private WeaponEffect GetWeaponEffect => Inventory.Items.wearing.GetWeaponEffect;
    private double _ep;
    private double _exp;
    private double _maxEp;

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
      PhysicalDamage = 0;
      PhysicalDefense = 0;
      PhysicalPenetration = 0;
      MagicDamage = 0;
      MagicDefense = 0;
      MagicPenetration = 0;
      Gender = Gender.Male;
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
      .Append("{\n????????? : }")
      .Append(GetExpBar())
      .Append($"{{\t?????? : }}{{{Gold} G,{Colors.txtWarning}}}")
      .Append($"{{\n?????? : }}{{{Loc.Loc},{Colors.txtInfo}}}")
      .Append($"{{\n{GetSep(40)}}}")
      .Append("{\n?????? : }")
      .Append(GetHpBar())
      .Append("{\n????????? : }")
      .Append(GetEpBar())
      .Append($"{{\n?????? ????????? : }}{{{PhysicalDamage},{Colors.txtDanger}}}")
      .Append($"{{\t\t?????? ????????? : }}{{{MagicDamage},{Colors.txtInfo}}}")

      .Append($"{{\n?????? ????????? : }}{{{PhysicalPenetration},{Colors.txtDanger}}}")
      .Append($"{{\t\t?????? ????????? : }}{{{MagicPenetration},{Colors.txtInfo}}}")

      .Append($"{{\n?????? ????????? : }}{{{PhysicalDefense},{Colors.txtDanger}}}{{ ({Math.Floor(1 - (100 / (100 + PhysicalDefense)))}%)}}")
      .Append($"{{\t?????? ????????? : }}{{{MagicDefense},{Colors.txtInfo}}}{{ ({Math.Floor(1 - (100 / (100 + MagicDefense)))}%)}}")

      .Append($"{{\n????????? ????????? : }}{{{CriticalDamage} %,{Colors.txtWarning}}}")
      .Append($"{{\t????????? ?????? : }}{{{CriticalPercent} %,{Colors.txtWarning}}}")
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
                              where qst.Type == QuestType.KillEntity
                              select qst).Cast<QKillEntity>().ToList();

      foreach (var qst in killEntityQuests)
      {
        qst.OnKillEntity(monster);
      }
    }

    public void ReceiveGold(int value)
    {
      PrintCText($"{{\n\n  }}{{{value} G,{Colors.txtWarning}}}{{??? ??????????????????. }}{{( ?????? {Gold + value} G??? ???????????? ????????????. ),{Colors.txtPrimary}}}");
      Pause(false);
      Gold += value;
    }

    public void ReceiveExp(double value)
    {
      PrintCText(CTexts.Make($"{{\n\n  }}{{{value} Exp,{Colors.txtSuccess}}}{{??? ??????????????????. ( }}").Combine(GetExpBar(true, value)).Combine("{ )}"));
      Pause(false);
      Exp += value;
    }

    public void ReceiveItem(ItemPair value)
    {
      PrintCText(CTexts.Make($"{{\n\n  ????????? }}").Combine(value.ItemM.DisplayName).Combine($"{{ {(value.Count == 1 ? "(???)???" : $"{value.Count}??????")} ??????????????????. }}"));
      Pause(false);
      Inventory.GetItem(value);
    }

    public void ReceiveItems(ItemPair[] values)
    {
      foreach (var value in values)
      {
        Inventory.GetItem(value);
        PrintCText(CTexts.Make($"{{\n\n  ????????? }}").Combine(value.ItemM.DisplayName).Combine($"{{ {(value.Count == 1 ? "(???)???" : $"{value.Count}??????")} ??????????????????. \n}}"));
      }
      Pause(false);
    }

    public bool CompleteQuest(QuestList quest)
    {
      var cond = CompletedQuests.Contains(quest);
      if (cond)
      {
        PrintCText($"{{  {Questss.GetQuestInstance(quest).Name},{Colors.txtInfo}}}{{(???)??? ?????? ????????? ??????????????????.\n}}");
        Pause();
      }
      else
      {
        CompletedQuests.Add(quest);
        PrintCText($"{{  {Questss.GetQuestInstance(quest).Name},{Colors.txtInfo}}}{{(???)??? ?????????????????????.\n}}");
        Pause();
      }
      Quest.Remove(quest);
      return !cond;
    }

    public void MeetNpc(NpcList npc)
    {
      var quests = (from quest in Quest.Quests
                    where quest.Type == QuestType.MeetNpc
                    select quest).Cast<QMeetNpc>().ToList();
      foreach (var qst in quests)
      {
        qst.OnMeetNpc(npc);
      }
    }

  }
}
