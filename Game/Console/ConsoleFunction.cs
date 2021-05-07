using System;
using static Goguma.Game.Console.StringFunction;
using static System.Console;

namespace Goguma.Game.Console
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

    static public void Pause(bool isPauseText = true)
    {
      if (isPauseText)
        PrintText(CTexts.Make("{\n계속하려면 아무 키를 누르시오., gray}"));

      ReadKey();
    }

    static public int SelectScene(CTexts qustionText, SelectSceneItems answerItems)
    {
      while (true)
      {
        PrintText("\n\n Q. ");
        PrintText(qustionText);
        PrintText("\n\n");

        for (int i = 1; i <= answerItems.Items.Count; i++)
        {
          PrintText($"{i}. ");
          PrintText(answerItems.Items[i - 1].Texts);
          PrintText("\n");
        }

        PrintText(CTexts.Make("{\n>> , cyan}"));

        string readText = ReadLine();

        PrintText("\n");

        if (IsInt(readText))
        {
          int readInt = Convert.ToInt32(readText);

          for (int i = 1; i <= answerItems.Items.Count; i++)
          {
            if (readInt == i)
            {
              return readInt;
            }
          }
        }
      }
    }

    static public string ReadTextScean(CTexts qustionText)
    {
      while (true)
      {
        PrintText("\n\n Q. ");
        PrintText(qustionText);
        PrintText("\n\n");

        PrintText(CTexts.Make("{\n>> , cyan}"));

        string readText = ReadLine();

        PrintText("\n");

        if (readText != "")
          return readText;
      }
    }
  }
}
