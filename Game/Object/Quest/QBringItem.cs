using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest
{
  [Serializable]
  public abstract class QBringItem : Quest
  {
    public abstract List<ItemPair> ItemsToBring { get; }

    public List<ItemPair> ItemsToBring_ { get; set; }

    public override QuestType Type => QuestType.BRING_ITEM;

    protected QBringItem() : base()
    {
      ItemsToBring_ = ItemsToBring;
    }

    public void OnBringItem()
    {
      var player = InGame.player;
      foreach (var item in ItemsToBring_)
      {
        PrintText("\n");
        if (player.Inventory.RemoveItem(item))
        {
          ItemsToBring_.Remove(item);
          PrintCText(CTexts.Make("{아이템 }").Combine(item.ItemM.DisplayName).Combine("{(을)를 주었습니다.\n}"));
        }
        Pause();
      }
      // CheckAvailableComplete();
    }

    public override bool IsCompleted
    {
      get
      {
        return (ItemsToBring_.Count == 0);
      }
    }

    protected override CTexts InfoDetails()
    {
      var resCt = new CTexts();
      foreach (var item in ItemsToBring)
      {
        var isCompleted = ItemsToBring_.Contains(item);
        resCt.Append(item.ItemM.DisplayName.Combine($"{{ {item.Count}개 가져다 주기 - }}{{( {(isCompleted ? "완료" : "진행 중")} )\n,{(isCompleted ? Colors.txtSuccess : Colors.txtDefault)}}}"));
      }

      return resCt;
    }
  }
}