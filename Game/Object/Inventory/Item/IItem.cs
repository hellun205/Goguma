﻿using System.Runtime.CompilerServices;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item

{
  interface IItem
  {
    CTexts Name { get; set; }
    string Lore { get; set; }
    CTexts Description { get; set; }
    int Count { get; set; }
    int LoseCount { get; set; }
    ItemType Type { get; set; }

    void UseItem(IPlayer player);
    void DescriptionItem();

    void DescriptionItemAP(IPlayer player);
  }
}
