using System;
using Colorify;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DInformation : Dialog
  {
    public string PlayerSay { get; set; }
    public override DialogType Type => DialogType.INFORMATION;

    public DInformation(CTexts text, string playerText = "다음") : base(text)
    {
      PlayerSay = playerText;
    }
    
    public DInformation(string text, string playerText = "다음") : this(CTexts.Make(text), playerText) { }
    
    public DInformation(CTexts prefix, CTexts text, string playerText = "다음") : base(prefix, text)
    {
      PlayerSay = playerText;
    }
    
    public DInformation(CTexts prefix, string text, string playerText = "다음") : this(prefix, CTexts.Make(text), playerText) { }
    public DInformation(string prefix, CTexts text, string playerText = "다음") : this(CTexts.Make(prefix), text, playerText) { }
    
    
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