using System;
using System.Collections.Generic;
using Colorify;
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
    public List<IQuest> Quests { get; set; }
    public string TypeString => Npcs.GetNpcTypeToString(Type);
    public abstract NpcType Type { get; }

    public virtual void OnDialogOpen()
    {
      while (true)
      {
        var ssi = new SelectSceneItems();
        foreach (var quest in InGame.player.Quest.Quests)
          if (quest.IsCompleted)
          {
            ssi.Add("{퀘스트 완료}");
            break;
          }
        foreach (var quest in Quests)
          if (quest.MeetTheRequirements)
          {
            ssi.Add("{퀘스트 받기}");
            break;
          }
        ssi.Add("{대화 하기}");
        var ss = new SelectScene(Meet.Text[String.Empty], ssi, true, CTexts.Make($"{{대화 종료,{Colors.txtMuted}}}"));
        if (ss.isCancelled) return;

        switch (ss.getString)
        {
          case "퀘스트 완료":
            CompleteQuest();
            break;
          case "퀘스트 받기":
            ReceiveQuest();
            break;
          case "대화 하기":
            Conversation.Show();
            break;
        }
      }
    }

    public Npc()
    {
      Quests = new();
    }

    public void CompleteQuest()
    {

    }

    public void ReceiveQuest()
    {

    }
  }
}
