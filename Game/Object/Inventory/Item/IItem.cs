﻿using System.Runtime.CompilerServices;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item

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
    void RemoveItem(int count);
    void DescriptionItem();
  }
}
