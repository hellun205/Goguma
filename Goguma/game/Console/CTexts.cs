using System;
using System.Collections.Generic;
using System.Globalization;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Console
{
  class CTexts
  {
    public List<CText> Texts { get; set; }

    public CTexts()
    {
      Texts = new List<CText>();
    }

    public void Combine(CTexts cTexts)
    {
      for (int i = 0; i < cTexts.Texts.Count; i++)
      {
        Texts.Add(cTexts.Texts[i]);
      }
    }

    static public CTexts Make(string cText)
    {
      CTexts result = new CTexts();
      string remainingString = cText;

      for (int i = 0; i <= remainingString.Split('{').Length; i++)
      {

        string splitStrings = Splits(remainingString, '{', '}');
        remainingString = remainingString.Substring(remainingString.IndexOf('}') + 1);

        string splitText = "";
        string splitFGColor = "hite";
        string splitBGColor = "Black";

        string[] ssSplit = splitStrings.Split(',');

        if (ssSplit.Length > 0)
          splitText = ssSplit[0];

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        if (ssSplit.Length > 1)
          splitFGColor = textInfo.ToTitleCase(ssSplit[1].Trim().ToLower());

        if (ssSplit.Length > 2)
          splitBGColor = textInfo.ToTitleCase(ssSplit[2].Trim().ToLower());

        try
        {
          result.Texts.Add(new CText(splitText,
                    (ConsoleColor)Enum.Parse(typeof(ConsoleColor), splitFGColor),
                    (ConsoleColor)Enum.Parse(typeof(ConsoleColor), splitBGColor)));

        }
        catch
        {
        }

      }

      return result;
    }

  }
}
