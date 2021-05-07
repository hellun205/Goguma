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

    public CTexts Combine(CTexts cTexts)
    {
      CTexts resultCTexts = this;
      for (int i = 0; i < cTexts.Texts.Count; i++)
      {
        resultCTexts.Texts.Add(cTexts.Texts[i]);
      }

      return resultCTexts;
    }

    public override string ToString()
    {
      string resultStr = "";
      for (int i = 0; i < Texts.Count; i++)
      {
        resultStr = resultStr + Texts[i].Text;
      }

      return resultStr;
    }

    static public CTexts Make(string cText)
    {
      TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
      CTexts result = new CTexts();
      string remainingString = cText;
      
      for (int i = 0; i <= cText.Split('{').Length; i++)
      {
        string splitStrings = Splits(remainingString, '{', '}');
        remainingString = remainingString.Substring(remainingString.IndexOf('}') + 1);

        

        string splitText = "";
        string splitFGColor = "White";
        string splitBGColor = "Black";

        string[] ssSplit = splitStrings.Split(',');

        if (ssSplit.Length > 0)
          splitText = ssSplit[0];

        

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
