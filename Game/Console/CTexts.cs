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
      var resultCTexts = new CTexts { Texts = this.Texts };
      for (var i = 0; i < cTexts.Texts.Count; i++)
        resultCTexts.Texts.Add(cTexts.Texts[i]);

      return resultCTexts;
    }

    public override string ToString()
    {
      var resultStr = "";
      for (var i = 0; i < Texts.Count; i++)
      {
        resultStr = resultStr + Texts[i].Text;
      }

      return resultStr;
    }

    static public CTexts Make(string cText)
    {
      var textInfo = new CultureInfo("en-US", false).TextInfo;
      var result = new CTexts();
      var remainingString = cText;

      for (var i = 0; i <= cText.Split('{').Length; i++)
      {
        var splitStrings = Splits(remainingString, '{', '}');
        remainingString = remainingString.Substring(remainingString.IndexOf('}') + 1);

        var splitText = "";
        var splitFGColor = "White";
        var splitBGColor = "Black";

        var ssSplit = splitStrings.Split(',');

        if (ssSplit.Length > 0)
          splitText = ssSplit[0];
        else if (ssSplit.Length > 1)
          splitFGColor = textInfo.ToTitleCase(ssSplit[1].Trim().ToLower());
        else if (ssSplit.Length > 2)
          splitBGColor = textInfo.ToTitleCase(ssSplit[2].Trim().ToLower());

        try
        {
          result.Texts.Add(new CText(splitText,
            (ConsoleColor)Enum.Parse(typeof(ConsoleColor), splitFGColor),
            (ConsoleColor)Enum.Parse(typeof(ConsoleColor), splitBGColor)
          ));
        }
        catch
        {
          throw new NotImplementedException();
        }
      }
      return result;
    }
  }
}
