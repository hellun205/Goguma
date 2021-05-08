using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;

namespace Goguma.Game.Object.Entity.Player
{
  interface IPlayer
  {
    CTexts Name { get; set; }

    Inventory.Inventory Inventory { get; set; }

    int Hp { get; set; }
    int Ep { get; set; }

    int MaxHp { get; set; }
    int MaxEp { get; set; }

    int Level { get; }
    int Exp { get; set; }
    int Gold { get; set; }

    int AttDmg { get; }
    int ItemDmg { get; set; }

    int DefPer { get; set; }

    object Skill { get; set; }

    void AttackMonster(IMonster moster);

    void UseConsumedItem();

    void UseSkill();
  }
}
