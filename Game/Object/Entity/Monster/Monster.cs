using System.Collections.Generic;
using Colorify;
using Gogu_Remaster.Game.Object.Inventory.Item;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Skill;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Entity.Monster
{
  public class Monster : IMonster
  {
    public string Name { get; set; }
    public CTexts Descriptions { get; set; }
    public double Hp { get; set; }
    public double MaxHp
    {
      get => maxHp + BuffsIncrease.MaxHp;
      set => maxHp = value;
    }
    public int Level { get; set; }
    public double AttDmg
    {
      get => attDmg + BuffsIncrease.AttDmg;
      set => attDmg = value;
    }
    public double DefPer
    {
      get => defPer + BuffsIncrease.DefPer;
      set => defPer = value;
    }
    public List<Skill.Skill> Skills { get; set; }
    public double GivingGold { get; set; }
    public double GivingExp { get; set; }
    public DroppingItems DroppingItems { get; set; }
    public AttackSyss AttSystem { get; set; }
    public List<IBuffSkill> Buffs { get; set; }

    private double maxHp;
    private double attDmg;
    private double defPer;
    private Buff BuffsIncrease
    {
      get
      {
        var resultBuff = new Buff();
        foreach (var bf in Buffs)
        {
          resultBuff.MaxHp += bf.buff.MaxHp;
          resultBuff.MaxEp += bf.buff.MaxEp;
          resultBuff.AttDmg += bf.buff.AttDmg;
          resultBuff.DefPer += bf.buff.DefPer;
        }
        return resultBuff;
      }
    }

    public Monster()
    {
      Skills = new List<Skill.Skill>();
      DroppingItems = new DroppingItems();
      AttSystem = new AttackSyss(InGame.player, this);
      Buffs = new List<IBuffSkill>();
    }
    public void PrintAbout(IPlayer player = null)
    {
      PrintText($"\n{GetSep(40, $"{Name}")}");
      if (player != null) PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}\n, {ColorByLevel(player.Level, Level)}}}"));
      else PrintText(CTexts.Make($"{{\nLv. : }} {{{Level}\n, {Colors.txtWarning}}}"));
      PrintText(Descriptions);
      PrintText($"\n{GetSep(40)}");
      PrintText(CTexts.Make($"{{\nHP : }} {{{Hp} / {MaxHp}, {ColorByHp(Hp, MaxHp)}}}"));
    }

    public Monster(Monster monster) : this()
    {
      Name = monster.Name;
      Descriptions = monster.Descriptions;
      Level = monster.Level;
      MaxHp = monster.MaxHp;
      Hp = monster.Hp;
      AttDmg = monster.AttDmg;
      DefPer = monster.DefPer;
      GivingExp = monster.GivingExp;
      GivingGold = monster.GivingGold;

      var dropItem = new List<DroppingItem>();

      foreach (var i in monster.DroppingItems.Items)
      {
        var di = new DroppingItem(i.Item.GetInstance(), i.DropChance);
        dropItem.Add(di);
      }

      DroppingItems = new DroppingItems(dropItem);
    }

    public void AttackPlayer(IPlayer player)
    {

    }

    public Monster GetInstace()
    {
      return new Monster(this);
    }
  }
}
