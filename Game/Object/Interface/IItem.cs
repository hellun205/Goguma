using Goguma.Game.Object;
using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;
using Goguma.Game.Object.Inventory;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Interface

{
  interface IItem
  {
    CTexts Name { get; set; }
    CTexts Lore { get; set; }
    int Count { get; set; }

    bool IsAir { get; set; }

    ItemType Type { get; set; }

  }
}
