using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest;
using Goguma.Game.Object.Quest.Dialog;

namespace Goguma.Game.Object.Npc
{
  public interface INpc
  {
    string Name { get; }
    string NameColor { get; }
    Prefix Prefix { get; }
    DNpcSay Meet { get; set; }
    DNpcSay Conversation { get; set; }
    List<QuestList> Quests { get; set; }
    string TypeString => Npcs.GetNpcTypeToString(Type);
    NpcType Type { get; }
    CTexts DisplayName { get; }
    void OnDialogOpen();
    void CompleteQuest();
    void ReceiveQuest();
  }
}