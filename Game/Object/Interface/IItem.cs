using Goguma.Game.Object.Enum;
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
