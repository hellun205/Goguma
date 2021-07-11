using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Quest.Exceptions;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest
{
  [Serializable]
  public abstract class QBringItem : Quest
  {
    public abstract List<ItemPair> ItemsToBring { get; }
    public List<ItemPair> ItemsReceived { get; set; }

    public override QuestType Type => QuestType.BRING_ITEM;

    protected QBringItem() : base()
    {
      ItemsReceived = new();
    }

    public void OnBringItem(ItemPair[] items)
    {
      var player = InGame.player;
      foreach (var item in items)
      {
        if (player.Inventory.CheckItem(item))
        {
          player.Inventory.RemoveItem();
        }
        
      }
      CheckAvailableComplete();
    }

    public override bool IsCompleted
    {
      get
      {
        // TO DO
        return false;
      }
    }

    protected override CTexts InfoDetails()
    {
      // var resCT = new CTexts();
      // foreach (var entity in Entitys)
      // {
      //   var ent = Monster.GetInstance(entity.Mob);
      //   resCT.Append($"{{{ent.Name},{Colors.txtInfo}}}{{ {entity.Count} 마리 처치 - ( {entity.KilledCount} / {entity.Count} )\n,{(entity.KilledCount >= entity.Count ? Colors.txtSuccess : Colors.txtDefault)}}}");
      // }
      //
      // return resCT; TO DO
    }
  }
}