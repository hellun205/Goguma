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
    public List<CText> Texts;
    public CTexts()
    {
      Texts = new List<CText>();
    }

    public CTexts(CTexts ct) : this()
    {
      Texts = ct.Texts;
    }

    public CTexts Combine(in CTexts TextsB)
    {
      var resultCTexts = GetInstance();
      var B = TextsB.GetInstance();
      for (var i = 0; i < B.Texts.Count; i++)
        resultCTexts.Texts.Add(B.Texts[i]);

      return resultCTexts;
    }

    public CTexts Append(in CTexts TextsB)
    {
      var B = TextsB.GetInstance();
      for (var i = 0; i < B.Texts.Count; i++)
        this.Texts.Add(B.Texts[i]);
      return this;
    }

    public CTexts Combine(string TextsB)
    {
      return Combine(CTexts.Make(TextsB));
    }

    public CTexts Append(string TextsB)
    {
      return Append(CTexts.Make(TextsB));
    }
    public CTexts GetInstance()
    {
      return new CTexts(this);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      for (var i = 0; i < Texts.Count; i++)
        sb.Append(Texts[i].Text);

      return sb.ToString();
    }

    public void Add(string txt, string color = Colors.txtDefault)
    {
      Texts.Add(new CText(txt, color));
    }

    public void Add(CText cT)
    {
      Texts.Add(cT);
    }

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
          result.Texts.Add(new CText(splitText, splitColor));
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.StackTrace);
          Environment.Exit(-1);
        }
      }
      return result;
    }
  }
}
