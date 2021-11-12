using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Npc;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DNpcSay : Dialog
  {
    public string PlayerSay { get; set; }
    public override DialogType Type => DialogType.NPC_SAY;

    public DNpcSay(Npc.Npc npc, CTexts text, string playerText = "다음") : base(npc, text)
    {
      PlayerSay = playerText;
    }
    
    public DNpcSay(Npc.Npc npc, string text, string playerText = "다음") : this(npc, CTexts.Make(text), playerText) { }
    public DNpcSay(NpcList npc, CTexts text, string playerText = "다음") : this(Npcs.Get(npc),text) { }
    public DNpcSay(NpcList npc, string text, string playerText = "다음") : this(Npcs.Get(npc), CTexts.Make(text)) { }
    
    public override string Show(string playerAns = "")
    {
      PrintCText(SelectScene.PrintQuestionText(Text.DisplayText(playerAns)));
      PrintText("\n");
      PrintCText(SelectScene.PrintReadText().Combine($"{{{PlayerSay}}}"));

      PrintCText($"{{\nESC. 대화 종료,{Colors.txtMuted}}}");
      var key = System.Console.ReadKey(true);
      if (key.Key == ConsoleKey.Escape) IsCancelled = true;
      PrintText("\n");
      return PlayerSay;
    }
  }
}