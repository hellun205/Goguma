using Goguma.Game.Object;
using Goguma.Game.Object.Enum;
using Goguma.Game.Object.Interface;
using Goguma.Game.Object.Inventory;

namespace Goguma.Game.Object.Interface

{
  interface IItem
  {
    string Name { get; set; }
    string Lore { get; set; }
    int Count { get; set; }

    bool IsAir { get; set; }

    ItemType Type { get; set; }

  }
}
