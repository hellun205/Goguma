using System;
using static Goguma.Game.Console.StringFunction;
using static System.Console;
using Colorify;
using System.Linq;

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
      if (air)
        PrintText("\n");
      PrintText("\nQ. ");
      PrintText(questionText);
      PrintText("\n\n");
    }

    static private void PrintReadText()
    {
      PrintText(CTexts.Make($"{{\n>> , {Colors.txtInfo}}}"));
    }

    static public int SelectScene(CTexts questionText, SelectSceneItems answerItems, bool air = true)
    {
      while (true)
      {

        PrintQuestionText(questionText, air);

        for (int i = 1; i <= answerItems.Items.Count; i++)
        {
          var enabledColor = Colors.txtDefault;
          if (!answerItems.Items[i - 1].Enabled)
            enabledColor = Colors.txtMuted;
          PrintText(CTexts.Make($"{{{i}. , {enabledColor}}}"));
          PrintText(answerItems.Items[i - 1].Texts);
          PrintText("\n");
        }

        PrintReadText();

        string readText = ReadLine();

        PrintText("\n");

        if (IsInt(readText))
        {
          int readInt = Convert.ToInt32(readText);

          for (int i = 1; i <= answerItems.Items.Count; i++)
            if (readInt == i && answerItems.Items[readInt - 1].Enabled)
              return readInt;
        }
      }
    }

    static public string ReadTextScean(CTexts questionText, bool air = true)
    {
      while (true)
      {
        PrintQuestionText(questionText, air);
        PrintReadText();

        string readText = ReadLine();

        PrintText("\n");

        if (readText != "")
          return readText;
      }
    }

    static public bool ReadYesOrNoScean(CTexts questionText, bool air = true)
    {
      while (true)
      {
        PrintQuestionText(questionText, air);

        PrintText("1. 예\n2. 아니오");

        PrintReadText();

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
        PrintReadText();

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
