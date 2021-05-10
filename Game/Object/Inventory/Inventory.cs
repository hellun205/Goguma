using Goguma.Game.Object.Inventory.Item;
using static Goguma.Game.Console.ConsoleFunction;
using System;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  class Inventory
  {
    public InvenItems Items { get; set; }
    public IPlayer Player { get; set; }

    public Inventory(IPlayer player)
    {
      Items = new InvenItems();
      Player = player;
    }

    public void Print() // Select Inventory (Wearing, Having)
    {
      var repeat = true;
      while (repeat)
      {
        var qt = InvenInfo.Scene.SelInvenType.GetQText();
        var ssi = InvenInfo.Scene.SelInvenType.GetSSI();
        var ss = new SelectScene(qt, ssi);

        if (ss.GetString == "뒤로 가기")
          repeat = false;
        else
          Print((InvenType)ss.GetIndex - 1);
      }
    }
    public void Print(InvenType invenType)
    {
      switch (invenType)
      {
        case InvenType.Wearing: // Select WearingItems
          while (true)
          {
            var qt = InvenInfo.Scene.WearingInven.GetQText();
            var ssi = InvenInfo.Scene.WearingInven.GetSSI(this);
            var ss = new SelectScene(qt, ssi);

            if (ss.GetString == "뒤로 가기")
              return;
            else
              Select((WearingType)ss.GetIndex - 1);
          }
        case InvenType.Having: // Select HavingType
          while (true)
          {
            var qt = InvenInfo.Scene.SelHavingInven.GetQText();
            var ssi = InvenInfo.Scene.SelHavingInven.GetSSI();
            var ss = new SelectScene(qt, ssi);

            if (ss.GetString == "뒤로 가기")
              return;
            else
              Print((HavingType)ss.GetIndex - 1);
          }
      }
    }

    public void Print(HavingType hType) // Select HavingItems
    {
      var repeat = true;
      while (repeat)
      {
        var qt = InvenInfo.Scene.HavingInven.GetQText(hType);
        var ssi = InvenInfo.Scene.HavingInven.GetSSI(this, hType);
        var ss = new SelectScene(qt, ssi);

        if (ss.GetString == "뒤로 가기")
          repeat = false;
        else
          Select(hType, ss.GetIndex - 1);
      }
    }

    public void Select(WearingType wType) // Selected WearingItem
    {
      var qt = InvenInfo.Scene.ItemOption.Wearing.GetQText(this, wType);
      var ssi = InvenInfo.Scene.ItemOption.Wearing.GetSSI(wType);
      var ss = new SelectScene(qt, ssi);

      if (ss.GetString == "뒤로 가기")
        return;
      else
      {
        var io = new ItemOption(this, wType, ss.GetString);
        io.Act();
      }

    }

    public void Select(HavingType hType, int index) // Selected HavingItem
    {
      var qt = InvenInfo.Scene.ItemOption.Having.GetQText(this, hType, index);
      var ssi = InvenInfo.Scene.ItemOption.Having.GetSSI(hType, index);
      var ss = new SelectScene(qt, ssi);

      if (ss.GetString == "뒤로 가기")
        return;
      else
      {
        var io = new ItemOption(this, hType, index, ss.GetString);
        io.Act();
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
    public void GetItem(HavingType hType, IItem item) // Having Item Get
    {
      var inven = Items.having.GetItems(hType);
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
