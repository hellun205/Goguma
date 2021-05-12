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

    static private void PrintQuestionText(CTexts questionText, bool air)
    {
      SelectScene.PrintQuestionText(questionText, air);
    }

    static public string ReadTextScean(CTexts questionText, Func<string, bool> check = null)
    {
      PrintQuestionText(questionText, true);
      PrintText("\n'취소'를 입력하시면 입력을 취소합니다.\n");
      while (true)
      {
        SelectScene.PrintReadText();

        string readText = ReadLine().Trim();

        PrintText("\n");
        if (readText == "취소")
          return null;
        else
        {
          if (!check(readText))
            continue;
          else
            return readText;
        }
      }
    }

    static public bool ReadYesOrNoScean(CTexts questionText)
    {
      while (true)
      {
        PrintQuestionText(questionText, true);

        PrintText("1. 예\n2. 아니오");

        SelectScene.PrintReadText();

        string readText = ReadLine();

        PrintText("\n");

        if (IsInt(readText))
        {
          int readInt = Convert.ToInt32(readText);

          if (readInt == 1)
            return true;
          else if (readInt == 2)
            return false;
        }
      }
    }
    static public int ReadIntScean(CTexts questionText, int minValue = Int32.MinValue, int maxValue = Int32.MaxValue, bool air = true)
    {
      while (true)
      {
        PrintQuestionText(questionText, air);
        SelectScene.PrintReadText();

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
