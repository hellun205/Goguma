using System;
using Colorify;

namespace Goguma.Game.Console
{
  static class StringFunction
  {
    static public bool IsInt(string text)
    {
      var result = Int32.TryParse(text, out int n);
      return result;
    }

    static public string Splits(string strings, char char1, char? char2 = null)
    {
      if (char2 == null)
        char2 = char1;

      string stringA;

      try
      {
        stringA = strings.Split(char1)[1].Split((char)char2)[0];
      }
      catch
      {
        return "";
      }
      return stringA;
    }

    static public CTexts NumberColor(int number, string minusColor = Colors.txtDanger, string plusColor = Colors.txtInfo, string zeroColor = Colors.txtMuted)
    {
      CTexts resultCT = new CTexts();
      var resultColor = Colors.txtDefault;
      resultCT.Texts.Add(new CText(number.ToString()));

      if (number > 0){
        resultColor = plusColor;
        resultCT.Texts[0].Text = resultCT.Texts[0].Text.Insert(0, "+");
      }       
      else if (number == 0)
        resultColor = zeroColor;
      else if (number < 0)
        resultColor = minusColor;
      
      
      resultCT.Texts[0].Color = resultColor;

      return resultCT;
    }
  }
}
