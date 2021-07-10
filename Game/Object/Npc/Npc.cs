using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;
using System.Linq;

namespace Goguma.Game.Object.Npc
{
  public abstract class Npc
  {
    public abstract string Name { get; }
    public virtual string NameColor => Colors.txtDefault;
    public abstract NpcList Type { get; }
    public Prefix Prefix { get; protected set; }
    public abstract DNpcSay MeetDialog { get; }
    public abstract DNpcSay ConversationDialog { get; }
    public abstract List<QuestList> Quests { get; }
    public string TypeString => Npcs.GetNpcTypeToString(NpcType);
    public abstract NpcType NpcType { get; }
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
        var ss = new SelectScene(MeetDialog.Text[String.Empty], ssi, true, CTexts.Make($"{{대화 종료,{Colors.txtMuted}}}"));
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
            ConversationDialog.Show();
            break;
        }
      }
    }

    public Npc()
    {
      Prefix = new Prefix("NPC", Colors.txtSuccess).Add(TypeString, Colors.txtWarning);
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

      var ss = new SelectScene(MeetDialog.Text.DisplayText(String.Empty), ssi, true);

      // TO DO
    }
  }
}
