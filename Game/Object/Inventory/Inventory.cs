using Goguma.Game.Object.Inventory.Item;
using static Goguma.Game.Console.ConsoleFunction;
using System;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  public class Inventory
  {
    public InvenItems Items { get; set; }
    public IPlayer Player { get; set; }

    public Inventory(IPlayer player)
    {
      Items = new InvenItems();
      Player = player;
    }

    public bool Open()
    {
      while (true)
      {
        var select = Select();
        if (select == null) break;
        var itemInfo = (ItemInfo)select;
        SelectScene ss = null;
        ItemOption io = null;
        switch (itemInfo.InvenType)
        {
          case InvenType.Having:
            while (true)
            {
              ss = InvenInfo.Scene.ItemOption.Having.Scene(this, itemInfo.hType, itemInfo.havingIndex);
              if (ss.getString == "뒤로 가기") break;

              io = new ItemOption(this, itemInfo.hType, itemInfo.havingIndex, ss.getString);
              if (io.Act()) return true;
            }
            break;
          case InvenType.Wearing:
            while (true)
            {
              ss = InvenInfo.Scene.ItemOption.Wearing.Scene(this, itemInfo.wType);
              if (ss.getString == "뒤로 가기") break;

              io = new ItemOption(this, itemInfo.wType, ss.getString);
              if (io.Act()) return true;
            }
            break;
        }
      }
      return false;
    }
    public ItemInfo? Select()
    {
      var resultII = new ItemInfo();
      while (true)
      {
        var invenTypeSS = InvenInfo.Scene.SelInvenType.Scene(); // Select InvenType
        if (invenTypeSS.getString == "뒤로 가기") return null;
        resultII.InvenType = (InvenType)invenTypeSS.getIndex;
        switch ((InvenType)invenTypeSS.getIndex)
        {
          case InvenType.Wearing:
            while (true)
            {
              var wearingTypeSS = InvenInfo.Scene.WearingInven.Scene(this); // Select Wearing Item (Type)
              if (wearingTypeSS.getString == "뒤로 가기") break;
              resultII.wType = (WearingType)wearingTypeSS.getIndex;
              resultII.Item = Items.wearing.Items[wearingTypeSS.getIndex];
              return resultII;
            }
            break;
          case InvenType.Having:
            while (true)
            {
              var havingTypeSS = InvenInfo.Scene.SelHavingInven.Scene(); // Select Having Type
              if (havingTypeSS.getString == "뒤로 가기") break;
              resultII.hType = (HavingType)havingTypeSS.getIndex;
              while (true)
              {
                var havingIndexSS = InvenInfo.Scene.HavingInven.Scene(this, (HavingType)havingTypeSS.getIndex); // Select Having Item
                if (havingIndexSS.getString == "뒤로 가기") break;
                resultII.havingIndex = havingIndexSS.getIndex;
                resultII.Item = Items.having.Items[havingTypeSS.getIndex][havingIndexSS.getIndex];
                return resultII;
              }
            }
            break;
          default:
            return null;
        }
      }
    }
    public void RemoveItem(WearingType wType, int count) // Wearing Item Remove
    {
      var inven = Items.wearing.Items;
      var sItem = Items.wearing.GetItem(wType);

      if (count == sItem.Count)
        inven[(int)wType] = EquipmentItem.GetAir();
      else
        sItem.Count -= count;
    }
    public void RemoveItem(HavingType hType, int index, int count) // Having Item Remove
    {
      var inven = Items.having.GetItems(hType);
      var sItem = inven[index];

      if (count == sItem.Count)
        inven.RemoveAt(index);
      else
        sItem.Count -= count;
    }

    public void SetItem(WearingType wType, IEquipmentItem item) // Wearing Item Set
    {
      var inven = Items.wearing.Items;
      inven[(int)wType] = item;
    }
    public void SetItem(HavingType hType, int index, IEquipmentItem item) // Having Item Set
    {
      var inven = Items.having.GetItems(hType);
      inven[index] = item;
    }
    public void GetItem(IItem item) // Having Item Get
    {
      var inven = Items.having.GetItems(item.Type);
      foreach (var item1 in inven)
      {
        if (item1.Name.ToString() == item.Name.ToString() && (item1.Count + item.Count)! <= item1.MaxCount)
        {
          item1.Count += item.Count;
          return;
        }
      }
      inven.Add(item);
    }

  }
}
