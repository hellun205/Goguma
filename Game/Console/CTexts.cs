using System;
using System.Collections.Generic;
using System.Text;
using Colorify;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Console
{
  [Serializable]
  public class CTexts
  {
    public List<CText> texts;
    public CTexts()
    {
      texts = new List<CText>();
    }

    public CTexts(CTexts ct) : this()
    {
      for (var i = 0; i < ct.texts.Count; i++)
        texts.Add(ct.texts[i]);
    }

    public CTexts Combine(CTexts textsB)
    {
      var resultCTexts = GetInstance();

      for (var i = 0; i < textsB.texts.Count; i++)
        resultCTexts.texts.Add(textsB.texts[i]);

      return resultCTexts;
    }

    public CTexts Append(CTexts textsB)
    {
      for (var i = 0; i < textsB.texts.Count; i++)
        this.texts.Add(textsB.texts[i]);
      return this;
    }

    public CTexts Combine(string textsB)
    {
      return Combine(CTexts.Make(textsB));
    }

    public CTexts Append(string textsB)
    {
      return Append(CTexts.Make(textsB));
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      for (var i = 0; i < texts.Count; i++)
        sb.Append(texts[i].Text);

      return sb.ToString();
    }

    public CTexts GetInstance()
    {
      return new CTexts(this);
    }

    public void Add(string txt, string color = Colors.txtDefault)
    {
      texts.Add(new CText(txt, color));
    }

    public void Add(CText cT)
    {
      texts.Add(cT);
    }

    public void RemoveAt(int index)
    {
      texts.RemoveAt(index);
    }

    public void Remove(CText item)
    {
      texts.Remove(item);
    }

    public int Count => texts.Count;

    static public CTexts Make(string cText)
    {
      // var textInfo = new CultureInfo("en-US", false).TextInfo;
      var result = new CTexts();
      var remainingString = cText;

      for (var i = 0; i <= cText.Split('{').Length; i++)
      {
        var splitStrings = Splits(remainingString, '{', '}');
        remainingString = remainingString.Substring(remainingString.IndexOf('}') + 1);

        var splitText = "";
        var splitColor = "text-default";

        var ssSplit = splitStrings.Split(',');

        if (ssSplit.Length > 0)
          splitText = ssSplit[0];
        if (ssSplit.Length > 1)
          splitColor = ssSplit[1].Trim();

        try
        {
          result.texts.Add(new CText(splitText, splitColor));
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.StackTrace);
          Environment.Exit(-1);
        }
      }
      return result;
    }

    public static CTexts Empty => new CTexts();
  }
}
