﻿using Goguma.Game.Object.Enum;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Interface

{
  interface IItem
  {
    CTexts Name { get; set; }
    CTexts Lore { get; set; }
    CTexts Description { get; set; }
    int Count { get; set; }
    bool IsAir { get; set; }
    ItemType Type { get; set; }

    void UseItem(IPlayer player);
    void DescriptionItem();
  }
}
