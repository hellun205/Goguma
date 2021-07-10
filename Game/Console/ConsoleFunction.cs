using System;
using static Goguma.Game.Console.StringFunction;
using static System.Console;
using Colorify;

namespace Goguma.Game.Console
{
  static class ConsoleFunction
  {
    public static Format colorify { get; set; }

    static public void PrintCText(CTexts printCText)
    {
      for (var i = 0; i < printCText.Texts.Count; i++)
      {
        try
        {
          colorify.Write(printCText.Texts[i].Text, printCText.Texts[i].Color);
        }
        catch
        {
          colorify.Write(printCText.Texts[i].Text, Colors.txtDefault);
        }
      }
    }
    static public void PrintText(string printString)
    {
      colorify.Write(printString);
    }
    static public void PrintCText(string printString)
    {
      PrintCText(CTexts.Make(printString));
    }

    static public void Pause(bool isPauseText = false)
    {
      if (isPauseText)
        PrintCText($"{{\n계속하려면 아무 키나 누르시오., {Colors.txtMuted} }}");

      ReadKey(true);
      PrintText("\n");
    }

    static private void PrintQuestionText(CTexts questionText)
    {
      PrintCText(SelectScene.PrintQuestionText(questionText));
    }

    static public string ReadText(CTexts questionText, Func<string, bool> check = null)
    {
      PrintQuestionText(questionText);
      PrintText("\n\n");
      PrintCText("{'취소'를 입력하시면 입력을 취소합니다.\n}");
      while (true)
      {
        PrintCText(SelectScene.PrintReadText());

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

    static public string ReadText(string questionText, Func<string, bool> check = null)
    {
      return ReadText(CTexts.Make(questionText), check);
    }

    static public bool ReadYesOrNo(CTexts questionText, string yesText = "예", string noText = "아니오")
    {
      PrintQuestionText(questionText);
      PrintText("\n\n");

      while (true)
      {
        PrintCText($"{{1. }}{{{yesText},{Colors.txtSuccess}}}{{\n2. }}{{{noText},{Colors.txtDanger}}}");
        PrintCText(SelectScene.PrintReadText());
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
    static public bool ReadYesOrNo(string questionText)
    {
      return ReadYesOrNo(CTexts.Make(questionText));
    }
    static public int ReadInt(CTexts questionText, int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
    {
      PrintQuestionText(questionText);
      while (true)
      {
        PrintCText(SelectScene.PrintReadText());
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

    static public int ReadInt(string questionText, int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
    {
      return ReadInt(CTexts.Make(questionText), minValue, maxValue);
    }

    static public bool ReadInt(CTexts questionText, out int oInt, int condInt = 0, int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
    {
      oInt = ReadInt(questionText.Combine($"{{\n  {condInt}(을)를 입력하면 취소합니다.}}"), Math.Min(condInt, minValue), maxValue);
      return (oInt == condInt);
    }

    static public bool ReadInt(string questionText, out int oInt, int condInt = 0, int minValue = Int32.MinValue, int maxValue = Int32.MaxValue)
    {
      return ReadInt(CTexts.Make(questionText), out oInt, condInt, minValue, maxValue);
    }
  }
}
