using System;
using static Goguma.game.Console.StringFunction;
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



    static public CTexts MakeCTexts(string cText)
    {
      CTexts result = new CTexts();
      string remainingString = cText;

      for (int i = 0; i <= remainingString.Split('{').Length; i++)
      {

        string splitStrings = Splits(remainingString,'{','}');
        remainingString = remainingString.Substring(remainingString.IndexOf('}') + 1);

        string splitText = "";
        string splitFGColor = "White";
        string splitBGColor = "Black";

        string[] ssSplit = splitStrings.Split(',');

        if (ssSplit.Length > 0)
          splitText = ssSplit[0];

        if (ssSplit.Length > 1)
          splitFGColor = ssSplit[1].Trim();

        if (ssSplit.Length > 2)
          splitBGColor = ssSplit[2].Trim();

        result.Texts.Add(new CText(splitText, 
          (ConsoleColor)Enum.Parse(typeof(ConsoleColor), splitFGColor), 
          (ConsoleColor)Enum.Parse(typeof(ConsoleColor), splitBGColor)));

      }

      return result;
    }

    static public int SelectScene(CTexts qustionText, SelectSceneItems answerItems)
    {
      while (true)
      {
        PrintText("\n Q. ");
        PrintText(qustionText);
        PrintText("\n");

        for (int i = 1; i <= answerItems.Items.Count; i++)
        {
          PrintText($"{i}. ");
          PrintText(answerItems.Items[i - 1].Texts);
          PrintText("\n");
        }

        string readText = ReadLine();
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


  }
}
