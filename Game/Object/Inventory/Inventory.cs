using Goguma.Game.Object.Inventory.Item;
using System;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;
using static Goguma.Game.Console.ConsoleFunction;

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
        inven[(int)wType] = null;
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

    public void GetItem(IItem item, int count = 1) // Having Item Get
    {
      var inven = Items.having.GetItems(item.Type);
      foreach (var it in inven)
      {
        if (it.Name == item.Name)
        {
          it.Count += count;
          CountTheorem();
          return;
        }
      }
      item.Count = count;
      inven.Add(item);
      CountTheorem();
    }

    private void CountTheorem()
    {
      for (var i = 0; i < Enum.GetValues(typeof(HavingType)).Length; i++)
      {
        var inven = Items.having.GetItems((HavingType)i);
        var iCount = inven.Count;
        for (var j = 0; j < iCount; j++)
        {
          var it = inven[j];
          if (it.Count > it.MaxCount)
          {
            var count = it.Count;
            for (var k = 0; k < (int)(count / it.MaxCount) - 1; k++)
            {
              var item = it.GetInstance();
              item.Count = it.MaxCount;
              inven.Add(item);
            }
            int div;
            Math.DivRem(count, it.MaxCount, out div);
            if (div > 0)
            {
              var item = it.GetInstance();
              item.Count = div;
              inven.Add(item);
            }
            it.Count = it.MaxCount;
          }
        }
      }
    }

  }
}
