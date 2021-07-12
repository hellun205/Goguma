using Goguma.Game.Object.Inventory.Item;
using System;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;
using System.Linq;
using System.Collections.Generic;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  public class Inventory
  {
    public InvenItems Items { get; set; }
    public Player Player { get; set; }

    public Inventory(Player player)
    {
      Items = new InvenItems();
      Player = player;
    }

    public bool Open()
    {
      while (true)
      {
        InvenType invenType;
        var select = Select(out invenType);
        if (select == null) break;

        SelectScene ss = null;
        ItemOption io = null;
        switch (invenType)
        {
          case InvenType.Having:
            while (true)
            {
              ss = InvenInfo.Scene.ItemOption(this, select);
              if (ss.isCancelled) break;

              io = new ItemOption(this, select, ss.getString);
              if (io.Act()) return true;
            }
            break;
          case InvenType.Wearing:
            while (true)
            {
              var wType = ((EquipmentItem)select.ItemM).EType;
              ss = InvenInfo.Scene.ItemOption(this, wType);
              if (ss.isCancelled) break;

              io = new ItemOption(this, wType, ss.getString);
              if (io.Act()) return true;
            }
            break;
        }
      }
      return false;
    }

#nullable enable
    public ItemPair? Select(out InvenType invenType)
    {
      invenType = InvenType.Wearing;
      var resultIP = new ItemPair();
      while (true)
      {
        var invenTypeSS = InvenInfo.Scene.SelInvenType(); // Select InvenType
        if (invenTypeSS.isCancelled) return null;

        invenType = (InvenType)invenTypeSS.getIndex;
        switch (invenType)
        {
          case InvenType.Wearing:
            while (true)
            {
              var wearingTypeSS = InvenInfo.Scene.WearingInven(this); // Select Wearing Item (Type)
              if (wearingTypeSS.isCancelled) break;
              resultIP = (ItemPair)Items.wearing[wearingTypeSS.getIndex];
              return resultIP;
            }
            break;
          case InvenType.Having:
            while (true)
            {
              var havingTypeSS = InvenInfo.Scene.SelHavingInven(); // Select Having Type
              if (havingTypeSS.isCancelled) break;
              while (true)
              {
                var havingIndexSS = InvenInfo.Scene.HavingInven(this, (HavingType)havingTypeSS.getIndex); // Select Having Item
                if (havingIndexSS.isCancelled) break;
                resultIP = Items.having[(HavingType)(havingTypeSS.getIndex), true][havingIndexSS.getIndex];
                return resultIP;
              }
            }
            break;
          default:
            return null;
        }
      }
    }
    public void RemoveItem(WearingType wType) // Wearing Item Remove
    {
      Items.wearing.Items[(int)wType] = null;
    }

    public bool RemoveItem(ItemPair item) // Having Item Remove
    {
      List<ItemPair> list;
      var check = CheckItem(item, out list);

      if (item.Count == list[0].Count)
        Items.having.Items.Remove(list[0]);
      else
        Items.having.Items[Items.having.Items.IndexOf(list[0])].Count -= item.Count;

      return check;
    }

    public void SetItem(WearingType wType, ItemPair item) // Wearing Item Set
    {
      var inven = Items.wearing.Items;
      inven[(int)wType] = item;
    }

    public void GetItem(ItemPair item) // Having Item Get
    {
      foreach (var it in Items.having.Items)
      {
        if (it.Item == item.Item)
        {
          it.Count += item.Count;
          return;
        }
      }
      Items.having.Items.Add(item);
    }

    public bool CheckItem(ItemPair item, out List<ItemPair> list)
    {
      var checkedItems = (from ite in Items.having.Items
                          where (ite.Item == item.Item) && (ite.Count >= item.Count)
                          select ite).ToList();
      list = checkedItems;
      return (checkedItems.Count > 0);
    }
  }
}
