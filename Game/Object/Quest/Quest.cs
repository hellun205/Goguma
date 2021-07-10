using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Npc;
using Goguma.Game.Object.Quest.Dialog;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Quest
{
  abstract class Quest : IQuest
  {
    public abstract string Name { get; }
    public abstract Npc.Npc Npc { get; }
    public abstract List<IDialog> Dialogs { get; }
    public abstract QuestList QuestEnum { get; }
    public abstract DNpcAsk AskDialog { get; }
    public abstract DNpcSay CancelledDialog { get; }
    public abstract DNpcSay AcceptDialog { get; }
    public abstract DNpcSay DeclineDialog { get; }
    public abstract QuestRequirements QRequirements { get; }
    public bool MeetTheRequirements => (QRequirements.Check());
    public abstract bool IsCompleted { get; }
    public abstract double GivingExp { get; }
    public abstract double GivingGold { get; }
    public abstract List<GivingItem> GivingItems { get; }

    protected abstract CTexts InfoDetails();

    public CTexts Information()
    {
      var info = new CTexts()
      .Append($"{{\n{GetSep(40, $"{Name}")}}}")
      .Append($"{{\nNPC : }}{{{Npc.TypeString} ,{Colors.txtWarning}}}{{{Npc.Name},{Colors.txtInfo}}}")
      .Append($"{{\n필요 레벨 : {QRequirements.MinLv} ~ {(QRequirements.MaxLv == Int32.MaxValue ? "" : $"{QRequirements.MaxLv}")}}}")
      .Append($"{{\n완료 시 받는 골드 : }}{{{GivingGold} G, {Colors.txtWarning}}}")
      .Append($"{{\n완료 시 받는 경험치 : }}{{{GivingExp} , {Colors.txtWarning}}}")
      .Append($"{{\n완료 시 받는 아이템 : }}");
      // foreach (var item in GivingItems)
      // {
      //   info.Append("{\n    }")
      //   .Append(item.Item)
      //   .Append($"{{ {GivingItemCounts[GivingItems.IndexOf(item)]} 개}}");
      // } TO DO
      info.Append($"{{\n{GetSep(40, "내용")}\n}}")
      .Append(InfoDetails())
      .Append($"{{\n{GetSep(40)}\n}}");

      return info;
    }

    public Quest()
    {
    }

    public bool ShowDialog()
    {
      var ask = Dialog.Dialog.ShowDialogs(Dialogs, AskDialog, CancelledDialog);
      if (ask)
        AcceptDialog.Show();
      else
        DeclineDialog.Show();

      return ask;
    }

    public void Exe(IPlayer player)
    {
      var ask = ShowDialog();
      if (ask)
      {
        player.Quest.Add(this);
      }
    }

    public void OnCompleted()
    {
      InGame.player.Gold += GivingGold;
      InGame.player.Exp += GivingExp;
      // foreach (var item in GivingItems)
      //   InGame.player.Inventory.GetItem(item.GetInstance(), GivingItemCounts[GivingItems.IndexOf(item)]); TO DO

    }
  }
}