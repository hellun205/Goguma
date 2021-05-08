using System;
using static Goguma.Game.Console.StringFunction;
using static System.Console;
using Colorify;

namespace Goguma.Game.Console
{
  static class ConsoleFunction
  {
    public static Format colorify { get; set; }

    static public void PrintText(CTexts printCText)
    {
      for (var i = 0; i < printCText.Texts.Count; i++)
      {
        colorify.Write(printCText.Texts[i].Text, printCText.Texts[i].Color);
      }
    }
    static public void PrintText(string printstring)
    {
      colorify.Write(printstring, Colors.txtDefault);
    }

    static public void Pause(bool isPauseText = true)
    {
      if (isPauseText)
        PrintText(CTexts.Make($"{{\n계속하려면 아무 키나 누르시오., {Colors.txtMuted} }}"));

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

        PrintText(CTexts.Make($"{{\n>> , {Colors.txtInfo}}}"));

        string readText = ReadLine();

        PrintText("\n");

        if (IsInt(readText))
        {
          int readInt = Convert.ToInt32(readText);

          for (int i = 1; i <= answerItems.Items.Count; i++)
            if (readInt == i)
              return readInt;
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

        PrintText(CTexts.Make($"{{\n>> , {Colors.txtInfo}}}"));

        string readText = ReadLine();

        PrintText("\n");

        if (readText != "")
          return readText;
      }
    }

    static public int ReadIntScean(CTexts qustionText, int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
    {
      while (true)
      {
        PrintText("\n\n Q. ");
        PrintText(qustionText);
        PrintText("\n\n");

        PrintText(CTexts.Make($"{{\n>> , {Colors.txtInfo}}}"));

        string readText = ReadLine();

        PrintText("\n");

        if (IsInt(readText))
        {
          var resultInt = Convert.ToInt32(readText);
          if (resultInt >= minValue && resultInt <= maxValue)
          {
            return resultInt;
          }
        }
      }
    }
  }
}
