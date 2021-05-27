using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Npc;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  class DNpcSay : Dialog
  {
    public string PlayerSay { get; set; }
    public override DialogType Type => DialogType.NPC_SAY;

    public DNpcSay(NpcList npc, DialogText text, string playerText = "다음") : base(npc, text)
    {
      PlayerSay = playerText;
    }
    public override string Show(string playerAns = "")
    {
      PrintCText(SelectScene.PrintQuestionText(NpcText(playerAns)));
      PrintCText(SelectScene.PrintReadText().Combine($"{{{PlayerSay}}}"));

      PrintCText($"{{\nESC. 대화 종료,{Colors.txtMuted}}}");
      var key = System.Console.ReadKey(true);
      if (key.Key == ConsoleKey.Escape) isCancelled = true;
      PrintText("\n");
      return PlayerSay;
    }
  }
}