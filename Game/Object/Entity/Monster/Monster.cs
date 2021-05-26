using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.AttSys;
using Goguma.Game.Object.Inventory.Item.Drop;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Entity.Monster
{
  public class Monster : Entity, IMonster
  {
    public override EntityType Type => EntityType.MONSTER;
    public CTexts Descriptions { get; set; }
    public double GivingGold { get; set; }
    public double GivingExp { get; set; }
    public DroppingItems DroppingItems { get; set; }
    public AttackSyss AttSystem { get; set; }

    public Monster() : base()
    {
      DroppingItems = new DroppingItems();
      AttSystem = new AttackSyss(InGame.player, this);
    }
    public Monster(Monster monster) : base(monster)
    {
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

    public Monster GetInstance()
    {
      return new Monster(this);
    }

    new public void Information()
    {
      PrintCText(Info());
      Pause();
    }
    new protected CTexts Info()
    {
      var resCT = new CTexts()
        .Append($"{{\n{GetSep(40, $"{Name} [ Lv. {Level} ]")}\n}}")
        .Append(Descriptions)
        .Append($"{{\n{GetSep(40)}}}")
        .Append("{\n체력 : }")
        .Append(GetHpBar())
        .Append($"{{\n공격력 : }}{{{AttDmg},{Colors.txtDanger}}}")
        .Append($"{{\n크리티컬 데미지 : }}{{{CritDmg} %,{Colors.txtDanger}}}")
        .Append($"{{\n크리티컬 확률 : }}{{{CritPer} %,{Colors.txtDanger}}}")
        .Append($"{{\n방어율 무시 : }}{{{IgnoreDef} %,{Colors.txtDanger}}}")
        .Append($"{{\n방어율 : }}{{{DefPer} %,{Colors.txtInfo}}}")
        .Append($"{{\n{GetSep(40)}}}")
        .Append($"{{\n드랍 아이템 : }}");

      var drItems = from drItem in DroppingItems.Items
                    where drItem.Visible == true
                    select drItem;
      var i = 0;
      var b = false;
      foreach (var drItem in drItems.ToList<DroppingItem>())
      {
        var mi = (b ? 1 : 2);
        PrintText((i == mi ? "\n" : ""));
        i = (i == mi ? 0 : i + 1);
        resCT.Append(drItem.Item.Name);
        resCT.Append("{，}");
      }

      resCT.RemoveAt(resCT.Count - 1);
      resCT.Append($"{{\n{GetSep(40)}}}");
      return resCT;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
