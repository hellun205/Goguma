using System;
using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Npc
{
  public abstract class Npc
  {
    public string Name { get; protected set; }
    public DNpcSay Meet { get; set; }
    public DNpcSay Conversation { get; set; }
    public List<QuestList> Quests { get; set; }
    public string TypeString => Npcs.GetNpcTypeToString(Type);
    public abstract NpcType Type { get; }

    public void OnDialogOpen()
    {
      var ssi = new SelectSceneItems();
      ssi.Add("{대화 하기}");
      ssi.Add("{}");
      var ss = new SelectScene(Meet.Text[String.Empty], ssi, true);
    }

    public Npc()
    {
      Quests = new List<QuestList>();
    }

    public abstract void OnUse();
  }
}
