﻿using System.Runtime.CompilerServices;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item

{
  interface IItem
  {
    CTexts Name { get; set; }
    CTexts Descriptions { get; set; }
    int Count { get; set; }
    int MaxCount { get; set; }
    bool IsAir { get; set; }
    ItemType Type { get; set; }

    void UseItem(IPlayer player);
    void DescriptionItem();

    void DescriptionItemAP(IPlayer player);
  }
}
