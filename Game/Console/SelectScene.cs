using System;
using Colorify;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using static System.Console;
namespace Goguma.Game.Console
{
  class SelectScene
  {
    public int getIndex;
    public string getString;

    public SelectScene(CTexts questionText, SelectSceneItems answerItems)
    {
      PrintQuestionText(questionText);

      for (int i = 1; i <= answerItems.Items.Count; i++)
      {
        var enabledColor = answerItems.Items[i - 1].Enabled ? Colors.txtDefault : Colors.txtMuted;
        PrintCText($"{{{i}. , {enabledColor}}}");
        PrintCText(answerItems.Items[i - 1].Texts);
        PrintText("\n");
      }

      while (true)
      {
        PrintReadText();

        string readText = ReadLine();

        PrintText("\n");

        if (IsInt(readText))
        {
          int readInt = Convert.ToInt32(readText);

          for (int i = 1; i <= answerItems.Items.Count; i++)
            if (readInt == i && answerItems.Items[readInt - 1].Enabled)
            {
              getIndex = readInt - 1;
              getString = answerItems.Items[readInt - 1].Texts.ToString();
              return;
            }
        }
      }
    }

    public SelectScene(string questionText, SelectSceneItems answerItems) : this(CTexts.Make(questionText), answerItems) { }

    static public void PrintQuestionText(CTexts questionText, CTexts plusText = null)
    {
      PrintText("\n\nQ. ");
      PrintCText(questionText);
      if (plusText != null) PrintCText(plusText);
      PrintText("\n\n");
    }

    static public void PrintReadText()
    {
      PrintCText($"{{\n>> , {Colors.txtInfo}}}");
    }
  }
}
