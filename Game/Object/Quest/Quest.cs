using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Quest.Dialog;
using static Goguma.Game.Console.StringFunction;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest
{
  [Serializable]
  public abstract class Quest : IQuest
  {
    public abstract string Name { get; }
    public abstract QuestType Type { get; }
    public abstract Npc.Npc ReceiveNpc { get; }
    public virtual Npc.Npc CompleteNpc => ReceiveNpc;
    public abstract List<IDialog> Dialogs { get; }
    public abstract List<IDialog> OnCompleteDialog { get; }
    public abstract QuestList Material { get; }
    public abstract DNpcAsk AskDialog { get; }
    public abstract DNpcSay CancelledDialog { get; }
    public abstract DNpcSay AcceptDialog { get; }
    public abstract DNpcSay DeclineDialog { get; }
    public abstract QuestRequirements QRequirements { get; }
    public bool MeetTheRequirements => (QRequirements.Check());
    public abstract bool IsCompleted { get; }
    public abstract double GivingExp { get; }
    public abstract int GivingGold { get; }
    public abstract List<ItemPair> GivingItems { get; }

    protected abstract CTexts InfoDetails();

    public CTexts Information()
    {
      var info = new CTexts()
      .Append($"{{\n{GetSep(40, $"{Name}")}}}")
      .Append($"{{\nNPC : }}{{{ReceiveNpc.TypeString} ,{Colors.txtWarning}}}{{{ReceiveNpc.Name},{Colors.txtInfo}}}")
      .Append($"{{\n필요 레벨 : {QRequirements.MinLv} ~ {(QRequirements.MaxLv == Int32.MaxValue ? "" : $"{QRequirements.MaxLv}")}}}")
      .Append($"{{\n완료 시 받는 골드 : }}{{{GivingGold} G, {Colors.txtWarning}}}")
      .Append($"{{\n완료 시 받는 경험치 : }}{{{GivingExp} , {Colors.txtWarning}}}")
      .Append($"{{\n완료 시 받는 아이템 : }}");
      foreach (var item in GivingItems)
      {
        info.Append(item.ItemM.DisplayName).Append($"{{ {item.Count}개， }}");
      }
      info.Append($"{{\n{GetSep(40, "내용")}\n}}")
      .Append(InfoDetails())
      .Append($"{{\n{GetSep(40)}\n}}")
      .Append("{위 내용을 달성 후 }").Append(CompleteNpc.DisplayName).Append("{(을)를 찾아가 퀘스트 완료\n}");

      return info;
    }

    public Quest() { }

    public bool ShowDialog()
    {
      var ask = Dialog.Dialog.ShowDialogs(Dialogs, AskDialog, CancelledDialog);
      if (ask)
        AcceptDialog.Show();
      else
        DeclineDialog.Show();

      return ask;
    }

    public void Exe(Player player)
    {
      var ask = ShowDialog();
      if (ask)
      {
        player.Quest.Add(Material);
      }
    }

    public void OnCompleted()
    {
      // InGame.player.Gold += GivingGold;
      // InGame.player.Exp += GivingExp;

      // foreach (var item in GivingItems)
      //   InGame.player.Inventory.GetItem(Itemss.GetNew(item.Item), item.Count);
      Dialog.Dialog.ShowDialogs(OnCompleteDialog);

      InGame.player.ReceiveGold(GivingGold);
      InGame.player.ReceiveExp(GivingExp);
      InGame.player.ReceiveItems(GivingItems.ToArray());

    }

    public void CheckAvailableComplete()
    {
      if (IsCompleted)
      {
        PrintCText($"{{\n퀘스트 : }}{{{Name},{Colors.txtInfo}}}{{(을)를 완료할 수 있습니다.\n}}");
        Pause();
      }
    }
  }
}