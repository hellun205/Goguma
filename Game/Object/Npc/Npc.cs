using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;
using System.Linq;

namespace Goguma.Game.Object.Npc
{
  public abstract class Npc : INpc
  {
    public string Name { get; protected set; }
    public string NameColor { get; protected set; }
    public Prefix Prefix { get; protected set; }
    public DNpcSay Meet { get; set; }
    public DNpcSay Conversation { get; set; }
    public List<QuestList> Quests { get; set; }
    public string TypeString => Npcs.GetNpcTypeToString(Type);
    public abstract NpcType Type { get; }
    public CTexts DisplayName => new CTexts().Append(Prefix.Display).Append($"{{{Name},{NameColor}}}");

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
          if (Questss.GetQuestInstance(quest).MeetTheRequirements)
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
      Prefix = new Prefix("NPC", Colors.txtSuccess);
      NameColor = Colors.txtInfo;
    }

    public void CompleteQuest()
    {
      // TO DO
    }

    public void ReceiveQuest()
    {
      var ssi = new SelectSceneItems();
      var quests = (from qst in Quests
                    where Questss.GetQuestInstance(qst).MeetTheRequirements
                    select qst).ToList();
      foreach (var quest in quests)
      {
        ssi.Add($"{{[ Lv. {Questss.GetQuestInstance(quest).QRequirements.MinLv} ] ,{Colors.txtWarning}}}{{{Questss.GetQuestInstance(quest).Name}}}");
      }

      var ss = new SelectScene(Meet.Text[String.Empty], ssi, true);
    }
  }
}
