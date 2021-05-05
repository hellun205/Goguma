using System;
using static System.Console;

namespace Goguma.game.Console
{
  static class ConsoleFunction
  {
    static public void PrintText(CTexts printCText)
    {

      for (int i = 0; i < printCText.Texts.Count; i++)
      {
        BackgroundColor = printCText.Texts[i].BackgroundColor;
        ForegroundColor = printCText.Texts[i].ForegroundColor;

        Write(printCText.Texts[i].Text);

        ResetColor();
      }

    }

    static public void PrintText(string printstring)
    {
      BackgroundColor = ConsoleColor.Black;
      ForegroundColor = ConsoleColor.White;
      Write(printstring);
      ResetColor();
    }

    static public void Pause()
    {
      Read();
    }
  }
}
