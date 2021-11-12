using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DPlayerSay : Dialog
  {
    public string PlayerSay { get; set; }
    public override DialogType Type => DialogType.PLAYER_SAY;

    public DPlayerSay(CTexts text, string playerText = "다음") : base(InGame.player.DisplayName, text)
    {
      PlayerSay = playerText;
    }
    public DPlayerSay(string text, string playerText = "다음") : this(CTexts.Make(text), playerText) { }
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