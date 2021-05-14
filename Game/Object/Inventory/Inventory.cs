using Goguma.Game.Object.Inventory.Item;
using static Goguma.Game.Console.ConsoleFunction;
using System;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;

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

    public bool Print() // Select Inventory (Wearing, Having)
    {
      while (true)
      {
        var ss = InvenInfo.Scene.SelInvenType.Scene();

        if (ss.getString == "뒤로 가기")
          return false;
        else
          if (Print((InvenType)ss.getIndex - 1)) return true;
      }
    }
    private bool Print(InvenType invenType)
    {
      switch (invenType)
      {
        case InvenType.Wearing: // Select WearingItems
          while (true)
          {
            var ss = InvenInfo.Scene.WearingInven.Scene(this);

            if (ss.getString == "뒤로 가기")
              return false;
            else
              return Select((WearingType)ss.getIndex - 1);
          }
        case InvenType.Having: // Select HavingType
          while (true)
          {
            var ss = InvenInfo.Scene.SelHavingInven.Scene();

            if (ss.getString == "뒤로 가기")
              return false;
            else
              return Print((HavingType)ss.getIndex - 1);
          }
        default:
          return false;
      }
    }

    private bool Print(HavingType hType) // Select HavingItems
    {
      while (true)
      {
        var ss = InvenInfo.Scene.HavingInven.Scene(this, hType);

        if (ss.getString == "뒤로 가기")
          return false;
        else
          if (Select(hType, ss.getIndex - 1)) return true;
      }
    }

    private bool Select(WearingType wType) // Selected WearingItem
    {
      var ss = InvenInfo.Scene.ItemOption.Wearing.Scene(this, wType);

      if (ss.getString == "뒤로 가기")
        return false;
      else
      {
        var io = new ItemOption(this, wType, ss.getString);
        return io.Act();
      }
    }

    private bool Select(HavingType hType, int index) // Selected HavingItem
    {
      var ss = InvenInfo.Scene.ItemOption.Having.Scene(this, hType, index);

      if (ss.getString == "뒤로 가기")
        return false;
      else
      {
        var io = new ItemOption(this, hType, index, ss.getString);
        return io.Act();
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
