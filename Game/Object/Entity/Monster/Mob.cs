using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Drop;
using System.Linq;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using Goguma.Game.Object.Entity.AttackSystem;

namespace Goguma.Game.Object.Entity.Monster
{
  public abstract class Mob : Entity, IMonster
  {
    public override EntityType Type => EntityType.MONSTER;
    public abstract MonsterList Material { get; }
    public abstract CTexts Descriptions { get; }
    public abstract double GivingGold { get; }
    public abstract double GivingExp { get; }
    public abstract DroppingItems DroppingItems { get; }
    public AttackSyss AttSystem { get; set; }

    public Mob() : base()
    {
      AttSystem = new();
    }

    protected override CTexts Info()
    {
      var resCT = new CTexts()
        .Append($"{{\n{GetSep(40, $"{Name} [ Lv. {Level} ]")}\n}}")
        .Append(Descriptions)
        .Append($"{{\n{GetSep(40)}}}")
        .Append("{\n체력 : }")
        .Append(GetHpBar())
        .Append($"{{\n공격력 : }}{{{PhysicalDamage},{Colors.txtDanger}}}")
        .Append($"{{\n크리티컬 데미지 : }}{{{CriticalDamage} %,{Colors.txtDanger}}}")
        .Append($"{{\n크리티컬 확률 : }}{{{CriticalPercent} %,{Colors.txtDanger}}}")
        .Append($"{{\n방어율 무시 : }}{{{PhysicalPenetration} %,{Colors.txtDanger}}}")
        .Append($"{{\n방어율 : }}{{{PhysicalDefense} %,{Colors.txtInfo}}}")
        .Append($"{{\n{GetSep(40)}}}")
        .Append($"{{\n드랍 아이템 : }}");

      var drItems = from drItem in DroppingItems.Items
                    where drItem.Visible == true
                    select drItem;
      foreach (var drItem in drItems.ToList<DroppingItem>())
      {
        resCT.Append(drItem.Item.ItemM.Name).Append($"{{ {(drItem.Item.Count == 1 ? "" : $"{drItem.Item.Count}개")}}}").Append("{，}");
      }

      resCT.Append("{등}");
      resCT.Append($"{{\n{GetSep(40)}}}");
      return resCT;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
