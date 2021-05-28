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
    public List<IDialog> Dialogs { get; set; }
    public DAsk AskDialog { get; set; }
    public DNpcSay CancelledDialog { get; set; }
    public DNpcSay AcceptDialog { get; set; }
    public DNpcSay DeclineDialog { get; set; }
    public string Name { get; set; }
    public NpcList Npc { get; set; }
    public RequireLevel RequireLv { get; set; }
    public bool IsCompleted { get; set; }
    public double GivingExp { get; set; }
    public double GivingGold { get; set; }
    public List<IItem> GivingItems { get; set; }
    public List<int> GivingItemCounts { get; set; }

    public abstract bool CheckCompleted();
    protected abstract CTexts InfoDetails();

    public CTexts Information()
    {
      var info = new CTexts()
      .Append($"{{\n{GetSep(40, $"{Name}")}}}")
      .Append($"{{\nNPC : }}{{{Npcs.GetTraderByEnum(Npc).TypeString} ,{Colors.txtWarning}}}{{{Npcs.GetTraderByEnum(Npc).Name},{Colors.txtInfo}}}")
      .Append($"{{\n필요 레벨 : {RequireLv.Min} ~ {(RequireLv.Max == Int32.MaxValue ? "" : $"{RequireLv.Max}")}}}")
      .Append($"{{\n완료 시 받는 골드 : }}{{{GivingGold} G, {Colors.txtWarning}}}")
      .Append($"{{\n완료 시 받는 경험치 : }}{{{GivingExp} , {Colors.txtWarning}}}")
      .Append($"{{\n완료 시 받는 아이템 : }}");
      foreach (var item in GivingItems)
      {
        info.Append("{\n    }")
        .Append(item.DisplayName)
        .Append($"{{ {GivingItemCounts[GivingItems.IndexOf(item)]} 개}}");
      }
      info.Append($"{{\n{GetSep(40, "내용")}\n}}")
      .Append(InfoDetails())
      .Append($"{{\n{GetSep(40)}\n}}");

      return info;
    }

    public Quest()
    {
      Dialogs = new List<IDialog>();
      GivingItems = new List<IItem>();
      GivingItemCounts = new List<int>();
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

    }

    public void OnCompleted()
    {
      InGame.player.Gold += GivingGold;
      InGame.player.Exp += GivingExp;
      foreach (var item in GivingItems)
        InGame.player.Inventory.GetItem(item.GetInstance(), GivingItemCounts[GivingItems.IndexOf(item)]);

    }
  }
}