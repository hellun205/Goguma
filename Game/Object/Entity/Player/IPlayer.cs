using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Object.Map;

namespace Goguma.Game.Object.Entity.Player
{
  interface IPlayer
  {
    string Name { get; set; }

    Inventory.Inventory Inventory { get; set; }
    MapList Map { get; set; }
    int Hp { get; set; }
    int Ep { get; set; }

    int MaxHp { get; set; }
    int MaxEp { get; set; }

    int Level { get; }
    int Exp { get; set; }
    int MaxExp { get; set; }
    int IncreaseMaxExp { get; set; }
    int Gold { get; set; }

    int AttDmg { get; }
    int PAttDmg { get; set; }
    int ItemDmg { get; set; }

    int DefPer { get; set; }

    object Skill { get; set; }

    void AttackMonster(IMonster moster);

    void UseSkill();
    void PrintAbout();
  }
}
