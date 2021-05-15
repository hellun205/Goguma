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

    public SelectScene(CTexts questionText, SelectSceneItems answerItems, bool air = true)
    {
      PrintQuestionText(questionText, air);

      for (int i = 1; i <= answerItems.Items.Count; i++)
      {
        var enabledColor = answerItems.Items[i - 1].Enabled ? Colors.txtDefault : Colors.txtMuted;
        PrintText(CTexts.Make($"{{{i}. , {enabledColor}}}"));
        PrintText(answerItems.Items[i - 1].Texts);
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
    static public void PrintQuestionText(CTexts questionText, bool air)
    {
      if (air)
        PrintText("\n");
      PrintText("\nQ. ");
      PrintText(questionText);
      PrintText("\n\n");
    }

    static public void PrintReadText()
    {
      PrintText(CTexts.Make($"{{\n>> , {Colors.txtInfo}}}"));
    }
  }
}
