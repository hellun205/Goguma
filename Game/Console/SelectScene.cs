using System;
using Colorify;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;
using static System.Console;
namespace Goguma.Game.Console
{
  class SelectScene
  {
    public int GetIndex;
    public string GetString;

    public SelectScene(CTexts questionText, SelectSceneItems answerItems, bool air = true)
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
            {
              GetIndex = readInt;
              GetString = answerItems.Items[readInt - 1].Texts.ToString();
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